using System;
namespace QuoraClone.Models
{
	public class QuestionModel
	{
		private int Id;
		private int TopicId;
		private string CreatedBy;
		private DateTime CreatedDateTime;
		private string ModifiedBy;
		private DateTime ModifiedDateTime;
		private string Description;

		public int Idpr
		{
			get { return Id; }
			set { Id = value; }
		}
		public int TopicIdpr
		{
			get { return TopicId; }
			set { TopicId = value; }
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
		public DateTime ModifiedDateTimepr
		{
			get { return ModifiedDateTime; }
			set { ModifiedDateTime = value; }
		}
		public string Descriptionpr
		{
			get { return Description; }
			set { Description = value; }
		}
	}
}

