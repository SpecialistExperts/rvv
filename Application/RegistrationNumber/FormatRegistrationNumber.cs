using System;
using System.Collections.Generic;


namespace Application
{

    static class StringExtensions
    {

        public static IEnumerable<String> SplitInParts(this String s, Int32 partLength)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s));
            if (partLength <= 0)
                throw new ArgumentException("Part length has to be positive.", nameof(partLength));

            for (var i = 0; i < s.Length; i += partLength)
                yield return s.Substring(i, Math.Min(partLength, s.Length - i));
        }
    }
    public class FormatNumbers
    {


        public static string FormatNumber(string encryption, string municipality)
        {
            // create variables
            char[] municipalityArray = municipality.ToCharArray();
            int[] positions = {3, 7, 9, 12};
            List<char> data = new List<char>();
            data.AddRange(encryption);            

            for (int i =0; i<positions.Length; i++){
                data.Insert(positions[i], municipality[i]);
            }

            var resParts = StringExtensions.SplitInParts(new string(data.ToArray()), 4);
            string res = "";
            foreach (var item in resParts)
            {
                res += item + " ";
            }

            return res;
        }
    }
}