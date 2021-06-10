using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppRestaurantDemoApp.Models;


namespace WebAppRestaurantDemoApp.Repositories
{
    public class ItempRepository
    {
        public RestarantDBAEntities objRestarantDBEntities;

        public ItempRepository()
        {
            objRestarantDBEntities = new RestarantDBAEntities();
        }

        public IEnumerable<SelectListItem> GetAllItems()          //IEnumerable : 인터페이스
        {
            var objselectListItems = new List<SelectListItem>();
            objselectListItems = (from obj in objRestarantDBEntities.Items
                                  select new SelectListItem()
                                  {
                                      Text = obj.ItemName,
                                      Value = obj.ItemId.ToString(),
                                      Selected = false
                                  }).ToList();

            return objselectListItems;
        }
    }
}