using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigRoom.Service.Common.Mappings
{
    public  interface IMapFrom
    {
        void Mapping(Profile profile);
    }
}
