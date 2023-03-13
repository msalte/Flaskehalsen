using Flaskehalsen.Data;
using Flaskehalsen.Service.Models;
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
        var person = await _context.Persons.SingleOrDefaultAsync(p => p.Id == request.PersonId, cancellationToken);

        if (person == null)
        {
            throw new Exception("Could not find person");
        }

        person.DisplayName = request.Update.Name;

        await _context.SaveChangesAsync(cancellationToken);

        return new PersonRead
        {
            Id = person.Id,
            Name = person.DisplayName
        };
    }
}