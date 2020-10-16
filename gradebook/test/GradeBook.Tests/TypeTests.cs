using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        public class Person
        {

        }
        public struct Point 
        {
            
        }
        [Fact]
        public void Test1 ()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }

        private void SetInt(ref int z)
        {
            z = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByOut()
        {
            var book1 = GetBook("Book 1");
            OutBookSetName(out book1, "New Name");

            Assert.Equal("New Name", book1.name);
        }

        private void OutBookSetName(out Book book, string name)
        {
            book = new Book(name);
        }
        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.name);
        }

        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
        }
        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.name);
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
            book.name = name;
        }
        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.name);
        }

        private void SetName(Book book, string name)
        {
            book.name = name;
        }
        

        [Fact]
        public void GetBookReturnDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.name);
            Assert.Equal("Book 2", book2.name);
            Assert.NotSame(book1, book2);
        }
        [Fact]
        public void TwoVarsCanReferenceSameObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
