using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("Images")]
    public class Images
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImageId { get; set; }
        public int? EventId { get; set; }
        public int? CategoryId { get; set; }
        public string ImageUrl { get; set; }
        public string ImageTitle { get; set; }
        public string ImageDetails { get; set; }
        public string PC { get; set; }
        public int? ImageLike { get; set; }
        public string ImageTag { get; set; }
        public DateTime? UploadDate { get; set; }
        public int? UploadedBy { get; set; }
        public int? IsApproved { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? ApproveDate { get; set; }
        public int? NoOfDownload { get; set; }

    }


    public class Images_VM
    {
        public int ImageId { get; set; }
        public int? EventId { get; set; }
        public int? CategoryId { get; set; }
        public string ImageUrl { get; set; }
        public string ImageTitle { get; set; }
        public string ImageDetails { get; set; }
        public string PC { get; set; }
        public int? ImageLike { get; set; }
        public string ImageTag { get; set; }
        public string UploadedBy { get; set; }
        public DateTime? UploadDate { get; set; }
        public int? IsApproved { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? ApproveDate { get; set; }

    }
}
