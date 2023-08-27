using LivingPokedexWebsite.Data;
using LivingPokedexWebsite.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivingPokedexWebsite.Models
{
    public class AddPokemonViewModel
    {
        public int PokeDexNum { get; set; }
        public string PokemonName { get; set; }
        public string FormName { get; set; }
    }
}
