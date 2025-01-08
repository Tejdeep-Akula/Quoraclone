using System;
using QuoraClone.Models;
namespace QuoraClone.Interfaces
{
	public interface IService
	{
        Task PostTopic(TopicModel topicModel,CancellationToken cancellationToken);
        Task PostQuestion(QuestionModel questionModel,CancellationToken cancellationToken);
        Task PostAnswer(AnswerModel answerModel,CancellationToken cancellationToken);
        List<TopicModel> GetTopic(CancellationToken cancellationToken);
        List<QuestionModel> GetQuestions(int Id,CancellationToken cancellationToken);
        List<AnswerModel> GetAnswers(int Id,CancellationToken cancellationToken);
        Task PutTopic(TopicModel topicModel,CancellationToken cancellationToken);
        Task PutQuestion(QuestionModel questionModel,CancellationToken cancellationToken);
        Task PutAnswer(AnswerModel answerModel,CancellationToken cancellationToken);
        Task DeleteTopic(int Id, CancellationToken cancellationToken);
        Task DeleteQuestion(int Id, CancellationToken cancellationToken);
        Task DeleteAnswer(int Id, CancellationToken cancellationToken);
    }
}

