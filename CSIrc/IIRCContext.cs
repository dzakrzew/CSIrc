using System.Collections.Generic;

namespace CSIrc
{
    public interface IIrcContext
    {
        string Name { get; set;  }
        UsersListCollection UsersList { get; }
        string Content { get; }
        string Topic { get; set; }
        void WriteLine(string _msg);
        void WriteMessage(string _nick, string _msg);
    }
}
