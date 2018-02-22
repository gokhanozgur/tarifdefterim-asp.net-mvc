using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TarifDefterim.Utility
{
    public class ImageUploader
    {
        public static string DefaultProfileImagePath = "/Content/Uploads/User_Images/Original_Images/user_default_image.png";

        public static string DefaultXSmallProfileImage = "/Content/Uploads/User_Images/XSmall_Images/user_default_image.png";

        public static string DefaulCruptedProfileImage = "/Content/Uploads/User_Images/Crupted_Images/user_default_image.png";

        public static string OriginalProfileImagePath = "~/Content/Uploads/User_Images/Original_Images/";

        public static string DefaultMealImagePath = "/Content/Uploads/Meal_Images/Original_Images/default_image.png";

        public static string OriginalMealImagePath = "~/Content/Uploads/Meal_Images/Original_Images/";
        

        public static List<string> UploadSingleImage(string serverPath, HttpPostedFileBase file, int saveAsParam)
        {
            string OriginalImagePath = "~/Content/Uploads/User_Images/Original_Images/";
            string XSmallImagePath = "~/Content/Uploads/User_Images/XSmall_Images/";
            string CruptedImagePath = "~/Content/Uploads/User_Images/Crupted_Images/";

            List<string> ImagePaths = new List<string>();

            if (file != null)
            {
                var uniqueName = Guid.NewGuid();

                serverPath = serverPath.Replace("~", string.Empty);

                var fileArray = file.FileName.Split('.');
                string extension = fileArray[fileArray.Length - 1].ToLower();

                var fileName = uniqueName + "." + extension;

                if (saveAsParam == 2)
                {
                    OriginalImagePath = "~/Content/Uploads/Meal_Images/Original_Images/";
                    XSmallImagePath = "~/Content/Uploads/Meal_Images/XSmall_Images/";
                    CruptedImagePath = "~/Content/Uploads/Meal_Images/Crupted_Images/";
                }


                if (extension == "jpg" || extension == "jpeg" || extension == "png" || extension == "gif")
                {
                    if (File.Exists(HttpContext.Current.Server.MapPath(serverPath + fileName)))
                    {
                        ImagePaths.Add("1");

                        return ImagePaths;
                    }
                    else
                    {
                        var filePath = HttpContext.Current.Server.MapPath(serverPath + fileName);


                        file.SaveAs(filePath);

                        /* Görselleri boyutlandırmak için ImageResizer namespace`ini kullanıyorum. Bu işlemin dökümantasyonu imageresizing.net adresinde var(Package Manager Console ile hallettim). */
                        
                        ImageResizer.ResizeSettings ImageSetting = new ImageResizer.ResizeSettings();
                        ImageSetting.Width = 29;
                        ImageSetting.Height = 29;
                        ImageSetting.Mode = ImageResizer.FitMode.Crop;
                        

                        ImageResizer.ImageBuilder.Current.Build(OriginalImagePath + fileName, XSmallImagePath + fileName, ImageSetting);

                        ImageSetting.Width = 150;
                        ImageSetting.Height = 150;
                        ImageSetting.Mode = ImageResizer.FitMode.Crop;

                        ImageResizer.ImageBuilder.Current.Build(OriginalImagePath + fileName, CruptedImagePath + fileName, ImageSetting);

                        ImagePaths.Add(serverPath+fileName);
                        ImagePaths.Add(XSmallImagePath.Replace("~",string.Empty)+ fileName);
                        ImagePaths.Add(CruptedImagePath.Replace("~", string.Empty) + fileName);

                        return ImagePaths;
                    }
                }
                else
                {
                    ImagePaths.Add("2");

                    return ImagePaths;
                }


            }
            ImagePaths.Add("0");

            return ImagePaths;
        }

    }
}
