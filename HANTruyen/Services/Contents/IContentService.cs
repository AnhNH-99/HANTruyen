using HANTruyen.ViewModels.Contents;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HANTruyen.Services.Contents
{
    public interface IContentService
    {
        public Task<List<ContentViewModel>> GetListContentAsync();
        public Task CreateContentAsync(ContentCreateViewModel content);
        public string ConvertImageToBase64(IFormFile path);
    }
}
