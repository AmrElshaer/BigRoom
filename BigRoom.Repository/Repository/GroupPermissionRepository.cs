using BigRoom.Model.Entities;
using BigRoom.Repository.Contexts;
using BigRoom.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigRoom.Repository.Repository
{
    public class GroupPermissionRepository:RepositoryAsync<GroupPermission>,IGroupPermissionRepository
    {
        public GroupPermissionRepository(BigRoomDbContext context):base(context)
        {

        }
    }
}
