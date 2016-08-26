using System.Text.RegularExpressions;

namespace CSIrc
{
    class CommandProcessingMethods
    {
        [CommandProcessor("close")]
        static public void CloseCommand(string _params)
        {
            if (ContextCollection.Current is IrcServer)
            {
                ContextCollection.Current.WriteLine("You cannot close the server context!");
            }
            else
            {
                var ctxToClose = ContextCollection.Current;

                if (ctxToClose is IrcChannel)
                {
                    PartCommand(ctxToClose.Name);
                }

                ContextCollection.Current = ContextCollection.Server;
                ContextCollection.Remove(ctxToClose);
                Program.MainWindow.UpdateContext();
            }
        }

        [CommandProcessor("deop")]
        static public void DeopCommand(string _params)
        {
            if (_params.Trim().Length > 0)
            {
                ContextCollection.Server.SendQuery("MODE " + ContextCollection.Current.Name + " -o " + _params);
            }
            else
            {
                ContextCollection.Current.WriteLine("This command needs more parameters.");
            }
        }

        [CommandProcessor("invite")]
        static public void InviteCommand(string _params)
        {
            if (_params.Trim().Length > 0)
            {
                ContextCollection.Server.SendQuery("INVITE " + _params);
            }
            else
            {
                ContextCollection.Current.WriteLine("This command needs more parameters.");
            }
        }

        [CommandProcessor("join")]
        static public void JoinCommand(string _params)
        {
            ContextCollection.Server.SendQuery("JOIN " + _params);
        }

        [CommandProcessor("kick")]
        static public void KickCommand(string _params)
        {
            if (_params.Trim().Length > 0)
            {
                ContextCollection.Server.SendQuery("KICK " + ContextCollection.Current.Name + " " + _params);
            }
            else
            {
                ContextCollection.Current.WriteLine("This command needs more parameters.");
            }
        }

        [CommandProcessor("left")]
        static public void LeftCommand(string _params)
        {
            PartCommand(_params);
        }

        [CommandProcessor("me")]
        static public void ActionCommand(string _params)
        {
            ContextCollection.Server.SendQuery("PRIVMSG " + ContextCollection.Current.Name + " :\u0001ACTION " + _params + "\u0001");
            ContextCollection.Current.WriteMessage(ContextCollection.Server.Client.Nickname, "\u0001ACTION " + _params + "\u0001");
        }

        [CommandProcessor("mode")]
        static public void ModeCommand(string _params)
        {
            if (_params.Trim().Length > 0)
            {
                ContextCollection.Server.SendQuery("MODE " + _params);
            }
            else
            {
                ContextCollection.Current.WriteLine("This command needs more parameters.");
            }
        }

        [CommandProcessor("op")]
        static public void OpCommand(string _params)
        {
            if (_params.Trim().Length > 0)
            {
                ContextCollection.Server.SendQuery("MODE " + ContextCollection.Current.Name + " +o " + _params);
            }
            else
            {
                ContextCollection.Current.WriteLine("This command needs more parameters.");
            }
        }

        [CommandProcessor("part")]
        static public void PartCommand(string _params)
        {
            if (ContextCollection.Current is IrcChannel && (_params == null || _params.Trim().Length == 0))
            {
                ContextCollection.Server.SendQuery("PART " + ContextCollection.Current.Name);
            }
            else
            {
                Match m = Regex.Match(_params, "^(.*?) ?(.*)?$");

                string channelName = m.Groups[1].Value;
                string reason = (m.Groups[2] != null) ? m.Groups[2].Value : "Leaving...";

                ContextCollection.Server.SendQuery("PART " + channelName + " :" + reason);
            }
        }

        [CommandProcessor("quote")]
        static public void QuoteCommand(string _params)
        {
            RawCommand(_params);
        }

        [CommandProcessor("query")]
        static public void QueryCommand(string _params)
        {
            Match m = Regex.Match(_params.Trim(), @"^([A-Za-z0-9_\-\[\]\\^{}|`]+)$");

            if (m.Groups[1] == null || m.Groups[1].Value.Length == 0)
            {
                ContextCollection.Current.WriteLine("Usage: /query [<nickname>]");
                return;
            }

            var ctx = ContextCollection.GetByName(m.Groups[1].Value);

            if (ctx == null)
            {
                IrcQuery query = new IrcQuery(m.Groups[1].Value);
                ContextCollection.Add(query);
            }
            else
            {
                ContextCollection.Current = ctx;
                Program.MainWindow.UpdateContext();
            }
        }

        [CommandProcessor("raw")]
        static public void RawCommand(string _params)
        {
            if (_params.Trim().Length > 0)
            {
                ContextCollection.Server.SendQuery(_params);
            }
            else
            {
                ContextCollection.Current.WriteLine("This command needs more parameters.");
            }
        }

        [CommandProcessor("whois")]
        static public void WhoisCommand(string _params)
        {
            ContextCollection.Server.SendQuery("WHOIS " + _params);
        }
    }
}
