using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppRestaurantDemoApp.Models;

namespace WebAppRestaurantDemoApp.Repositories
{
    public class CustomerRepository
    {
        private RestarantDBAEntities objRestarantDBEntities;

        public CustomerRepository()
        {
            objRestarantDBEntities = new RestarantDBAEntities();
        }

        //IEnumerable 인터페이스 메소드 : MyClass
        public IEnumerable<SelectListItem> GetAllCustomers()
        {
            var objselectListItems = new List<SelectListItem>();
            objselectListItems = (from obj in objRestarantDBEntities.Customers
                                  select new SelectListItem()
                                  {
                                      Text = obj.CustomerName,
                                      Value = obj.CustomerId.ToString(),
                                      Selected = true
                                  }).ToList();

            return objselectListItems;
        
        }


    }
}