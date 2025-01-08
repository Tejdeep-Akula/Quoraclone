using System;
using Microsoft.Extensions.Options;
using QuoraClone.Models;
using QuoraClone.Interfaces;
using QuoraClone.MYDB;
using QuoraClone.Entities;

namespace QuoraClone.Services

{
    public class QuoraService:IService
	{
		private readonly IRepo repo;
		private readonly SQLDB Mysqldb;
		private readonly MyquoraDbContext myquoraDbContext;
		public QuoraService(IRepo repo,IOptions<SQLDB>options)
		{
			this.repo = repo;
			Mysqldb = options.Value;
			myquoraDbContext = new MyquoraDbContext(Mysqldb.ConnectionString);
		}
		/// <summary>
		/// creates a Topic
		/// </summary>
		/// <param name="topicModel"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task PostTopic(TopicModel topicModel,CancellationToken cancellationToken)
		{
			try
			{
				Topic topic = new Topic(){
					TopicId=topicModel.Idpr,
					TopicName=topicModel.TopicNamepr,
					TopicDescription=topicModel.TopicDescriptionpr,
					TcreatedBy=topicModel.CreatedBypr,
					TcreatedDateTime=DateTime.Now,
					TmodifiedBy=topicModel.ModifiedBypr,
					TmodifiedDateTime=DateTime.Now

				};
				await repo.PostTopic(topic,cancellationToken);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		/// <summary>
		/// creates a question
		/// </summary>
		/// <param name="questionModel"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task PostQuestion(QuestionModel questionModel, CancellationToken cancellationToken)
		{
			try
			{
				Question question = new Question(){
					Qid=questionModel.Idpr,
					TopicId=questionModel.TopicIdpr,
					Qdescription=questionModel.Descriptionpr,
					QcreatedBy=questionModel.CreatedBypr,
					QcreatedDateTime=DateTime.Now,
					QmodifiedBy=questionModel.ModifiedBypr,
					QmodifiedDateTime=DateTime.Now
				};
				
				await	repo.PostQuestion(question,cancellationToken);
			}
			catch (Exception ex) { 
			
				throw ex;
			}
		}
		/// <summary>
		/// creates an answer
		/// </summary>
		/// <param name="answerModel"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task PostAnswer(AnswerModel answerModel, CancellationToken cancellationToken)
		{
			try
			{
				Answer answer = new Answer(){
					Aid=answerModel.Idpr,
					QuestionId=answerModel.QuestionIdpr,
					Adescription=answerModel.Descriptionpr,
					AcreatedBy=answerModel.Createdbypr,
					AcreatedDateTime=DateTime.Now,
					AmodifiedBy=answerModel.ModifiedBypr,
					AmodifiedDateTime=answerModel.ModifiedDateTimepr
				};
				
				await repo.PostAnswer(answer,cancellationToken);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		/// <summary>
		/// updates a topic
		/// </summary>
		/// <param name="topicModel"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task PutTopic(TopicModel topicModel, CancellationToken cancellationToken)
		{
			try
			{
				Topic topic = new Topic(){
					TopicId=topicModel.Idpr,
					TopicName=topicModel.TopicNamepr,
					TopicDescription=topicModel.TopicDescriptionpr,
					TcreatedBy=topicModel.CreatedBypr,
					TcreatedDateTime=DateTime.Now,
					TmodifiedBy=topicModel.ModifiedBypr,
					TmodifiedDateTime=DateTime.Now

				};
                await repo.PutTopic(topic,cancellationToken);
            }
			catch (Exception ex)
			{
				throw ex;
			}
		}
		/// <summary>
		/// updates a question
		/// </summary>
		/// <param name="questionModel"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task PutQuestion(QuestionModel questionModel, CancellationToken cancellationToken)
		{
			try
			{
				Question question = new Question(){
					Qid=questionModel.Idpr,
					TopicId=questionModel.TopicIdpr,
					Qdescription=questionModel.Descriptionpr,
					QcreatedBy=questionModel.CreatedBypr,
					QcreatedDateTime=DateTime.Now,
					QmodifiedBy=questionModel.ModifiedBypr,
					QmodifiedDateTime=DateTime.Now
				};
                await repo.PutQuestion(question,cancellationToken);
            }
			catch (Exception ex)
			{
				throw ex;
			}
		}
		/// <summary>
		/// updates an answer
		/// </summary>
		/// <param name="answerModel"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task PutAnswer(AnswerModel answerModel, CancellationToken cancellationToken)
		{
			try
			{
				Answer answer = new Answer(){
					Aid=answerModel.Idpr,
					QuestionId=answerModel.QuestionIdpr,
					Adescription=answerModel.Descriptionpr,
					AcreatedBy=answerModel.Createdbypr,
					AcreatedDateTime=DateTime.Now,
					AmodifiedBy=answerModel.ModifiedBypr,
					AmodifiedDateTime=answerModel.ModifiedDateTimepr
				};
                await repo.PutAnswer(answer,cancellationToken);
            }
			catch (Exception ex)
			{
				throw ex;
			}
		}
		/// <summary>
		/// Gets list of Topics
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public List<TopicModel> GetTopic(CancellationToken cancellationToken)
		{
			try
			{
				List<TopicModel> topicModel = repo.GetTopics(cancellationToken);
				return topicModel;
 			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		/// <summary>
		/// Gets list of Questions
		/// </summary>
		/// <param name="Id"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public List<QuestionModel> GetQuestions(int Id, CancellationToken cancellationToken)
		{
			try
			{
				List<QuestionModel> questionModel= repo.GetQuestions(Id, cancellationToken);
                return questionModel;
            }
			catch (Exception ex)
			{
				throw ex;
			}
		}
		/// <summary>
		/// Gets list of Answers
		/// </summary>
		/// <param name="Id"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public List<AnswerModel> GetAnswers(int Id, CancellationToken cancellationToken)
		{
			try
			{
				List<AnswerModel> answerModel = repo.GetAnswers(Id, cancellationToken);
                return answerModel;
            }
			catch (Exception ex)
			{
				throw ex;
			}
		}
		/// <summary>
		/// Deletes a Topic
		/// </summary>
		/// <param name="Id"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
        public async Task DeleteTopic(int Id, CancellationToken cancellationToken)
        {
            try
            {
				repo.DeleteTopic(Id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Deletes a Question
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task DeleteQuestion(int Id, CancellationToken cancellationToken)
        {
            try
            {
				repo.DeleteQuestion(Id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Deletes an Answer 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task DeleteAnswer(int Id, CancellationToken cancellationToken)
        {
            try
            {
				repo.DeleteAnswer(Id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}

