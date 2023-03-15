using MediatR;
using Flaskehalsen.Data;
using Flaskehalsen.Service.Dto;
using Mapster;

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
        return Task.Run(() => _context.Clubs.ProjectToType<ClubRead>(), cancellationToken);
    }
}