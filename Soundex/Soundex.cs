using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Soundex
{
    /// <summary>
    /// Provides functionality to retrieve a soundex code for a given word.
    /// </summary>
    public class Soundex
    {
        /// <summary>
        /// Returns the soundex code for a specified word.
        /// </summary>
        /// <param name="word">Word to get the soundex for.</param>
        /// <returns>Soundex code for word.</returns>
        public string For(string word)
        {
            const int MaxSoundexCodeLength = 4;

            var soundexCode = new StringBuilder();
            var previousWasHOrW = false;

            // Upper case all letters in word and remove any punctuation
            word = Regex.Replace(
                word == null ? string.Empty : word.ToUpper(),
                    @"[^\w\s]", 
                        string.Empty);

            if (string.IsNullOrEmpty(word)) 
                return string.Empty.PadRight(MaxSoundexCodeLength, '0');

            // Retain the first letter
            soundexCode.Append(word.First());

            for (var i = 1; i < word.Length; i++)
            {
                var numberCharForCurrentLetter = GetCharNumberForLetter(word[i]);

                // Skip this number if it matches the number for the first character
                if (i == 1 && 
                        numberCharForCurrentLetter == GetCharNumberForLetter(soundexCode[0]))
                    continue;

                // Skip this number if the previous letter was a 'H' or a 'W' 
                // and this number matches the number assigned before that
                if (soundexCode.Length > 2 && previousWasHOrW && 
                        numberCharForCurrentLetter == soundexCode[soundexCode.Length - 2])
                    continue;

                // Skip this number if it was the last added
                if (soundexCode.Length > 0 && 
                        numberCharForCurrentLetter == soundexCode[soundexCode.Length - 1])
                    continue; 

                soundexCode.Append(numberCharForCurrentLetter);

                previousWasHOrW = "HW".Contains(word[i]);
            }

            return soundexCode
                    .Replace("0", string.Empty)
                        .ToString()
                            .PadRight(MaxSoundexCodeLength, '0')
                                .Substring(0, MaxSoundexCodeLength);
        }

        /// <summary>
        /// Retrieves the soundex number for a given letter.
        /// </summary>
        /// <param name="letter">Letter to get the soundex number for.</param>
        /// <returns>Soundex number (as a character) for letter.</returns>
        private char GetCharNumberForLetter(char letter)
        {
            if ("BFPV".Contains(letter)) return '1';
            if ("CGJKQSXZ".Contains(letter)) return '2';
            if ("DT".Contains(letter)) return '3';
            if ('L' == letter) return '4';
            if ("MN".Contains(letter)) return '5';
            if ('R' == letter) return '6';

            return '0'; // i.e. letter is [AEIOUWYH]
        }
    }
}