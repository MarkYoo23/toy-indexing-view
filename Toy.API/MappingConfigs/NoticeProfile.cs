using AutoMapper;
using Toy.API.Dtos.Notices;
using Toy.API.Helpers;
using Toy.Application.Services.Notices;
using Toy.Domain.Notices;

namespace Toy.API.MappingConfigs;

public class NoticeProfile : Profile
{
    public NoticeProfile()
    {
        CreateMap<NoticeReadQueryDto, NoticeQueryParameter>()
            .ForMember(
                dest => dest.Channels,
                opt => opt.MapFrom(src =>
                    src.Channels != null ? StringHelper.StringToArrayConverter(src.Channels) : Array.Empty<string>()));

        CreateMap<NoticeCreateDto, AddNoticeCommand>()
            .ForMember(
                dest => dest.Channels,
                opt => opt.MapFrom(src =>
                    src.Channels != null ? StringHelper.StringToArrayConverter(src.Channels) : Array.Empty<string>()));

        CreateMap<Notice, NoticeSummaryDto>()
            .ForMember(
                dest => dest.Channels,
                opt => opt.MapFrom(src => src.Channels.Select(channel => channel.Code)));
        
        CreateMap<Notice, NoticeDetailDto>()
            .ForMember(
                dest => dest.Channels,
                opt => opt.MapFrom(src => src.Channels.Select(channel => channel.Code)));
    }
}