using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnytourApi.Domain.Models.Shared;

[PrimaryKey(nameof(FirstId), nameof(SecondId))]
public abstract class RelationModel<TFirst, TSecond>
    where TFirst : class, IModel
    where TSecond : class, IModel
{
    public required Guid FirstId { get; set; }
    public required Guid SecondId { get; set; }

    [ForeignKey(nameof(FirstId))] public virtual TFirst First { get; set; } = default!;

    [ForeignKey(nameof(SecondId))] public virtual TSecond Second { get; set; } = default!;

    public void Deconstruct(out Guid firstId, out Guid secondId)
    {
        firstId = FirstId;
        secondId = SecondId;
    }
}
