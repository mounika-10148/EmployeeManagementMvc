using AutoMapper;
using DemoAutoMapper.Data;
using Microsoft.AspNetCore.Mvc;

namespace DemoAutoMapper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        // This is a sample controller for demonstrating AutoMapper usage in an ASP.NET Core application.
        private readonly IMapper _mapper;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }
        // method to get the invoice details
        [HttpGet]
        public IActionResult GetInvoice()
        {
            Invoice invoiceFromDb = new Invoice()
            {
                Id = 1,
                Description = "Grocery",
                Amount = 300
            };
            // This is a sample invoice object that would typically be retrieved from a database.
            InvoiceDto invoiceDto = _mapper.Map<InvoiceDto>(invoiceFromDb);

            // This is where the mapping from the Invoice entity to the InvoiceDto occurs using AutoMapper and return the status code 200.
            return Ok(invoiceDto);

        }
    }
}