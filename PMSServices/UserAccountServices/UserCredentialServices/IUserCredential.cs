using System.Collections.Generic;
using DataLayer.Model.UserAccount;
namespace PMSServices.UserAccountServices.UserCredentialServices
{

    public interface ICredentialUtils
    {

        string ConvertByteArrayToString(byte[] bytes);
        bool VerifyHashPassword(long Id,string src);
        string ComputeSha256Hash(string raw);

        //Return New Credential  key into tbl_userCredential Table
        long GenrateCredentials(string password);


    }
    public interface IUserCredentialServices:ICredentialUtils
    {
            IEnumerable<UserCredential> GetAllUserCredential();
            UserCredential GetUserCredential(long id);
            void InsertUserCredential(UserCredential user);
            void UpdateUserCredential(UserCredential user);
            void DeleteUserCredential(long id);
    }
}
