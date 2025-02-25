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

            //Print instructions.
            Console.WriteLine("The following commands are available:");
            Console.WriteLine("':e' => Lets you enter a plaintext to encrypt.");
            Console.WriteLine("':d' => Lets you enter an encrypted text to read.");
            Console.WriteLine("':q' => Closes the program.");

            while (true)
            {
                Console.WriteLine();
                Console.Write("Enter command => ");
                var command = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(command)) { continue; }
                switch (command.ToLower())
                {
                    case ":e":
                        EncryptText();
                        break;

                    case ":d":
                        DecryptText();
                        break;

                    case ":q":
                        return;

                    default:
                        Console.WriteLine($"Unknown command '{command}'.");
                        break;
                }
            }
        }

        private static void EncryptText()
        {
            //Collect cleartext
            Console.WriteLine();
            Console.Write("Enter cleartext => ");
            var plaintext = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(plaintext))
            {
                Console.WriteLine("No plaintext entered.");
                return;
            }

            //Encrypt the text.
            var encryptedText = ScreamCiper.Screamify(plaintext);

            //Write the encrypted text to result file.
            var encryptedFile = PathHelper.GetPathToEncryptionFile();
            File.WriteAllText(encryptedFile, encryptedText, encoding);
            Console.WriteLine("The encrypted text has been written to");
            Console.WriteLine(encryptedFile);
        }

        private static void DecryptText()
        {
            //Collect encrypted text.
            Console.WriteLine();
            Console.Write("Enter ciphertext => ");
            var ciphertext = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(ciphertext))
            {
                Console.WriteLine("No ciphertext entered.");
                return;
            }

            //Decrypt the text.
            var decryptedText = ScreamCiper.Unscreamify(ciphertext);

            //Write the decrypted text to result file.
            var decryptedFile = PathHelper.GetPathToDecryptionFile();
            File.WriteAllText(decryptedFile, decryptedText, encoding);
            Console.WriteLine("The decrypted text has been written to");
            Console.WriteLine(decryptedFile);
        }
    }
}
