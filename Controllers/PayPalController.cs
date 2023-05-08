using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildingDemo.Service;
using PayPal.Api;

namespace BuildingDemo.Controllers
{
    public class PayPalController : Controller
    {

        private static string clientId = "ARivUGXMkudv-oiTQbNJHzm-3j9qYJ9T0bONOq4W1w6IX7ahfZv9QxpRBHGcvx5Qu8rrK2hzYNF0bsVH";
        private static string clientSecret = "EKwHSXAz_fl57MM2XOcbUtES6g7pzYXzRbOotFHx-ZdXo91V65jJzi_7FsnT-AP9wOZ3fKPl9j_M9uwg";

        // Thực hiện thanh toán
        //public ActionResult PaymentWithPaypal()
        //{
        //    // Bước 1: Tạo một đơn hàng PayPal
        //    var apiContext = GetApiContext();

        //    // Tạo một đơn hàng PayPal với các thông tin cần thiết
        //    var itemList = new ItemList() {
        //        items = new List<Item>()
        //        {
        //            new Item()
        //            {
        //                name = "Product Name",
        //                currency = "USD",
        //                price = "10.00",
        //                quantity = "1",
        //                sku = "sku"
        //            }
        //        }
        //    };
        //    var payer = new Payer() { payment_method = "paypal" };
        //    var redirectUrl = new RedirectUrls() {
        //        cancel_url = Url.Action("Index", "Home", null, protocol: Request.Url.Scheme),
        //        return_url = Url.Action("PaymentSuccessful", "PayPal", null, protocol: Request.Url.Scheme)
        //    };
        //    var details = new Details() {
        //        tax = "0",
        //        shipping = "0",
        //        subtotal = "10.00"
        //    };
        //    var amount = new Amount() {
        //        currency = "USD",
        //        total = "10.00",
        //        details = details
        //    };
        //    var transactionList = new List<Transaction>();
        //    transactionList.Add(new Transaction() {
        //        description = "Transaction Description",
        //        invoice_number = "your_invoice_number",
        //        amount = amount,
        //        item_list = itemList
        //    });
        //    var payment = new Payment() {
        //        intent = "sale",
        //        payer = payer,
        //        redirect_urls = redirectUrl,
        //        transactions = transactionList
        //    };

        //    // Bước 2: Thực hiện thanh toán
        //    var createdPayment = payment.Create(apiContext);

        //    // Chuyển hướng người dùng đến trang thanh toán của PayPal
        //    var links = createdPayment.links.GetEnumerator();
        //    while (links.MoveNext())
        //    {
        //        var link = links.Current;
        //        if (link.rel.ToLower().Trim().Equals("approval_url"))
        //        {
        //            return Redirect(link.href);
        //        }
        //    }

        //    // Nếu không tìm thấy đường dẫn thanh toán, hiển thị thông báo lỗi
        //    return View("Error");
        //}
        public ActionResult PaymentWithPaypal(double price, string buildingid)
        {
            // Lấy context của Paypal
            APIContext apiContext = GetApiContext();

            // Tạo đối tượng Payment
            var payment = new Payment() {
                intent = "sale",
                payer = new Payer() {
                    payment_method = "paypal"
                },
                transactions = new List<Transaction>()
                {
            new Transaction()
            {
                amount = new Amount()
                {
                    currency = "USD", // Sử dụng VND làm đơn vị tiền tệ
                    total = price.ToString(), // Sử dụng giá trị price được truyền vào
                    details = new Details()
                    {
                        tax = "0",
                        shipping = "0",
                        subtotal = price.ToString() // Sử dụng giá trị price được truyền vào
                    }
                },
                description = "Mô tả thanh toán"
            }
        },
                redirect_urls = new RedirectUrls() {
                    return_url = Url.Action("PaymentSuccessful", "PayPal", new { buildingid = buildingid }, Request.Url.Scheme),
                    cancel_url = Url.Action("PaymentCancelled", "PayPal", null, Request.Url.Scheme)
                }
            };

            // Tạo Payment và trả về link thanh toán
            var createdPayment = payment.Create(apiContext);
            var links = createdPayment.links.GetEnumerator();
            string paypalRedirectUrl = null;
            while (links.MoveNext())
            {
                Links lnk = links.Current;
                if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                {
                    paypalRedirectUrl = lnk.href;
                }
            }

            // Nếu tạo Payment thành công, chuyển hướng sang trang thanh toán PayPal
            if (paypalRedirectUrl != null)
            {
                return Redirect(paypalRedirectUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        // Xác nhận giao dịch thanh toán
        public ActionResult PaymentSuccessful(string paymentId, string token, string PayerID, string buildingid)
        {
            // Bước 3: Xác nhận giao dịch thanh toán
            var apiContext = GetApiContext();

            // Lấy thông tin giao dịch từ PayPal
            var paymentExecution = new PaymentExecution() { payer_id = PayerID };
            var payment = new Payment() { id = paymentId };
            var executedPayment = payment.Execute(apiContext, paymentExecution);

            // Hiển thị trang xác nhận thanh toán thành công
            BuildingService buildingService = new BuildingService();
            bool rs = buildingService.ChangePay(buildingid);
            return Redirect("/User");
        }

        private static APIContext GetApiContext()
        {
            // Khởi tạo đối tượng TokenCredential để xác thực với PayPal
            var accessToken = new OAuthTokenCredential(clientId, clientSecret, GetConfig()).GetAccessToken();
            var apiContext = new APIContext(accessToken);
            apiContext.Config = GetConfig();
            return apiContext;
        }
        // Lấy cấu hình kết nối với PayPal
        private static Dictionary<string, string> GetConfig()
        {
            var config = new Dictionary<string, string>();
            config.Add("mode", "sandbox"); // Thực hiện thanh toán trên PayPal Sandbox
            config.Add("connection_timeout", "360000");
            config.Add("requestRetries", "1");
            config.Add("clientId", clientId);
            config.Add("clientSecret", clientSecret);

            return config;
        }
    }
}