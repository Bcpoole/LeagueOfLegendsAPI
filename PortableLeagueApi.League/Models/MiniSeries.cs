﻿using PortableLeagueApi.Core.Models;
using PortableLeagueApi.Core.Services;
using PortableLeagueApi.Interfaces.Core;
using PortableLeagueApi.Interfaces.League;
using PortableLeagueApi.League.Models.DTO;

namespace PortableLeagueApi.League.Models
{
    public class MiniSeries : LeagueApiModel, IMiniSeries
    {
        // TODO : Change progress type
        //public IList<int?> Progress { get; set; }
        public string Progress { get; set; }
        public int Target { get; set; }
        public long TimeLeftToPlayInMs { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }

        internal static void CreateMap(AutoMapperService autoMapperService, ILeagueAPI source)
        {
            autoMapperService.CreateMap<MiniSeriesDto, IMiniSeries>().As<MiniSeries>();
            autoMapperService.CreateMap<MiniSeriesDto, MiniSeries>()
                .ForMember(x => x.TimeLeftToPlayInMs, x => x.MapFrom(z => z.TimeLeftToPlayMillis))
                .BeforeMap((s, d) =>
                           {
                               d.Source = source;
                           });
        }
    }
}