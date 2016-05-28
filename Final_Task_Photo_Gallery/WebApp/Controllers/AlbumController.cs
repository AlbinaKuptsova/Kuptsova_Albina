using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using System.Web.Mvc;
using WebApp.DAL;
using WebApp.Helpers;

namespace WebApp.Controllers
{
    [Authorize]
    public class AlbumController : Controller
    {
        private FilesHelper filesHelper;
        private DataAccessLayer db;

        string _serverMapPath = "~/Files/somefiles/";
        string StorageRoot
        {
            get { return Path.Combine(HostingEnvironment.MapPath(_serverMapPath)); }
        }
        string _urlBase = "/Files/somefiles/";
        string _deleteUrl = "/Album/DeleteFile/?file=";

        public AlbumController()
        {
            filesHelper = new FilesHelper(_deleteUrl, StorageRoot, _urlBase);
            db = new DataAccessLayer();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Upload()
        {
            var resultList = filesHelper.UploadAll(HttpContext);

            foreach (var imageInfo in resultList)
            {
                var newPhoto = new Photo
                {
                    Owner = User.Identity.Name,
                    UploadDate = DateTime.Now,
                    FileName = imageInfo.name
                };
                db.AddNewPhoto(newPhoto);
            }

            JsonFiles files = new JsonFiles(resultList);
            bool isEmpty = !resultList.Any();
            if (isEmpty)
            {
                return Json("Error");
            }
            return Json(files);
        }

        public JsonResult GetFileList()
        {
            var list = filesHelper.GetFileList();
            var photos = db.GetAllPhotos(User.Identity.Name);

            //var result = list.Where(imageInfo => photos.Any(photo => photo.FileName == imageInfo.name)).ToList();

            var result = new List<ImageInfo>();
            foreach (var fileInfo in list)
            {
                var photo = photos.SingleOrDefault(p => p.FileName == fileInfo.name);
                if (photo != null)
                {
                    fileInfo.author = photo.Owner;
                    fileInfo.likes = photo.Likes;
                    fileInfo.id = photo.Id;
                    result.Add(fileInfo);
                }
            }

            var data = new JsonFiles(result);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult DeleteFile(string file)
        {
            db.DeletePhoto(file, User.Identity.Name);
            filesHelper.DeleteFile(file);
            return Json("OK", JsonRequestBehavior.AllowGet);
        }
    }
}