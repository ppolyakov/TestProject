using System.Text.Json.Serialization;

namespace Test_project.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FilmStudio
    {
        WarnerBros = 1,
        ColumbiaPictures = 2,
        UniversalPictures = 3
    }
}