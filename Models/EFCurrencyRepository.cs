using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebService.Models
{
    public class EFCurrencyRepository:ICurrencyRepository
    {
        private readonly ApplicationDbContext _context;

        public EFCurrencyRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IQueryable<CurrentCurrency> CurrentCurrency => _context.CurrentCurrency.Include(c => c.Currencies);

        public void Add(CurrentCurrency currency)
        {
            _context.Add(currency);
            _context.SaveChanges();
        }
    }
}
