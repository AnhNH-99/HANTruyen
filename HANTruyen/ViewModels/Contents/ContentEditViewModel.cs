using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HANTruyen.ViewModels.Contents
{
    public class ContentEditViewModel
    {
        public int Id { get; set; }
        public int ChapterId { get; set; }
        public string Name { get; set; }
        public string BaseImage { get; set; }
        public IFormFile FileUpload { get; set; }
        public string GetSrcImg()
        {
            return (this.BaseImage != null) ? "data:image/png;base64," + this.BaseImage : null;
        }
    }
}
