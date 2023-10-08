using System.Text.Json.Serialization;

namespace MoviesTheaterApplication.Dtos.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Category
    {
        ACTION,
        COMEDY,
        DRAMA,
        FANTASY,
        HORROR,
        ROMANCE,
        THRILLER
    }
}
