
namespace Test_project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActorsController : ControllerBase
    {
        private readonly IActorsService _actorsService;

        public ActorsController(IActorsService _actorsService)
        {
            this._actorsService = _actorsService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetActorDto>>>> Get()
        {
            return Ok(await _actorsService.GetAllActors());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetActorDto>>>> GetSingle(int id)
        {
            return Ok(await _actorsService.GetActorById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetActorDto>>>> AddCharacter(AddActorDto newActor)
        {
            return Ok(await _actorsService.AddActor(newActor));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetActorDto>>>> UpdateCharacter(UpdateActorDto newActor)
        {
            var response = await _actorsService.UpdateActor(newActor);

            if(response.Data is null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetActorDto>>>> DeleteActor(int id)
        {
            var response = await _actorsService.DeleteActor(id);

            if(response.Data is null)
                return NotFound(response);

            return Ok(response);
        }
    }
}