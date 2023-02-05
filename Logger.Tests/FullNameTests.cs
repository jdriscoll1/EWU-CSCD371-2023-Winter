using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Tests
{
    [TestClass]
    public class FullNameTests
    {

        [TestMethod]
        public void InstantiateFullNameObject_ReturnTrueIfNotNull()
        {
            Assert.IsNotNull(new FullName("Billy", "Joe", null));

        }

        [TestMethod]
        public void InstantiateFullNameObjectWithMiddleName_ReturnTrueIfNotNull()
        {
            Assert.IsNotNull(new FullName("Billy", "Joe", "Bob"));

        }

        [TestMethod]
        public void FullNameComparesByValue_AssertTrueIfObjectsAreEqual()
        {
            FullName name1 = new("Johnny", "Smith", "J");
            FullName name2 = new("Johnny", "Smith", "J");
            Assert.AreEqual(name1, name2);

        }
    }
}
