using RDITechChallenge.Domain.Entities;
using System.Threading.Tasks;

namespace RDITechChallenge.Application.Tests.Fixtures
{
    public static class CustomerFixtures
    {
        public static Task<Customer> GetTestTaskCustomer() =>
            Task.FromResult(new Customer
            {
                CustomerId = 1
            });
    }
}
