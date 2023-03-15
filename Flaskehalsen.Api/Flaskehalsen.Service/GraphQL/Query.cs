using Flaskehalsen.Service.Domain.Clubs;
using Flaskehalsen.Service.Domain.Persons;
using Flaskehalsen.Service.Dto;
using MediatR;

namespace Flaskehalsen.Service.GraphQL;

public class Query
{
    public async Task<IQueryable<ClubRead>> GetClubs([Service] IMediator mediator) =>
        await mediator.Send(new GetClubsRequest());

    public async Task<IQueryable<PersonRead>> GetPersons([Service] IMediator mediator) =>
        await mediator.Send(new GetPersonsRequest());

    public async Task<PersonRead> GetPerson([Service()] IMediator mediator, Guid personId) =>
        await mediator.Send(new GetPersonByIdRequest(personId));
}