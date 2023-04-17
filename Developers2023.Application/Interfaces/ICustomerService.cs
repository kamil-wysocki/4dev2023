using Developers2023.Model;

namespace Developers2023.Application.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll();

        Customer? GetById(int id);

        void Add(Customer customer);

        void Update(Customer customer);

        void Delete(int id);
    }
}
