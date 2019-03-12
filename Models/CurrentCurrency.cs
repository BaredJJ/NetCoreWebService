using System;
using System.Collections.Generic;

namespace WebService.Models
{
    public class CurrentCurrency
    {
        public CurrentCurrency() => Currencies = new List<Currency>();

        public int Id { get; set; }
        public DateTime Date{get;set;}
        public virtual List<Currency> Currencies{get;set;}
    }
}
