using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppRestaurantDemoApp.Models;
using WebAppRestaurantDemoApp.Repositories;


namespace WebAppRestaurantDemoApp.Controllers
{
    public class HomeController : Controller
    {
        private RestarantDBAEntities objRestarantDBEntities;

        public HomeController()
        {
            objRestarantDBEntities = new RestarantDBAEntities();
        }

        // GET: Home
        public ActionResult Index()
        {
            CustomerRepository objcustomerRepository = new CustomerRepository();
            ItempRepository objitempRepository = new ItempRepository();
            PaymentRepository objpaymentRepository = new PaymentRepository();

            var objMultipleModels = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>(objcustomerRepository.GetAllCustomers(), objitempRepository.GetAllItems(), objpaymentRepository.GetAllPaymentType());

            return View(objMultipleModels);         //view(model)
        }

        [HttpGet]
        public JsonResult getItemUnitPrice(int itemId)
        {
            decimal UnitPrice = objRestarantDBEntities.Items.Single(model => model.ItemId == itemId).ItemPrice;  //DB 속 Items 테이블의 model에 itemID 찾기 -> ItemPrice 출력 -> ietmId가 같으면 출력
            return Json(UnitPrice, JsonRequestBehavior.AllowGet);
        }

    }
}


/*42분 15초*/