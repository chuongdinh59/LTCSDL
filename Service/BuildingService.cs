using BuildingDemo.Areas.Admin.Controllers;
using BuildingDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BuildingDemo.Service
{
    public class BuildingService
    {
        private  BuildingDB db = new BuildingDB();
        public List<Building> getAll()
        {
            return db.Buildings.Where(b => b.IsResolve == true).ToList();
        }
        public List<Building> Search(string keyword, double? price, int? BuildingTypeID, string address, int? beds, int? baths)
        {
            try
            {
                var SearchResult = db.Buildings.ToList();
                if (!string.IsNullOrEmpty(keyword)) // có nhập tên nhà
                {
                    if (price != null) //có nhập giá
                    {
                        if (BuildingTypeID != null) // có chọn loại nhà 
                        {
                            if (!string.IsNullOrEmpty(address)) // có nhập địa chỉ
                            {
                                if (beds != null) // có chọn số phòng ngủ
                                {
                                    if (baths != null)  // có chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.Name.Contains(keyword)
                                        && (b.PurchasePrice <= price + 20 && b.PurchasePrice >= price - 20)
                                        && b.BuildingTypeID == BuildingTypeID
                                        && b.Address.Contains(address)
                                        && b.Bed == beds
                                        && b.Bath == baths).ToList();
                                    }
                                    else // không chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.Name.Contains(keyword)
                                        && (b.PurchasePrice <= price + 20 && b.PurchasePrice >= price - 20)
                                        && b.BuildingTypeID == BuildingTypeID
                                        && b.Address.Contains(address)
                                        && b.Bed == beds).ToList();
                                    }
                                }
                                else //không chọn số phòng ngủ
                                {
                                    if (baths != null)  // có chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.Name.Contains(keyword)
                                        && (b.PurchasePrice <= price + 20 && b.PurchasePrice >= price - 20)
                                        && b.BuildingTypeID == BuildingTypeID
                                        && b.Address.Contains(address)
                                        && b.Bath == baths).ToList();
                                    }
                                    else // không chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.Name.Contains(keyword)
                                        && (b.PurchasePrice <= price + 20 && b.PurchasePrice >= price - 20)
                                        && b.BuildingTypeID == BuildingTypeID
                                        && b.Address.Contains(address)).ToList();
                                    }
                                }
                            }
                            else // không nhập địa chỉ
                            {
                                if (beds != null) // có chọn số phòng ngủ
                                {
                                    if (baths != null)  // có chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.Name.Contains(keyword)
                                        && (b.PurchasePrice <= price + 20 && b.PurchasePrice >= price - 20)
                                        && b.BuildingTypeID == BuildingTypeID
                                        && b.Bed == beds
                                        && b.Bath == baths).ToList();
                                    }
                                    else // không chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.Name.Contains(keyword)
                                        && (b.PurchasePrice <= price + 20 && b.PurchasePrice >= price - 20)
                                        && b.BuildingTypeID == BuildingTypeID
                                        && b.Bed == beds).ToList();
                                    }
                                }
                                else //không chọn số phòng ngủ
                                {
                                    if (baths != null)  // có chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.Name.Contains(keyword)
                                        && (b.PurchasePrice <= price + 20 && b.PurchasePrice >= price - 20)
                                        && b.BuildingTypeID == BuildingTypeID
                                        && b.Bath == baths).ToList();
                                    }
                                    else // không chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.Name.Contains(keyword)
                                        && (b.PurchasePrice <= price + 20 && b.PurchasePrice >= price - 20)
                                        && b.BuildingTypeID == BuildingTypeID).ToList();
                                    }
                                }
                            }
                        }
                        else // không chọn loại nhà
                        {
                            if (!string.IsNullOrEmpty(address)) // có nhập địa chỉ
                            {
                                if (beds != null) // có chọn số phòng ngủ
                                {
                                    if (baths != null)  // có chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.Name.Contains(keyword)
                                        && (b.PurchasePrice <= price + 20 && b.PurchasePrice >= price - 20)
                                        && b.Address.Contains(address)
                                        && b.Bed == beds
                                        && b.Bath == baths).ToList();
                                    }
                                    else // không chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.Name.Contains(keyword)
                                        && (b.PurchasePrice <= price + 20 && b.PurchasePrice >= price - 20)
                                        && b.Address.Contains(address)
                                        && b.Bed == beds).ToList();
                                    }
                                }
                                else //không chọn số phòng ngủ
                                {
                                    if (baths != null)  // có chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.Name.Contains(keyword)
                                        && (b.PurchasePrice <= price + 20 && b.PurchasePrice >= price - 20)
                                        && b.Address.Contains(address)
                                        && b.Bath == baths).ToList();
                                    }
                                    else // không chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.Name.Contains(keyword)
                                        && (b.PurchasePrice <= price + 20 && b.PurchasePrice >= price - 20)
                                        && b.Address.Contains(address)).ToList();
                                    }
                                }
                            }
                            else // không nhập địa chỉ
                            {
                                if (beds != null) // có chọn số phòng ngủ
                                {
                                    if (baths != null)  // có chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.Name.Contains(keyword)
                                        && (b.PurchasePrice <= price + 20 && b.PurchasePrice >= price - 20)
                                        && b.Bed == beds
                                        && b.Bath == baths).ToList();
                                    }
                                    else // không chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.Name.Contains(keyword)
                                        && (b.PurchasePrice <= price + 20 && b.PurchasePrice >= price - 20)
                                        && b.Bed == beds).ToList();
                                    }
                                }
                                else //không chọn số phòng ngủ
                                {
                                    if (baths != null)  // có chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.Name.Contains(keyword)
                                        && (b.PurchasePrice <= price + 20 && b.PurchasePrice >= price - 20)
                                        && b.Bath == baths).ToList();
                                    }
                                    else // không chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.Name.Contains(keyword)
                                        && (b.PurchasePrice <= price + 20 && b.PurchasePrice >= price - 20)).ToList();
                                    }
                                }
                            }
                        }
                    }
                    else // không nhập giá 
                    {
                        if (BuildingTypeID != null) // có chọn loại nhà 
                        {
                            if (!string.IsNullOrEmpty(address)) // có nhập địa chỉ
                            {
                                if (beds != null) // có chọn số phòng ngủ
                                {
                                    if (baths != null)  // có chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.Name.Contains(keyword)
                                        && b.BuildingTypeID == BuildingTypeID
                                        && b.Address.Contains(address)
                                        && b.Bed == beds
                                        && b.Bath == baths).ToList();
                                    }
                                    else // không chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.Name.Contains(keyword)
                                        && b.BuildingTypeID == BuildingTypeID
                                        && b.Address.Contains(address)
                                        && b.Bed == beds).ToList();
                                    }
                                }
                                else //không chọn số phòng ngủ
                                {
                                    if (baths != null)  // có chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.Name.Contains(keyword)
                                        && b.BuildingTypeID == BuildingTypeID
                                        && b.Address.Contains(address)
                                        && b.Bath == baths).ToList();
                                    }
                                    else // không chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.Name.Contains(keyword)
                                        && b.BuildingTypeID == BuildingTypeID
                                        && b.Address.Contains(address)).ToList();
                                    }
                                }
                            }
                            else // không nhập địa chỉ
                            {
                                if (beds != null) // có chọn số phòng ngủ
                                {
                                    if (baths != null)  // có chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.Name.Contains(keyword)
                                        && b.BuildingTypeID == BuildingTypeID
                                        && b.Bed == beds
                                        && b.Bath == baths).ToList();
                                    }
                                    else // không chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.Name.Contains(keyword)
                                        && b.BuildingTypeID == BuildingTypeID
                                        && b.Bed == beds).ToList();
                                    }
                                }
                                else //không chọn số phòng ngủ
                                {
                                    if (baths != null)  // có chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.Name.Contains(keyword)
                                        && b.BuildingTypeID == BuildingTypeID
                                        && b.Bath == baths).ToList();
                                    }
                                    else // không chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.Name.Contains(keyword)
                                        && b.BuildingTypeID == BuildingTypeID).ToList();
                                    }
                                }
                            }
                        }
                        else // không chọn loại nhà
                        {
                            if (!string.IsNullOrEmpty(address)) // có nhập địa chỉ
                            {
                                if (beds != null) // có chọn số phòng ngủ
                                {
                                    if (baths != null)  // có chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.Name.Contains(keyword)
                                        && b.Address.Contains(address)
                                        && b.Bed == beds
                                        && b.Bath == baths).ToList();
                                    }
                                    else // không chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.Name.Contains(keyword)
                                        && b.Address.Contains(address)
                                        && b.Bed == beds).ToList();
                                    }
                                }
                                else //không chọn số phòng ngủ
                                {
                                    if (baths != null)  // có chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.Name.Contains(keyword)
                                        && b.Address.Contains(address)
                                        && b.Bath == baths).ToList();
                                    }
                                    else // không chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.Name.Contains(keyword)
                                        && b.Address.Contains(address)).ToList();
                                    }
                                }
                            }
                            else // không nhập địa chỉ
                            {
                                if (beds != null) // có chọn số phòng ngủ
                                {
                                    if (baths != null)  // có chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.Name.Contains(keyword)
                                        && b.Bed == beds
                                        && b.Bath == baths).ToList();
                                    }
                                    else // không chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.Name.Contains(keyword)
                                        && b.Bed == beds).ToList();
                                    }
                                }
                                else //không chọn số phòng ngủ
                                {
                                    if (baths != null)  // có chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.Name.Contains(keyword)
                                        && b.Bath == baths).ToList();
                                    }
                                    else // không chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.Name.Contains(keyword)).ToList();
                                    }
                                }
                            }
                        }
                    }
                }
                else //không nhập tên nhà
                {
                    if (price != null) //có nhập giá
                    {
                        if (BuildingTypeID != null) // có chọn loại nhà 
                        {
                            if (!string.IsNullOrEmpty(address)) // có nhập địa chỉ
                            {
                                if (beds != null) // có chọn số phòng ngủ
                                {
                                    if (baths != null)  // có chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => (b.PurchasePrice <= price + 20 && b.PurchasePrice >= price - 20)
                                        && b.BuildingTypeID == BuildingTypeID
                                        && b.Address.Contains(address)
                                        && b.Bed == beds
                                        && b.Bath == baths).ToList();
                                    }
                                    else // không chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => (b.PurchasePrice <= price + 20 && b.PurchasePrice >= price - 20)
                                        && b.BuildingTypeID == BuildingTypeID
                                        && b.Address.Contains(address)
                                        && b.Bed == beds).ToList();
                                    }
                                }
                                else //không chọn số phòng ngủ
                                {
                                    if (baths != null)  // có chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => (b.PurchasePrice <= price + 20 && b.PurchasePrice >= price - 20)
                                        && b.BuildingTypeID == BuildingTypeID
                                        && b.Address.Contains(address)
                                        && b.Bath == baths).ToList();
                                    }
                                    else // không chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => (b.PurchasePrice <= price + 20 && b.PurchasePrice >= price - 20)
                                        && b.BuildingTypeID == BuildingTypeID
                                        && b.Address.Contains(address)).ToList();
                                    }
                                }
                            }
                            else // không nhập địa chỉ
                            {
                                if (beds != null) // có chọn số phòng ngủ
                                {
                                    if (baths != null)  // có chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => (b.PurchasePrice <= price + 20 && b.PurchasePrice >= price - 20)
                                        && b.BuildingTypeID == BuildingTypeID
                                        && b.Bed == beds
                                        && b.Bath == baths).ToList();
                                    }
                                    else // không chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => (b.PurchasePrice <= price + 20 && b.PurchasePrice >= price - 20)
                                        && b.BuildingTypeID == BuildingTypeID
                                        && b.Bed == beds).ToList();
                                    }
                                }
                                else //không chọn số phòng ngủ
                                {
                                    if (baths != null)  // có chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => (b.PurchasePrice <= price + 20 && b.PurchasePrice >= price - 20)
                                        && b.BuildingTypeID == BuildingTypeID
                                        && b.Bath == baths).ToList();
                                    }
                                    else // không chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => (b.PurchasePrice <= price + 20 && b.PurchasePrice >= price - 20)
                                        && b.BuildingTypeID == BuildingTypeID).ToList();
                                    }
                                }
                            }
                        }
                        else // không chọn loại nhà
                        {
                            if (!string.IsNullOrEmpty(address)) // có nhập địa chỉ
                            {
                                if (beds != null) // có chọn số phòng ngủ
                                {
                                    if (baths != null)  // có chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => (b.PurchasePrice <= price + 20 && b.PurchasePrice >= price - 20)
                                        && b.Address.Contains(address)
                                        && b.Bed == beds
                                        && b.Bath == baths).ToList();
                                    }
                                    else // không chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => (b.PurchasePrice <= price + 20 && b.PurchasePrice >= price - 20)
                                        && b.Address.Contains(address)
                                        && b.Bed == beds).ToList();
                                    }
                                }
                                else //không chọn số phòng ngủ
                                {
                                    if (baths != null)  // có chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => (b.PurchasePrice <= price + 20 && b.PurchasePrice >= price - 20)
                                        && b.Address.Contains(address)
                                        && b.Bath == baths).ToList();
                                    }
                                    else // không chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => (b.PurchasePrice <= price + 20 && b.PurchasePrice >= price - 20)
                                        && b.Address.Contains(address)).ToList();
                                    }
                                }
                            }
                            else // không nhập địa chỉ
                            {
                                if (beds != null) // có chọn số phòng ngủ
                                {
                                    if (baths != null)  // có chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => (b.PurchasePrice <= price + 20 && b.PurchasePrice >= price - 20)
                                        && b.Bed == beds
                                        && b.Bath == baths).ToList();
                                    }
                                    else // không chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => (b.PurchasePrice <= price + 20 && b.PurchasePrice >= price - 20)
                                        && b.Bed == beds).ToList();
                                    }
                                }
                                else //không chọn số phòng ngủ
                                {
                                    if (baths != null)  // có chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => (b.PurchasePrice <= price + 20 && b.PurchasePrice >= price - 20)
                                        && b.Bath == baths).ToList();
                                    }
                                    else // không chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => (b.PurchasePrice <= price + 20 && b.PurchasePrice >= price - 20)).ToList();
                                    }
                                }
                            }
                        }
                    }
                    else // không nhập giá 
                    {
                        if (BuildingTypeID != null) // có chọn loại nhà 
                        {
                            if (!string.IsNullOrEmpty(address)) // có nhập địa chỉ
                            {
                                if (beds != null) // có chọn số phòng ngủ
                                {
                                    if (baths != null)  // có chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.BuildingTypeID == BuildingTypeID
                                        && b.Address.Contains(address)
                                        && b.Bed == beds
                                        && b.Bath == baths).ToList();
                                    }
                                    else // không chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.BuildingTypeID == BuildingTypeID
                                        && b.Address.Contains(address)
                                        && b.Bed == beds).ToList();
                                    }
                                }
                                else //không chọn số phòng ngủ
                                {
                                    if (baths != null)  // có chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.BuildingTypeID == BuildingTypeID
                                        && b.Address.Contains(address)
                                        && b.Bath == baths).ToList();
                                    }
                                    else // không chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.BuildingTypeID == BuildingTypeID
                                        && b.Address.Contains(address)).ToList();
                                    }
                                }
                            }
                            else // không nhập địa chỉ
                            {
                                if (beds != null) // có chọn số phòng ngủ
                                {
                                    if (baths != null)  // có chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.BuildingTypeID == BuildingTypeID
                                        && b.Bed == beds
                                        && b.Bath == baths).ToList();
                                    }
                                    else // không chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.BuildingTypeID == BuildingTypeID
                                        && b.Bed == beds).ToList();
                                    }
                                }
                                else //không chọn số phòng ngủ
                                {
                                    if (baths != null)  // có chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.BuildingTypeID == BuildingTypeID
                                        && b.Bath == baths).ToList();
                                    }
                                    else // không chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.BuildingTypeID == BuildingTypeID).ToList();
                                    }
                                }
                            }
                        }
                        else // không chọn loại nhà
                        {
                            if (!string.IsNullOrEmpty(address)) // có nhập địa chỉ
                            {
                                if (beds != null) // có chọn số phòng ngủ
                                {
                                    if (baths != null)  // có chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.Address.Contains(address)
                                        && b.Bed == beds
                                        && b.Bath == baths).ToList();
                                    }
                                    else // không chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.Address.Contains(address)
                                        && b.Bed == beds).ToList();
                                    }
                                }
                                else //không chọn số phòng ngủ
                                {
                                    if (baths != null)  // có chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.Address.Contains(address)
                                        && b.Bath == baths).ToList();
                                    }
                                    else // không chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.Address.Contains(address)).ToList();
                                    }
                                }
                            }
                            else // không nhập địa chỉ
                            {
                                if (beds != null) // có chọn số phòng ngủ
                                {
                                    if (baths != null)  // có chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.Bed == beds
                                        && b.Bath == baths).ToList();
                                    }
                                    else // không chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.Bed == beds).ToList();
                                    }
                                }
                                else //không chọn số phòng ngủ
                                {
                                    if (baths != null)  // có chọn số phòng tắm
                                    {
                                        SearchResult = db.Buildings.Where(b => b.Bath == baths).ToList();
                                    }
                                }
                            }
                        }
                    }
                }
                return SearchResult;
            }
            catch
            {
                return null;
            }
        }
        public bool DeleteBuilding(string id)
        {
            try
            {
                Building building = db.Buildings.Find(id);
                if (building == null) return false;
                db.Buildings.Remove(building);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ChangePay(string id)
        {
            try
            {
                Building building = db.Buildings.Find(id);
                if (building == null) return false;
                building.IsPay = true;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<Building> SearchName(string keyword, double? price)
        {
            try
            {
                var SearchResult = db.Buildings.ToList();
                if (!string.IsNullOrEmpty(keyword))
                {
                    if (price != null)
                    {
                        SearchResult = db.Buildings.Where(b => b.Name.Contains(keyword) && (b.PurchasePrice <= price + 20 && b.PurchasePrice >= price - 20)).ToList();
                    }
                    else
                    {
                        SearchResult = db.Buildings.Where(b => b.Name.Contains(keyword)).ToList();
                    }
                }
                else
                {
                    if (price != null)
                    {
                        SearchResult = db.Buildings.Where(b => b.PurchasePrice <= price + 20 && b.PurchasePrice >= price - 20).ToList();
                    }
                }
                return SearchResult;
            }
            catch
            {
                return null;
            }
        }
        public List<Building> getTop(int x)
        {
            return db.Buildings.Take(x).ToList();
        }

        [Obsolete]
        public bool CreateBuilding(Building building, HttpPostedFileBase Image, int AccountID)
        {
            try
            {
                Customer cus = db.Customers.FirstOrDefault(c => c.AccountID == AccountID);
                if (cus == null) return false;
                Guid uuid = Guid.NewGuid();
                string ID = "KG-" + uuid.ToString();
                building.ID = ID;
                building.IsResolve = false;
                building.IsPay = false;
                building.CustomerID = cus.ID;
                if (Image != null) // Đoạn này kiểm tra có hình không 
                {
                    building.Image = CloudinaryController.UploadImage(Image);
                }
                db.Buildings.Add(building);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool save(Building building)
        {
            try
            {
                db.Buildings.Add(building);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // handle any exceptions here
                return false;
            }
        }
        public bool update()
        {
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // handle any exceptions here
                return false;
            }
        }
        public List<Building> GetAll()
        {
            return db.Buildings.ToList();
        }
        public Building FindByID(string id)
        {
            return db.Buildings.Find(id);
        }
        public bool EditInfoBuilding(Building building, HttpPostedFileBase Image)
        {
            try
            {
                using (var db = new BuildingDB())
                {
                    Building b = db.Buildings.Find(building.ID);
                    b.Bath = building.Bath;
                    b.Bed = building.Bed;
                    b.Name = building.Name;
                    b.Address = building.Address;
                    b.Area = building.Area;
                    b.PurchasePrice = building.PurchasePrice;
                    b.NumFloors = building.NumFloors;
                    b.BuildingTypeID = building.BuildingTypeID;
                    b.YearBuild = building.YearBuild;
                    if (Image != null)
                    {
                        b.Image = CloudinaryController.UploadImage(Image);
                    }
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<Building> GetBuildingFromCustomer(Customer customer)
        {
            return customer.Buildings.ToList();
        }
    }
}