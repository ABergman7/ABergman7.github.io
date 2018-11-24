namespace Auction.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Item
    {
        public int ITEMID { get; set; }

        [Required]
        [StringLength(128)]
        public string ITEMNAME { get; set; }

        [Required]
        public string ITEMDESC { get; set; }

        public int SELLERID { get; set; }

        public virtual Bid Bid { get; set; }

        public virtual Seller Seller { get; set; }
    }
}
