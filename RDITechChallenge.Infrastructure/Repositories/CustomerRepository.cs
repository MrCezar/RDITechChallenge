using RDITechChallenge.Domain.Entities;
using RDITechChallenge.Domain.Interfaces;
using RDITechChallenge.Infrastructure.Data;

namespace RDITechChallenge.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Customer?> GetCustomerById(int customerId)
        {
            return await _context.Customers.FindAsync(customerId);
        }
    }
}