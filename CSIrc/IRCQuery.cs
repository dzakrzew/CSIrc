using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIrc
{
    class IrcQuery : IIrcContext
    {
        private string name;
        private string content;

        public IrcQuery(string _name)
        {
            name = _name;
            content = "";
        }

        #region IIRCContext interface members
        string IIrcContext.Name
        {
            get { return name; }
            set { name = value; }
        }

        string IIrcContext.Topic
        {
            get { return null; }
            set { }
        }

        string IIrcContext.Content
        {
            get { return content; }
        }

        UsersListCollection IIrcContext.UsersList
        {
            get { return null; }
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
            string c = (_nick == ContextCollection.Server.Client.Nickname) ? RTF.Colors["red"] : RTF.Colors["blue"];

            content += RTF.ColourfulTimestamp() + @"<{" + c + " " + _nick + @"}> " + RTF.Escape(_msg) + @"\line";

            if (ContextCollection.Current == this)
            {
                Program.MainWindow.UpdateContent();
            }
        }
    }
}
