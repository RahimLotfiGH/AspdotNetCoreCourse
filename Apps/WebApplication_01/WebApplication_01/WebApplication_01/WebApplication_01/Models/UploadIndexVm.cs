using System.IO;

namespace WebApplication_01.Models
{
    public class UploadIndexVm : BaseVm
    {
        public UploadVm UploadVm { get; set; }

        public FileInfo[] FilesInfo { get; set; }

    }
}
