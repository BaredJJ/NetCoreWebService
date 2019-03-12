using System.Linq;

namespace WebService.Models
{
    public interface ICurrencyRepository
    {
        IQueryable<CurrentCurrency> CurrentCurrency { get; }

        void Add(CurrentCurrency currency);
    }
}
