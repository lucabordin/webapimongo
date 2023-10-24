using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mongo.Entities;
using Mongo.Services;

namespace Mongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MongoProdottiController : ControllerBase
    {
        IProdottiService _serviceProdotti;

        public MongoProdottiController(IProdottiService serviceProdotti)
        {
            _serviceProdotti = serviceProdotti;
        }

        // GET api/MongoProdottiController/61a6058e6c43f32854e51f51       
        [HttpGet("id")]
        public async Task<ActionResult<Prodotto>> Get(string id)
        {
            return await _serviceProdotti.GetProdotto(id);
        }

        [HttpGet]
        public async Task<ActionResult<List<Prodotto>>> Get()
        {
            return await _serviceProdotti.GetProdotti();
        }

        [HttpPost]
        public async void Post([FromBody] Prodotto p)
        {
            await _serviceProdotti.CreateProdotto(p);
        }

        [HttpPut("{id}")]
        public async void Put(int id, Prodotto p)
        {
            await _serviceProdotti.UpdateProdotto(p);
        }

        [HttpDelete("{id}")]
        public async void Delete(string id)
        {
            await _serviceProdotti.DeleteProdotto(id);
        }


    }
}
