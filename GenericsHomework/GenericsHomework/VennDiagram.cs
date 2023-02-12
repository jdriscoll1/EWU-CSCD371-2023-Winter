using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsHomework
{
    public class VennDiagram<TCircleType>
    {
        private List<CircularLinkedList<TCircleType>> CircleList { get; set; } = new List<CircularLinkedList<TCircleType>>();

        public CircularLinkedList<TCircleType> Get(int id) {

            return CircleList[id];
        }

        public void Add(TCircleType firstIndex) {
            CircleList.Add(item: new CircularLinkedList<TCircleType>(firstIndex));
        }

        public override string ToString()
        {
            string output = "";
            foreach (CircularLinkedList<TCircleType> circle in CircleList) {
                output += circle.ToString(); 
            
            }
            return output; 
        }
    }
}
