using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TRW.CommonLibraries.Core.Tests
{
    [TestClass]
    public class CollectionsTests : TRW.UnitTesting.UnitTestBase
    {
        [TestMethod]
        public void FilterStringTest()
        {
            FilterableCollection<string> stringCol = new FilterableCollection<string>();
            stringCol.Add("Test");
            stringCol.Add("Fun");
            Assert.AreEqual(2, stringCol.Count);

            stringCol.Add("Test1");

            stringCol.Filter((t) => t == "Test");
            Assert.AreEqual(1, stringCol.Count);

            stringCol.ClearFilter();
            Assert.AreEqual(3, stringCol.Count);
            
            stringCol.Filter((t) => t.Item.StartsWith("Test"));
            Assert.AreEqual(2, stringCol.Count);

        }

        [TestMethod]
        public void FilterClassTest()
        {
            FilterableCollection<TestClass> classCol = new FilterableCollection<TestClass>();
            classCol.Add(new TestClass("Fun"));
            classCol.Add(new TestClass("Test"));
            Assert.AreEqual(2, classCol.Count);

            classCol.Filter((t) => t.Item.Prop == "Test");
            Assert.AreEqual(1, classCol.Count);

            classCol[1].OtherProp = "OtherProperty";
            classCol.Add(new TestClass("NoTest"));
            Assert.AreEqual(1, classCol.Count);
            Assert.AreEqual("OtherProperty", classCol[1].OtherProp);

            classCol.ClearFilter();
            Assert.AreEqual(3, classCol.Count);

            bool foundIt = false;
            foreach (TestClass c in classCol)
            {
                if (c.OtherProp == "OtherProperty"
                    && c.Prop == "Test")
                    foundIt = true;
            }

            Assert.IsTrue(foundIt);
        }

        [TestMethod]
        public void FilterIntegersTest()
        {
            FilterableCollection<int> col = new FilterableCollection<int>();
            col.Add(1);
            col.Add(17);
            col.Add(-5);
            col.Add(200);

            Assert.AreEqual(4, col.Count);

            col.Filter(t => t > 100);

            Assert.AreEqual(1, col.Count);
            Assert.AreEqual(3, col.FilteredCount);

            col.Filter(t => t > 10 && t < 20);

            Assert.AreEqual(1, col.Count);
            // index aligns to filtered
            Assert.AreEqual(17, col[1]);

            int[] expected = new int[1]{ 17};
            int count = 0;
            foreach(int i in col)
            {
                Assert.AreEqual(expected[count++], i);
            }
        }

        [TestMethod]
        public void FilterWithDuplicatesTest()
        {
            FilterableCollection<int> col = new FilterableCollection<int>();
            col.Add(10);
            col.Add(10);
            col.Add(100);
            col.Add(1);

            col.Filter(t => t == 10);
            Assert.AreEqual(2, col.Count);

            col[0] = 1;
            Assert.AreEqual(1, col.Count);

            col.ClearFilter();
            Assert.AreEqual(1, col[0]);

            col.Filter(t => t == 1);
            Assert.AreEqual(2, col.Count);

            FilterableCollection<TestClass> col2 = new FilterableCollection<TestClass>();
            col2.Add(new TestClass("T"));
            col2.Add(new TestClass("E"));
            col2.Add(new TestClass("F"));

            col2[0].OtherProp = "P";
            col2[2].OtherProp = "P";

            col2.Filter(t => t.Item.OtherProp == "P");
            Assert.AreEqual(2, col2.Count);
        }

        [TestMethod]
        public void RectangleCollectionTest()
        {
            RectangularCollection<TestClass> col = new RectangularCollection<TestClass>(10, 10);
            Assert.IsNotNull(col);
            Assert.AreEqual(10, col.Width);
            Assert.AreEqual(10, col.Height);
            Assert.AreEqual(100, col.Count);
            
            Assert.IsFalse(col.FirstNonNull());
            
            col.Fill();
            col.First();
            do
            {
                col.Current = new TestClass("Test");
            } while (col.Next());

            Assert.IsTrue(col.FirstNonNull());
            
            foreach (TestClass test in col)
                Assert.AreEqual("Test", test.Prop);

            // test that GetEnumerator didn't break something
            Assert.IsNotNull(col[0, 0]);
            Assert.AreEqual("Test", col[0, 0].Prop);
            Assert.IsNotNull(col[9, 9]);
            Assert.AreEqual("Test", col[9, 9].Prop);

        }
        
        [TestMethod]
        public void RectangleCollectionFindTest()
        {
            RectangularCollection<TestClass> col = new RectangularCollection<TestClass>(10, 10);
            int iterator = 0;
            col.First();
            do
            {
                col.Current = new TestClass(iterator.ToString());
                iterator++;
            } while (col.Next());

            Tuple<int, int> loc = col.Find(new TestClass("3"));
            Assert.IsNotNull(loc);
            Assert.AreEqual(3, loc.Item1);
            Assert.AreEqual(0, loc.Item2);
        }

        [TestMethod]
        public void NodeTreeTest()
        {
            NodeTree<string> tree = new NodeTree<string>();
            tree.Root = new Node<string>(tree, "Root");
            tree.Root.Left = new Node<string>(tree, "L1");
            tree.Root.Right = new Node<string>(tree, "R1");
            tree.Root.Left.Left = new Node<string>(tree, "LL2");
            tree.Root.Left.Right = new Node<string>(tree, "LR2");
            tree.Root.Right.Left = new Node<string>(tree, "RL3");
            tree.Root.Right.Right = new Node<string>(tree, "RR3");
            tree.Root.Left.Left.Left = new Node<string>(tree, "LL3");

            /*
             *           Root
             *          /    \
             *        L1      R1
             *       /  \    /  \
             *      LL2 LR2 RL3  RR3
             *     / \
             *   LL3
             */

            #region PreOrder
            tree.TraversalStyle = TraversalStyles.PreOrder;
            Assert.IsTrue(tree.First());
            Assert.AreEqual("Root", tree.Current.Data);
            Assert.IsTrue(tree.Next());
            Assert.AreEqual("L1", tree.Current.Data);
            Assert.IsTrue(tree.Next());
            Assert.AreEqual("LL2", tree.Current.Data);
            Assert.IsTrue(tree.Next());
            Assert.AreEqual("LL3", tree.Current.Data);
            Assert.IsTrue(tree.Next());
            Assert.AreEqual("LR2", tree.Current.Data);
            Assert.IsTrue(tree.Next());
            Assert.AreEqual("R1", tree.Current.Data);
            Assert.IsTrue(tree.Next());
            Assert.AreEqual("RL3", tree.Current.Data);
            Assert.IsTrue(tree.Next());
            Assert.AreEqual("RR3", tree.Current.Data);
            Assert.IsFalse(tree.Next());
            #endregion

            #region InOrder
            tree.TraversalStyle = TraversalStyles.InOrder;
            Assert.IsTrue(tree.First());
            Assert.AreEqual("LL3", tree.Current.Data);
            Assert.IsTrue(tree.Next());
            Assert.AreEqual("LL2", tree.Current.Data);
            Assert.IsTrue(tree.Next());
            Assert.AreEqual("L1", tree.Current.Data);
            Assert.IsTrue(tree.Next());
            Assert.AreEqual("LR2", tree.Current.Data);
            Assert.IsTrue(tree.Next());
            Assert.AreEqual("Root", tree.Current.Data);
            Assert.IsTrue(tree.Next());
            Assert.AreEqual("RL3", tree.Current.Data);
            Assert.IsTrue(tree.Next());
            Assert.AreEqual("R1", tree.Current.Data);
            Assert.IsTrue(tree.Next());
            Assert.AreEqual("RR3", tree.Current.Data);
            Assert.IsFalse(tree.Next());
            #endregion

            #region PostOrder
            tree.TraversalStyle = TraversalStyles.PostOrder;
            Assert.IsTrue(tree.First());
            Assert.AreEqual("LL3", tree.Current.Data);
            Assert.IsTrue(tree.Next());
            Assert.AreEqual("LL2", tree.Current.Data);
            Assert.IsTrue(tree.Next());
            Assert.AreEqual("LR2", tree.Current.Data);
            Assert.IsTrue(tree.Next());
            Assert.AreEqual("L1", tree.Current.Data);
            Assert.IsTrue(tree.Next());
            Assert.AreEqual("RL3", tree.Current.Data);
            Assert.IsTrue(tree.Next());
            Assert.AreEqual("RR3", tree.Current.Data);
            Assert.IsTrue(tree.Next());
            Assert.AreEqual("R1", tree.Current.Data);
            Assert.IsTrue(tree.Next());
            Assert.AreEqual("Root", tree.Current.Data);
            Assert.IsFalse(tree.Next());
            #endregion
        }

        [TestMethod]
        public void BinarySearchTest()
        {
            SearchTree<string> tree = new SearchTree<string>();
            tree.Insert("Aardvark");
            tree.Insert("Xylophone");
            tree.Insert("A");
            tree.Insert("Zipper");
            tree.Insert("Mnemonic");
            tree.Insert("Alphabet");

            Assert.IsTrue(tree.Contains("A"));
            Assert.IsTrue(tree.Contains("Zipper"));
            Assert.IsTrue(tree.Contains("Xylophone"));
            Assert.IsTrue(tree.Contains("Alphabet"));
            Assert.IsTrue(tree.Contains("Aardvark"));
            Assert.IsTrue(tree.Contains("Mnemonic"));
            Assert.IsFalse(tree.Contains("Test"));

            Assert.IsTrue(tree.Find("Mnemonic", out Node<string> mnemonicNode));
            Assert.IsNotNull(mnemonicNode);

        }
    }
}
