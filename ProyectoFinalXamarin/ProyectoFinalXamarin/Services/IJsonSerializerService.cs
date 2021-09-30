using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalXamarin.Services
{
    interface IJsonSerializerService
    {
        string Serialize(object payload);
        T Deserialize<T>(string payload);
    }
}
