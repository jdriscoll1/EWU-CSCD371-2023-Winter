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
            Node newNode = new(data, CurrentNode.NextNode);
            CurrentNode.SetNext(newNode);
            Size++; 
        
        }

        public bool Exists(TNodeType data) {
            for (int i = 0; i < Size; i++) {
                CurrentNode = CurrentNode.NextNode;
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
                linkedListString = linkedListString + CurrentNode.Value + " ";
                CurrentNode = CurrentNode.NextNode; 
            }
            return linkedListString;

        }
        public CircularLinkedList(TNodeType value) {
     
            CurrentNode = new(value);
            CurrentNode.SetNext(CurrentNode);
            Size = 1; 
    
        
        }
        private class Node {
            private TNodeType? _Value { get; set; }
            private Node _NextNode { get; set; } = null!; 

            public TNodeType Value {
                get {
                    return _Value!; 
                }
                set {
                    ArgumentNullException.ThrowIfNull(value);
                    _Value = value ; 
                
                }
            }

            public Node NextNode
            {
                get
                {
                    return _NextNode!;
                }
                set
                {
                    ArgumentNullException.ThrowIfNull(value);
                    _NextNode = value;

                }
            }



            public void SetNext(Node node) {
                NextNode = node; 
            }

            public Node(TNodeType value, Node nextNode) {
                Value = value;
                NextNode = nextNode; 
            }
            public Node(TNodeType value)
            {
                Value = value;
    
            }

        }

    }
}