using Flaskehalsen.Data;
using Flaskehalsen.Service.Dto;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Flaskehalsen.Service.Domain.Persons;

public class UpdatePersonRequest : IRequest<PersonRead>
{
    public Guid PersonId { get; set; }
    public PersonUpdate Update { get; }

    public UpdatePersonRequest(Guid personId, PersonUpdate update)
    {
        Update = update;
        PersonId = personId;
    }
}

public class UpdatePersonRequestHandler : IRequestHandler<UpdatePersonRequest, PersonRead>
{
    private readonly FlaskeContext _context;

    public UpdatePersonRequestHandler(FlaskeContext context)
    {
        _context = context;
    }

    public async Task<PersonRead> Handle(UpdatePersonRequest request, CancellationToken cancellationToken)
    {
        var person = await _context.Persons.Include(p => p.Clubs).SingleOrDefaultAsync(p => p.Id == request.PersonId, cancellationToken);

        if (person == null)
        {
            throw new Exception("Could not find person");
        }

        person.DisplayName = request.Update.Name;

        await _context.SaveChangesAsync(cancellationToken);

        return person.Adapt<PersonRead>();
    }
}