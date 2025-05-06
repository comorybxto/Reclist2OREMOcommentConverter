using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomajiKanaConverter
{
    internal class Kana2Romaji
    {
        public static string Convert(string line)
        {
            var result = new StringBuilder();
            int i = 0;

            while (i < line.Length)
            {
                string match = null;
                int matchLength = 0;
                int maxLength = Table.h2rTable.Keys.Max(key => key.Length);
                // Check for n-character syllables
                // ...
                // Check for 3-character syllables         (eg. ふぃぇ)
                // Then for 2-character syllables          (eg. ふぇ)
                // Finally for single character syllables  (eg. ふ)
                for (int length = maxLength; length >= 1; length--)
                {
                    if (i + length <= line.Length)
                    {
                        string substring = line.Substring(i, length);
                        if (Table.h2rTable.ContainsKey(substring))
                        {
                            match = Table.h2rTable[substring];
                            matchLength = length;
                            break;
                        }
                    }
                }

                bool isMatched = match != null;

                if (isMatched)
                {
                    i += matchLength;
                }
                else
                {
                    match = line[i].ToString();
                    i += 1;
                }

                // Is this the last syllable on the line
                bool isLastSyllable = i == line.Length;

                if (isLastSyllable || !isMatched)
                    result.Append(match);
                else
                    result.Append($"{match}-");

            }
            return result.ToString();
        }
    }
}
