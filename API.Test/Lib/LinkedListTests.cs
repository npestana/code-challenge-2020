using System.Collections;
using API.Lib;
using NUnit.Framework;

namespace API.Test.Lib
{
    public class LinkedListTests
    {
        private LinkedList<int> _list;
        
        [SetUp]
        public void Setup()
        {
            _list = new LinkedList<int>();
        }

        [Test]
        public void IsEmpty()
        {
            Assert.AreEqual(_list.Count, 0);
        }
        
        [Test]
        public void AddSingleItem()
        {
            _list.Add(10);

            Assert.AreEqual(_list.Count, 1);
        }
        
        [Test]
        public void RemoveSingleItem()
        {
            _list.Add(10);
            _list.Remove(10);

            Assert.AreEqual(_list.Count, 0);
        }
        
        [Test]
        public void RemoveSingleItemWithEmptyList()
        {
           Assert.False(_list.Remove(10));
        }
        
        [Test]
        public void RemoveSingleItemNonExistent()
        {
            _list.Add(10);
            
            Assert.False(_list.Remove(20));
        }

        [Test]
        public void AddMultipleItems()
        {
            _list.Add(10);
            _list.Add(20);
            _list.Add(30);

            Assert.AreEqual(_list.Count, 3);
        }
        
        [Test]
        public void AddRemoveSingleItem()
        {
            _list.Add(10);

            Assert.True(_list.Remove(10));
        }

        [Test]
        public void AddRemoveMultipleItems()
        {
            _list.Add(10);
            _list.Add(20);
            _list.Add(30);
            _list.Remove(10);

            _list.Add(40);
            _list.Remove(40);

            _list.Remove(20);
            _list.Remove(30);

            Assert.AreEqual(_list.Count, 0);
        }
        
        [Test]
        public void ContainsItem()
        {
            _list.Add(10);
            
            Assert.True(_list.Contains(10));
        }

        [Test]
        public void DontContainsItem()
        {
            _list.Add(10);
            
            Assert.False(_list.Contains(20));
        }
        
        [Test]
        public void GetEnumeratorEmpty()
        {
            _list.Add(10);

            var enumerator = ((IEnumerable)_list).GetEnumerator();
            
            Assert.False(enumerator.MoveNext());
        }
        
        [Test]
        public void GetEnumeratorSingleItem()
        {
            _list.Add(10);

            var enumerator = _list.GetEnumerator();
            
            Assert.True(enumerator?.Current?.Equals(10));
        }
        
        [Test]
        public void GetEnumeratorTwoItems()
        {
            _list.Add(10);
            _list.Add(20);

            var enumerator = _list.GetEnumerator();
            enumerator.MoveNext();

            Assert.True(enumerator.Current?.Equals(20));
        }
        
        [Test]
        public void GetEnumeratorTwoItemsReset()
        {
            _list.Add(10);
            _list.Add(20);

            var enumerator = _list.GetEnumerator();
            enumerator.MoveNext();
            enumerator.Reset();

            Assert.True(enumerator.Current?.Equals(10));
        }
    }
}
