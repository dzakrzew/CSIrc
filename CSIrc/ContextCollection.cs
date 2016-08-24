using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CSIrc
{
    static class ContextCollection
    {
        static public IrcServer Server { get; set; }
        static private List<IIrcContext> Collection = new List<IIrcContext>();
        static public List<string> ActiveContexts = new List<string>();
        static public IIrcContext Current { get; set; }

        static public void Add(IIrcContext context, bool DoNotOpen = false)
        {
            Collection.Add(context);

            if (!DoNotOpen)
            {
                Current = context;
            }

            Program.MainWindow.UpdateContext();
        }

        static public void Remove(IIrcContext context)
        {
            Collection.Remove(context);
            Current = Server;
            
            Program.MainWindow.UpdateContext();
        }

        static public IIrcContext GetByName(string _name)
        {
            string name;
            Match m = Regex.Match(_name, @"^\*? ?(.*)$");

            name = m.Groups[1].Value;

            foreach (var item in Collection)
            {
                if (name == item.Name)
                {
                    return item;
                }
            }

            return null;
        }

        static public IIrcContext GetByIndex(int _i)
        {
            if (_i == 0)
            {
                return Server;
            }

            int i = 0;

            foreach (var item in Collection)
            {
                i++;

                if (_i == i)
                {
                    return item;
                }
            }

            return null;
        }

        static public List<IIrcContext> GetAll()
        {
            return Collection;
        }

        static public List<string> GetContextNames()
        {
            List<string> ret = new List<string>();

            foreach (var item in Collection)
            {
                ret.Add(item.Name);
            }

            return ret;
        }
    }
}
