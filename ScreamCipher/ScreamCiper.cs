using System.Text;

namespace ScreamCipher
{
    public static class ScreamCiper
    {
        public static string Screamify(string plaintext)
        {
            plaintext = plaintext.ToUpper();
            var encryptText = new StringBuilder();

            for (int i = 0; i < plaintext.Length; i++)
            {
                encryptText.Append(Encrypt(plaintext[i]));
            }

            return encryptText.ToString();
        }

        private static string Encrypt(char plainchar) =>
            plainchar switch
            {
                /* For more information about the characters used, see
                 * https://www.explainxkcd.com/wiki/index.php/3054:_Scream_Cipher#Trivia
                 */

                'A' => "A",
                'B' => "A\u0307",
                'C' => "A\u0327",
                'D' => "A\u0331",
                'E' => "A\u0301",
                'F' => "A\u032e",
                'G' => "A\u030b",
                'H' => "A\u0330",
                'I' => "A\u0309",
                'J' => "A\u0313",
                'K' => "A\u0323",
                'L' => "A\u0306",
                'M' => "A\u030c",
                'N' => "A\u0302",
                'O' => "A\u030a",
                'P' => "A\u032f",
                'Q' => "A\u0324",
                'R' => "A\u0311",
                'S' => "A\u0303",
                'T' => "A\u0304",
                'U' => "A\u0308",
                'V' => "A\u0300",
                'W' => "A\u030f",
                'X' => "A\u033d",
                'Y' => "A\u0326",
                'Z' => "\u023a",

                /* The encryption algorithm only supports the English alphabet
                 * in plaintext so just use the plaintext character if it
                 * doesn't belong to the mentioned set.
                 * Yes, it is a horrible security hole when it comes to security,
                 * but you shouldn't use a substitution cipher for your bank
                 * transactions in any case!
                 */
                _ => plainchar.ToString()
            };
    }
}
