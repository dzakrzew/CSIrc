using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSIrc
{
    class IrcChannel : IIrcContext
    {
        private string name;
        private string topic;
        private string content;
        //private List<string> users;
        public UsersListCollection Users;

        public IrcChannel(string _name)
        {
            name = _name;
            topic = "";
            content = "";
            //users = new List<string>();
            Users = new UsersListCollection();
        }

        #region IIRCContext interface members
        string IIrcContext.Name
        {
            get { return name;  }
            set { name = value;  }
        }

        string IIrcContext.Topic
        {
            get { return topic; }
            set { topic = value; }
        }

        string IIrcContext.Content
        {
            get { return content; }
        }

        UsersListCollection IIrcContext.UsersList
        {
            get { return Users; }
        }
        #endregion

        public void WriteLine(string msg)
        {
            content += RTF.ColourfulTimestamp() + RTF.Escape(msg) + @"\line";

            if (ContextCollection.Current == this)
            {
                Program.MainWindow.UpdateContent();
            }
        }

        public void WriteMessage(string _nick, string _msg)
        {
            if (_msg.Length > 5 && _msg.Substring(0,7) == "\u0001ACTION")
            {
                content += RTF.ColourfulTimestamp() + @"{" + RTF.Colors["red"] + " * " + _nick + RTF.Escape(_msg.Substring(7)) + "}" + @"\line";
            }
            else
            {
                string c = (_nick == ContextCollection.Server.Client.Nickname) ? RTF.Colors["red"] : RTF.Colors["blue"];

                content += RTF.ColourfulTimestamp() + @"<{" + c + " " + _nick + @"}> " + RTF.Escape(_msg) + @"\line";
            }

            if (ContextCollection.Current == this)
            {
                Program.MainWindow.UpdateContent();
            }
            else
            {
                ContextCollection.ActiveContexts.Add(this.name);
                Program.MainWindow.UpdateChannelsList();
            }
        }

        public void WriteNotify(string _msg, string _color = "green")
        {
            content += RTF.ColourfulTimestamp() + @"{" + RTF.Colors[_color] + " " + RTF.Escape(_msg) + " } " + @"\line"; 

            if (ContextCollection.Current == this)
            {
                Program.MainWindow.UpdateContent();
            }
        }
    }
}
