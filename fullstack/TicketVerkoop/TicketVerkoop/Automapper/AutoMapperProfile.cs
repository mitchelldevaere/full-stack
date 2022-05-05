using AutoMapper;
using TicketModels.Entities;
using TicketVerkoop.ViewModels;

namespace TicketVerkoop.Automapper
{
    public class AutoMapperProfile : Profile

    {
        public AutoMapperProfile()
        {
            //CreateMap<TSource, TDestination>();
            /*  CreateMap<Bieren, BeerVM>();*/
            CreateMap<Match, MatchVM>().ForMember(dest => dest.ThuisploegNaam, opts => opts.MapFrom(src => src.Thuisploeg.PloegNaam))
                                       .ForMember(dest => dest.UitploegNaam, opts => opts.MapFrom(src => src.Uitploeg.PloegNaam))
                                       .ForMember(dest => dest.StadionNaam, opts => opts.MapFrom(src => src.Stadion.StadionNaam));
                                       


        }
    }
}
