using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public enum DiscountType : byte
    {
        GiftCard = 1,
        SumSale = 2,
        ProcentSale = 3,
        VipCard = 4
    }
}