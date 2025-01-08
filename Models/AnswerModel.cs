using System;
namespace QuoraClone.Models
{
	public class AnswerModel
	{
		private int Id;
		private int QuestionId;
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
		public int QuestionIdpr
		{
			get { return QuestionId; }
			set { QuestionId = value; }
		}
		public string Createdbypr
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

