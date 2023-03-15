using MediatR;
using Flaskehalsen.Data;
using Flaskehalsen.Service.Dto;
using Mapster;
using Microsoft.EntityFrameworkCore;

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
        return Task.Run(() => _context.Persons.Include(p => p.Clubs).AsNoTracking().ProjectToType<PersonRead>(),
            cancellationToken);
    }
}