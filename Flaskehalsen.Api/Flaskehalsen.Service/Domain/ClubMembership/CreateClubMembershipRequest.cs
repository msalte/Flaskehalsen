using Flaskehalsen.Data;
using Flaskehalsen.Service.Dto;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Flaskehalsen.Service.Domain.ClubMembership;

public class CreateClubMembershipRequest : IRequest<PersonRead>
{
    public Guid PersonId { get; set; }
    public Guid ClubId { get; set; }

    public CreateClubMembershipRequest(Guid personId, Guid clubId)
    {
        PersonId = personId;
        ClubId = clubId;
    }
}

public class CreateClubMembershipRequestHandler : IRequestHandler<CreateClubMembershipRequest, PersonRead>
{
    private readonly FlaskeContext _context;

    public CreateClubMembershipRequestHandler(FlaskeContext context)
    {
        _context = context;
    }

    public async Task<PersonRead> Handle(CreateClubMembershipRequest request, CancellationToken cancellationToken)
    {
        await _context.ClubMemberships.AddAsync(
            new Data.Entity.ClubMembership {PersonId = request.PersonId, ClubId = request.ClubId}, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        var person = await _context.Persons
            .Include(p => p.Clubs)
            .AsNoTracking()
            .SingleAsync(p => p.Id == request.PersonId, cancellationToken);

        return person.Adapt<PersonRead>();
    }
}