Projede startup ayarýnda deðiþiklik yapýldýðý için console komutlarýnda aþaðýdaki komutlar uygulanýr.

1- Enable-Migrations -ProjectName "TarifDefterim.DAL" -StartUpProjectName "TarifDefterim.UI" -Verbose
	1.1 Tüm sayfalarda yetki ve hata bazýnda korumalar olduðu için ilk kullanýcýyý açýlan konfigürasyon sýnýfýnda AutomaticMigrationsEnabled = true; yapýlýr ve  ilk kullanýcýyý aþaðýdaki kod ile seed ediyorum.
	1.1.1
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

2- add-migration initial -StartUpProjectName "TarifDefterim.UI" -Verbose
3- update-database -StartUpProjectName "TarifDefterim.UI"

// Üye kullanýcýya yemek ekleme sayfasý yapmalýyým.