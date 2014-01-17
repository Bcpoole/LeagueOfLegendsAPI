﻿using System.Collections.Generic;
using System.Threading.Tasks;
using PortableLeagueAPI.Models;
using PortableLeagueAPI.Models.Constants;
using PortableLeagueAPI.Models.Enums;
using PortableLeagueAPI.Models.Team;

namespace PortableLeagueAPI.Services
{
    public class TeamService : BaseService
    {
        private TeamService()
        {
            CompatibleVersions = new[]
            {
                VersionEnum.V2Rev1,
                VersionEnum.V2Rev2
            };
        }

        private static TeamService _instance;

        internal static TeamService Instance
        {
            get { return _instance ?? (_instance = new TeamService()); }
        }

        public async Task<IEnumerable<Team>> GetTeamsBySummonerId(
            long summonerId,
            RegionEnum? region = null,
            VersionEnum? version = null)
        {
            var versionValue = GetVersion(version);

            var url = string.Format("{0}{1}/{2}/team/by-summoner/{3}",
                versionValue == VersionEnum.V2Rev1 ? string.Empty : "lol/",
                GetRegionAsString(region), 
                VersionConsts.Versions[versionValue],
                summonerId);

            return await GetResponse<List<Team>>(url);
        }
    }
}