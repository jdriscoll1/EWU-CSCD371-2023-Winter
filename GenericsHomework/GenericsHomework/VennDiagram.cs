using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsHomework
{
    public class VennDiagram<TCircleType>
    {
        private List<Node<TCircleType>> CircleList { get; set; } = new List<Node<TCircleType>>();

        public Node<TCircleType> Get(int id)
        {

            return CircleList[id];
        }

        public void Add(TCircleType firstIndex)
        {
            CircleList.Add(item: new Node<TCircleType>(firstIndex));
        }

        public override string ToString()
        {
            string output = "";
            foreach (Node<TCircleType> circle in CircleList)
            {
                foreach (TCircleType element in circle) {
                    output += element; 
                }
                

            }
            return output;
        }


    }
}
    
