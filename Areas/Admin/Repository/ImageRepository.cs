using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuildingDemo.Models;

namespace BuildingDemo.Areas.Admin.Repository
{
    public class ImageRepository
    {
        private static BuildingDB db = new BuildingDB();

        public bool save(Image image)
        {
            try
            {
                db.Images.Add(image);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // handle any exceptions here
                return false;
            }
        }
    }
}