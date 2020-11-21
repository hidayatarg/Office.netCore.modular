using System;
using AutoMapper;
using Office.API.DTOs;
using Office.Core.Models;

namespace Office.API.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();

        }
    }
}
