using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using TRW.CommonLibraries.Core;

namespace TRW.Apps.TrwAppsBase
{
    public partial class TrwFormBase : Form
    {
        protected Dictionary<string, string> _settings;
        protected static Random R = new Random();
        private readonly string _configFilePath;
        private readonly string _logFilePath;
        private readonly string _applicationPath;

        public static Image AddButtonImage 
        { 
            get 
            {
                return Properties.Resources.AddButton;
            } 
        }
        public static Image CancelButtonImage
        {
            get
            {
                return Properties.Resources.CancelButton;
            }
        }
        public static Image CopyButtonImage
        {
            get
            {
                return Properties.Resources.CopyButton;
            }
        }
        public static Image DeleteButtonImage
        {
            get
            {
                return Properties.Resources.DeleteButton;
            }
        }
        public static Image EditButtonImage
        {
            get
            {
                return Properties.Resources.EditButton;
            }
        }
        public static Image SaveButtonImage
        {
            get
            {
                return Properties.Resources.SaveButton;
            }
        }
        public static Image CloseButtonImage
        {
            get
            {
                return Properties.Resources.CloseButton;
            }
        }
        public static Image CloseButtonGreyImage
        {
            get
            {
                return Properties.Resources.CloseButtonGrey;
            }
        }

        private readonly Dictionary<int, Task> _taskList;

        public TrwFormBase()
        {
            Application.ThreadException += BaseApplicationThreadExceptionHandler;
            AppDomain.CurrentDomain.UnhandledException += BaseDomainExceptionHandler;

            InitializeComponent();

            _applicationPath = Environment.CurrentDirectory;

            _configFilePath = Path.Combine(_applicationPath, string.Format("{0}.config", this.GetType().Name));
            _logFilePath = Path.Combine(_applicationPath, string.Format("{0}.log", this.GetType().Name));
            _taskList = new Dictionary<int, Task>();

            if (HasConfigFile)
                LoadConfigFile();

        }

        public delegate void BackgroundTaskComplete(Task task);
        /// <summary>
        /// Event fired when a background task is completed
        /// </summary>
        public event BackgroundTaskComplete BackgroundTaskComplete_Event;
        public delegate void BackgroundTaskFailed(Task task, AggregateException e);
        /// <summary>
        /// Event fired when a background task failed. Fired after BackgroundTaskComplete_Event
        /// </summary>
        public event BackgroundTaskFailed BackgroundTaskFailed_Event;
        public delegate void BackgroundTaskCanceled(Task task);
        /// <summary>
        /// Event fired when a background task is canceled. Fired after BackgroundTaskComplete_Event
        /// </summary>
        public event BackgroundTaskCanceled BackgroundTaskCanceled_Event;

        protected delegate void UpdateUIStatus(TextBox statusBox, string statusMessage);
        protected virtual bool HasConfigFile { get { return false; } }

        #region Base Methods
        /// <summary>
        /// Send a status update to the designated Form TextBox
        /// </summary>
        /// <param name="message"></param>
        public void UpdateStatus(string message)
        {
            UpdateStatus(this, message);
        }
        /// <summary>
        /// Implement locally. Invoke from the mainForm control the UpdateUIStatus delegate pointing
        /// to AddStatusMessage passing in the TextBox which should get the status message
        /// e.g. mainForm.Invoke(new UpdateUIStatus(AddStatusMessage), message, (TextBox)txt_StatusTextBox);
        /// </summary>
        /// <param name="mainForm"></param>
        /// <param name="message"></param>
        protected virtual void UpdateStatus(Control mainForm, string message)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Adds a status message to a designated TextBox. Must be invoked or called from UI Thread
        /// </summary>
        /// <param name="statusBox"></param>
        /// <param name="statusMessage"></param>
        protected void AddStatusMessage(TextBox statusBox, string statusMessage)
        {
            statusBox.AppendText(string.Format("{0}{1}", statusMessage, Environment.NewLine));
        }

        /// <summary>
        /// Display a Load File Dialog for all files
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        protected static bool LoadFile(out string fileName)
        {
            return LoadFile("All Files|*.*", out fileName);
        }
        /// <summary>
        /// Display a Load File Dialog for a filtered set of files
        /// </summary>
        /// <param name="filter">e.g. "Text Files (txt)|*.txt|All Files|*.*"</param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        protected static bool LoadFile(string filter, out string fileName)
        {
            fileName = string.Empty;
            using (OpenFileDialog dialog = new OpenFileDialog
            {
                Multiselect = false,
                Filter = filter
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = dialog.FileName;
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Display a Save File Dialog for all files
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        protected static bool SaveFile(out string fileName)
        {
            return SaveFile("All Files|*.*", out fileName);
        }
        /// <summary>
        /// Display a Save File Dialog for a filtered set of files
        /// </summary>
        /// <param name="filter">e.g. "Text Files (txt)|*.txt|All Files|*.*"</param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        protected static bool SaveFile(string filter, out string fileName)
        {
            fileName = string.Empty;
            using (SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = filter
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = dialog.FileName;
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Populate a combo box with enumerated values
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="combobox"></param>
        protected static void PopulateComboBoxWithEnum<T>(ComboBox combobox) where T : IComparable
        {
            combobox.Items.Clear();
            foreach (var val in Enum.GetValues(typeof(T)))
            {
                combobox.AddItem<T>((T)val, EnumExtensions.GetDescription(val as Enum));
            }

        }
        /// <summary>
        /// Get a list of items as type T from a listbox
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listBox"></param>
        /// <returns></returns>
        protected static List<T> GetItemsAsList<T>(ListBox listBox) where T : class
        {
            List<T> val = new List<T>();
            foreach (var item in listBox.Items)
            {
                T i = item as T;
                val.Add(i);
            }

            return val;
        }
        /// <summary>
        /// Get a list of items as type T from a combobox
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="comboBox"></param>
        /// <returns></returns>
        protected static List<T> GetItemsAsList<T>(ComboBox comboBox) where T : class
        {
            List<T> val = new List<T>();
            foreach (var item in comboBox.Items)
            {
                T i = item as T;
                val.Add(i);
            }

            return val;
        }

        protected void StartTaskInNewThread(Action action, CancellationTokenSource cancellationToken = null)
        {
            Task bgTask;
            if (cancellationToken == null)
                bgTask = new Task(action);
            else
                bgTask = new Task(action, cancellationToken.Token);

            StartTask(bgTask);
        }

        protected void StartTask(Task task)
        {
            task.ContinueWith(TaskComplete_Event);

            _taskList.Add(task.Id, task);
            task.Start();
        }

        protected void LoadConfigFile()
        {
            if (_settings == null)
                _settings = new Dictionary<string, string>();

            if (File.Exists(_configFilePath))
            {
                try
                {
                    CommonLibraries.Xml.XmlParser configParser = new CommonLibraries.Xml.XmlParser(_configFilePath);
                    if (configParser.RootElement.Name == "Config")
                    {
                        foreach (CommonLibraries.Xml.XmlDocumentElement setting in configParser.RootElement.Children)
                        {
                            _settings.Add(setting.Name, setting.Value);
                        }
                    }
                }
                catch (System.Xml.XmlException)
                {
                    File.Delete(_configFilePath);
                }
            }
        }

        protected void SaveConfigFile()
        {
            if (_settings != null)
            {
                using (CommonLibraries.Xml.XmlBuilder configWriter = new CommonLibraries.Xml.XmlBuilder(_configFilePath))
                {
                    configWriter.OpenElement("Config");
                    foreach (KeyValuePair<string, string> setting in _settings)
                    {
                        configWriter.WriteElement(setting.Key, setting.Value);
                    }
                    configWriter.FinalizeDocument();
                }
            }
        }

        protected void WriteLog(string logEntry)
        {
            using (StreamWriter writer = File.AppendText(_logFilePath))
                writer.WriteLine($"{DateTime.Now:yyyy.MM.dd hh.mm.ss}\t\t{logEntry}");
        }
        #endregion

        #region Base Events
        private void TaskComplete_Event(Task task)
        {
            if (_taskList.ContainsKey(task.Id))
            {
                if(BackgroundTaskComplete_Event !=  null)
                    BackgroundTaskComplete_Event(task);
                if (task.IsCanceled)
                {
                    // handle cancelation here
                    if(BackgroundTaskCanceled_Event != null)
                        BackgroundTaskCanceled_Event(task);
                }
                if (task.IsFaulted)
                {
                    // handle exceptions here
                    var exception = task.Exception;
                    if(BackgroundTaskFailed_Event != null)
                        BackgroundTaskFailed_Event(task, exception);
                }
                // remove task from task list as it has completed
                _taskList.Remove(task.Id);
                // explicitely dispose the task
                task.Dispose();
            }
        }

        private void TrwFormBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (HasConfigFile)
                SaveConfigFile();

            Application.ThreadException -= BaseApplicationThreadExceptionHandler;
            AppDomain.CurrentDomain.UnhandledException -= BaseDomainExceptionHandler;
        }

        private void BaseApplicationThreadExceptionHandler(object sender, ThreadExceptionEventArgs e)
        {
            try
            {
                WriteLog($"Unhandled Exception: [{e.Exception}]");
            }
            catch
            {
                // give up here - don't blow up blowing up
            }
        }

        private void BaseDomainExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                WriteLog("Catastrophic failure!");
                WriteLog($"Application Domain Is Terminating: {e.IsTerminating}");
                WriteLog($"Exception: {e.ExceptionObject}");

                if(HasConfigFile)
                    SaveConfigFile();
            }
            catch
            {

            }
        }


        #endregion
    }
}

