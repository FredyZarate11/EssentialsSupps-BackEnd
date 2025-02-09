using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using EssentialsSupps_Backend.Infrastructure.Data;

namespace EssentialsSupps_Backend.UI
{
    [ApiController]
    [Route("[controller]")]
    public class PageController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public PageController(IConfiguration configuration, ApplicationDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpGet]
        [Route("TestDataBase")]
        public async Task<IActionResult> TestDataBase()
        {
            try
            {
                bool isConnected = await _context.Database.CanConnectAsync(); // Await the async method
                var cadena = _configuration.GetConnectionString("DefaultConnection");

                return Ok(new { isConnected, cadena });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
