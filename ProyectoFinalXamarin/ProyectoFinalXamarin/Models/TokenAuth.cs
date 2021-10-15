using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ProyectoFinalXamarin.Models
{
    public class TokenAuth
    {
        [JsonPropertyName("Token")]
        public string Token { get; set; }
        [JsonPropertyName("ValidThrough")]
        public int ValidThrough { get; set; }
    }
}
