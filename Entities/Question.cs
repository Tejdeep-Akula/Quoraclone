using System;
using System.Collections.Generic;

namespace QuoraClone.Entities;

public partial class Question
{
    public int Qid { get; set; }

    public int TopicId { get; set; }

    public string? Qdescription { get; set; }

    public string? QcreatedBy { get; set; }

    public DateTime? QcreatedDateTime { get; set; }

    public string? QmodifiedBy { get; set; }

    public DateTime? QmodifiedDateTime { get; set; }

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual Topic Topic { get; set; } = null!;
}
