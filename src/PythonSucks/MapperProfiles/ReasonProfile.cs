using AutoMapper;
using PythonSucks.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PythonSucks.MapperProfiles
{
    public class ReasonProfile : Profile
    {
        public ReasonProfile()
        {
            CreateMap<Reason, Model.Reason>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
                .ForMember(m=>m.Hater,
                            opt => opt.Ignore())
                .ForMember(m=>m.Votes, opt=>opt.Ignore());
            CreateMap<Model.Reason, Reason>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
                .ForMember(m => m.Hater,
                            opt => opt.MapFrom(src => src.Hater))
                .ForMember(m=>m.Votes, opt=>opt.MapFrom(src=> src.Votes.Count));
        }

    }
}
