using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PostDetail
    {
        [Key]
        public Guid PostDetailID { get; set; }
        public Guid PostID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int SortOrder { get; set; }
    }
}
