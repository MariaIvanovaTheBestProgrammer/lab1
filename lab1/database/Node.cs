using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using models;


namespace database
{
    public class Node
    {
        private Person myPerson;
        Node prev, next;
        public Node(Person person)
        {
            this.myPerson = person;
        }
        public Person MyPerson
        {
            get { return this.myPerson; }
            set { this.myPerson = value; }
        }
        public Node Next
        {
            get { return this.next; }
            set { this.next = value; }
        }
        public Node Prev
        {
            get { return this.prev; }
            set { this.prev = value; }
        }
    }
}
