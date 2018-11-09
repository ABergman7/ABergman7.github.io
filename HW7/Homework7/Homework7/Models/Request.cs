namespace Homework7.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Request
    {
        [Key]
        public int ID { get; set; }

        public DateTime DateRequested { get; set; }

        [Column("REQUEST")]
        [Required]
        [StringLength(40)]
        public string RequestType { get; set; }

        [Required]
        [StringLength(40)]
        public string IPAddress { get; set; }

        [Required]
        [StringLength(40)]
        public string Browser { get; set; }
    }
}
