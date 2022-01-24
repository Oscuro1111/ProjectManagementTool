using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using DataLayer.Model.UserAccount;
using PMSRepository;


namespace PMSServices.UserAccountServices.UserCredentialServices
{


    public class UserCredentialServices:IUserCredentialServices
    {
        private readonly IPMSRepository<UserCredential> userCredentialRepository;

        public UserCredentialServices(IPMSRepository<UserCredential> userCredentialRepo)
        {
            this.userCredentialRepository = userCredentialRepo;
        }


        public string ComputeSha256Hash(string raw)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(raw));

                return ConvertByteArrayToString(bytes);
            }
        }

        public string ConvertByteArrayToString(byte[] bytes)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("X2"));//hexadedcimal string
            }
            return builder.ToString();
        }

        public void DeleteUserCredential(long id)
        {
            var uc = GetUserCredential(id);
            userCredentialRepository.Delete(uc);
        }

        public long GenrateCredentials(string password)
        {
            byte[] rawsalt = new byte[16];
            var RNG = new RNGCryptoServiceProvider();

            UserCredential uc = new UserCredential();
            
            RNG.GetBytes(rawsalt);

            string salt = ConvertByteArrayToString(rawsalt);
            string hashPass = ComputeSha256Hash(string.Concat(password,salt));

            uc.PassHash = hashPass;
            uc.Salt = salt;

            //Creating new UserCredentials for new User Account
            userCredentialRepository.Insert(uc);

            return uc.Id;
           }

        public IEnumerable<UserCredential> GetAllUserCredential()
        {
            return this.userCredentialRepository.GetAll();
        }

        public UserCredential GetUserCredential(long Id)
        {
            return userCredentialRepository.Get(Id);
        }

        public void InsertUserCredential(UserCredential user)
        {
            userCredentialRepository.Insert(user);
        }

        public void UpdateUserCredential(UserCredential user)
        {
            userCredentialRepository.Update(user);
        }

        public bool VerifyHashPassword(long Id,string src)
        {
            UserCredential uc = GetUserCredential(Id);

            return uc.PassHash.Equals(ComputeSha256Hash(string.Concat(src, uc.Salt)));
        }



        //SMTP

        
    }
}
