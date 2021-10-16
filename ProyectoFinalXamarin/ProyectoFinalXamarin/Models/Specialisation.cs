using System.Text.Json.Serialization;

namespace ProyectoFinalXamarin.Models
{
    public class Specialisation
    {
        [JsonPropertyName("ID")]
        public int ID { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("SpecialistID")]
        public int SpecialistID { get; set; }
    }
}