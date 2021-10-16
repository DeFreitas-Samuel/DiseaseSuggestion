using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalXamarin.Models
{
    public class Symptom
    {
        [JsonProperty("ID")]
        public int Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }
    }
}
