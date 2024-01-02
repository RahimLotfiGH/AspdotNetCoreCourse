using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication_01.AppCode;
using WebApplication_01.Models;

namespace WebApplication_01.Controllers
{
    public class UploadController : BaseController
    {

        private string _errorMessage = string.Empty;

        public IActionResult Index()
        {
            var indexVm = CreateUploadIndexVm();

            return View(indexVm);
        }

        private UploadIndexVm CreateUploadIndexVm()
        {
            return new UploadIndexVm
            {
                UploadVm = new UploadVm(),
                FilesInfo = GetFilesInfo(),
            };
        }

        private static FileInfo[] GetFilesInfo()
        {
            var directoryInfo = new DirectoryInfo(UploadFileHelper.GetImagePath());

            return directoryInfo.GetFiles();
        }

        public IActionResult UploadFile(UploadVm uploadVm)
        {

            ValidationFile(uploadVm.TheFile);

            if (!HasError)
                DoUpload(uploadVm.TheFile);

            if (HasError)
                ShowMessage(_errorMessage);

            return RedirectToAction("Index");
        }

        private void ValidationFile(IFormFile formFile)
        {
            if (!UploadFileHelper.AllowedFileTypes.ContainsValue(formFile.ContentType))
                _errorMessage = "نوع فایل مجاز نمی باشد";

            if (formFile.Length / 1024 / 1024 > 50)
                _errorMessage = "حجم فایل مجاز نمی باشد";

        }

        private void DoUpload(IFormFile formFile)
        {
            var filePath = UploadFileHelper.CreateImageFilePath(formFile.FileName);

            var fileStream = new FileStream(filePath, FileMode.Create);

            formFile.CopyTo(fileStream);

            ShowMessage("فایل به درستی آپلود شد");
        }


        private bool HasError => !string.IsNullOrWhiteSpace(_errorMessage);

    }
}
