namespace TarifDefterim.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TarifDefterim.DAL.Context.ProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TarifDefterim.DAL.Context.ProjectContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            // Sisteme t�m yetkiler ile eri�im yapabilecek bir kullan�c�y� database olu�turma i�leminde olu�turuyorum.

            context.AppUsers.AddOrUpdate(

                x => x.ID, new Model.Option.AppUser()
                {
                    Name = "G�KHAN",
                    LastName = "�ZG�R",
                    UserName = "gozgur",
                    Email = "g.ozgur@outlook.com",
                    Password = "202cb962ac59075b964b07152d234b70",
                    Role = Model.Option.Role.Admin,
                    Status = Core.Enum.Status.Active,
                    UserImage = "/Content/Uploads/User_Images/Original_Images/user_default_image.png",
                    XSmallUserImage = "/Content/Uploads/User_Images/XSmall_Images/user_default_image.png",
                    CruptedUserImage = "/Content/Uploads/User_Images/Crupted_Images/user_default_image.png"

                }

            );

        }
    }
}
