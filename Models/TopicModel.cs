using System;
namespace QuoraClone.Models
{
	public class TopicModel
	{
		private int Id;
		private string CreatedBy;
		private DateTime CreatedDateTime;
		private string ModifiedBy;
		private DateTime ModifiedDateTime;
		private string TopicName;
		private string TopicDescription;

		public int Idpr
		{
			get { return Id; }
			set { Id = value; }
		}
		public string CreatedBypr
		{
			get { return CreatedBy; }
			set { CreatedBy = value; }
		}
		public DateTime CreatedDateTimepr
		{
			get { return CreatedDateTime; }
			set { CreatedDateTime = value; }
		}
		public string ModifiedBypr
		{
			get { return ModifiedBy; }
			set { ModifiedBy = value; }
		}
		public DateTime ModifiedDateTimePr
		{
			get { return ModifiedDateTime; }
			set { ModifiedDateTime = value; }
		}
		public string TopicNamepr
		{
			get { return TopicName; }
			set { TopicName = value; }
		}
		public string TopicDescriptionpr
		{
			get { return TopicDescription; }
			set { TopicDescription = value; }
		}
	} 
}

