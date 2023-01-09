
namespace Test_project.Services.ActorService
{
    public class ActorsService : IActorsService
    {
        private static List<Actor> actors = new List<Actor>();
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public ActorsService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetActorDto>>> AddActor(AddActorDto newActor)
        {
            var serviceResponse = new ServiceResponse<List<GetActorDto>>();
            var dbActor = _mapper.Map<Actor>(newActor);
            dbActor.Id = await _context.Actors.MaxAsync(c => c.Id) + 1;
            actors.Add(dbActor);
            serviceResponse.Data = actors.Select(c => _mapper.Map<GetActorDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetActorDto>>> DeleteActor(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetActorDto>>();
            try
            {
                var dbActor = await _context.Actors.FirstOrDefaultAsync(c => c.Id == id);
                if (dbActor is null) 
                    throw new Exception($"Character with Id '{id}' not found");

                actors.Remove(dbActor);

                serviceResponse.Data = actors.Select(c => _mapper.Map<GetActorDto>(c)).ToList();
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;

            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetActorDto>>> GetAllActors()
        {
            var serviceResponse = new ServiceResponse<List<GetActorDto>>();
            var dbActor = await _context.Actors.ToListAsync();
            serviceResponse.Data = dbActor.Select(c => _mapper.Map<GetActorDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetActorDto>> GetActorById(int id)
        {
            var serviceResponse = new ServiceResponse<GetActorDto>();
            var dbActor = await _context.Actors.FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetActorDto>(dbActor);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetActorDto>> UpdateActor(UpdateActorDto updateActor)
        {
            var serviceResponse = new ServiceResponse<GetActorDto>();
            try
            {
                var dbActor = await _context.Actors.FirstOrDefaultAsync(c => c.Id == updateActor.Id);
                if(dbActor is null)
                    throw new Exception($"Actor with Id'{updateActor.Id}' not found");

                dbActor.Name = updateActor.Name;
                dbActor.Movies = updateActor.Movies;
                dbActor.Age = updateActor.Age;
                dbActor.Agent = updateActor.Agent;
                dbActor.Studio = updateActor.Studio;

                serviceResponse.Data = _mapper.Map<GetActorDto>(dbActor);
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;

            }
            return serviceResponse;
        }
    }
}