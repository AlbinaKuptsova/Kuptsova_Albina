using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace WebApp.Helpers
{
    public class FilesHelper
    {
        string _deleteUrl;
        string _storageRoot;
        string _urlBase;

        public FilesHelper(string deleteUrl, string storageRoot, string urlBase)
        {
            _deleteUrl = deleteUrl;
            _storageRoot = storageRoot;
            _urlBase = urlBase;
        }

        public void DeleteFile(string file)
        {
            var fullPath = Path.Combine(_storageRoot, file);
            var partThumb1 = Path.Combine(_storageRoot, "thumbs");
            var partThumb2 = Path.Combine(partThumb1, file + ".80x80.jpg");

            if (File.Exists(fullPath))
            {
                //delete thumb 
                if (File.Exists(partThumb2))
                {
                    File.Delete(partThumb2);
                }
                File.Delete(fullPath);
            }
        }

        public List<ImageInfo> GetFileList()
        {
            var r = new List<ImageInfo>();

            var fullPath = Path.Combine(_storageRoot);
            if (Directory.Exists(fullPath))
            {
                var dir = new DirectoryInfo(fullPath);
                foreach (var file in dir.GetFiles())
                {
                    int sizeInt = unchecked((int)file.Length);
                    r.Add(GetImageInfo(file.Name, sizeInt, file.FullName));
                }
            }
            return r;
        }

        public List<ImageInfo> UploadAll(HttpContextBase contentBase)
        {
            List<ImageInfo> resultList = new List<ImageInfo>();
            var request = contentBase.Request;

            var pathOnServer = Path.Combine(_storageRoot);
            var thumbPath = Path.Combine(pathOnServer, "thumbs");

            Directory.CreateDirectory(pathOnServer);
            Directory.CreateDirectory(thumbPath);

            for (int i = 0; i < request.Files.Count; i++)
            {
                var file = request.Files[i];

                var filePath = Path.Combine(pathOnServer, Path.GetFileName(file.FileName));
                file.SaveAs(filePath);

                //Create thumb
                string[] imageArray = file.FileName.Split('.');
                if (imageArray.Length != 0)
                {
                    var extension = imageArray[imageArray.Length - 1];
                    if (extension == "jpg" || extension == "png") //Do not create thumb if file is not an image
                    {
                        var thumbFileName = file.FileName + ".80x80.jpg";
                        var thumbFilePath = Path.Combine(thumbPath, thumbFileName);
                        using (MemoryStream stream = new MemoryStream(File.ReadAllBytes(filePath)))
                        {
                            var thumbnail = new WebImage(stream).Resize(80, 80);
                            thumbnail.Save(thumbFilePath, "jpg");
                        }
                    }
                }
                resultList.Add(GetImageInfo(file.FileName, file.ContentLength, file.FileName));
            }
            return resultList;
        }

        private ImageInfo GetImageInfo(string fileName, int fileSize, string fileFullPath)
        {
            string getType = MimeMapping.GetMimeMapping(fileFullPath);
            var result = new ImageInfo
            {
                name = fileName,
                size = fileSize,
                type = getType,
                url = _urlBase + fileName,
                deleteUrl = _deleteUrl + fileName,
                thumbnailUrl = _urlBase + "/thumbs/" + fileName + ".80x80.jpg",
                deleteType = "GET"
            };
            return result;
        }
    }

    public class ImageInfo
    {
        public int id { get; set; }
        public string name { get; set; }
        public int size { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string deleteUrl { get; set; }
        public string thumbnailUrl { get; set; }
        public string deleteType { get; set; }
        public int likes { get; set; }
        public string author { get; set; }
    }

    public class JsonFiles
    {
        public ImageInfo[] files;
        public JsonFiles(List<ImageInfo> filesList)
        {
            files = new ImageInfo[filesList.Count];
            for (int i = 0; i < filesList.Count; i++)
            {
                files[i] = filesList.ElementAt(i);
            }
        }
    }
}

