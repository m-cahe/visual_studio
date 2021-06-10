using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppRestaurantDemoApp.Models;

namespace WebAppRestaurantDemoApp.Repositories
{
    public class PaymentRepository
    {
       private RestarantDBAEntities objRestarantDBEntities;

        public PaymentRepository()
        {
            objRestarantDBEntities = new RestarantDBAEntities();
        }

        public IEnumerable<SelectListItem> GetAllPaymentType()
        {
            var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (
                                  from obj in objRestarantDBEntities.PaymentTypes       //PaymentTypes: 테이블명
                                  select new SelectListItem()
                                  {
                                      Text = obj.PaymentTypeName,
                                      Value = obj.PaymentTypeId.ToString(),              //text:string형식일때,  vlaue: string 외의 형식
                                      Selected = true
                                  }).ToList();
            //IEnumerable: list를 for문으로
            
            return objSelectListItems;
        }
    }
}