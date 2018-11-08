using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldWideImporters.Models.ViewModels
{
    /// <summary>
    /// Item info that will added up into PersonSearch
    /// </summary>
    public class ItemSearchVM

    {
        public int StockItemID { get; set; }
        public string ItemDescription { get; set; }
        public decimal LineProfit { get; set; }
        public string SalesPerson { get; set; }


    }
}