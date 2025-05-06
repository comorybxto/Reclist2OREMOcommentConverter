using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RomajiKanaConverter
{
    internal class Romaji2Kana
    {
        public static string Convert(string line)
        {

            var result = new StringBuilder();

            string[] lineArray = line.Split('-');

            for (int i = 0; i < lineArray.Length; i++)
            {
                if (Table.r2hTable.TryGetValue(lineArray[i], out string value))
                    lineArray[i] = value;
                else if (Table.r2hTable.TryGetValue(lineArray[i].Replace("_", ""), out string value2))
                    lineArray[i] = "_" + value2;
            }

            return result.Append(string.Join("", lineArray)).ToString();
        }
    }
}
