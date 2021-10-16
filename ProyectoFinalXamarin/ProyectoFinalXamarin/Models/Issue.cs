using System.Text.Json.Serialization;

namespace ProyectoFinalXamarin.Models
{
    public class Issue
    {
        [JsonPropertyName("ID")]
        public int ID { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Accuracy")]
        public double Accuracy { get; set; }

        [JsonPropertyName("Icd")]
        public string Icd { get; set; }

        [JsonPropertyName("IcdName")]
        public string IcdName { get; set; }

        [JsonPropertyName("ProfName")]
        public string ProfName { get; set; }

        [JsonPropertyName("Ranking")]
        public int Ranking { get; set; }
    }
}