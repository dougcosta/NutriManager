using AutoMapper;

namespace NutriManager.Services.Helpers
{
    public static class MapperHelper
    {
        public static TDestine Map<TSource, TDestine>(TSource item)
        {
            Mapper.CreateMap<TSource, TDestine>();
            return Mapper.Map<TSource, TDestine>(item);
        }
    }
}