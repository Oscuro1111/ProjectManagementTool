
using PMSServices.UserAccountServices.UserCredentialServices;
using PMSServices.UserAccountServices.UserServices;

namespace PMSServices.UserAccountServices.JWT
{
    public interface IJWTAuth
    {
        string Authentication(string userEmail, string userPassword);
        public void setDependency(IUserServices userServices, IUserCredentialServices userCredentialServices);
    }
}
