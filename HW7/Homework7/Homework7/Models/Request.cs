using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Homework7.Models
{

    public partial class Request
    {
        [Column("ID")]
        [Key]
        public int ID { get; set; }
        
        [Column("DATEREQ")]
        public DateTime DateRequested { get; set; }

        [Column("REQUEST")]
        [Required]
        [StringLength(100)]
        public string RequestType { get; set; }

        [Column("IPADDRESS")]
        [Required]
        [StringLength(128)]
        public string IPAddress { get; set; }

        [Column("BROWSERAG")]
        [Required]
        [StringLength(128)]
        public string Browser { get; set; }
    }
}
