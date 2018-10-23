using AutoMapper;
using PythonSucks.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PythonSucks.MapperProfiles
{
    public class HaterProfile : Profile
    {
        public HaterProfile()
        {
            CreateMap<Hater, Model.Hater>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            CreateMap<Model.Hater, Hater>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
        }
    }
}
