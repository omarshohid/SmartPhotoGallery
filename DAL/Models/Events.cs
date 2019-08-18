using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("Events")]
    public class Events
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime? EventDate { get; set; }
        public int? EventType { get; set; }
        public string EventLocation { get; set; }
        public int? UploaderId { get; set; }
        public string GalleryPath { get; set; }
    }

}
