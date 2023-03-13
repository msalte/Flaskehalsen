using Flaskehalsen.Service.Models;
using MediatR;
using Flaskehalsen.Data;

namespace Flaskehalsen.Service.Domain.Persons;

public class GetPersonsRequest : IRequest<IQueryable<PersonRead>>
{
}

public class GetPersonsRequestHandler : IRequestHandler<GetPersonsRequest, IQueryable<PersonRead>>
{
    private readonly FlaskeContext _context;

    public GetPersonsRequestHandler(FlaskeContext context)
    {
        _context = context;
    }

    public Task<IQueryable<PersonRead>> Handle(GetPersonsRequest request, CancellationToken cancellationToken)
    {
        return Task.Run(() => _context.Persons.Select(p => new PersonRead()
        {
            Id = p.Id,
            Name = p.DisplayName
        }), cancellationToken);
    }
}