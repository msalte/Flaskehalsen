using Flaskehalsen.Service.Models;
using MediatR;
using Flaskehalsen.Data;

namespace Flaskehalsen.Service.Domain.Clubs;

public class GetClubsRequest : IRequest<IQueryable<ClubRead>>
{
}

public class GetClubsRequestHandler : IRequestHandler<GetClubsRequest, IQueryable<ClubRead>>
{
    private readonly FlaskeContext _context;

    public GetClubsRequestHandler(FlaskeContext context)
    {
        _context = context;
    }

    public Task<IQueryable<ClubRead>> Handle(GetClubsRequest request, CancellationToken cancellationToken)
    {
        return Task.Run(() => _context.Clubs.Select(c => new ClubRead()
        {
            Id = c.Id,
            Name = c.Name
        }), cancellationToken);
    }
}