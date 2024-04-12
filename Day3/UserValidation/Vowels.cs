namespace UserValidation
{
    internal class Vowels
    {
        private readonly HashSet<char> _vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u'};

        /*
         * for getting Frequency map
         */
        private Dictionary<char, int> GetFrequency(string str)
        {
            var map = new Dictionary<char, int>();
            foreach (var ch in str.ToCharArray())
            {
                if (_vowels.Contains(ch))
                {
                   map[ch] = map.GetValueOrDefault(ch, 0) + 1;
                }
            }
            return map;
        }

        private int GetVowelsCount(string str)
        {
            var count = 0;
            foreach(var ch in str.ToCharArray())
            {
                if (_vowels.Contains(ch))
                    count++;
            }
            return count;
        }

        public Dictionary<string, int> GetLeastWords(string input)
        {
            var inputList = input.Split(",").ToList();
            var leastCount = GetFreqNum(inputList[0]);
            var res = new Dictionary<string, int>();

            foreach (var word in inputList) {
                var currCount = GetFreqNum(word);
                if( leastCount > currCount)
                {
                    leastCount = currCount;
                    res.Clear();
                    res[word] = GetVowelsCount(word);
                }
            }
            return res;

        }
        /*
         * Returns a specialised comparitor num,
         * for the vowels aaeiio it will be generated as 1122
         * as frequencies in sorted order
         */
        private int GetFreqNum(string word)
        {
            var wordFreq = GetFrequency(word);
            var freqStore = new List<int>();
            foreach (var item in wordFreq.Values)
            {
                freqStore.Add(item);
            }
            freqStore.Sort();

            var compNo = "";

            foreach (var item in freqStore)
            {
                compNo += item;
            }
            return int.Parse(compNo);
        }

    }
}
