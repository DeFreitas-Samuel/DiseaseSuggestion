using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ProyectoFinalXamarin.Models
{
    public class Diagnostic
    {
        [JsonPropertyName("Issue")]
        public DiagnoseIssue Issue { get; set; }

        [JsonPropertyName("Specialisation")]
        public List<Specialisation> Specialisation { get; set; }
    }
}
