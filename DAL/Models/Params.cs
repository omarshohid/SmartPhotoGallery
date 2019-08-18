using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ImageLoadRequest
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public string Category { get; set; }
        public string FileName { get; set; }
        public string TagName { get; set; }
        public string EventName { get; set; }
    }
}
