// Tüm sayfalarda yetki ve hata bazýnda korumalar olduðu için ilk kullanýcýyý seed ederek sisteme dahil ediyorum.

            context.AppUsers.AddOrUpdate(

                x => x.ID, new Model.Option.AppUser() {
                    Name = "GÖKHAN",
                    LastName = "ÖZGÜR",
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