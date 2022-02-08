using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<ApplicationCore.Entitites.UserLogin, ApplicationCore.DTOs.UserResponse> ();
        }
    }
}
