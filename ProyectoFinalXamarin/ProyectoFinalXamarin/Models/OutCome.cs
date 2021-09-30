using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ProyectoFinalXamarin.Models
{
   public class OutComeResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("data")]
        public List<string> Data { get; set; }
    }
}
