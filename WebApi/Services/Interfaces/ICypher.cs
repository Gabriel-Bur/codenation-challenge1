namespace WebApi.Services.Interfaces
{
    public interface ICypher
    {
        string Decode(int jumps, string encryptedText);
    }
}
