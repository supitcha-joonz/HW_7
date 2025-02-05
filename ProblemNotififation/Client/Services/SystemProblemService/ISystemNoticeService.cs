﻿

namespace ProblemNotififation.Client.Services.SystemProblemService
{
    public interface ISystemNoticeService
    {
        List<Problem> Problems { get; set; }
        List<Application> Applications { get; set; }

        Task GetProblem();
        Task GetApplication();

        Task<Problem> GetSingleProblem(int id);

        Task CreateProblem(Problem pro);
        Task UpdateProblem(Problem pro);
        Task DeleteProblem(int id);

        Task<Application> GetSingleApplication(int id);

        Task CreateApplication(Application app);
        Task UpdateApplication(Application app);
        Task DeleteApplication(int id);
    }
}
