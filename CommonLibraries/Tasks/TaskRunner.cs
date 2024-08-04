using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TRW.CommonLibraries.Tasks
{
    public class TaskRunner
    {
        public List<Task> Tasks { get; private set; } = new List<Task>();
        public static TaskFactory Factory { get; private set; } = new TaskFactory();

        public void AddTask<T>(ReportProgressDelegate progress, params object[] args)
            where T : ITask, new()
        {
            Task t = new(() =>
            {
                try
                {
                    T task = new();
                    task.ReportProgress += progress;
                    task.Run(args);
                    task.ReportProgress -= progress;
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                    if (ex.InnerException != null)
                        message = $"{message}. Inner Exception: {ex.InnerException.Message}";

                    progress.Invoke($"Task failed. Exception: {message}");
                }
                progress.Invoke("Task Complete.");
            });
            Tasks.Add(t);
        }

        public void RunAllTasksSynchronously()
        {
            Factory.StartNew(() =>
            {
                foreach (Task t in Tasks)
                {
                    t.Start();
                    t.Wait();
                }
            });
        }

        public void RunAllTasks()
        {
            RunAllTasks(false, -1);
        }

        public void RunAllTasks(bool waitAll, int timeout)
        {
            Factory.StartNew(() =>
            {
                foreach (Task t in Tasks)
                {
                    t.Start();
                }

                if (waitAll)
                {
                    Task.WaitAll(Tasks.ToArray(), timeout);
                }
            });
            Tasks.Clear();
        }

        public static void RunTask<T>(ReportProgressDelegate progress, params object[] args)
            where T : ITask, new()
        {
            progress.Invoke("Starting Task...");

            Task t = Factory.StartNew(() =>
            {
                T task = new();
                try
                {
                    task.ReportProgress += progress;
                    task.Run(args);
                }
                catch (Exception ex)
                {
                    progress.Invoke(ex.ToString());
                }
                finally
                {
                    task.ReportProgress -= progress;
                }
                progress.Invoke("Task Complete.");
            });
        }

    }
}
