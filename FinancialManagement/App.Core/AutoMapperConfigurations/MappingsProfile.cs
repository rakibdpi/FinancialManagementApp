using App.Core.CommandsQueries.Group;
using App.Core.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.AutoMapperConfigurations
{
    public class MappingsProfile : Profile
    {
        public override string ProfileName => "MappingsProfile";

        public MappingsProfile()
        {
            CreateMap<Group, GroupQuery>();
        }

    }
}
