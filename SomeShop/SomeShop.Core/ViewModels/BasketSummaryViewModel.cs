﻿namespace SomeShop.Core.ViewModels
{
    public class BasketSummaryViewModel
    {
        public int BasketCount { get; set; }
        public decimal BasketTotal { get; set; }

        public BasketSummaryViewModel()
        {

        }
        public BasketSummaryViewModel(int BasketCount, decimal BasketTotal)
        {
            this.BasketCount = BasketCount;
            this.BasketTotal = BasketTotal;
        }

    }
}
