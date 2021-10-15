using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalXamarin
{
    public static class Config
    {
        public const string GetSuggestionsURL = "https://api.endlessmedical.com/v1/dx/GetSuggestedSpecializations?SessionID={SessionId}&NumberOfResults=10";
        public const string GetOutcomesURL = "https://api.endlessmedical.com/v1/dx/GetOutcomes";
        public const string GetDiseasesURL = "https://api.endlessmedical.com/";
        public const string LoginUrl = "https://sandbox-authservice.priaid.ch/login";
    }
}
