using LivingPokedexWebsite.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace LivingPokedexWebsite.Models.Domain
{
    public class Pokemon
    {
        public Guid Id { get; set; }
        public int PokeDexNum { get; set; }
        public string PokemonName { get; set;}

        public string? FormName { get; set; }

    }
}
