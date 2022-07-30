using RDITechChallenge.Domain.Entities;

namespace RDITechChallenge.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetCustomerById(int customerId);
    }
}
