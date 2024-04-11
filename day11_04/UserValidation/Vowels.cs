using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserValidation
{
    internal class Vowels
    {
        HashSet<Char> vowels = new HashSet<Char>() { 'a', 'e', 'i', 'o', 'u'};

        /*
         * for getting Frequency map
         */
        private Dictionary<Char, int> getFrequency(string str)
        {
            Dictionary<Char, int> map = new Dictionary<Char, int>();
            foreach (var ch in str.ToCharArray())
            {
                if (vowels.Contains(ch))
                {
                   map[ch] = map.GetValueOrDefault(ch, 0) + 1;
                }
            }
            return map;
        }

        private int getVowelsCount(string str)
        {
            int count = 0;
            foreach(var ch in str.ToCharArray())
            {
                if (vowels.Contains(ch))
                    count++;
            }
            return count;
        }

        public Dictionary<string, int> getLeastWords(string input)
        {
            var inputList = input.Split(",").ToList();
            var leastCount = getFreqNum(inputList[0]);
            var res = new Dictionary<string, int>();

            foreach (var word in inputList) {
                var currCount = getFreqNum(word);
                if( leastCount > currCount)
                {
                    leastCount = currCount;
                    res.Clear();
                    res[word] = getVowelsCount(word);
                }
            }
            return res;

        }
        /*
         * Returns a specialised comparitor num,
         * for the vowels aaeiio it will be generated as 1122
         * as frequencies in sorted order
         */
        private int getFreqNum(string word)
        {
            var wordFreq = getFrequency(word);
            List<int> freqStore = new List<int>();
            foreach (var item in wordFreq.Values)
            {
                freqStore.Add(item);
            };
            freqStore.Sort();

            string compNo = "";

            foreach (var item in freqStore)
            {
                compNo += item;
            }
            return int.Parse(compNo);
        }

    }
}
