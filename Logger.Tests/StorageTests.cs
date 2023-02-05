﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Tests
{
    [TestClass]
    public class StorageTests
    {
        // Test Add and Get 
        [TestMethod]
        public void ValidateRecordStorageValidateAddAndGet()
        {
            // Arrange
            Storage recordStorage = new();
            string isbn = "12345";
            FullName author = new("Poe", "Edgar", "Alan");
            Book bookRecord = new("The Cat In The Hat", author, isbn);
            Guid bookID = bookRecord.Id;

            // Act
            recordStorage.Add(bookRecord);
            Book storedBook = recordStorage.Get(bookID) as Book ?? throw new ArgumentNullException();

            // Assert
            Assert.AreEqual<Book>(storedBook, bookRecord);

        }

    
        [TestMethod]
        public void ValidateRecordStorageRemoveReturnTrueIfContainsIsTrue()
        {
            Storage recordStorage = new();
            FullName author = new("Poe", "Edgar", "Alan");
            Book bookRecord = new("The Cat In The Hat", author, "12345");

            // Act 
            recordStorage.Add(bookRecord);

            // Assert
            Assert.IsTrue(recordStorage.Contains(bookRecord));
        }

        [TestMethod]
        public void ValidateRecordStorageRemoveReturnTrueIfContainsIsFalse()
        {
            Storage recordStorage = new();
            FullName author = new("Poe", "Edgar", "Alan");
            Book bookRecord = new("The Cat In The Hat", author, "12345");

            // Act 
            recordStorage.Add(bookRecord);

            // Assert
            recordStorage.Remove(bookRecord);
            Assert.IsFalse(recordStorage.Contains(bookRecord));

        }

    }
}

