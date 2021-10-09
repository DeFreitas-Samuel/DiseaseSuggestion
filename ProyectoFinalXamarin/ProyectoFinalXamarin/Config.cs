using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalXamarin
{
    public class Config
    {
        public string SessionId { get; set; } = "KEY HERE";
        public string GetSuggestionsURL { get; } = "https://api.endlessmedical.com/v1/dx/GetSuggestedSpecializations?SessionID={SessionId}&NumberOfResults=10";
        public string GetOutcomesURL { get; } = "https://api.endlessmedical.com/v1/dx/GetOutcomes";
        public string GetDiseasesURL { get; } = "https://api.endlessmedical.com/";
        public string GetSessionURL { get; } = "https://api.endlessmedical.com/v1/dx/InitSession";
        public string TermsAndConditionsURL1 = "https://api.endlessmedical.com/v1/dx/AcceptTermsOfUse?SessionID=";
        public string TermsAndConditionsURL2 = "&passphrase=I have read, understood and I accept and agree to comply with the Terms of Use of EndlessMedicalAPI and Endless Medical services. The Terms of Use are available on endlessmedical.com";


    }
}
