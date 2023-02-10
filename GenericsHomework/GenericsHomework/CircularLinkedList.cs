namespace GenericsHomework
{
    public class CircularLinkedList<TNodeType>
    {
        private Node CurrentNode; 
        private int Size; 
        public CircularLinkedList(TNodeType value) {
     
            Node CurrentNode = new(value);
            CurrentNode.SetNext(CurrentNode); 
    
        
        }
        private class Node {
            private TNodeType _Value { get;  }
            private Node _NextNode { get; set; }

            private TNodeType Value {
                get {
                    return _Value; 
                }
                set { 

                
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