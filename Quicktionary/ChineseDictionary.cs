using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quicktionary
{
    public class ChineseDictionary
    {
        ArrayList dictionary;

        public ChineseDictionary(String path)
        {
            this.dictionary = new ArrayList();
            this.dictionary = ParseDictionary(path);
        }

        private ArrayList ParseDictionary(String path)
        {
            System.IO.StreamReader reader = new System.IO.StreamReader(path);
            return ParseUntilEmpty(reader);
        }

        private ArrayList ParseUntilEmpty(System.IO.StreamReader reader)
        {
            ArrayList dict = new ArrayList();
            String line = reader.ReadLine();
            while (IsNotEmpty(line))
            {
                AddUnlessCommentedOut(dict, line);
                line = reader.ReadLine();
            }
            return dict;
        }

        private void AddUnlessCommentedOut(ArrayList dict, String line)
        {
            if (line[0] != '#')
            {
                dict.Add(CreateEntry(line));
            }
        }

        private DictionaryEntry CreateEntry(String line)
        {
            String traditional = ParseTraditional(line);
            String simplified = ParseSimplified(line);
            String pinyin = ParsePinyin(line);
            String english = ParseEnglish(line);
            return new DictionaryEntry(traditional, simplified, pinyin, english);
        }

        private String ParseTraditional(String line)
        {
            return GetFieldIndex(line, 0);
        }

        private String ParseSimplified(String line)
        {
            return GetFieldIndex(line, 1);
        }

        private String ParsePinyin(String line)
        {
            return GetFieldIndex(line, 2);
        }

        private String ParseEnglish(String line)
        {
            return GetFieldIndex(line, 3);
        }

        private String GetFieldIndex(String line, int index)
        {
            String[] fields = GetFields(line);
            return fields[index];
        }

        private String[] GetFields(String line)
        {
            return line.Split(new char[] { ' ' }, 4, StringSplitOptions.None);
        }

        private bool IsNotEmpty(String line)
        {
            return line != null;
        }

        public ArrayList Query(String query)
        {
            ArrayList hits = new ArrayList();
            foreach (DictionaryEntry e in dictionary)
            {
                AddEntryIfQueryIsContained(hits, query, e);
            }
            return hits;
        }

        private void AddEntryIfQueryIsContained(ArrayList hits, String query, DictionaryEntry e)
        {
            if (e.Contains(query))
            {
                hits.Add(e);
            }
        }
    }
}
