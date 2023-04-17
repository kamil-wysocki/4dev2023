using AutoMapper;
using Bogus;
using Bogus.Extensions.Poland;
using Developers2023.Application.Interfaces;
using Developers2023.Model;

namespace Developers2023.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private List<Customer> _customers;
        private readonly IMapper _mapper;

        public CustomerService(IMapper mapper)
        {
            _customers = InitData();
            _mapper = mapper;
        }

        private List<Customer> InitData()
        {
            var customerFaker = new Faker<Customer>("pl")
                .UseSeed(Randomizer.Seed.Next())
                .StrictMode(true)
                .RuleFor(p => p.Id, p => p.IndexGlobal)
                .RuleFor(p => p.Email, p => p.Person.Email)
                .RuleFor(p => p.Phone, p => p.Person.Phone)
                .RuleFor(p => p.Address, p => p.Address.StreetAddress())
                .RuleFor(p => p.Name, p => p.Person.FullName)
                .RuleFor(p => p.PESEL, p => p.Person.Pesel());

            return customerFaker.Generate(20).ToList();
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customers;
        }

        public Customer? GetById(int id)
        {
            return _customers.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Customer customer)
        {
            _customers.Add(customer);
        }

        public void Delete(int id)
        {
            Customer? findCustomer = _customers.FirstOrDefault(p => p.Id == id);

            if(findCustomer != null)
            {
                _customers.Remove(findCustomer);
            }
        }

        public void Update(Customer customer)
        {
            Customer? findCustomer = _customers.Find(p => p.Id == customer.Id);

            if (findCustomer != null)
            {
                Delete(findCustomer.Id);
                findCustomer = _mapper.Map<Customer>(customer);
                Add(findCustomer);
            }
        }
    }
}
