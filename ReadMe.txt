// T�m sayfalarda yetki ve hata baz�nda korumalar oldu�u i�in ilk kullan�c�y� seed ederek sisteme dahil ediyorum.

            context.AppUsers.AddOrUpdate(

                x => x.ID, new Model.Option.AppUser() {
                    Name = "G�KHAN",
                    LastName = "�ZG�R",
                    UserName = "gozgur",
                    Email = "g.ozgur@outlook.com"
                    Password = "202cb962ac59075b964b07152d234b70",
                    Role = Model.Option.Role.Admin,
                    Status = Core.Enum.Status.Active,
                    UserImage = "/Content/Uploads/User_Images/Original_Images/user_default_image.png",
                    XSmallUserImage = "/Content/Uploads/User_Images/XSmall_Images/user_default_image.png",
                    CruptedUserImage = "/Content/Uploads/User_Images/Crupted_Images/user_default_image.png"

                }

            );