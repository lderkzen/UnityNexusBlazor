namespace UnityNexus.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "client-api")]
    [ApiController]
    public class GroupController
    {
        public GroupController()
        {

        }

        [HttpGet]
        [ProducesResponseType(typeof(ListGroupsResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListGroupsAsync([FromQuery] ListGroupsRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
