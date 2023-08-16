using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPI_Lab.Models;

namespace RestAPI_Lab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TacoController : ControllerBase
    {
        private TacoBellDbContext dbContext = new TacoBellDbContext();

        [HttpGet]
        public List<Taco> GetAll()
        {
            return dbContext.Tacos.ToList();
        }


        //api/Customer/1
        [HttpGet("{Id}")]
        public Taco GetById(int Id)
        {
            return dbContext.Tacos.FirstOrDefault(t => t.Id == Id);

        }

        [HttpDelete("Delete/{Id}")]
        public Taco DeleteTaco(int Id)
        {
            Taco t = dbContext.Tacos.FirstOrDefault(t => t.Id == Id);
            dbContext.Tacos.Remove(t);
            dbContext.SaveChanges();

            return t;
        }

        [HttpPatch("{Id}")]
        public Taco UpdateCost(int Id, float cost)
        {
            Taco t = dbContext.Tacos.FirstOrDefault(t => t.Id == Id);
            t.Cost = cost;
            dbContext.Tacos.Update(t);
            dbContext.SaveChanges();

            return t;
        }
    }
}
