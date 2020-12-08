using System.Web.Mvc;
using Task4.Models;
using System.IO;
using Newtonsoft.Json;

namespace Task4.Controllers
{
    public class BookController : Controller
    {
        BooksFactory bf = BookFactorySingleton.GetInstance().BooksFactory;
        // GET: Book

        //public ActionResult Index() => View(bf.GetBooks());

        public ActionResult Index(string filter)
        {
            ActionResult result = null;
            switch (filter)
            {
                case  "programming":
                    result = View(bf.GetProgramming());
                    break;
                case "lessthan20":
                    result = View(bf.GetLessThanTwenty());
                    break;
                default:
                    result = View(bf.GetBooks());
                    break;
            }

            return result;


        }

        public ActionResult Authors() => View(bf.GetAuthors());

        [HttpPost]
        public JsonResult Take() => Json(bf.GetBookById(GetIdFromJsonRequest(Request.InputStream)), JsonRequestBehavior.AllowGet);

        [HttpPost]
        public JsonResult Return() => Json(new { isReturned = true, returned = bf.GetBookById(GetIdFromJsonRequest(Request.InputStream)).Title });

        private int GetIdFromJsonRequest(Stream stream)
        {
            JsonRequest json = null;
            using (var sr = new StreamReader(stream))
            {
                string rawJson = sr.ReadLine();
                System.Diagnostics.Debug.WriteLine(rawJson);
                json = JsonConvert.DeserializeObject<JsonRequest>(rawJson);
            }

            return json.Id;
        }

        private class JsonRequest
        {
            public int Id { get; set; }
        }
    }
}