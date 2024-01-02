using System.Collections.Generic;
using System.IO;

namespace WebApplication_01.AppCode
{
    public class UploadFileHelper
    {
        public static Dictionary<string, string> AllowedFileTypes =>
                                            new Dictionary<string, string>
                                                {
                                                    {".txt", "text/plain"},
                                                    {".pdf", "application/pdf"},
                                                    {".doc", "application/vnd.ms-word"},
                                                    {".docx", "application/vnd.ms-word"},
                                                    {".xls", "application/vnd.ms-excel"},
                                                    {".png", "image/png"},
                                                    {".jpg", "image/jpeg"},
                                                    {".jpeg", "image/jpeg"},
                                                    {".gif", "image/gif"},
                                                    {".csv", "text/csv"}
                                           
                                                };


        public static string CreateImageFilePath(string fileName)
        {
            return Path.Combine(Directory.GetCurrentDirectory(),
                                "wwwRoot/UserFiles/Images/",
                                fileName);
        }

        public static string GetImagePath()
        {
            return Path.Combine(Directory.GetCurrentDirectory(),
                               "wwwRoot/UserFiles/Images/");
        }
    }
}
