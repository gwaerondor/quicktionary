using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quicktionary
{
    class DictionaryEntry
    {
        private String traditional;
        private String simplified;
        private String pinyin;
        private String english;

        public DictionaryEntry(String traditional, String simplified, String pinyin, String english)
        {
            this.traditional = traditional;
            this.simplified = simplified;
            this.pinyin = pinyin;
            this.english = english;
        }

        public bool Contains(String query)
        {
            return simplified.Contains(query) || english.Contains(query);
        }

        public override String ToString()
        {
            return simplified + " " + pinyin + " " + english;
        }
    }
}
