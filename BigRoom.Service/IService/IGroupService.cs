﻿using BigRoom.Repository.Entities;
using BigRoom.Service.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BigRoom.Service.IService
{
    public interface IGroupService : IServiceAsync<Group, GroupDto>
    {
        Task<GroupDto> GroupDetailsByIdAsync(int id);
    }
}
