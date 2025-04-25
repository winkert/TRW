using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TRW.UnitTesting
{
    [TestClass]
    public abstract class UnitTestBase
    {
        protected const string UnitTestDataBaseConnectionString = @"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;";

        public TestContext TestContext { get; set; }

        private static string _unitTestTempFolder;

        protected static string UnitTestTempFolder 
        {
            get
            {
                if(string.IsNullOrEmpty(_unitTestTempFolder))
                {
                    _unitTestTempFolder = Path.Combine(Path.GetTempPath(), $"UnitTest{DateTime.Now:yyyyMMddhhmmss}");
                    if (!Directory.Exists(_unitTestTempFolder))
                        Directory.CreateDirectory(_unitTestTempFolder);
                }
                return _unitTestTempFolder;
            }
            private set { _unitTestTempFolder = value; } 
        }

        private static string _unitTestExecutionFolder;
        protected static string UnitTestExecutionFolder
        {
            get
            {
                if (string.IsNullOrEmpty(_unitTestExecutionFolder))
                {
                    _unitTestExecutionFolder = Environment.CurrentDirectory;
                }
                return _unitTestExecutionFolder;
            }
            private set { _unitTestExecutionFolder = value; }
        }

        [TestInitialize]
        public void TestInit()
        {
            UnitTestExecutionFolder = Environment.CurrentDirectory;

            UnitTestTempFolder = Path.Combine(Path.GetTempPath(), $"UnitTest{DateTime.Now:yyyyMMddhhmmss}");
            if (!Directory.Exists(UnitTestTempFolder))
                Directory.CreateDirectory(UnitTestTempFolder);
        }

        [TestCleanup]
        public void CleanUp()
        {
            if (Directory.Exists(UnitTestTempFolder))
            {
                try
                {
                    foreach (string file in Directory.EnumerateFiles(UnitTestTempFolder))
                    {
                        try
                        {
                            File.Delete(file);
                        }
                        finally
                        {

                        }
                    }
                    Directory.Delete(UnitTestTempFolder, true);
                }
                catch(IOException)
                {
                    // ignore because maybe we can't delete the folder. Who cares?
                }
            }
        }


        protected static string MoveFileToCurrentWorkingDirectory(string fileName)
        {
            string searchPattern = $"*{Path.GetExtension(fileName)}";
            string path = Path.Combine(UnitTestTempFolder, fileName);
            foreach (string file in Directory.EnumerateFiles(UnitTestExecutionFolder, searchPattern, SearchOption.AllDirectories))
            {
                if (Path.GetFileName(file).Equals(fileName))
                {
                    File.Copy(file, Path.Combine(UnitTestTempFolder, fileName));
                    return path;
                }
            }
            foreach (string dir in Directory.EnumerateDirectories(UnitTestExecutionFolder))
            {
                foreach (string file in Directory.EnumerateFiles(dir))
                {
                    if (Path.GetFileName(file).Equals(fileName))
                    {
                        File.Copy(file, Path.Combine(UnitTestTempFolder, fileName));
                        return path;
                    }
                }
            }

            return path;
        }
    }
}
