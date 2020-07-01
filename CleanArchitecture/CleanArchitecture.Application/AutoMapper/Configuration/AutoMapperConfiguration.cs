using AutoMapper;
using CleanArchitecture.Application.AutoMapper.Profiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.AutoMapper.Configuration
{
    public class AutoMapperConfiguration 
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ViewModelToDomainProfile());
                cfg.AddProfile(new DomainToViewModelProfile());
            });
        }
    }
}
