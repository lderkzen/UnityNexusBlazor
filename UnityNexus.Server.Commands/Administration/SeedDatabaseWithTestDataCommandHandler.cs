using UnityNexus.Server.Shared.Stores;

namespace UnityNexus.Server.Commands.Administration
{
    public record SeedDatabaseWithTestDataCommand(UserId StartedByUserId) : IRequest<CommandResponse<Unit>>;

    public class SeedDatabaseWithTestDataCommandHandler : IRequestHandler<SeedDatabaseWithTestDataCommand, CommandResponse<Unit>>
    {
        private readonly IRemoteUserStore _remoteUserStore;

        public SeedDatabaseWithTestDataCommandHandler(
            IRemoteUserStore remoteUserStore
        )
        {
            _remoteUserStore = remoteUserStore;
        }

        public async ValueTask<CommandResponse<Unit>> Handle(SeedDatabaseWithTestDataCommand request, CancellationToken cancellationToken)
        {
            Randomizer.Seed = new Random(8675309);

            List<UserId>? userIds = await _remoteUserStore.GetAllUserIdsAsync();
            if (userIds is null)
            {
                // _logger.LogError("Failed to fetch all user ids from Keycloak");
                return CommandResponse<Unit>.Fail();
            }

            throw new NotImplementedException();
        }
    }
}
