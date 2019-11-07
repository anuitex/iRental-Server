namespace iRental.Core
{
    public interface IHashEncryptor
    {
        string SHA512(string input);
    }
}
