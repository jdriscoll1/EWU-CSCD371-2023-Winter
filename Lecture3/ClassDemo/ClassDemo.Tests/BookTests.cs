using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemo.Tests
{
    [TestClass]
    public class BookTests
    {
        [TestMethod]
        public void Create_Book_Success() {
            Book book = new Book("The Purple Crayon", "Author", "ISBN"); 
        }
    }
}
