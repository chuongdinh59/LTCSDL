using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuildingDemo.Areas.Admin.Repository;
using BuildingDemo.Models;

namespace BuildingDemo.Areas.Admin.Service
{
    public class ImageService
    {
        private ImageRepository imageRepository = new ImageRepository();

        public bool save(Image img)
        {
            return imageRepository.save(img);
        }
    }
}