Projede startup ayar�nda de�i�iklik yap�ld��� i�in console komutlar�nda a�a��daki komutlar uygulan�r.

1- Enable-Migrations -ProjectName "TarifDefterim.DAL" -StartUpProjectName "TarifDefterim.UI" -Verbose
	1.1 T�m sayfalarda yetki ve hata baz�nda korumalar oldu�u i�in ilk kullan�c�y� a��lan konfig�rasyon s�n�f�nda AutomaticMigrationsEnabled = true; yap�l�r ve  ilk kullan�c�y� a�a��daki kod ile seed ediyorum.
	1.1.1
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

2- add-migration initial -StartUpProjectName "TarifDefterim.UI" -Verbose
3- update-database -StartUpProjectName "TarifDefterim.UI"

// �ye kullan�c�ya yemek ekleme sayfas� yapmal�y�m.