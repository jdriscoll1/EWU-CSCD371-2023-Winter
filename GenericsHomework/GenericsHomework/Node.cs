using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GenericsHomework
{
    public class Node<TNodeType>
    {

        // We need to add a constructor that takes a value 
        // We also need a constructor that takes a value and a next value
        // Rename CircularLinkedList to Node
        // Remove the interior Node class
        // Remove the Set Next 
        // We remove Current Node
        // We get rid of size replacing for loops with while curr != header; 
        private Node<TNodeType>? _Next { get; set; }

        private TNodeType? _Value;

        public TNodeType? Value
        {
            get {
                return _Value; 
            }
            private set {
                _Value = value;
            }
        }        
       

        public Node<TNodeType> Next
        {
            get {
                return _Next!; 
            }
            private set {
                ArgumentNullException.ThrowIfNull(value);
                _Next = value; 
            }
        }

        public Node(TNodeType value)
        {
            Value = value;
            Next = this; 
        }

        private Node(TNodeType value, Node<TNodeType> next) {
            Value = value; 
            Next = next;
        }



        public void Append(TNodeType data) {
            if (Exists(data)) {
                throw new ArgumentException($"{data} is already added in list");
            }
            
            Node<TNodeType> newNode = new(data, Next);
            Console.WriteLine(newNode.Value);
            Next = newNode; 
        
        }

        public bool Exists(TNodeType data) {
            Node<TNodeType> head = this;
            Node<TNodeType> curr = head;
            do
            {
                if (EqualityComparer<TNodeType>.Default.Equals(data, curr.Value))
                {
                    return true;
                }
                curr = curr.Next; 

            } while (curr != head);
            return false; 
        }


        public override string ToString()
        {
            string linkedListString = Value + " ";
            Node<TNodeType> head = this;
            Node<TNodeType> curr = Next;
            while (curr != head)
            {
                linkedListString += curr.Value + " ";
                curr = curr.Next;
            }
            return linkedListString;

        }

        public void Clear() {
            // It is sufficient to set the current node's next to itself, this will allow the garbage collector to clean the whole linked list. 
            // We don't need to go through each individual and close the loop on it, setting it to itself
            // This is becaues the garbage collector will recognize that the first
            // Item in the list has no reference pointing to it, and will clean it, then look at the next one. This will occur recursively 
            // We tested to see if the Garbage Collector arrives sooner if each reference points to itself; however, the destructor
            // showed no signs of enhancement
            // We don't need the removed items to circle back on themselves because if they have a reference to themselves they may not be collected
            // Thus they cannot be in a a circle, because if there is a circular list of items, you will have to worry about garbage collection at least until the program closes

            Next = this; 
        }
  

    }
}