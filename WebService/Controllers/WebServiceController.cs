using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using WebService.Models;

namespace WebService.Controllers
{
    public class WebServiceController : Controller
    {
        WebServiceDB db = new WebServiceDB();
        Function fn = new Function();

        // GET: WebService

        public ActionResult Index(string QueryStr)
        {
            List<WebServiceData> list = new List<WebServiceData>();

            if (QueryStr == null)
                list = db.WebServiceDatas.ToList();
            else
                list = db.WebServiceDatas.Where(m => m.Type.Contains(QueryStr) || m.IP.Contains(QueryStr) || m.XMLString.Contains(QueryStr)).ToList();

            return View(list);
        }

        public ActionResult DetailDataToQuery(int Id)
        {
            WebServiceData WebserviceInfo = db.WebServiceDatas.Where(m => m.Id.Equals(Id)).First();
            XmlData XmlInfo = new XmlData();
            XmlInfo.XmlIP = WebserviceInfo.IP;
            XmlInfo.XmlStr = WebserviceInfo.XMLString;

            return RedirectToAction("WebServiceQuery", XmlInfo);
        }

        public ActionResult WebServiceQuery(XmlData XmlInfo)
        {
            ViewData["Msg"] = null;
            ViewBag.XMLDataTable = null;

            return View();
        }

        public ActionResult QueryByXML(XmlData XmlInfo)
        {
            ResponseInfo responseInfo = fn.QueryDataByXML(XmlInfo.XmlIP, XmlInfo.XmlStr);

            ViewData["Msg"] = responseInfo.ResponseMsg;

            if (responseInfo.ResponseMsg.Equals("Success"))
            {
                DataTable dt = responseInfo.ResponseData.Tables[0];
                ViewBag.XMLDataTable = dt;
            }

            return View("WebServiceQuery");
        }


        [System.Web.Http.HttpPost]
        public ActionResult QueryByExcel(HttpPostedFileBase excelFile , XmlData XmlInfo)
        {
            ResponseInfo responseInfo = new ResponseInfo();

            if (excelFile != null && excelFile.ContentLength > 0)
            {
                responseInfo = fn.QueryDataByExcel(excelFile, XmlInfo.XmlIP, XmlInfo.XmlStr);

                ViewData["Msg"] = responseInfo.ResponseMsg;

                if (responseInfo.ResponseMsg.Equals("Success"))
                {
                    DataTable dt = responseInfo.ResponseData.Tables[0];
                    ViewBag.XMLDataTable = dt;
                }
            }

            return View("WebServiceQuery");
        }

        public ActionResult Login()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Login(string Id , string Password)
        {
            Account account = new Account();

            if(ModelState.IsValid)
            {
                if (account.CheckAccount(Id, Password))
                {
                    ViewBag.Message = "成功登入";

                    var ticket = new FormsAuthenticationTicket(
                        version: 1,
                        name: Id, //可以放使用者Id
                        issueDate: DateTime.UtcNow,//現在UTC時間
                        expiration: DateTime.UtcNow.AddMinutes(5),//Cookie有效時間=現在時間往後+5分鐘
                        isPersistent: true,// 是否要記住我 true or false
                        userData: Id, //可以放使用者角色名稱
                        cookiePath: FormsAuthentication.FormsCookiePath);

                    var encryptedTicket = FormsAuthentication.Encrypt(ticket); //把驗證的表單加密
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    Response.Cookies.Add(cookie);
                    return RedirectToAction("AdminIndex", "Admin");
                }
            }

            ViewBag.Message = "帳號密碼錯誤";
            account.Id = "";
            account.Password = "";
            return View(account);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}