using System.Text;

namespace ScreamCipher
{
    public static class ScreamCiper
    {
        public static string Screamify(string plaintext)
        {
            var substitutes = GetSubstitutePairsForEncryption();
            return SubstitueText(substitutes, plaintext);
        }

        public static string Unscreamify(string ciphertext)
        {
            var substitutes = GetSubstitutePairsForDecryption();
            ciphertext = ciphertext.Normalize(NormalizationForm.FormC);
            return SubstitueText(substitutes, ciphertext);
        }

        private static string SubstitueText(Dictionary<string, string> substitutes, string text)
        {
            text = text.ToUpper();
            var substitutedText = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                var letter = text[i].ToString();
                (i, letter) = AdjustIndexForUncommonDiacritics(text, i, letter);
                
                var substitutedLetter = SubstituteLetters(substitutes, letter);
                substitutedText.Append(substitutedLetter);
            }

            return substitutedText.ToString();
        }

        private static (int i, string letter) AdjustIndexForUncommonDiacritics(string text, int i, string letter)
        {
            var isLastChar = i >= text.Length - 1;
            if (isLastChar) { return (i, letter); }

            var nextChar = text[i + 1];
            if (IsLoneDiacritic(nextChar))
            {
                //For some reason, some diacritics are not merged into the
                //letter when the substitute dictionary is normalised. Adding
                //it to the letter-string fix this (somehow).

                letter += text[i + 1];
                i++;
            }

            return (i, letter);
        }

        private static bool IsLoneDiacritic(char nextChar)
        {
            //Diacritis that are not normalised into the letter seems to be
            //placed in the range indicated by the if-statement.
            return nextChar > 750 && nextChar < 900;
        }

        private static string SubstituteLetters(Dictionary<string, string> substitutes, string letter)
        {
            return substitutes.TryGetValue(letter, out string? substitute)
                ? substitute : letter;
        }

        private static Dictionary<string, string> GetSubstitutePairsForEncryption()
        {
            /* For more information about the characters used, see
             * https://www.explainxkcd.com/wiki/index.php/3054:_Scream_Cipher#Trivia
             */

            return new Dictionary<string, string>()
            {
                { "A", "A".Normalize(NormalizationForm.FormC) },
                { "B", "A\u0307".Normalize(NormalizationForm.FormC) },
                { "C", "A\u0327".Normalize(NormalizationForm.FormC) },
                { "D", "A\u0331".Normalize(NormalizationForm.FormC) },
                { "E", "A\u0301".Normalize(NormalizationForm.FormC) },
                { "F", "A\u032e".Normalize(NormalizationForm.FormC) },
                { "G", "A\u030b".Normalize(NormalizationForm.FormC) },
                { "H", "A\u0330".Normalize(NormalizationForm.FormC) },
                { "I", "A\u0309".Normalize(NormalizationForm.FormC) },
                { "J", "A\u0313".Normalize(NormalizationForm.FormC) },
                { "K", "A\u0323".Normalize(NormalizationForm.FormC) },
                { "L", "A\u0306".Normalize(NormalizationForm.FormC) },
                { "M", "A\u030c".Normalize(NormalizationForm.FormC) },
                { "N", "A\u0302".Normalize(NormalizationForm.FormC) },
                { "O", "A\u030a".Normalize(NormalizationForm.FormC) },
                { "P", "A\u032f".Normalize(NormalizationForm.FormC) },
                { "Q", "A\u0324".Normalize(NormalizationForm.FormC) },
                { "R", "A\u0311".Normalize(NormalizationForm.FormC) },
                { "S", "A\u0303".Normalize(NormalizationForm.FormC) },
                { "T", "A\u0304".Normalize(NormalizationForm.FormC) },
                { "U", "A\u0308".Normalize(NormalizationForm.FormC) },
                { "V", "A\u0300".Normalize(NormalizationForm.FormC) },
                { "W", "A\u030f".Normalize(NormalizationForm.FormC) },
                { "X", "A\u033d".Normalize(NormalizationForm.FormC) },
                { "Y", "A\u0326".Normalize(NormalizationForm.FormC) },
                { "Z", "\u023a".Normalize(NormalizationForm.FormC) }
            };
        }

        private static Dictionary<string, string> GetSubstitutePairsForDecryption()
        {
            return new Dictionary<string, string>()
            {
                { "A".Normalize(NormalizationForm.FormC), "A" },
                { "A\u0307".Normalize(NormalizationForm.FormC), "B" },
                { "A\u0327".Normalize(NormalizationForm.FormC), "C" },
                { "A\u0331".Normalize(NormalizationForm.FormC), "D" },
                { "A\u0301".Normalize(NormalizationForm.FormC), "E" },
                { "A\u032e".Normalize(NormalizationForm.FormC), "F" },
                { "A\u030b".Normalize(NormalizationForm.FormC), "G" },
                { "A\u0330".Normalize(NormalizationForm.FormC), "H" },
                { "A\u0309".Normalize(NormalizationForm.FormC), "I" },
                { "A\u0313".Normalize(NormalizationForm.FormC), "J" },
                { "A\u0323".Normalize(NormalizationForm.FormC), "K" },
                { "A\u0306".Normalize(NormalizationForm.FormC), "L" },
                { "A\u030c".Normalize(NormalizationForm.FormC), "M" },
                { "A\u0302".Normalize(NormalizationForm.FormC), "N" },
                { "A\u030a".Normalize(NormalizationForm.FormC), "O" },
                { "A\u032f".Normalize(NormalizationForm.FormC), "P" },
                { "A\u0324".Normalize(NormalizationForm.FormC), "Q" },
                { "A\u0311".Normalize(NormalizationForm.FormC), "R" },
                { "A\u0303".Normalize(NormalizationForm.FormC), "S" },
                { "A\u0304".Normalize(NormalizationForm.FormC), "T" },
                { "A\u0308".Normalize(NormalizationForm.FormC), "U" },
                { "A\u0300".Normalize(NormalizationForm.FormC), "V" },
                { "A\u030f".Normalize(NormalizationForm.FormC), "W" },
                { "A\u033d".Normalize(NormalizationForm.FormC), "X" },
                { "A\u0326".Normalize(NormalizationForm.FormC), "Y" },
                { "\u023a".Normalize(NormalizationForm.FormC), "Z" },
            };
        }
    }
}
