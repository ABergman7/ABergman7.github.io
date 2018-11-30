namespace Art.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Artist
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Artist()
        {
            ArtWorks = new HashSet<ArtWork>();
        }


        [Display(Name = "Artist ID")]
        public int ARTISTID { get; set; }

        [Required]
        [StringLength(50), Display(Name = "Artist Name")]
        public string ARTISTNAME { get; set; }

        [Required]
        [StringLength(64), Display(Name = "Date of Birth")]
        public string ARTISTDOB { get; set; }

        [Required]
        [StringLength(50), Display(Name = "Origin City")]
        public string BIRTHCITY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArtWork> ArtWorks { get; set; }
    }
}
