using System;
using System.Collections.Generic;

namespace QuoraClone.Entities;

public partial class Topic
{
    public int TopicId { get; set; }

    public string? TopicName { get; set; }

    public string? TopicDescription { get; set; }

    public string? TcreatedBy { get; set; }

    public DateTime? TcreatedDateTime { get; set; }

    public string? TmodifiedBy { get; set; }

    public DateTime? TmodifiedDateTime { get; set; }

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
