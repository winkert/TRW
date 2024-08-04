namespace TRW.CommonLibraries.Tasks
{
    public interface ITask
    {
        void Run(params object[] args);

        event ReportProgressDelegate ReportProgress;
        event TaskCompleteDelegate TaskComplete;
    }
}
