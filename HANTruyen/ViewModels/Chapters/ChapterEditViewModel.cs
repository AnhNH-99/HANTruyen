using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HANTruyen.ViewModels.Chapters
{
    public class ChapterEditViewModel
    {
        public int Id { get; set; }
        public int StroyId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }
}
