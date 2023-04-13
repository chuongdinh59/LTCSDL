using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuildingDemo.Areas.Admin.Controllers
{
    public class CloudinaryController : Controller
    {
        private static Account account = new Account("dzgugrqxz", "553752333718615", "M69pV8K_AXfB6l1SVciFIrIA4CE");
        [HttpPost]
        [Obsolete]
        public static string UploadImage(HttpPostedFileBase Image)
        {   
            if (Image != null && Image.ContentLength > 0)
            {
                //string IsExists = GetImageUrl(Image.FileName);
                //if (IsExists != null)
                //    return IsExists;
                Cloudinary cloudinary = new Cloudinary(account);
                var uploadResult = cloudinary.Upload(new ImageUploadParams() {
                    File = new FileDescription(Image.FileName, Image.InputStream),
                    Folder = "building_img"
                });

                return uploadResult.SecureUri.AbsoluteUri;
            }

            return "";
        }
        public static string GetImageUrl(string filename)
        {
            Cloudinary cloudinary = new Cloudinary(account);
            var result = cloudinary.Search().Expression($"folder:building_img filename:{filename}").Execute();
            if (result.Resources.Any())
            {
                // Return the URL of the first image in the search results
                return result.Resources.First().SecureUrl;
            }
            else
            {
                // No image found with the specified filename
                return null;
            }
        }

        public static String DeleteImage(string imageIdOrUrl)
        {
            Cloudinary cloudinary = new Cloudinary(account);
            var deletionResult = cloudinary.DeleteResources(imageIdOrUrl);

            if (deletionResult.DeletedCounts.ContainsKey(imageIdOrUrl))
            {
                return "success";
            }
            else if (deletionResult.Error != null)
            {
                return "fail: " + deletionResult.Error.Message;
            }
            else
            {
                return "fail";
            }
        }
    }
}