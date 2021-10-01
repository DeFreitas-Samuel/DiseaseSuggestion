
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json.Serialization;

namespace ProyectoFinalXamarin.Models
{
   public class Disease
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("data")]
        public ObservableCollection<string> Data { get; set; }
    }
}
