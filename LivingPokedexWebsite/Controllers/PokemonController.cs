using LivingPokedexWebsite.Data;
using LivingPokedexWebsite.Models;
using LivingPokedexWebsite.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace LivingPokedexWebsite.Controllers
{
    [Authorize]
    public class PokemonController : Controller
    {
        private readonly PokeDexDbContext pokeDexDbContext;

        public PokemonController(PokeDexDbContext pokeDexDbContext)
        {
            this.pokeDexDbContext = pokeDexDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var pokemon = await pokeDexDbContext.Pokemon.ToListAsync();
            return View(pokemon);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPokemonViewModel addPokemonRequest)
        {
            var pokemon = new Pokemon()
            {
                Id = Guid.NewGuid(),
                PokeDexNum = addPokemonRequest.PokeDexNum,
                PokemonName = addPokemonRequest.PokemonName,
                FormName = addPokemonRequest.FormName
            };

            await pokeDexDbContext.Pokemon.AddAsync(pokemon);
            await pokeDexDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid Id)
        {
            var pokemon = await pokeDexDbContext.Pokemon.FirstOrDefaultAsync(x => x.Id == Id);

            if (pokemon != null)
            {
                var viewModel = new UpdatePokemonViewModel()
                {
                    Id = pokemon.Id,
                    PokeDexNum = pokemon.PokeDexNum,
                    PokemonName = pokemon.PokemonName,
                    FormName = pokemon.FormName
                };

                return await Task.Run(() => View("View", viewModel));
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdatePokemonViewModel model)
        {
            var pokemon = await pokeDexDbContext.Pokemon.FindAsync(model.Id);

            if (pokemon != null)
            {
                pokemon.PokemonName = model.PokemonName;
                pokemon.FormName = model.FormName;
                pokemon.PokeDexNum = model.PokeDexNum;

                await pokeDexDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            // Need to add Error page if pokemon not found here
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdatePokemonViewModel model)
        {
            var pokemon = await pokeDexDbContext.Pokemon.FindAsync(model.Id);

            if (pokemon != null)
            {
                pokeDexDbContext.Pokemon.Remove(pokemon);
                await pokeDexDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

    }
}
