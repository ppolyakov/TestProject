
namespace Test_project.Dtos.ActorActions
{
    public class UpdateActorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Leonardo DiCaprio";
        public int Movies { get; set; } = 36;
        public int Age { get; set; } = 48;
        public string Agent { get; set; } = "John Dash";
        public FilmStudio Studio { get; set; } = FilmStudio.UniversalPictures;
    }
}