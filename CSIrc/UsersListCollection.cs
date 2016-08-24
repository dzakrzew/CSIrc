using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIrc
{
    public class UsersListCollection
    {
        // Dictionary<NICK, MODES>
        private SortedList<string, string> collection;

        public int Count
        {
            get
            {
                return collection.Count;
            }
        }

        public UsersListCollection()
        {
            collection = new SortedList<string, string>();
        }

        public void Add(string _nick)
        {
            Match m = Regex.Match(_nick, "^([@,+])?(.*)$");

            string mode = "";
            string nick = m.Groups[2].Value;
            
            switch (m.Groups[1].Value)
            {
                case "@":
                    mode += "o";
                    break;
                case "+":
                    mode += "v";
                    break;
            }

            if (collection.ContainsKey(nick))
            {
                collection.Remove(nick);
            }

            collection.Add(nick, mode);
        }

        public bool Contains(string _nick)
        {
            return collection.ContainsKey(_nick);
        }

        public void Remove(string _nick)
        {
            collection.Remove(_nick);
        }

        public string[] ToArray()
        {
            List<string> ops = new List<string>();
            List<string> voices = new List<string>();
            List<string> other = new List<string>();

            foreach (var item in collection)
            {
                if (item.Value.Contains("o"))
                {
                    ops.Add("@" + item.Key);
                }

                if (item.Value.Contains("v") && !ops.Contains(item.Key))
                {
                    voices.Add("+" + item.Key);
                }

                if (item.Value == "" && !ops.Contains(item.Key) && !voices.Contains(item.Key))
                {
                    other.Add(item.Key);
                }
            }

            List<string> names = new List<string>();

            names.AddRange(ops);
            names.AddRange(voices);
            names.AddRange(other);

            return names.ToArray();
        }
    }
}
