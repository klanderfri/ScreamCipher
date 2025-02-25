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
        private static readonly Encoding encoding = Encoding.Unicode;

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
                        TransformText(
                            transformText: ScreamCiper.Screamify,
                            pathToResultFile: PathHelper.GetPathToEncryptionFile(),
                            fromLabel: "plaintext",
                            toLabel: "encrypted");
                        break;

                    case ":d":
                        TransformText(
                            transformText: ScreamCiper.Unscreamify,
                            pathToResultFile: PathHelper.GetPathToDecryptionFile(),
                            fromLabel: "ciphertext",
                            toLabel: "decrypted");
                        break;

                    case ":q":
                        return;

                    default:
                        Console.WriteLine($"Unknown command '{command}'.");
                        break;
                }
            }
        }

        private static void TransformText(
            Func<string, string> transformText,
            string pathToResultFile,
            string fromLabel,
            string toLabel)
        {
            //Collect encrypted text.
            Console.WriteLine();
            Console.Write($"Enter {fromLabel} => ");
            var from = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(from))
            {
                Console.WriteLine($"No {fromLabel} entered.");
                return;
            }

            //Decrypt the text.
            var to = transformText(from);

            //Write the decrypted text to result file.
            File.WriteAllText(pathToResultFile, to, encoding);
            Console.WriteLine($"The {toLabel} text has been written to");
            Console.WriteLine(pathToResultFile);
        }
    }
}
