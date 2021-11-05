using AutoMapper;
using CMGEngineeringAudition.Application.DTOs.GetCodeTableContent;
using CMGEngineeringAudition.Application.DTOs.GetSystemParameter;
using CMGEngineeringAudition.Application.Features.Orders.Queries.GetCodeTableContentQuery;
using CMGEngineeringAudition.Application.Features.Orders.Queries.GetSystemParameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMGEngineeringAudition.Application.Mappings
{
    public class CodeTableItemProfile : Profile
    {
        public CodeTableItemProfile()
        {
            CreateMap<CodeTableItem, DTOCodeTableContent>();
            CreateMap<DTOCodeTableContent, CodeTableItem>().ReverseMap();

        }
    }
}
