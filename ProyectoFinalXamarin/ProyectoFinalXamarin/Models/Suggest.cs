using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalXamarin.Models
{
    public class Suggest
    {
        public string Status { get; set; }
        public List<List<string>> SuggestedSpecializations { get; set; }
    }
}
