using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TRW.CommonLibraries.Data.Core;

namespace TRW.CommonLibraries.Data.Test
{
    [TestClass]
    public class ConnectionTests:TRW.UnitTesting.UnitTestBase
    {
        [TestMethod, Ignore] // Azure doesn't support ACE
        public void TestExcelConnection()
        {
            string excelFile = MoveFileToCurrentWorkingDirectory("sounds.xlsx");
            Assert.IsTrue(System.IO.File.Exists(excelFile));

            using (DAL.ExcelConnector target = new DAL.ExcelConnector(excelFile))
            {
                Assert.IsNotNull(target.DbConnection);
                CustomDataTable targetTable = new CustomDataTable(target);
                targetTable.Fetch("select * from [Sheet1$]");
                Assert.IsTrue(targetTable.First());
            }

        }

        [TestMethod, Ignore] // Azure doesn't support ACE
        public void TestSchema()
        {
            string excelFile = MoveFileToCurrentWorkingDirectory("sounds.xlsx");
            using (DAL.ExcelConnector target = new DAL.ExcelConnector(excelFile))
            {
                Assert.AreEqual(1, target.DataSchema["Sheet1$"]["Note"]);
                CustomDataColumnCollection col = target.DataSchema["Sheet1$"];
                Assert.AreEqual(DataType.String, col[1].Type);
                Assert.AreEqual(DataType.Decimal, col[2].Type);
                Assert.AreEqual(DataType.Decimal, col[3].Type);
                Assert.AreEqual(DataType.String, col[4].Type);
                Assert.AreEqual(DataType.Decimal, col[5].Type);
                Assert.AreEqual(DataType.String, col[6].Type);
                Assert.AreEqual(DataType.String, col[7].Type);

                string query = target.DataSchema.CreateQuery();
                CustomDataTable targetTable = new CustomDataTable(target);
                targetTable.Fetch(query);
                Assert.IsTrue(targetTable.First());
            }
        }

        [TestMethod,Ignore] // TODO: Set up Azure local db to test
        public void TestLocalTestDb()
        {
            using (DAL.SqlConnector con = new DAL.SqlConnector(UnitTestDataBaseConnectionString))
            {
                CustomDataTable target = new CustomDataTable(con);
                Assert.AreEqual(System.Data.ConnectionState.Closed, con.ConnectionState);
                con.Open();
                Assert.AreEqual(System.Data.ConnectionState.Open, con.ConnectionState);
                con.Close();
                Assert.AreEqual(System.Data.ConnectionState.Closed, con.ConnectionState);
            }
        }
    }
}
