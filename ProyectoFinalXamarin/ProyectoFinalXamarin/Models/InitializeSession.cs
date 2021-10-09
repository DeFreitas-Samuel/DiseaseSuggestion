using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ProyectoFinalXamarin.Models
{
    public class InitializeSession
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("SessionID")]
        public string SessionID { get; set; }
    }
}
