using FiltroDotnet.Models;

namespace FiltroDotnet.Repositories
{
    public interface IUtilities
    {
        string EncryptSHA256(string input);
        string GenerateJwtToken(User user);
    }

}