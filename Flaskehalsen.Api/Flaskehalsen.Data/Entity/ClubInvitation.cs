using System.ComponentModel.DataAnnotations;

namespace Flaskehalsen.Data.Entity;

public class ClubInvitation : IEntity
{
    [Key]
    public Guid Id { get; set; }
    public Guid ClubId { get; set; }
    public Club Club { get; set; }
    public Guid PersonId { get; set; }
    public Person Invitee { get; set; }
    public InvitationStatus InvitationStatus { get; set; }
    public DateTime CreatedUtc { get; set; }
    public DateTime UpdatedUtc { get; set; }
    public bool IsDeleted { get; set; }
}