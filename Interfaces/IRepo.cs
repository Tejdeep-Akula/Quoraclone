using QuoraClone.Models;
using QuoraClone.Entities;

namespace QuoraClone.Interfaces
{
	public interface IRepo
	{
        Task PostTopic(Topic topic,CancellationToken cancellationToken);
        Task PostQuestion(Question question,CancellationToken cancellationToken);
        Task PostAnswer(Answer answer,CancellationToken cancellationToken);
        Task PutTopic(Topic topic,CancellationToken cancellationToken);
        Task PutQuestion(Question question,CancellationToken cancellationToken);
        Task PutAnswer(Answer answer,CancellationToken cancellationToken);
        Task DeleteTopic(int Id, CancellationToken cancellationToken);
        Task DeleteQuestion(int Id, CancellationToken cancellationToken);
        Task DeleteAnswer(int Id, CancellationToken cancellationToken);
        List<AnswerModel> GetAnswers(int Id, CancellationToken cancellationToken);
        List<TopicModel> GetTopics(CancellationToken cancellationToken);
        List<QuestionModel> GetQuestions(int Id, CancellationToken cancellationToken);
    }
}

