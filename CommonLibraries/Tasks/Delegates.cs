namespace TRW.CommonLibraries.Tasks
{
    public delegate void ReportProgressDelegate(string message);
    public delegate void TaskCompleteDelegate(params object[] args);
}