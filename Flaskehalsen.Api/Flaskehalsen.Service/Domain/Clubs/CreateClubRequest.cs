using Flaskehalsen.Data;
using Flaskehalsen.Data.Entity;
using Flaskehalsen.Service.Dto;
using Mapster;
using MediatR;

namespace Flaskehalsen.Service.Domain.Clubs;

public class CreateClubRequest : IRequest<ClubRead>
{
    public ClubCreate Create { get; set; }

    public CreateClubRequest(ClubCreate create)
    {
        Create = create;
    }
}

public class CreateClubRequestHandler : IRequestHandler<CreateClubRequest, ClubRead>
{
    private readonly FlaskeContext _context;

    public CreateClubRequestHandler(FlaskeContext context)
    {
        _context = context;
    }

    public async Task<ClubRead> Handle(CreateClubRequest request, CancellationToken cancellationToken)
    {
        var e = await _context.Clubs.AddAsync(new Club
        {
            Name = request.Create.Name
        }, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return e.Entity.Adapt<ClubRead>();
    }
}