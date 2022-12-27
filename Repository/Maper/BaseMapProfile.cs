using AutoMapper;

namespace Repository;

public class BaseMapProfile<TSource, TDestination> : Profile
{
    public BaseMapProfile() 
    {
        CreateMap<TSource, TDestination>();
        CreateMap<TDestination, TSource>();
    }
}
