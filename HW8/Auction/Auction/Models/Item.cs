using Auction.Controllers;

namespace Auction.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Items")]
    public partial class Item
    {

        public Item()
        {
            Bids = new HashSet<Bid>();
        }

        [Display(Name = "Item ID")]
        public int ItemID { get; set; }

        [Required]
        [StringLength(128), Display(Name = "Item Name")]
        public string Itemname { get; set; }

        [Required]
        [Display(Name = "Item Description")]
        public string Itemdesc { get; set; }

        [Display(Name = "Seller")]
        public int SellerID { get; set; }

        public virtual ICollection<Bid> Bids { get; set; }

        public virtual Seller Seller { get; set; }
    }
}
