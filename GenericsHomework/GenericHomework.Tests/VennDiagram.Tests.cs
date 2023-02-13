using GenericsHomework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsHomework.Tests
{
    
    [TestClass]
    public class VennDiagram
    {

        VennDiagram<int> TestVennDiagram { get; set; } = null!; 
        [TestInitialize]
        public void InstantateVennDiagram()
        {
            TestVennDiagram = new VennDiagram<int>();
            TestVennDiagram.Add(0);
            TestVennDiagram.Add(1);
            TestVennDiagram.Get(0).Append(1);
            TestVennDiagram.Get(0).Append(2);
            TestVennDiagram.Get(1).Append(2);
            TestVennDiagram.Get(1).Append(3);

        }
        [TestMethod]
        public void InstantiateVennDiagram() {

            VennDiagram<char> charDiagram = new();
            charDiagram.Add('A');
            charDiagram.Add('B');
            charDiagram.Get(0).Append('C');
            charDiagram.Get(0).Append('D');
            charDiagram.Get(1).Append('E');
            charDiagram.Get(1).Append('F');
            string expected = "A D C B F E ";
            Assert.AreEqual<string>(expected, charDiagram.ToString());

        }

        [TestMethod]
        public void PrintVennDiagram()
        {
            string expected = "0 2 1 1 3 2 ";
            Assert.AreEqual<string>(expected, TestVennDiagram.ToString());

        }

    
    }
}
