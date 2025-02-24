using System.Text;

namespace ScreamCipher
{
    /* Implemented based on
     * https://xkcd.com/3054/
     * 
     * The program implementation is licesed as of LICENSE.txt
     * All rights related to the encryption algorithm belongs to Randall Munroe.
     */

    internal class Program
    {
        private static readonly Encoding encoding = Encoding.UTF8;

        static void Main(string[] args)
        {
            //Use unicode for the program since we are going to use som weird diacritics.
            Console.OutputEncoding = encoding;
            Console.InputEncoding = encoding;

            Console.WriteLine("Enter ':q' to quit.'");
            while (true)
            {
                //Collect cleartext
                Console.WriteLine();
                Console.WriteLine("Enter cleartext: ");
                var plaintext = Console.ReadLine();

                //Check for command inputs.
                if (string.IsNullOrWhiteSpace(plaintext)) { continue; }
                if (plaintext.Equals(":q")) { break; }

                //Encrypt the text.
                var encryptedText = ScreamCiper.Screamify(plaintext);

                //Write the encrypted text to result file.
                var encryptedFile = PathHelper.GetPathToEncryptionFile();
                File.WriteAllText(encryptedFile, encryptedText, encoding);
                Console.WriteLine("The encrypted text has been written to");
                Console.WriteLine(encryptedFile);
            }
        }
    }
}
