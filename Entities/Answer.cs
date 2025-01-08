using System;
using System.Collections.Generic;

namespace QuoraClone.Entities;

public partial class Answer
{
    public int Aid { get; set; }

    public int QuestionId { get; set; }

    public string? Adescription { get; set; }

    public string? AcreatedBy { get; set; }

    public DateTime? AcreatedDateTime { get; set; }

    public string? AmodifiedBy { get; set; }

    public DateTime? AmodifiedDateTime { get; set; }

    public virtual Question Question { get; set; } = null!;
}
