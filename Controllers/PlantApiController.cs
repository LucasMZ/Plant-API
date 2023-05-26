
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PlantApi.Data;

namespace PlantApi.Controllers
{
    [ApiController]
    [Route("[controller]")]


    public class PlantApiController : ControllerBase
    {
        private PlantContext _context;
        private static List<PlantInfo> filmes = new List<PlantInfo>();
        private static int id = 0;
        public PlantApiController(PlantContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionarPlanta([FromBody] PlantInfo planta)
        {
            _context.Plant.Add(planta);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RecuperaPlantaPorId), new { id = planta.id }, planta);
        }
        [HttpGet("{id}")]
        public IActionResult RecuperaPlantaPorId(int id)
        {
            var planta = _context.Plant
                .FirstOrDefault(planta => planta.id == id);
            if (planta == null) return NotFound();
            return Ok(planta);
        }
        
       

    }
};
