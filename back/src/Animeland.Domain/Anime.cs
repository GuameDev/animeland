namespace Animeland.Domain
{
    public class Anime
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
    }

}
