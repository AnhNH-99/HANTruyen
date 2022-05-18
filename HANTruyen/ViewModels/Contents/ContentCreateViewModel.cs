using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HANTruyen.ViewModels.Contents
{
    public class ContentCreateViewModel
    {
        public int ChapterId { get; set; }
        public string Name { get; set; }
        public IFormFile FileUpload { get; set; }
    }
}
