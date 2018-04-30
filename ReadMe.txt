Bu proje katmanli mimari projesi olup aşağıdaki teknolojiler kullanılmıştır.

Object Oriented Programming, 
N-tier Architecture,
Code First
ASP.NET MVC,
Wep API, 
RESTful, 
Javascript,
jQuery,
AJAX,
Entity Framework, 
Html,
Css, 
Bootstrap, 
GitHub, 
BitBucket


Projede startup ayarında değişiklik yapıldığı için console komutlarýnda aþaðýdaki komutlar uygulanýr.

1- Enable-Migrations -ProjectName "TarifDefterim.DAL" -StartUpProjectName "TarifDefterim.UI" -Verbose
	1.1 Tüm sayfalarda yetki ve hata bazında korumalar olduğu için ilk kullanıcıyı açılan konfigürasyon sayfasında AutomaticMigrationsEnabled = true; yaparak, ilk kullanıcıyı aşağıdaki kod ile seed ediyorum.
	1.1.1
            context.AppUsers.AddOrUpdate(

                x => x.ID, new Model.Option.AppUser()
                {
                    Name = "ADMIN",
                    LastName = "ADMINISTRATOR",
                    UserName = "admin",
                    Email = "g.ozgur@outlook.com",
                    Password = "202cb962ac59075b964b07152d234b70",
                    Role = Model.Option.Role.Admin,
                    Status = Core.Enum.Status.Active,
                    UserImage = "/Content/Uploads/User_Images/Original_Images/user_default_image.png",
                    XSmallUserImage = "/Content/Uploads/User_Images/XSmall_Images/user_default_image.png",
                    CruptedUserImage = "/Content/Uploads/User_Images/Crupted_Images/user_default_image.png"

                }

            );

            context.AppUsers.AddOrUpdate(
                
                x => x.ID, new Model.Option.AppUser()
                {
                    Name = "GÖKHAN",
                    LastName = "ÖZGÜR",
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

2- add-migration initial -ProjectName "TarifDefterim.DAL" -StartUpProjectName "TarifDefterim.UI" -Verbose
3- update-database -StartUpProjectName "TarifDefterim.UI"
