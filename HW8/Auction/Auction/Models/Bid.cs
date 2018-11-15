namespace Auction.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bid
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BIDID { get; set; }

        public decimal PRICE { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ITEMID { get; set; }

        public int BUYERID { get; set; }

        public DateTime TIMESTAMP { get; set; }

        public virtual Buyer Buyer { get; set; }

        public virtual Item Item { get; set; }
    }
}
