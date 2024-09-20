using AnytourApi.Constants.Models.AppUsers;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Shared;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AnytourApi.Domain.Models;

public class User : IdentityUser<Guid>, IModel, ICloneable
{
    [Required]
    public override required string Email
    {
        get => base.Email!;
#pragma warning disable CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
        set => base.Email = value;
#pragma warning restore CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
    }

    [StringLength(UserNumberConstants.NameLength)]
    public override required string UserName { get => base.UserName; set => base.UserName = value; }

    public virtual ICollection<IdentityRole<Guid>> Roles { get; set; } = [];

    public virtual ICollection<Tour> Tours { get; set; } = new List<Tour>();


    object ICloneable.Clone()
    {
        return Clone();
    }

    public User Clone()
    {
        return (User)MemberwiseClone();
    }


}
