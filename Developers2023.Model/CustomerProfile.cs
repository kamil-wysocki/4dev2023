using AutoMapper;

namespace Developers2023.Model
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, Customer>();
        }
    }
}
