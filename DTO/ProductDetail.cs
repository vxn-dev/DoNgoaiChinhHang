using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductDetail
    {
        [Key]
        public Guid ProductDetailID { get; set; }
        public Guid ProductID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int SortOrder { get; set; }
    }
}
