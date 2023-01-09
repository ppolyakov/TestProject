
namespace Test_project
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Actor, GetActorDto>();
            CreateMap<Actor, AddActorDto>();
        }
    }
}