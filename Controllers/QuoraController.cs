using System;
using Microsoft.AspNetCore.Mvc;
using QuoraClone.Services;
using QuoraClone.Interfaces;
using QuoraClone.Repositories;
using QuoraClone.Models;
namespace QuoraClone.Controllers
//This is my api
{
	[Route("api/Quora")]
	[ApiController]
	public class QuoraController : ControllerBase
	{
		private readonly IService service;
		public QuoraController(IService service)
		{
			this.service = service;
		}


        /// <summary>
        /// create a topic
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="cancellationToken"></param>
        [HttpPost("Topic")]
		public async Task PostTopic(TopicModel topicModel,CancellationToken cancellationToken)
		{
			try
			{
				await service.PostTopic(topicModel,cancellationToken);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        /// <summary>
        /// Create a question
        /// </summary>
        /// <param name="questionModel"></param>
        /// <param name="cancellationToken"></param>
        [HttpPost("Question")]
		public async Task PostQuestion(QuestionModel questionModel,CancellationToken cancellationToken)
		{
			try
			{
				await service.PostQuestion(questionModel, cancellationToken);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


        /// <summary>
        /// Create an Answer
        /// </summary>
        /// <param name="answerModel"></param>
        /// <param name="cancellationToken"></param>
        [HttpPost("Answer")]
		public async Task PostAnswer(AnswerModel answerModel,CancellationToken cancellationToken)
		{
			try
			{
				await service.PostAnswer(answerModel, cancellationToken);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        /// <summary>
        /// update a Topic
        /// </summary>
        /// <param name="topicModel"></param>
        /// <param name="cancellationToken"></param>
        [HttpPut("Topic")]
		public async Task PutTopic(TopicModel topicModel,CancellationToken cancellationToken)
		{
			try
			{
				await service.PutTopic(topicModel, cancellationToken);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        /// <summary>
        /// Update a Question
        /// </summary>
        /// <param name="questionModel"></param>
        /// <param name="cancellationToken"></param>
        [HttpPut("Question")]
		public async Task PutQuestion(QuestionModel questionModel,CancellationToken cancellationToken)
		{
			try
			{
				await service.PutQuestion(questionModel, cancellationToken);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        /// <summary>
        /// update an Answer
        /// </summary>
        /// <param name="answerModel"></param>
        /// <param name="cancellationToken"></param>
        [HttpPut("Answer")]
		public async Task PutAnswer(AnswerModel answerModel,CancellationToken cancellationToken)
		{
			try
			{
				await service.PutAnswer(answerModel, cancellationToken);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        /// <summary>
        /// Get all the Topics
        /// </summary>
		/// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("Topic")]
		public  List<TopicModel> GetTopics(CancellationToken cancellationToken)
		{
			try
			{
				List<TopicModel> topicModel = new();
				topicModel=service.GetTopic(cancellationToken);
				return topicModel;

			}
			catch (Exception ex)
			{
				throw ex;
			}
        }

        /// <summary>
        /// Get all Questions
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("Question")]
		public List<QuestionModel> GetQuestions(int Id,CancellationToken cancellationToken)
		{
			try
			{
                List<QuestionModel> questionModel = new();
                return questionModel=service.GetQuestions(Id,cancellationToken);
            }
			catch (Exception ex)
			{
				throw ex;
			}
		}

        /// <summary>
        /// Get all Answers
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("Answer")]
		public List<AnswerModel> GetAnswers(int Id,CancellationToken cancellationToken)
		{
			try
			{
                List<AnswerModel> answerModel = new();
                return answerModel=service.GetAnswers(Id,cancellationToken);
            }
			catch (Exception ex)
			{
				throw ex;
			}
		}

        /// <summary>
        /// Delete Topic you wish
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="cancellationToken"></param>
        [HttpDelete("Topic")]
		public async Task DeleteTopic(int Id,CancellationToken cancellationToken)
		{
			try
			{
				await service.DeleteTopic(Id, cancellationToken);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        /// <summary>
        /// Delete Question you wish
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="cancellationToken"></param>
        [HttpDelete("Question")]
		public async Task DeleteQuestion(int Id,CancellationToken cancellationToken)
		{
			try
			{
				await service.DeleteQuestion(Id, cancellationToken);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        /// <summary>
        /// Delete Answer you wish
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="cancellationToken"></param>
        [HttpDelete("answer")]		
		public async Task DeleteAnswer(int Id,CancellationToken cancellationToken)
		{
			try
			{
				await service.DeleteAnswer(Id, cancellationToken);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

	}	
		
}

