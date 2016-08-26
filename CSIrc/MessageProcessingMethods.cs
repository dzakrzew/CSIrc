using System;

namespace CSIrc
{
    class MessageProcessingMethods
    {
        #region Numeric commands
        #region Welcome commands
        [MessageProcessor("001")]
        static public void WelcomeAction(Message message)
        {
            ContextCollection.Server.WriteLine(RTF.ColourString(message.Text, IrcColor.Blue));
        }

        [MessageProcessor("002")]
        static public void YourHostAction(Message message)
        {
            ContextCollection.Server.WriteLine(RTF.ColourString(message.Text, IrcColor.Blue));
        }

        [MessageProcessor("003")]
        static public void CreatedAction(Message message)
        {
            ContextCollection.Server.WriteLine(RTF.ColourString(message.Text, IrcColor.Blue));
        }

        [MessageProcessor("004")]
        static public void MyInfoAction(Message message)
        {
            string[] val = message.Params.Split(' ');

            ((IIrcContext)ContextCollection.Server).Name = val[2];
            Program.MainWindow.UpdateChannelsList();
        }

        [MessageProcessor("005")]
        static public void ServerInfoAction(Message message)
        {

        }
        #endregion

        [MessageProcessor("250")]
        static public void ConnectionCountAction(Message message)
        {
            ContextCollection.Server.WriteLine(message.Text);
        }

        [MessageProcessor("251")]
        static public void LUserClientAction(Message message)
        {
            ContextCollection.Server.WriteLine(RTF.ColourString(message.Text, IrcColor.Blue));
        }

        [MessageProcessor("252")]
        static public void LUserOpAction(Message message)
        {
            ContextCollection.Server.WriteLine(RTF.ColourString(message.ParamsArray[2], IrcColor.LightRed) + " " + message.Text);
        }

        [MessageProcessor("253")]
        static public void LUserUnknownAction(Message message)
        {
            ContextCollection.Server.WriteLine(RTF.ColourString(message.ParamsArray[2], IrcColor.LightRed) + " " + message.Text);
        }

        [MessageProcessor("254")]
        static public void LUserChannelsAction(Message message)
        {
            ContextCollection.Server.WriteLine(RTF.ColourString(message.ParamsArray[2], IrcColor.LightRed) + " " + message.Text);
        }

        [MessageProcessor("255")]
        static public void LUserMeAction(Message message)
        {
            ContextCollection.Server.WriteLine(RTF.ColourString(message.Text, IrcColor.Blue));
        }

        [MessageProcessor("265")]
        static public void LocalUsersAction(Message message)
        {
            ContextCollection.Server.WriteLine(RTF.ColourString(message.Text, IrcColor.Blue));
        }

        [MessageProcessor("266")]
        static public void GlobalUsersAction(Message message)
        {
            ContextCollection.Server.WriteLine(RTF.ColourString(message.Text, IrcColor.Blue));
        }

        [MessageProcessor("301")]
        static public void AwayAction(Message message)
        {
            ContextCollection.Current.WriteLine(RTF.ColourString(message.ParamsArray[1], IrcColor.Pink) + " is away (" + message.Text + ")");
        }

        [MessageProcessor("302")]
        static public void UserHostAction(Message message)
        {
            ContextCollection.Current.WriteLine(message.Text);
        }

        [MessageProcessor("303")]
        static public void IsOnAction(Message message)
        {
            ContextCollection.Current.WriteLine(message.Text);
        }

        [MessageProcessor("305")]
        static public void UnAwayAction(Message message)
        {
            ContextCollection.Current.WriteLine(message.Text);
        }

        [MessageProcessor("306")]
        static public void NowAwayAction(Message message)
        {
            ContextCollection.Current.WriteLine(message.Text);
        }

        [MessageProcessor("311")]
        static public void WhoisUserAction(Message message)
        {
            ContextCollection.Current.WriteLine(RTF.ColourString(message.ParamsArray[2], IrcColor.Pink) + " (" + RTF.ColourString(message.ParamsArray[3], IrcColor.Orange) + "@" + RTF.ColourString(message.ParamsArray[4], IrcColor.Orange) + "): " + message.Text);
        }

        [MessageProcessor("312")]
        static public void WhoisServerAction(Message message)
        {
            ContextCollection.Current.WriteLine(RTF.ColourString(message.ParamsArray[2], IrcColor.Pink) + " is connected with " + RTF.ColourString(message.ParamsArray[3], IrcColor.Orange) + " (" + message.Text + ")");
        }

        [MessageProcessor("313")]
        static public void WhoisOperatorAction(Message message)
        {
            ContextCollection.Current.WriteLine(RTF.ColourString(message.ParamsArray[2], IrcColor.Pink) + " " + message.Text);
        }

        [MessageProcessor("314")]
        static public void WhoWasAction(Message message)
        {
            ContextCollection.Current.WriteLine(message.ParamsArray[2] + " was (" + message.ParamsArray[3] + "@" + message.ParamsArray[4] + "): " + message.Text);
        }

        [MessageProcessor("317")]
        static public void WhoisIdleAction(Message message)
        {
            int secs = int.Parse(message.ParamsArray[3]);
            TimeSpan idle = TimeSpan.FromSeconds(secs);
            string idle_string = string.Format("{0:D2}:{1:D2}:{2:D2}", idle.Hours, idle.Minutes, idle.Seconds);

            ContextCollection.Current.WriteLine(RTF.ColourString(message.ParamsArray[2], IrcColor.Pink) + " idle: " + RTF.ColourString(idle_string, IrcColor.Orange));
        }

        [MessageProcessor("318")]
        static public void WhoisEndAction(Message message)
        {
            ContextCollection.Current.WriteLine(RTF.ColourString(message.ParamsArray[2], IrcColor.Pink) + ": " + message.Text);
        }

        [MessageProcessor("319")]
        static public void Action(Message message)
        {
            ContextCollection.Current.WriteLine(RTF.ColourString(message.ParamsArray[2], IrcColor.Pink) + " is on: " + message.Text);
        }

        [MessageProcessor("330")]
        static public void WhoisAccountAction(Message message)
        {
            ContextCollection.Current.WriteLine(RTF.ColourString(message.ParamsArray[2], IrcColor.Pink) + " " + message.Text + " " + RTF.ColourString(message.ParamsArray[3], IrcColor.Pink));
        }

        [MessageProcessor("332")]
        static public void TopicAction(Message message)
        {
            var ctx = ContextCollection.GetByName(message.ParamsArray[2]);

            ctx.Topic = message.Text;
            ctx.WriteLine(RTF.ColourString("Topic for " + message.ParamsArray[2] + ": " + message.Text, IrcColor.Green));

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

            ctx.WriteLine(RTF.ColourString("Topic set by " + message.ParamsArray[3] + " on " + dateTime, IrcColor.Green));
        }

        [MessageProcessor("353")]
        static public void NamesAction(Message message)
        {
            var ctx = ContextCollection.GetByName(message.ParamsArray[3]);

            string[] names = message.Text.Split(' ');

            foreach (string name in names)
            {
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

        [MessageProcessor("369")]
        static public void WhoWasEndAction(Message message)
        {
            ContextCollection.Current.WriteLine(RTF.ColourString(message.ParamsArray[2], IrcColor.Pink) + ": " + message.Text);
        }

        [MessageProcessor("372")]
        static public void ShowMotdAction(Message message)
        {
            if (ContextCollection.Server.Client.ShowMotd)
                ContextCollection.Server.WriteLine(message.Text);
        }

        [MessageProcessor("375")]
        static public void StartMotdAction(Message message)
        {
            if (ContextCollection.Server.Client.ShowMotd)
            {
                ContextCollection.Server.WriteLine(message.Text);
            }
            else
            {
                ContextCollection.Server.WriteLine("Skipping MOTD...");
            }
        }

        [MessageProcessor("376")]
        static public void StopMotdAction(Message message)
        {
            if (ContextCollection.Server.Client.ShowMotd)
                ContextCollection.Server.WriteLine(message.Text);
        }

        [MessageProcessor("401")]
        static public void NoSuchNickAction(Message message)
        {
            ContextCollection.Current.WriteLine(RTF.ColourString(message.ParamsArray[2], IrcColor.Pink) + ": " + message.Text);
        }

        [MessageProcessor("402")]
        static public void NoSuchServerAction(Message message)
        {
            ContextCollection.Current.WriteLine(RTF.ColourString(message.ParamsArray[2], IrcColor.Pink) + ": " + message.Text);
        }

        [MessageProcessor("403")]
        static public void NoSuchChannelAction(Message message)
        {
            ContextCollection.Current.WriteLine(RTF.ColourString(message.ParamsArray[2], IrcColor.Pink) + ": " + message.Text);
        }

        [MessageProcessor("404")]
        static public void CannotSendAction(Message message)
        {
            ContextCollection.Current.WriteLine(RTF.ColourString(message.ParamsArray[2], IrcColor.Pink) + ": " + message.Text);
        }

        [MessageProcessor("405")]
        static public void TooManyChannelsAction(Message message)
        {
            ContextCollection.Current.WriteLine(RTF.ColourString(message.ParamsArray[2], IrcColor.Pink) + ": " + message.Text);
        }

        [MessageProcessor("406")]
        static public void WasNoSuchNickAction(Message message)
        {
            ContextCollection.Current.WriteLine(RTF.ColourString(message.ParamsArray[2], IrcColor.Pink) + ": " + message.Text);
        }

        [MessageProcessor("407")]
        static public void TooManyTargetsAction(Message message)
        {
            ContextCollection.Current.WriteLine(RTF.ColourString(message.ParamsArray[2], IrcColor.Pink) + ": " + message.Text);
        }

        [MessageProcessor("409")]
        static public void NoOriginAction(Message message)
        {
            ContextCollection.Current.WriteLine(RTF.ColourString(message.ParamsArray[2], IrcColor.Pink) + ": " + message.Text);
        }

        [MessageProcessor("411")]
        static public void NoRecipientAction(Message message)
        {
            ContextCollection.Current.WriteLine(message.Text);
        }

        [MessageProcessor("412")]
        static public void NoTextToSendAction(Message message)
        {
            ContextCollection.Current.WriteLine(message.Text);
        }

        [MessageProcessor("413")]
        static public void NoTopLevelAction(Message message)
        {
            ContextCollection.Current.WriteLine(RTF.ColourString(message.ParamsArray[2], IrcColor.Pink) + ": " + message.Text);
        }

        [MessageProcessor("414")]
        static public void NoWildTopLevelAction(Message message)
        {
            ContextCollection.Current.WriteLine(RTF.ColourString(message.ParamsArray[2], IrcColor.Pink) + ": " + message.Text);
        }

        [MessageProcessor("421")]
        static public void UnknownCommandAction(Message message)
        {
            ContextCollection.Current.WriteLine(RTF.ColourString(message.ParamsArray[2], IrcColor.Pink) + ": " + message.Text);
        }

        [MessageProcessor("422")]
        static public void NoMOTDAction(Message message)
        {
            ContextCollection.Server.WriteLine(message.Text);
        }

        [MessageProcessor("423")]
        static public void NoAdminInfoAction(Message message)
        {
            ContextCollection.Current.WriteLine(RTF.ColourString(message.ParamsArray[2], IrcColor.Pink) + ": " + message.Text);
        }

        [MessageProcessor("424")]
        static public void FileErrorAction(Message message)
        {
            ContextCollection.Current.WriteLine(message.Text);
        }

        [MessageProcessor("431")]
        static public void NoNickNameGivenAction(Message message)
        {
            ContextCollection.Current.WriteLine(message.Text);
        }

        [MessageProcessor("432")]
        static public void ErroneusNickAction(Message message)
        {
            ContextCollection.Current.WriteLine(RTF.ColourString(message.ParamsArray[2], IrcColor.Pink) + ": " + message.Text);
        }

        [MessageProcessor("433")]
        static public void NickInUseAction(Message message)
        {
            ContextCollection.Current.WriteLine("Your nickname is already in use, so _ was appended to it.");
            ContextCollection.Server.Client.Nickname += "_";
            ContextCollection.Server.SendQuery("NICK " + ContextCollection.Server.Client.Nickname);
        }

        [MessageProcessor("436")]
        static public void NickCollisionAction(Message message)
        {
            ContextCollection.Current.WriteLine(RTF.ColourString(message.ParamsArray[2], IrcColor.Pink) + ": " + message.Text);
        }

        [MessageProcessor("441")]
        static public void UserNotInChannelAction(Message message)
        {
            ContextCollection.Current.WriteLine(RTF.ColourString(message.ParamsArray[2], IrcColor.Pink) + ": " + message.Text);
        }

        [MessageProcessor("442")]
        static public void NotOnChannelAction(Message message)
        {
            ContextCollection.Current.WriteLine(RTF.ColourString(message.ParamsArray[2], IrcColor.Pink) + ": " + message.Text);
        }

        [MessageProcessor("443")]
        static public void AlreadyOnChannelAction(Message message)
        {
            ContextCollection.Current.WriteLine(RTF.ColourString(message.ParamsArray[2], IrcColor.Pink) + ": " + message.Text);
        }

        [MessageProcessor("444")]
        static public void NoLoginAction(Message message)
        {
            ContextCollection.Current.WriteLine(RTF.ColourString(message.ParamsArray[2], IrcColor.Pink) + ": " + message.Text);
        }

        [MessageProcessor("445")]
        static public void SummonDisabledAction(Message message)
        {
            ContextCollection.Current.WriteLine(message.Text);
        }

        [MessageProcessor("446")]
        static public void UsersDisabledAction(Message message)
        {
            ContextCollection.Current.WriteLine(message.Text);
        }

        [MessageProcessor("451")]
        static public void NotRegisteredAction(Message message)
        {
            ContextCollection.Current.WriteLine(message.Text);
        }

        [MessageProcessor("461")]
        static public void NeedMoreParamsAction(Message message)
        {
            ContextCollection.Current.WriteLine(RTF.ColourString(message.ParamsArray[2], IrcColor.Pink) + ": " + message.Text);
        }

        [MessageProcessor("462")]
        static public void AlreadyRegisteredAction(Message message)
        {
            ContextCollection.Current.WriteLine(message.Text);
        }

        [MessageProcessor("463")]
        static public void NoPermForHostAction(Message message)
        {
            ContextCollection.Current.WriteLine(message.Text);
        }

        [MessageProcessor("464")]
        static public void IncorrectPasswordAction(Message message)
        {
            ContextCollection.Current.WriteLine(message.Text);
        }

        [MessageProcessor("465")]
        static public void ServerBannedAction(Message message)
        {
            ContextCollection.Server.WriteLine(message.Text);
        }

        [MessageProcessor("467")]
        static public void KeySetAction(Message message)
        {
            ContextCollection.Current.WriteLine(RTF.ColourString(message.ParamsArray[2], IrcColor.Pink) + ": " + message.Text);
        }

        [MessageProcessor("471")]
        static public void ChannelFullAction(Message message)
        {
            ContextCollection.Current.WriteLine(RTF.ColourString(message.ParamsArray[2], IrcColor.Pink) + ": " + message.Text);
        }

        [MessageProcessor("472")]
        static public void UnknownModeAction(Message message)
        {
            ContextCollection.Current.WriteLine("{" + RTF.Colors[13] + message.ParamsArray[2] + "} " + message.Text);
        }

        [MessageProcessor("473")]
        static public void InviteOnlyChanAction(Message message)
        {
            ContextCollection.Current.WriteLine(RTF.ColourString(message.ParamsArray[2], IrcColor.Pink) + ": " + message.Text);
        }

        [MessageProcessor("474")]
        static public void BannedAction(Message message)
        {
            ContextCollection.Current.WriteLine(RTF.ColourString(message.ParamsArray[2], IrcColor.Pink) + ": " + message.Text);
        }

        [MessageProcessor("475")]
        static public void BadChannelKeyAction(Message message)
        {
            ContextCollection.Current.WriteLine(RTF.ColourString(message.ParamsArray[2], IrcColor.Pink) + ": " + message.Text);
        }

        [MessageProcessor("481")]
        static public void NoPrivilegesAction(Message message)
        {
            ContextCollection.Current.WriteLine(message.Text);
        }

        [MessageProcessor("482")]
        static public void ChanOPrivsNeededAction(Message message)
        {
            ContextCollection.Current.WriteLine(RTF.ColourString(message.ParamsArray[2], IrcColor.Pink) + ": " + message.Text);
        }

        [MessageProcessor("483")]
        static public void CantKillServerAction(Message message)
        {
            ContextCollection.Current.WriteLine(message.Text);
        }

        [MessageProcessor("491")]
        static public void NoOperHostAction(Message message)
        {
            ContextCollection.Current.WriteLine(message.Text);
        }

        [MessageProcessor("501")]
        static public void UModeUnknownFlagAction(Message message)
        {
            ContextCollection.Current.WriteLine(message.Text);
        }

        [MessageProcessor("502")]
        static public void UseersDontMatchAction(Message message)
        {
            ContextCollection.Current.WriteLine(message.Text);
        }

        [MessageProcessor("671")]
        static public void WhoisSecuredAction(Message message)
        {
            ContextCollection.Current.WriteLine(RTF.ColourString(message.ParamsArray[2], IrcColor.Pink) + " " + message.Text);
        }
        #endregion

        #region Text commands

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
                    ctx.WriteLine(RTF.ColourString(message.Nick + " (" + message.Ident + "@" + message.Host + ") has joined.", IrcColor.Orange));

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
                ctx.WriteLine(RTF.ColourString(string.Format("{0} has been kicked by {1} ({2})", message.ParamsArray[2], message.Nick, message.Text), IrcColor.Orange));
                ctx.UsersList.Remove(message.ParamsArray[2]);
                Program.MainWindow.UpdateUsersList();
            }
        }

        [MessageProcessor("MODE")]
        static public void ModeAction(Message message)
        {
            var ctx = ContextCollection.GetByName(message.ParamsArray[1]);

            if (ctx != null)
            {
                ctx.WriteLine(RTF.ColourString(message.Nick + " sets mode" + message.Params, IrcColor.Green));
                ContextCollection.Server.SendQuery("NAMES " + message.ParamsArray[1]);
            }
            else
            {
                ContextCollection.Server.WriteLine(RTF.ColourString(message.Nick + " sets mode " + message.Text, IrcColor.Green));
            }
        }

        [MessageProcessor("NOTICE")]
        static public void NoticeAction(Message message)
        {

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
                    ctx.WriteLine(RTF.ColourString(message.Nick + " has left.", IrcColor.Orange));


                    Program.MainWindow.UpdateUsersList();
                }
            }
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

            ctx.WriteLine(RTF.ColourString(message.Nick + " changed topic to: " + message.Text, IrcColor.Green));
            ctx.Topic = message.Text;

            if (ctx == ContextCollection.Current)
            {
                Program.MainWindow.UpdateTopic();
            }
        }

        #endregion
    }
}
