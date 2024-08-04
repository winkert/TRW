using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TRW.CommonLibraries.Data;
using TRW.CommonLibraries.Data.Core;

namespace TRW.CommonLibraries.Data.Test
{
    [TestClass]
    public class CustomDataTableTests : UnitTesting.UnitTestBase
    {
        CustomDataColumn[] _testColumns = new CustomDataColumn[] { new CustomDataColumn("String", DataType.String), new CustomDataColumn("Int", DataType.Integer), new CustomDataColumn("Bool", DataType.Boolean), new CustomDataColumn("Date", DataType.DateTime) };

        [TestMethod, Ignore]
        public void ConnectedTableTest()
        {
            using (Data.DAL.SqlConnector con = new DAL.SqlConnector(UnitTestDataBaseConnectionString))
            {
                con.ExecuteQuery(@"CREATE TABLE Test(id int, value varchar(max)");
                CustomDataTable target = new CustomDataTable(con);
                target.Fetch(@"select id, value from Test");
                Assert.IsFalse(target.First());
            }
        }

        [TestMethod]
        public void DataTableInstantiationTest()
        {
            CustomDataTable tableNoParameters = new CustomDataTable();
            Assert.IsNotNull(tableNoParameters);

            CustomDataTable tableWithColumns = new CustomDataTable(_testColumns);
            Assert.AreEqual(_testColumns.Length, tableWithColumns.Columns.Count);
            for (int i = 0; i < _testColumns.Length; i++)
            {
                Assert.AreEqual(_testColumns[i].Name, tableWithColumns.Columns[i].Name);
            }
            // need to do some unit test work to create data bases etc to test connections
        }

        [TestMethod]
        public void DataTableAddRowTest()
        {
            DateTime now = DateTime.Now;
            CustomDataTable table = new CustomDataTable(_testColumns);
            table.Add();
            table.Current["String"] = "TestString1";
            table["Int"] = 1;
            table[2] = false;
            table["Date"] = now;

            table.Add();
            table.Current[0] = "TestString2";
            table["Int"] = 2;
            table["Bool"] = true;
            table["Date"] = now;

            Assert.IsTrue(table.First());
            Assert.AreEqual(table.Current["String"], "TestString1");
            Assert.AreEqual(table[1], 1);
            Assert.IsFalse(Convert.ToBoolean(table.Current["Bool"]));
            Assert.AreEqual(now, table.Current["Date"]);

            Assert.IsTrue(table.Next());
            Assert.AreEqual(table.Current["String"], "TestString2");
            Assert.AreEqual(table[1], 2);
            Assert.IsTrue(Convert.ToBoolean(table.Current["Bool"]));
            Assert.AreEqual(now, table.Current["Date"]);
        }

        [TestMethod]
        public void DataTableDeleteRowTest()
        {
            DateTime now = DateTime.Now;
            CustomDataTable table = new CustomDataTable(_testColumns);
            table.Add();
            table.Current["String"] = "TestString1";
            table["Int"] = 1;
            table[2] = false;
            table["Date"] = now;

            table.Add();
            table.Current[0] = "TestString2";
            table["Int"] = 2;
            table["Bool"] = true;
            table["Date"] = now;

            table.First();
            table.Delete();
            Assert.AreEqual(1, table.Count);
            Assert.IsTrue(table.First());
            Assert.AreEqual("TestString2", table.Current[0]);

            table.Delete();
            Assert.IsNull(table.Current);
        }

        [TestMethod]
        public void DataTableEnumeratorTest()
        {
            DateTime now = DateTime.Now;
            CustomDataTable table = new CustomDataTable(_testColumns);
            for (int i = 0; i < 100; i++)
            {
                table.Add();
                table["String"] = string.Format("TestString{0:0000}", i);
                table["Int"] = i;
                table[2] = true;
                table["Date"] = now;
            }

            if (table.First())
            {
                do
                {
                    table["Bool"] = false;
                } while (table.Next());
            }

            int val = 0;
            foreach (CustomDataRow row in table)
            {
                Assert.AreEqual(string.Format("TestString{0:0000}", val), row["String"]);
                Assert.AreEqual(val++, row["Int"]);
                Assert.IsFalse(Convert.ToBoolean(row["Bool"]));
                Assert.AreEqual(now, row["Date"]);
            }

            Assert.IsNotNull(table.GetEnumerator());
            Assert.AreEqual(table.Count, val);
        }

        [TestMethod]
        public void DataTableSerializeMethodTest()
        {
            DateTime now = DateTime.Now;
            CustomDataTable table = new CustomDataTable(_testColumns);
            for (int i = 0; i < 100; i++)
            {
                table.Add();
                table["String"] = string.Format("TestString{0:0000}", i);
                table["Int"] = i;
                table[2] = true;
                table["Date"] = now;
            }

            // add a row with nulls
            table.Add();
            table[2] = false;

            CustomDataTable copyTable = new CustomDataTable();

            string filePath = System.IO.Path.Combine(UnitTestTempFolder, "table.tbl");

            table.SerializeTable(filePath);
            copyTable.DeserializeFromFile(filePath);

            AssertCopiedTables(table, copyTable);
        }

        [TestMethod]
        public void SubClassTests()
        {
            TestDataTable subTable = new TestDataTable();
            Assert.AreEqual(4, subTable.Columns.Count);

            TestDataRow newRow = subTable.Add();
            newRow.NamedStringColumn = "TestString";
            newRow.NamedIntColumn = 1;
            newRow.NamedBoolColumn = true;
            newRow.NamedDecimalColumn = 2.2m;

            newRow = subTable.Add();
            newRow.NamedStringColumn = "TestString2";
            newRow.NamedIntColumn = 2;
            newRow.NamedBoolColumn = true;
            newRow.NamedDecimalColumn = 4.2m;

            Assert.AreEqual(2, subTable.Count);

            // test do while next use of enumerator
            Assert.IsTrue(subTable.First());
            do
            {
                Assert.IsNotNull(subTable.Current.NamedStringColumn);
                Assert.IsNotNull(subTable.Current.NamedIntColumn);
                Assert.IsNotNull(subTable.Current.NamedBoolColumn);
                Assert.IsNotNull(subTable.Current.NamedDecimalColumn);
            } while (subTable.Next());

            // test foreach (implied GetEnumerator call)
            int rowsCounted = 0;
            foreach (TestDataRow row in subTable)
            {
                Assert.IsNotNull(row.NamedStringColumn);
                Assert.IsNotNull(row.NamedIntColumn);
                Assert.IsNotNull(row.NamedBoolColumn);
                Assert.IsNotNull(row.NamedDecimalColumn);
                rowsCounted++;
            }

            Assert.IsNotNull(subTable.Count);
            Assert.AreEqual(subTable.Count, rowsCounted);

            // test serialization and deserialization
            TestDataTable copyTable = new TestDataTable();

            string filePath = System.IO.Path.Combine(UnitTestTempFolder, "table.tbl");
            subTable.SerializeTable(filePath);

            copyTable.DeserializeFromFile(filePath);
            AssertCopiedTables(subTable, copyTable);
        }

        [TestMethod]
        public void DataColumnCollectionSerializationTest()
        {
            CustomDataColumnCollection testDict = new CustomDataColumnCollection(2);
            testDict[0].Name = "Field1";
            testDict[0].SetType(typeof(Boolean));
            testDict[1].Name = "Field2";
            testDict[1].SetType("System.Boolean");

            byte[] value = testDict.Serialize();

            CustomDataColumnCollection copyDict = new CustomDataColumnCollection();
            copyDict.Deserialize(value);

            Assert.AreEqual(testDict.Count, copyDict.Count);
            foreach (KeyValuePair<int, CustomDataColumn> column in testDict)
            {
                Assert.AreEqual(column.Value.Name, copyDict[column.Key].Name);
                Assert.AreEqual(column.Value.Type, copyDict[column.Key].Type);
            }
        }

        [TestMethod]
        public void DataTableIndexTests()
        {
            DateTime now = DateTime.Now;
            CustomDataTable table = new CustomDataTable(_testColumns);
            table.SetIndex("String");

            table.Add();
            table["String"] = "Thad";
            table["Int"] = 1;
            table["Bool"] = false;
            table["Date"] = now;
            table.Add();
            table["String"] = "Katie";
            table["Int"] = 2;
            table["Bool"] = true;
            table["Date"] = now.AddDays(1);

            Assert.IsTrue(table.Seek("Thad"));
            Assert.AreEqual(1, table["Int"]);
            Assert.IsFalse(Convert.ToBoolean(table["Bool"]));

            Assert.IsTrue(table.Seek("Katie"));
            Assert.AreEqual(2, table["Int"]);
            Assert.IsTrue(Convert.ToBoolean(table["Bool"]));

            Assert.IsFalse(table.Seek("Bad"));

            table.SetIndex("Int");
            Assert.IsTrue(table.Seek(1));
            Assert.AreEqual("Thad", table["String"]);
            Assert.IsFalse(Convert.ToBoolean(table["Bool"]));

            Assert.IsTrue(table.Seek(2));
            Assert.AreEqual("Katie", table["String"]);
            Assert.IsTrue(Convert.ToBoolean(table["Bool"]));

            table.SetIndex("Date");
            Assert.IsTrue(table.Seek(now));
            Assert.AreEqual("Thad", table["String"]);
            Assert.IsFalse(Convert.ToBoolean(table["Bool"]));

            Assert.IsTrue(table.Seek(now.AddDays(1)));
            Assert.AreEqual("Katie", table["String"]);
            Assert.IsTrue(Convert.ToBoolean(table["Bool"]));

        }

        [TestMethod]
        public void TestToFromXml()
        {
            DateTime now = DateTime.Parse(DateTime.Now.ToString("G")); // there is some data loss when writing to XML
            CustomDataTable table = new CustomDataTable(_testColumns);
            for (int i = 0; i < 5; i++)
            {
                table.Add();
                table["String"] = string.Format("TestString{0:0000}", i);
                table["Int"] = i;
                table[2] = true;
                table["Date"] = now;
            }

            // add a row with nulls
            table.Add();
            table[2] = false;

            CustomDataTable copyTable = new CustomDataTable(_testColumns);

            string filePath = System.IO.Path.Combine(UnitTestTempFolder, "table.xml");

            table.SaveToXml(filePath);
            copyTable.ReadFromXml(filePath);

            AssertCopiedTables(table, copyTable);
        }

        [TestMethod]
        public void TestToExcel()
        {
            DateTime now = new DateTime(2021,3,15,10,30,12);
            CustomDataTable table = new CustomDataTable(_testColumns);
            for (int i = 0; i < 5; i++)
            {
                table.Add();
                table["String"] = string.Format("TestString{0:0000}", i);
                table["Int"] = i;
                table[2] = true;
                table["Date"] = now;
            }

            // add a row with nulls
            table.Add();

            // add a row below the null one
            table.Add();
            table[2] = false;
            table["Date"] = now.AddMonths(8);
            table[0] = "Row After Blank";

            string filePath = System.IO.Path.Combine(UnitTestTempFolder, "table.xlsx");

            table.SaveToExcel(filePath, true);
            System.IO.FileInfo file = new System.IO.FileInfo(filePath);
            Assert.IsTrue(file.Exists, "File not created");
            Assert.AreEqual(3121, file.Length, "Unexpected file size; confirm the file looks like it should");
        }
        private void AssertCopiedTables<DataRow>(IConnectedDataTable<DataRow> table1, IConnectedDataTable<DataRow> table2) where DataRow : Data.Core.IDataRow
        {
            Assert.AreEqual(table1.Count, table2.Count);
            Assert.AreEqual(table1.Columns, table2.Columns);

            Assert.IsTrue(table1.First());
            Assert.IsTrue(table2.First());

            do
            {
                foreach (var column in table1.Columns)
                {
                    Assert.AreEqual(table1.Current[column.Key], table2.Current[column.Key], string.Format("Column mismatch: Name: [{0}] Type: [{1}]", column.Value.Name, column.Value.Type));
                }
            } while (table1.Next() && table2.Next());
        }

        #region TestSubClasses
        [Serializable]
        public class TestDataTable : CustomDataTable<TestDataRow>
        {
            public TestDataTable()
                : base(new CustomDataColumn("NamedStringColumn", DataType.String), new CustomDataColumn("NamedIntColumn", DataType.Integer), new CustomDataColumn("NamedBoolColumn", DataType.Boolean), new CustomDataColumn("NamedDecimalColumn", DataType.Decimal))
            { }

            public TestDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            { }

            public string NamedStringColumn { get { return Current.NamedStringColumn; } set { Current.NamedStringColumn = value; } }
            public int NamedIntColumn { get { return Current.NamedIntColumn; } set { Current.NamedIntColumn = value; } }
            public bool NamedBoolColumn { get { return Current.NamedBoolColumn; } set { Current.NamedBoolColumn = value; } }
            public decimal NamedDecimalColumn { get { return Current.NamedDecimalColumn; } set { Current.NamedDecimalColumn = value; } }

            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                base.GetObjectData(info, context);
            }

        }

        [Serializable]
        public class TestDataRow : CustomDataRow
        {
            public TestDataRow()
            { }

            public string NamedStringColumn { get { return Convert.ToString(Items[0]); } set { Items[0] = value; } }
            public int NamedIntColumn { get { return Convert.ToInt32(Items[1]); } set { Items[1] = value; } }
            public bool NamedBoolColumn { get { return Convert.ToBoolean(Items[2]); } set { Items[2] = value; } }
            public decimal NamedDecimalColumn { get { return Convert.ToDecimal(Items[3]); } set { Items[3] = value; } }

        }
        #endregion
    }
}
