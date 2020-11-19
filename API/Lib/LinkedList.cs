using System.Collections;

namespace API.Lib
{
    /// <summary>
    /// Linked List representation.
    /// </summary>
    /// <typeparam name="TListItem">Linked List item type.</typeparam>
    public class LinkedList<TListItem> : IEnumerable
    {
        /// <summary>
        /// First Linked List Node.
        /// </summary>
        private LinkedListNode<TListItem> _firstNode;

        /// <summary>
        /// Total items in the Linked List.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Add an item to the end of the Linked List.
        /// </summary>
        /// <param name="item">Item to be added.</param>
        public void Add(TListItem item)
        {
            Count++;
            var nodeItem = new LinkedListNode<TListItem>(item);

            if (_firstNode == null)
            {
                _firstNode = nodeItem;
                return;
            }

            var currentNode = _firstNode;

            while (currentNode.NextNode != null)
            {
                currentNode = currentNode.NextNode;
            }

            currentNode.NextNode = nodeItem;
        }

        /// <summary>
        /// Remove an item from the Linked List.
        /// </summary>
        /// <param name="item">Item to remove.</param>
        /// <returns>Returns true if removed the item.</returns>
        public bool Remove(TListItem item)
        {
            if (_firstNode == null)
            {
                return false;
            }

            var currentNode = _firstNode;
            LinkedListNode<TListItem> previousLinkedListNode = null;

            while (currentNode != null && !currentNode.Value.Equals(item))
            {
                previousLinkedListNode = currentNode;
                currentNode = currentNode.NextNode;
            }

            if (currentNode == null)
            {
                return false;
            }

            if (previousLinkedListNode == null)
            {
                _firstNode = currentNode.NextNode;
            }
            else
            {
                previousLinkedListNode.NextNode = currentNode.NextNode;
            }

            Count--;

            return true;
        }

        /// <summary>
        /// Check if an item exists in the Linked List.
        /// </summary>
        /// <param name="item">Item to search.</param>
        /// <returns>Returns true if found the item in the Linked List.</returns>
        public bool Contains(TListItem item)
        {
            var currentNode = _firstNode;

            while (currentNode != null)
            {
                if (currentNode.Value.Equals(item))
                {
                    return true;
                }

                currentNode = currentNode.NextNode;
            }

            return false;
        }

        /// <summary>
        /// Get the Linked List enumerator.
        /// </summary>
        /// <returns>Returns a new Linked List enumerator.</returns>
        public IEnumerator GetEnumerator()
        {
            return new LinkedListEnumerator<TListItem>(_firstNode);
        }

        /// <summary>
        /// Get the Linked List enumerator.
        /// </summary>
        /// <returns>Returns a new Linked List enumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        /// <summary>
        /// Linked List enumerator.
        /// </summary>
        /// <typeparam name="TEnumeratorType">Linked List item type.</typeparam>
        public class LinkedListEnumerator<TEnumeratorType> : IEnumerator
        {
            /// <summary>
            /// First Linked List node.
            /// </summary>
            private readonly LinkedListNode<TEnumeratorType> _firstNode;
            
            /// <summary>
            /// Current node in the enumerator.
            /// </summary>
            private LinkedListNode<TEnumeratorType> _currentNode;

            /// <summary>
            /// Linked List constructor with first node.
            /// </summary>
            /// <param name="firstNode">Linked List first node.</param>
            public LinkedListEnumerator(LinkedListNode<TEnumeratorType> firstNode)
            {
                _currentNode = _firstNode = firstNode;
            }

            /// <summary>
            /// Move to the next node in the Linked List.
            /// </summary>
            /// <returns>Returns true if successfully moved.</returns>
            public bool MoveNext()
            {
                if (_currentNode.NextNode == null)
                {
                    return false;
                }

                _currentNode = _currentNode.NextNode;
                return true;
            }

            /// <summary>
            /// Reset the enumerator to the first node.
            /// </summary>
            public void Reset()
            {
                _currentNode = _firstNode;
            }

            /// <summary>
            /// Current Linked List item in the enumerator.
            /// </summary>
            object IEnumerator.Current => Current;

            /// <summary>
            /// Current Linked List item in the enumerator.
            /// </summary>
            public TEnumeratorType Current => _currentNode.Value;
        }
    }
}
