using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HANTruyen.Models.Entities
{
    public class Chapter
    {
        public int Id { get; set; }
        public int StroyId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int Views { get; set; }
        public int Likes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public Boolean DeletedFlag { get; set; }
        public Story Story { get; set; }
        public List<Content> Contents { get; set; }
    }
}
