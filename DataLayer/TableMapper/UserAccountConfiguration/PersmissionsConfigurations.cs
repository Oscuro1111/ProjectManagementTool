using DataLayer.Model.UserAccount.AccountPermissions;
using Microsoft.EntityFrameworkCore;
namespace DataLayer.TableMapper.UserAccountConfiguration{
public class PermissionsConfigurations
 {
     public static void MapPermisssionsConfiguration (ModelBuilder builder){

          builder.Entity<Permissions>(table=>{
              
              table.ToTable("tbl_permissions");
             
              table.OwnsOne(p=>p.UserManagementPermissions,p=>{
                  p.Property(y=>y.AddUsers).HasColumnType("bit");
                  p.Property(y=>y.AllUsersVisible).HasColumnType("bit");
                  p.Property(y=>y.BlockUsers).HasColumnType("bit");
                  p.Property(y=>y.EditUsers).HasColumnType("bit");
                  p.Property(y=>y.RemoveUsers).HasColumnType("bit");
                 
                });

              table.OwnsOne(p => p.ProjectPermissions, p =>
                 {
                     p.Property(y =>y.AddMember).HasColumnType("bit");

                     p.Property(y => y.AddProject).HasColumnType("bit");
                     p.Property(y => y.DeleteProject).HasColumnType("bit");
                     p.Property(y => y.RemoveMember).HasColumnType("bit");
                 });
              });


     }
 
 }
}