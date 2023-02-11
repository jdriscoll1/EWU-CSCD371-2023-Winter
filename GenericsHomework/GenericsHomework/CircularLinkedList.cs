namespace GenericsHomework
{
    public class CircularLinkedList<TNodeType>
    {
        private Node? _CurrentNode { get; set; } = null!; 
        private int _Size { get; set; }

        private Node CurrentNode
        {
            get 
            {
                return _CurrentNode!; 
            }

            set 
            {
                ArgumentNullException.ThrowIfNull(value);
                _CurrentNode = value;
            }
        }
        public int Size
        {
            get {
                return _Size; 
            }

            set {
                ArgumentNullException.ThrowIfNull(value);
                _Size = value; 
            
            }
        }

        public void Append(TNodeType data) {
            if (Exists(data)) {
                throw new ArgumentException($"{data} is already added in list");
            }
            Node newNode = new(data, CurrentNode.Next);
            CurrentNode.SetNext(newNode);
            Size++; 
        
        }

        public bool Exists(TNodeType data) {
            for (int i = 0; i < Size; i++) {
                CurrentNode = CurrentNode.Next;
                if (CurrentNode.Value!.Equals(data)) {
                    return true; 
                }
            }
            return false; 
        }


        public override string ToString()
        {
            string linkedListString = "";
            for (int i = 0; i < Size; i++) {
                linkedListString += CurrentNode;
                CurrentNode = CurrentNode.Next; 
            }
            return linkedListString;

        }

        public void Clear() {
            // We have to go through each one and set its reference to itself
            CurrentNode = CurrentNode.Next; 
            for (int i = 0; i < Size - 1; i++) {
                Node previousNode = CurrentNode; 
                CurrentNode = CurrentNode.Next;
                previousNode.Destroy(); 
                
            
            }
            Size = 1; 
        }
        public CircularLinkedList(TNodeType value) {
     
            CurrentNode = new(value);
            CurrentNode.SetNext(CurrentNode);
            Size = 1; 
    
        
        }
        private class Node {
            private TNodeType? _Value { get; set; }
            private Node _Next { get; set; } = null!; 

            public TNodeType Value {
                get {
                    return _Value!; 
                }
                set {
                    ArgumentNullException.ThrowIfNull(value);
                    _Value = value ; 
                
                }
            }

            ~Node() {
                Console.WriteLine("Destructor Was Called ");
            }

            public Node Next
            {
                get
                {
                    return _Next!;
                }
                private set
                {
                    ArgumentNullException.ThrowIfNull(value);
                    _Next = value;

                }
            }

            public void Destroy() {
                Next = this;
            }

            public override string ToString()
            {
                return $"{Value} "; 
            }



            public void SetNext(Node node) {
                Next = node; 
            }

            public Node(TNodeType value, Node nextNode) {
                Value = value;
                Next = nextNode; 
            }
            public Node(TNodeType value)
            {
                Value = value;
    
            }

        }

    }
}