using AutoMapper;

namespace DemoAutoMapper.Data
{
    // This class is responsible for mapping between the Invoice and InvoiceDto classes using AutoMapper.
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            CreateMap<Invoice, InvoiceDto>();
        }

    }
}