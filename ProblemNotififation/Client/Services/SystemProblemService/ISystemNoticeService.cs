

namespace ProblemNotififation.Client.Services.SystemProblemService
{
    public interface ISystemNoticeService
    {
        List<Problem> Problems { get; set; }

        Task GetProblem();

        Task<Problem> GetSingleProblem(int id);

        Task CreateProblem(Problem pro);
        Task UpdateProblem(Problem pro);
        Task DeleteProblem(int id);
    }
}
