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

            CreateMap<Vak, VakVM>();

            CreateMap<Reservering, ReserveringVM>().ForMember(dest => dest.Thuisploeg, opts => opts.MapFrom(src => src.Match.ThuisploegId))
                                                   .ForMember(dest => dest.Uitploeg, opts => opts.MapFrom(src => src.Match.UitploegId))
                                                   .ForMember(dest => dest.Stadion, opts => opts.MapFrom(src => src.Match.StadionId))
                                                   .ForMember(dest => dest.Vaknaam, opts => opts.MapFrom(src => src.Vak.VakNaam));


            CreateMap<ReserveringVM, Reservering>();

        }
    }
}
