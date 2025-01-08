using Microsoft.Extensions.Options;
using QuoraClone.MYDB;
using QuoraClone.Interfaces;
using QuoraClone.Models;
using QuoraClone.Entities;

namespace QuoraClone.Repositories
{

	public class QuoraRepo : IRepo 
	{
        private readonly SQLDB MySqlDb;
		private readonly MyquoraDbContext myquoraDbContext;
        public QuoraRepo(IOptions<SQLDB> options)
		{
			MySqlDb = options.Value;
            myquoraDbContext = new MyquoraDbContext(MySqlDb.ConnectionString);
        }
		/// <summary>
		/// Posts a Topic in DataBase
		/// </summary>
		/// <param name="topic"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task PostTopic(Topic topic ,CancellationToken cancellationToken)
		{
			try
			{
                myquoraDbContext.Topics.Add(topic);
                await myquoraDbContext.SaveChangesAsync();
            }
			catch (Exception ex)
			{
				throw ex;
			}
		}
        /// <summary>
        /// Posts a Question in DataBase
        /// </summary>
        /// <param name="question"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task PostQuestion(Question question ,CancellationToken cancellationToken)
		{
			try
			{
                myquoraDbContext.Questions.Add(question);
                await myquoraDbContext.SaveChangesAsync();
            }
			catch (Exception ex)
			{
				throw ex;
			}
		}
        /// <summary>
        /// Posts a Anser in DataBase
        /// </summary>
        /// <param name="answer"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task PostAnswer(Answer answer ,CancellationToken cancellationToken)
		{
			try
			{
               myquoraDbContext.Answers.Add(answer);
               await myquoraDbContext.SaveChangesAsync();
            }
			catch (Exception ex)
			{
				throw ex;
			}
		}
        /// <summary>
        /// Updates a Topic in DataBase
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task PutTopic(Topic topic ,CancellationToken cancellationToken)
		{
			try
			{
                myquoraDbContext.Topics.Update(topic);
                await myquoraDbContext.SaveChangesAsync();
            }
			catch (Exception ex)
			{
				throw ex;
			}
		}
        /// <summary>
        /// Updates a Question in DataBase
        /// </summary>
        /// <param name="question"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task PutQuestion(Question question ,CancellationToken cancellationToken)
		{
			try
			{
                myquoraDbContext.Questions.Update(question);
                await myquoraDbContext.SaveChangesAsync();
            }
			catch (Exception ex)
			{
				throw ex;
			}
		}
        /// <summary>
        /// Updates an Answer in DataBase
        /// </summary>
        /// <param name="answer"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task PutAnswer(Answer answer ,CancellationToken cancellationToken)
		{
			try
			{
                myquoraDbContext.Answers.Update(answer);
                await myquoraDbContext.SaveChangesAsync();
                
            }
			catch (Exception ex)
			{
				throw ex;
			}
		}
		/// <summary>
		/// Deletes a Topic In DataBase
		/// </summary>
		/// <param name="Id"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task DeleteTopic(int Id,CancellationToken cancellationToken)
		{
			try
			{
                myquoraDbContext.Topics.Remove(myquoraDbContext.Topics.Where(c => c.TopicId == Id).First());
                await myquoraDbContext.SaveChangesAsync();
            }
			catch (Exception ex)
			{
				throw ex;
			}
		}
        /// <summary>
        /// Deletes a Question In DataBase
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task DeleteQuestion(int Id,CancellationToken cancellationToken)
		{
			try
			{
                myquoraDbContext.Questions.Remove(myquoraDbContext.Questions.Where(c => c.Qid == Id).First());
                await myquoraDbContext.SaveChangesAsync();
            }
			catch (Exception ex)
			{
				throw ex;
			}
		}
        /// <summary>
        /// Deletes an Answer In DataBase
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task DeleteAnswer(int Id,CancellationToken cancellationToken)
		{
			try
			{
                myquoraDbContext.Answers.Remove(myquoraDbContext.Answers.Where(c => c.Aid == Id).First());
                await myquoraDbContext.SaveChangesAsync();
            }
			catch (Exception ex)
			{
				throw ex;
			}
			
		}
        /// <summary>
		/// Gets list of Topics from DataBase
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
        public List<TopicModel> GetTopics(CancellationToken cancellationToken)
        {
            try
            {
                List<Topic>topics =myquoraDbContext.Topics.ToList();
                List<TopicModel> topicModel = topics.Select(c=>new TopicModel(){
                    Idpr=c.TopicId,
                    TopicNamepr=c.TopicName,
                    TopicDescriptionpr=c.TopicDescription,
                    CreatedBypr=c.TcreatedBy,
                    CreatedDateTimepr = c.TcreatedDateTime ?? DateTime.Now,
                    ModifiedBypr=c.TmodifiedBy,
                    ModifiedDateTimePr=c.TmodifiedDateTime??DateTime.Now
                }).ToList();
                return topicModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
         /// <summary>
         /// Gets list of Questions from DataBase
         /// </summary>
         /// <param name="Id"></param>
         /// <param name="cancellationToken"></param>
         /// <returns></returns>
        public List<QuestionModel> GetQuestions(int Id, CancellationToken cancellationToken)
        {
            try
            {
                List<Question>questions=myquoraDbContext.Questions.Where(c => c.TopicId==Id).ToList();
                List<QuestionModel> questionModel = questions.Select(c => new QuestionModel(){
                    Idpr=c.Qid,
                    TopicIdpr=c.TopicId,
                    Descriptionpr=c.Qdescription,
                    CreatedBypr=c.QcreatedBy,
                    CreatedDateTimepr=c.QcreatedDateTime ?? DateTime.Now,
                    ModifiedBypr=c.QmodifiedBy,
                    ModifiedDateTimepr=c.QmodifiedDateTime ?? DateTime.Now
                }).ToList();
                return questionModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
		/// Gets list of Answers from DataBase
		/// </summary>
		/// <param name="Id"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public List<AnswerModel> GetAnswers(int Id, CancellationToken cancellationToken)
        {
            try
            {
                List<Answer>answers=myquoraDbContext.Answers.Where(c => c.QuestionId==Id).ToList();
                List<AnswerModel> answerModel = answers.Select(c => new AnswerModel(){
                    Idpr=c.Aid,
                    QuestionIdpr=c.QuestionId,
                    Descriptionpr=c.Adescription,
                    Createdbypr=c.AcreatedBy,
                    CreatedDateTimepr=c.AcreatedDateTime??DateTime.Now,
                    ModifiedBypr=c.AmodifiedBy,
                    ModifiedDateTimepr=c.AmodifiedDateTime??DateTime.Now
                }).ToList();
                return answerModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

