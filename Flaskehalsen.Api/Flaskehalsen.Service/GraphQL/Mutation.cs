using Flaskehalsen.Service.Domain.Clubs;
using Flaskehalsen.Service.Domain.Persons;
using Flaskehalsen.Service.Models;
using MediatR;

namespace Flaskehalsen.Service.GraphQL;

public class Mutation
{
    public async Task<ClubRead> CreateClub([Service] IMediator mediator, ClubCreate create) =>
        await mediator.Send(new CreateClubRequest(create));

    public async Task<PersonRead> CreatePerson([Service] IMediator mediator, PersonCreate create) =>
        await mediator.Send(new CreatePersonRequest(create));

    public async Task<PersonRead> UpdatePerson([Service] IMediator mediator, Guid personId, PersonUpdate update) =>
        await mediator.Send(new UpdatePersonRequest(personId, update));
}