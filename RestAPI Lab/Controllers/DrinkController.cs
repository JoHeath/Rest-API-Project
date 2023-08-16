using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPI_Lab.Models;

namespace RestAPI_Lab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinkController : ControllerBase
    {
        private TacoBellDbContext dbContext = new TacoBellDbContext();
        [HttpGet]
        public List<Drink> GetAll()
        {
            return dbContext.Drinks.ToList();
        }


        //api/Customer/1
        [HttpGet("{Id}")]
        public Drink GetById(int Id)
        {
            return dbContext.Drinks.FirstOrDefault(d => d.Id == Id);

        }

        [HttpPost]
        public Drink AddDrink(string name, float cost, bool slushie)
        {
            Drink newDrink = new Drink();
            newDrink.Name = name;
            newDrink.Cost = cost;
            newDrink.Slushie = slushie;
            dbContext.Drinks.Add(newDrink);
            dbContext.SaveChanges();

            return newDrink;
        }
    }
}
