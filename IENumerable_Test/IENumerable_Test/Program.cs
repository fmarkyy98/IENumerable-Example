using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IENumerable_Test
{

    public class Person
    {
        public string firstName;
        public string lastName;

        public Person(string fName, string lName)
        {
            this.firstName = fName;
            this.lastName = lName;
        }
    }

    public class People : IEnumerable
    {
        private Person[] _people;

        public People(Person[] pArray)
        {
            this._people = pArray;
            //_people = new Person[pArray.Length];

            //for (int i = 0; i < pArray.Length; i++)
            //{
            //    _people[i] = pArray[i];
            //}
        }

        // Implementation for the GetEnumerator method.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
        //IEnumerator IEnumerable.GetEnumerator()
        //      {
        //          throw new NotImplementedException();
        //      }

        public PeopleEnum GetEnumerator()
        {
            return new PeopleEnum(_people);
        }
    }

    public class PeopleEnum : IEnumerator
    {
        public Person[] _people;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;

        public PeopleEnum(Person[] list)
        {
            this._people = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _people.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Person Current
        {
            get
            {
                try
                {
                    return _people[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
    // LÓFASZ
    class Program
    {
        static void Main(string[] args)
        {
            Person[] peopleArray = { new Person("John", "Smith"), new Person("Jim", "Johnson"), new Person("Sue", "Rabon") };

            People peopleList = new People(peopleArray);
            foreach (Person p in peopleList)
                Console.WriteLine(p.firstName + " " + p.lastName);
            Console.ReadKey();
        }
    }
}
