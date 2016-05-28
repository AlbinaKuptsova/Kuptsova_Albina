using System.IO;
using System.Linq;
using System.Web.Hosting;
using System.Web.Mvc;
using WebApp.DAL;
using WebApp.Helpers;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private FilesHelper filesHelper;
        private DataAccessLayer db;

        string serverMapPath = "~/Files/somefiles/";
        string urlBase = "/Files/somefiles/";
        string deleteURL = "/Album/DeleteFile/?file=";

        string StorageRoot
        {
            get { return Path.Combine(HostingEnvironment.MapPath(serverMapPath)); }
        }

        public HomeController()
        {
            filesHelper = new FilesHelper(deleteURL, StorageRoot, urlBase);
            db = new DataAccessLayer();
        }

        public ActionResult Index()
        {
            var fileList = filesHelper.GetFileList();
            var photos = db.GetAllPhotos();

            foreach (var imageInfo in fileList)
            {
                var photoInfo = photos.SingleOrDefault(photo => photo.FileName == imageInfo.name);
                if (photoInfo != null)
                {
                    imageInfo.id = photoInfo.Id;
                    imageInfo.likes = photoInfo.Likes;
                    imageInfo.author = photoInfo.Owner;
                }
            }

            var model = new FilesViewModel
            {
                Files = fileList.ToArray()
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Like(int fileId)
        {
            var result = db.AddLike(fileId, User.Identity.Name);
            return Json(result);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}