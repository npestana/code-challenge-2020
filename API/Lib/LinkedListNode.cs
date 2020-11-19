namespace API.Lib
{
    /// <summary>
    /// Linked List Node representation.
    /// </summary>
    /// <typeparam name="TNodeItem">LinkedList Node item type.</typeparam>
    public class LinkedListNode<TNodeItem>
    {
        /// <summary>
        /// Node Value.
        /// </summary>
        public TNodeItem Value { get; }
        
        /// <summary>
        /// Next Node in the Linked List.
        /// </summary>
        public LinkedListNode<TNodeItem> NextNode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">Node value.</param>
        /// <param name="nextNode">Next Linked List node.</param>
        public LinkedListNode(TNodeItem value, LinkedListNode<TNodeItem> nextNode = null)
        {
            Value = value;
            NextNode = nextNode;
        }
    }
}
