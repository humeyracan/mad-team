using AutoMapper;
using BusinessLayer.Dtos;
using DataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapping
{
    public static class MappingFactory
    {
        public static MapperConfiguration config;
        public static IMapper mapper;
        public static void CreateMappingFactory()
        {
            config= new MapperConfiguration(config =>
            {
                config.CreateTwoWayMap<Attachment, AttachmentDto>();
                config.CreateTwoWayMap<Label, LabelDto>();
                config.CreateTwoWayMap<User, UserDto>();
                config.CreateTwoWayMap<Post, PostDto>();
                config.CreateTwoWayMap<Vote, VoteDto>();
            });
            mapper = config.CreateMapper();
        }
        public static void CreateTwoWayMap<T, Y>(this IMapperConfigurationExpression config,
       Action<IMappingExpression<T, Y>> firstExpression = null,
       Action<IMappingExpression<Y, T>> secondExpression = null)
        {
            var mapT = config.CreateMap<T, Y>();
            var mapY = config.CreateMap<Y, T>();

            firstExpression?.Invoke(mapT);
            secondExpression?.Invoke(mapY);
        }
        public static IMapper GetMapper()
        {
            return mapper;
        }
        public static List<TDestination> MapList<TSource, TDestination>(List<TSource> source)
        {
            return mapper.Map<List<TDestination>>(source);
        }
    }
}
