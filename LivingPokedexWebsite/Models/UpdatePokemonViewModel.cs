namespace LivingPokedexWebsite.Models
{
    public class UpdatePokemonViewModel
    {
        public Guid Id { get; set; }
        public int PokeDexNum { get; set; }
        public string PokemonName { get; set; }

        public string? FormName { get; set; }
    }
}
