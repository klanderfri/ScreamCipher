using ScreamCipher;

namespace ScreamCipherTests
{
    public class ScreamCiperTests
    {
        [Theory]
        [InlineData("Sphinx of Black Quartz, Judge My Vow!", "ÃA̯A̰ẢÂA̽ ÅA̮ ȦĂAA̧Ạ A̤ÄAȂĀȺ, A̓ÄA̱A̋Á ǍA̦ ÀÅȀ!")]
        [InlineData("The quick brown fox jumps over the lazy dog", "ĀA̰Á A̤ÄẢA̧Ạ ȦȂÅȀÂ A̮ÅA̽ A̓ÄǍA̯Ã ÅÀÁȂ ĀA̰Á ĂAȺA̦ A̱ÅA̋")]
        [InlineData("abcdefghijklmnopqrstuvwxyz", "AȦA̧A̱ÁA̮A̋A̰ẢA̓ẠĂǍÂÅA̯A̤ȂÃĀÄÀȀA̽A̦Ⱥ")]
        public void EncryptionTest(string plaintext, string expected)
        {
            var actual = ScreamCiper.Screamify(plaintext);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("ÃA̯A̰ẢÂA̽ ÅA̮ ȦĂAA̧Ạ A̤ÄAȂĀȺ, A̓ÄA̱A̋Á ǍA̦ ÀÅȀ!", "SPHINX OF BLACK QUARTZ, JUDGE MY VOW!")]
        [InlineData("ÃA̯A̰ẢÂA̽ ÅA̮ ȦĂAA̧Ạ A̤ÄAȂĀȺ, A̓ÄA̱A̋Á ǍA̦ ÀÅȀ!", "SPHINX OF BLACK QUARTZ, JUDGE MY VOW!")]
        [InlineData("ĀA̰Á A̤ÄẢA̧Ạ ȦȂÅȀÂ A̮ÅA̽ A̓ÄǍA̯Ã ÅÀÁȂ ĀA̰Á ĂAȺA̦ A̱ÅA̋", "THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG")]
        [InlineData("ĀA̰Á A̤ÄẢA̧Ạ ȦȂÅȀÂ A̮ÅA̽ A̓ÄǍA̯Ã ÅÀÁȂ ĀA̰Á ĂAȺA̦ A̱ÅA̋", "THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG")]
        [InlineData("AȦA̧A̱ÁA̮A̋A̰ẢA̓ẠĂǍÂÅA̯A̤ȂÃĀÄÀȀA̽A̦Ⱥ", "ABCDEFGHIJKLMNOPQRSTUVWXYZ")]
        [InlineData("AȦA̧A̱ÁA̮A̋A̰ẢA̓ẠĂǍÂÅA̯A̤ȂÃĀÄÀȀA̽A̦Ⱥ", "ABCDEFGHIJKLMNOPQRSTUVWXYZ")]
        [InlineData("AAAAAA A ÃA̧AȂA̦ ǍÅÂÃĀÁȂ AAAAAAA!", "AAAAAA A SCARY MONSTER AAAAAAA!")]
        
        public void DecryptionTest(string ciphertext, string expected)
        {
            var actual = ScreamCiper.Unscreamify(ciphertext);

            Assert.Equal(expected, actual);
        }
    }
}
