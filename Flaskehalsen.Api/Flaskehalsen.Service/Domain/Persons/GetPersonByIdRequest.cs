using MediatR;
using Microsoft.EntityFrameworkCore;
using Flaskehalsen.Data;
using Flaskehalsen.Service.Dto;
using Mapster;

namespace Flaskehalsen.Service.Domain.Persons;

public class GetPersonByIdRequest : IRequest<PersonRead>
{
    public GetPersonByIdRequest(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}

public class GetPersonByIdRequestHandler : IRequestHandler<GetPersonByIdRequest, PersonRead>
{
    private readonly FlaskeContext _context;

    public GetPersonByIdRequestHandler(FlaskeContext context)
    {
        _context = context;
    }

    public async Task<PersonRead> Handle(GetPersonByIdRequest request, CancellationToken cancellationToken)
    {
        var p = await _context.Persons.Include(p => p.Clubs).AsNoTracking()
            .SingleOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (p == null)
        {
            throw new Exception("Person not found");
        }

        return p.Adapt<PersonRead>();
    }
}