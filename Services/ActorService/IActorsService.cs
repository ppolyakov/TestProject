
namespace Test_project.Services.ActorService
{
    public interface IActorsService
    {
        Task<ServiceResponse<List<GetActorDto>>> GetAllActors();
        Task<ServiceResponse<GetActorDto>> GetActorById(int id);
        Task<ServiceResponse<List<GetActorDto>>> AddActor(AddActorDto newActor);
        Task<ServiceResponse<GetActorDto>> UpdateActor(UpdateActorDto updateActor);
        Task<ServiceResponse<List<GetActorDto>>> DeleteActor(int id);
    }
}