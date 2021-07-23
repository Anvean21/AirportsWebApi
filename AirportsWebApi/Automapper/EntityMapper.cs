using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportsWebApi.Automapper
{
    public class EntityMapper : IMapper
    {
        readonly AutoMapper.IMapper mapper;

        public EntityMapper(AutoMapper.IMapper mapper)
        {
            this.mapper = mapper;
        }

        public TDestination Map<TSource, TDestination>(TSource source)
            where TSource : class
            where TDestination : class
        {
            return this.mapper.Map<TDestination>(source);
        }

        public IEnumerable<TDestination> Map<TSourse, TDestination>(IEnumerable<TSourse> sources)
            where TSourse : class
            where TDestination : class
        {
            return this.mapper.Map<IEnumerable<TDestination>>(sources);

        }
    }
}
