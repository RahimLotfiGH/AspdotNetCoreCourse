using Microsoft.AspNetCore.Http;

namespace WebApplication_01.Models
{
    public class UploadVm : BaseVm
    {
        public IFormFile TheFile { get; set; }
    }
}
