using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSIrc
{
    static class MessageProcessing
    {
        public static MethodInfo GetMethod(string _str)
        {
            MethodInfo oMethodInfo = null;
            Type oType = typeof(MessageProcessingMethods);
            MethodInfo[] aoInfo = oType.GetMethods();

            foreach (MethodInfo oInfo in aoInfo)
            {
                var oAttributes = oInfo.GetCustomAttributes(typeof(MessageProcessorAttribute), false);

                if (oAttributes == null || oAttributes.Count() == 0)
                {
                    continue;
                }

                foreach (MessageProcessorAttribute oAttribute in oAttributes)
                {
                    if (oAttribute.Property == _str)
                    {
                        oMethodInfo = oInfo;
                        break;
                    }
                }
            }

            return oMethodInfo;
        }
    }

    class MessageProcessingMethods
    {
        [MessageProcessor("001")]
        static public void WelcomeAction(Message message)
        {
            ContextCollection.Server.WriteLine(message.Text);
        }

        [MessageProcessor("002")]
        static public void YourHostAction(Message message)
        {
            ContextCollection.Server.WriteLine(message.Text);
        }

        [MessageProcessor("003")]
        static public void CreatedAction(Message message)
        {
            ContextCollection.Server.WriteLine(message.Text);
        }

        [MessageProcessor("004")]
        static public void MyInfoAction(Message message)
        {
            string[] val = message.Params.Split(' ');

            ((IIrcContext)ContextCollection.Server).Name = val[2];
            ContextCollection.Server.WriteLine(message.Params);
            Program.MainWindow.UpdateChannelsList();
        }

        [MessageProcessor("005")]
        static public void ServerInfoAction(Message message)
        {
            
        }

        [MessageProcessor("251")]
        static public void LUserClientAction(Message message)
        {
            ContextCollection.Server.WriteLine(message.Text);
        }

        [MessageProcessor("252")]
        static public void LUserOpAction(Message message)
        {
            ContextCollection.Server.WriteLine(message.ParamsArray[2] + " " + message.Text);
        }

        [MessageProcessor("253")]
        static public void LUserUnknownAction(Message message)
        {
            ContextCollection.Server.WriteLine(message.ParamsArray[2] + " " + message.Text);
        }

        [MessageProcessor("254")]
        static public void LUserChannelsAction(Message message)
        {
            ContextCollection.Server.WriteLine(message.ParamsArray[2] + " " + message.Text);
        }

        [MessageProcessor("255")]
        static public void LUserMeAction(Message message)
        {
            ContextCollection.Server.WriteLine(message.Text);
        }

        [MessageProcessor("265")]
        static public void LocalUsersAction(Message message)
        {
            ContextCollection.Server.WriteLine(message.Text);
        }

        [MessageProcessor("266")]
        static public void GlobalUsersAction(Message message)
        {
            ContextCollection.Server.WriteLine(message.Text);
        }

        [MessageProcessor("250")]
        static public void ConnectionCountAction(Message message)
        {
            ContextCollection.Server.WriteLine(message.Text);
        }

        [MessageProcessor("332")]
        static public void TopicAction(Message message)
        {
            var ctx = ContextCollection.GetByName(message.ParamsArray[2]);

            ctx.Topic = message.Text;

            if (ctx == ContextCollection.Current)
            {
                Program.MainWindow.UpdateTopic();
            }
        }

        [MessageProcessor("333")]
        static public void TopicInfoAction(Message message)
        {
            var ctx = ContextCollection.GetByName(message.ParamsArray[2]);

            var timeSpan = TimeSpan.FromSeconds(double.Parse(message.ParamsArray[4]));
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var dateTime = epoch.Add(timeSpan).ToLocalTime();

            ((IrcChannel)ctx).WriteNotify("Topic set by " + message.ParamsArray[3] + " on " + dateTime);
        }

        [MessageProcessor("353")]
        static public void NamesAction(Message message)
        {
            var ctx = ContextCollection.GetByName(message.ParamsArray[3]);

            string[] names = message.Text.Split(' ');

            foreach (string name in names)
            {
                //((IRCChannel)ctx).AddToUsersList(name);
                ((IrcChannel)ctx).Users.Add(name);
            }
        }

        [MessageProcessor("366")]
        static public void NamesEndAction(Message message)
        {
            var ctx = ContextCollection.GetByName(message.ParamsArray[2]);

            if (ctx == ContextCollection.Current)
            {
                Program.MainWindow.UpdateUsersList();
            }
        }

        [MessageProcessor("375")]
        static public void StartMotdAction(Message message)
        {
            if (ContextCollection.Server.Client.ShowMotd)
            {
                ContextCollection.Server.WriteLine("--- MOTD ---");
            }
            else
            {
                ContextCollection.Server.WriteLine("Skipping MOTD...");
            }
        }

        [MessageProcessor("372")]
        static public void ShowMotdAction(Message message)
        {
            if (ContextCollection.Server.Client.ShowMotd)
                ContextCollection.Server.WriteLine(message.Text);
        }

        [MessageProcessor("376")]
        static public void StopMotdAction(Message message)
        {
            if (ContextCollection.Server.Client.ShowMotd)
                ContextCollection.Server.WriteLine("------------");
        }

        [MessageProcessor("433")]
        static public void NickInUseAction(Message message)
        {
            ContextCollection.Server.WriteLine("Your nickname is already in use, so _ was appended to it.");
            ContextCollection.Server.Client.Nickname += "_";
            ContextCollection.Server.SendQuery("NICK " + ContextCollection.Server.Client.Nickname);
        }

        [MessageProcessor("465")]
        static public void ServerBannedAction(Message message)
        {
            ContextCollection.Server.WriteLine(message.Text);
        }

        [MessageProcessor("ERROR")]
        static public void ErrorAction(Message message)
        {
            ContextCollection.Server.WriteLine(message.Text);
        }

        [MessageProcessor("INVITE")]
        static public void InviteAction(Message message)
        {
            ContextCollection.Current.WriteLine(message.Nick + " invites you to " + message.Text);
        }

        [MessageProcessor("JOIN")]
        static public void JoinAction(Message message)
        {
            if (message.Nick == ContextCollection.Server.Client.Nickname)
            {
                ContextCollection.Add(new IrcChannel(message.ParamsArray[1]));
            }
            else
            {
               var ctx = ContextCollection.GetByName(message.ParamsArray[1]);

                if (ctx != null)
                {
                    ((IrcChannel)ctx).Users.Add(message.Nick);
                    ((IrcChannel)ctx).WriteNotify(message.Nick + " (" + message.Ident + "@" + message.Host + ") has joined.", "blue");

                    Program.MainWindow.UpdateUsersList();
                }
            }
        }

        [MessageProcessor("KICK")]
        static public void KickAction(Message message)
        {
            var ctx = ContextCollection.GetByName(message.ParamsArray[1]);

            if (ContextCollection.Server.Client.Nickname == message.ParamsArray[2])
            {
                ContextCollection.Server.WriteLine(string.Format("You were kicked from {0} by {1} ({2})", message.ParamsArray[1], message.Nick, message.Text));
                ContextCollection.Remove(ctx);
            }
            else
            {
                ((IrcChannel)ctx).WriteNotify(string.Format("{0} has been kicked by {1} ({2})", message.ParamsArray[2], message.Nick, message.Text), "blue");
                ctx.UsersList.Remove(message.ParamsArray[2]);
                Program.MainWindow.UpdateUsersList();
            }
        }

        [MessageProcessor("PART")]
        static public void PartAction(Message message)
        {
            if (message.Nick == ContextCollection.Server.Client.Nickname)
            {
                ContextCollection.Remove(ContextCollection.GetByName(message.ParamsArray[1]));
            }
            else
            {
                var ctx = ContextCollection.GetByName(message.ParamsArray[1]);

                if (ctx != null)
                {
                    ((IrcChannel)ctx).Users.Remove(message.Nick);
                    ((IrcChannel)ctx).WriteNotify(message.Nick + " has left.", "blue");


                    Program.MainWindow.UpdateUsersList();
                }
            }
        }

        [MessageProcessor("MODE")]
        static public void ModeAction(Message message)
        {
            var ctx = ContextCollection.GetByName(message.ParamsArray[1]);

            if (ctx != null)
            {
                ((IrcChannel)ctx).WriteNotify(message.Nick + " sets mode" + message.Params);
                ContextCollection.Server.SendQuery("NAMES " + message.ParamsArray[1]);
            }
            else
            {
                ContextCollection.Server.WriteLine(message.Nick + " sets mode " + message.Text);
            }
        }

        [MessageProcessor("NOTICE")]
        static public void NoticeAction(Message message)
        {
            
        }

        [MessageProcessor("PING")]
        static public void PongAction(Message message)
        {
            ContextCollection.Server.SendQuery("PONG " + message.Text);
        }

        [MessageProcessor("PRIVMSG")]
        static public void PrivmsgAction(Message message)
        {

            if (message.ParamsArray[1] == ContextCollection.Server.Client.Nickname) // Private message
            {
                var ctx = ContextCollection.GetByName(message.Nick);

                if (ctx != null)
                {
                    ctx.WriteMessage(message.Nick, message.Text);
                }
                else
                {
                    IrcQuery query = new IrcQuery(message.Nick);

                    ContextCollection.Add(query, true);
                    query.WriteMessage(message.Nick, message.Text);
                }
            }
            else // Channel
            {
                var ctx = ContextCollection.GetByName(message.ParamsArray[1]);

                if (ctx != null)
                {
                    ctx.WriteMessage(message.Nick, message.Text);
                }
            }
        }

        [MessageProcessor("TOPIC")]
        static public void TopicChangeAction(Message message)
        {
            var ctx = ContextCollection.GetByName(message.ParamsArray[1]);

            ((IrcChannel)ctx).WriteNotify(message.Nick + " changed topic to: " + message.Text);
            ctx.Topic = message.Text;

            if (ctx == ContextCollection.Current)
            {
                Program.MainWindow.UpdateTopic();
            }
        }
    }
}
