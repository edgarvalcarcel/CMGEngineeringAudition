﻿using AutoMapper;
using CMGEngineeringAudition.Application.DTOs.GetSystemParameter;
using CMGEngineeringAudition.Application.Features.Orders.Queries.GetSystemParameter;
using CMGEngineeringAudition.Application.Features.Queries.GetSystemParameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMGEngineeringAudition.Application.Mappings
{
    class SystemParameterProfile : Profile
    {
        public SystemParameterProfile()
        {
            CreateMap<SystemParameterContentResponse, DTOSystemParameter>();
            CreateMap<DTOSystemParameter, SystemParameterContentResponse>().ReverseMap();
        }



    }
}
