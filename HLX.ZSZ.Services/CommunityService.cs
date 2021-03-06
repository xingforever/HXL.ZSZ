﻿using HLX.ZSZ.DTO;
using HLX.ZSZ.IServices;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.Service.Entities;

namespace ZSZ.Service
{
    public class CommunityService : ICommunityService
    {
        /*
        private CommunityDTO ToDTO(CommunityEntity en)
        {
            CommunityDTO dto = new CommunityDTO();
            dto.bui
        }*/

        public CommunityDTO[] GetByRegionId(long regionId)
        {
            using (ZSZDbContext ctx = new ZSZDbContext())
            {
                BaseService<CommunityEntity> bs
                    = new BaseService<CommunityEntity>(ctx);
                var cities = bs.GetAll().AsNoTracking()
                    .Where(c => c.RegionId == regionId);
                return cities.Select(c => new CommunityDTO
                {
                    BuiltYear = c.BuiltYear,
                    CreateDateTime = c.CreateDateTime,
                    Id = c.Id,
                    Location = c.Location,
                    Name = c.Name,
                    RegionId = c.RegionId,
                    Traffic = c.Traffic
                }).ToArray();
            }
        }
    }
}
