namespace DataLayer.Model.UserAccount.AccountPermissions{

    public class Permissions:BaseEntity{

       public  Permissions(){

          UserManagementPermissions = new UserManagementPermissions();
          ProjectPermissions = new ProjectPermissions();
        }

        public UserManagementPermissions UserManagementPermissions{get;set;}
   
        
       public  User User{get;set;}

       public ProjectPermissions ProjectPermissions { get; set; }
    }

}