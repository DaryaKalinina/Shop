using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class GiftCardExpirationException : Exception
    {
        public GiftCardExpirationException(DateTime startDate, DateTime endDate) : base($"Срок действия карты прошел, карта была действительна с {startDate} по {endDate}")
        {
        }
    }
}