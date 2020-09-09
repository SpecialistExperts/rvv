using System;
using System.Collections.Generic;
using System.Linq;
using Domain;

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


        public string FormatNumber(string encryption, string municipality)
        {
            char[] municipalityArray = municipality.ToCharArray();
            int[] positions = {3, 7, 9, 12};

            List<char> data = new List<char>();
            data.AddRange(encryption);
            data.Insert(3, municipalityArray[0]);
            data.Insert(7, municipalityArray[1]);
            data.Insert(9, municipalityArray[2]);
            data.Insert(12, municipalityArray[3]);
            var resFAKE = StringExtensions.SplitInParts(new string(data.ToArray()), 4);
            string res = "";
            foreach (var item in resFAKE)
            {
                res += item + "     ";
            }

            return res;
        }
    }
}