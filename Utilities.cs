using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Christ- Yan Love LAROSE
/// </summary>
namespace Etudiant
{

    /// <summary>
    /// Methode to capitalize a string
    /// </summary>
    /// <param name="word"></param>
    /// <returns>A string capitalized </returns>
    static class Utilities
    {
        public static string capitalize(string text)
        {
            string result = "";
            string[] words = text.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                string firstLetter = words[i].Substring(0, 1).ToUpper();
                string restText = words[i].Substring(1).ToLower();
                result += firstLetter + restText + " ";
            }

            return result;
        }
    }
}