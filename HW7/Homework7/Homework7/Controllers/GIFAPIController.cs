using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homework7.Models;
using Homework7.DAL;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace Homework7.Controllers
{
    public class GIFAPIController : Controller
    {
        // GET: GIFAPI
        RequestContext requestContext = new RequestContext();

        public JsonResult Sentence(string gifInput)
        {
            string gifKey = System.Configuration.ConfigurationManager.AppSettings["GKey"];

            string gifRequest = "https://api.giphy.com/v1/stickers/translate?api_key=" + gifKey + "&s=" + gifInput;

            Debug.WriteLine(gifRequest);
            var req = WebRequest.Create(gifRequest);
            req.ContentType = "aaplication/json; charset=utf-8";
            var res = (HttpWebResponse)req.GetResponse();

            string content;

            using (var stream = new StreamReader(res.GetResponseStream()))
            {
                content = stream.ReadToEnd();
                stream.Close();
            }

            
            string data = JObject.Parse(content)["data"].ToString();
            string url = JObject.Parse(data)["embed_url"].ToString();

            var gifSticker = new { embed_url = url };
            

            var ip = Request.UserHostAddress;
            var browser = Request.Browser.Type;

            var model = new Models.Request
            {
                IPAddress = ip,
                Browser = browser,
                DateRequested = DateTime.Now,
                RequestType = gifInput
            };

            requestContext.Requests.Add(model);
            requestContext.SaveChanges();

            return Json(gifSticker, JsonRequestBehavior.AllowGet);
        }
    }
}