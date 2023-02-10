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
        public CircularLinkedList(TNodeType value) {
     
            Node CurrentNode = new(value);
            CurrentNode.SetNext(CurrentNode); 
    
        
        }
        private class Node {
            private TNodeType? _Value { get; set; }
            private Node _NextNode { get; set; } = null!; 

            private TNodeType Value {
                get {
                    return _Value!; 
                }
                set {
                    ArgumentNullException.ThrowIfNull(value);
                    _Value = value ; 
                
                }
            }

            private Node NextNode
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