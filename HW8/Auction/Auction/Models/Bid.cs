namespace Auction.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("Bids")]
    public partial class Bid
    {


        public int BidID { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Item")]
        public int ItemID { get; set; }

        [Display(Name = "Buyer")]
        public int BuyerID { get; set; }

        [Display(Name = "Time of Bid")]
        public DateTime Timestamp { get; set; } = DateTime.Now;

        public virtual Buyer Buyer { get; set; }

        public virtual Item Item { get; set; }
    }
}
