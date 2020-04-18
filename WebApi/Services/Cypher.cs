using System.Text;
using WebApi.Services.Interfaces;

namespace WebApi.Services
{
    public class Cypher : ICypher
    {
        public string Decode(int jumps, string encryptedText)
        {
            StringBuilder result = new StringBuilder();

            jumps = jumps * -1;

            for (int i = 0; i < encryptedText.Length; i++)
            {
                if (char.IsLetter(encryptedText[i]))
                {
                    int ASCIICode =
                        ((int)encryptedText[i]) + jumps ;

                    if (ASCIICode < 97) ASCIICode += 26;

                    char letter = (char)ASCIICode;

                    result.Append(letter);
                }
                else
                {
                    result.Append(encryptedText[i]);
                }
            }

            return result.ToString();
        }
    }
}
