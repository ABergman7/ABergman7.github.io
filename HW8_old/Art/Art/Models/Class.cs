namespace Art.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Class
    {
        public int CLASSID { get; set; }

        public int ARTWORKID { get; set; }

        public int GENREID { get; set; }

        public virtual ArtWork ArtWork { get; set; }

        public virtual Genre Genre { get; set; }
    }
}
