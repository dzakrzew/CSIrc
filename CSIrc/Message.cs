using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSIrc
{

    static class Pattern
    {
        static public string Matcher = @"^(?::(([^@!\ ]*)(?:(?:!([^@]*))?@([^\ ]*))?)\ )?([^\ ]+)((?:\ [^:\ ][^\ ]*){0,14})(?:\ :?(.*))?$";
    }

    class Message
    {
        public List<string> Parameters = new List<string>();

        public string Nick
        {
            get { return Parameters[2];}
        }
        public string Ident
        {
            get { return Parameters[3]; }
        }
        public string Host
        {
            get { return Parameters[4]; }
        }
        public string Command
        {
            get { return Parameters[5]; }
        }
        public string Params
        {
            get { return Parameters[6]; }
        }
        public string[] ParamsArray
        {
            get { return Params.Split(' '); }
        }
        public string Text
        {
            get {  return RTF.Escape(Parameters[7]); }
        }

        public Message(string _query)
        {
            Match match = Regex.Match(_query, Pattern.Matcher);

            foreach (Group g in match.Groups)
            {
                Parameters.Add(g.Value);
            }
        }
    }
}
