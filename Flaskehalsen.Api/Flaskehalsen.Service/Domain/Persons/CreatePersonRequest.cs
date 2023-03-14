using Flaskehalsen.Service.Models;
using MediatR;
using Flaskehalsen.Data;
using Flaskehalsen.Data.Entity;

namespace Flaskehalsen.Service.Domain.Persons;

public class CreatePersonRequest : IRequest<PersonRead>
{
    public PersonCreate Create { get; }

    public CreatePersonRequest(PersonCreate create)
    {
        Create = create;
    }
}

public class CreatePersonRequestHandler : IRequestHandler<CreatePersonRequest, PersonRead>
{
    private readonly FlaskeContext _context;

    public CreatePersonRequestHandler(FlaskeContext context)
    {
        _context = context;
    }

    public async Task<PersonRead> Handle(CreatePersonRequest request, CancellationToken cancellationToken)
    {
        var e = await _context.Persons.AddAsync(new Person
        {
            DisplayName = request.Create.DisplayName,
            Email = request.Create.Email
        }, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return new PersonRead
        {
            Id = e.Entity.Id,
            Name = e.Entity.DisplayName
        };
    }
}