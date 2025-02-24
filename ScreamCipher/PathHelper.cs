using System.Globalization;

namespace ScreamCipher
{
    public static class PathHelper
    {
        public static string GetPathToEncryptionFolder()
        {
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var encryptionFolder = Path.Combine(desktop, nameof(ScreamCipher));

            if (!Directory.Exists(encryptionFolder))
            {
                Directory.CreateDirectory(encryptionFolder);
            }

            return encryptionFolder;
        }

        public static string GetPathToEncryptionFile()
        {
            var folder = GetPathToEncryptionFolder();
            var time = DateTime.UtcNow.ToString("yyyyMMddTHHmmssZ", CultureInfo.InvariantCulture);
            return Path.Combine(folder, $"{time}-encrypted.txt");
        }
    }
}
