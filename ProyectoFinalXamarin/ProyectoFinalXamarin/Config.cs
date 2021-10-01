using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalXamarin
{
    public class Config
    {
        public string SessionId { get; } = "KEY HERE";
        public string GetSuggestionsURL { get; } = "https://api.endlessmedical.com/v1/dx/GetSuggestedSpecializations?SessionID={SessionId}&NumberOfResults=10";
        public string GetOutcomesURL { get; } = "https://api.endlessmedical.com/v1/dx/GetOutcomes";
        public string GetDiseasesURL { get; } = "https://api.endlessmedical.com/";

    }
}
