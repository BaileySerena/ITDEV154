using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAddressing
{
    class HashTable
    {
        private GroceryRecord[] array;
        private int m; //size of the array
        int n, j, i, tmp; //number of records

        public HashTable() : this(11)
        { }

        public HashTable(int tableSize)
        {
            m = tableSize;
            array = new GroceryRecord[m];
            n = 0;
        }

        int hash(int key)
        {
            return (key % m);
        }

        public void Insert(GroceryRecord newRecord)
        {
            int key = newRecord.getgroceryId();
            int h = hash(key);

            int location = h;

            for (int i = 1; i < m; i++)
            {
                if (array[location] == null || array[location].getgroceryId() == -1)
                {
                    array[location] = newRecord;
                    n++;
                    return;
                }

                if (array[location].getgroceryId() == key)
                    throw new System.InvalidOperationException("Duplicate key");

                location = (h + i) % m;
            }
            Console.WriteLine("table is full : item can't be inserted ");
        }

        public GroceryRecord Search(int key)
        {
            int h = hash(key);
            int location = h;

            for (int i = 1; i < m; i++)
            {
                if (array[location] == null)
                    return null;
                if (array[location].getgroceryId() == key)
                    return array[location];
                location = (h + i) % m;
            }
            return null;
        }

        public void Insert1(GroceryRecord newRecord)
        {
            if (n >= m / 2)
            {
                rehash(nextPrime(2 * m));
                Console.WriteLine("New List Size is : " + m);
            }
            Insert(newRecord);
        }

        private void rehash(int newSize)
        {
            HashTable temp = new HashTable(newSize);

            for (int i = 0; i < m; i++)
                if (array[i] != null && array[i].getgroceryId() != -1)
                    temp.Insert(array[i]);

            array = temp.array;
            m = newSize;
        }

        int nextPrime(int x)
        {
            while (!isPrime(x))
                x++;
            return x;
        }

        bool isPrime(int x)
        {
            for (int i = 2; i < x; i++)
            {
                if (x % i == 0)
                    return false;   
            }
            return true;
        }

        public void DisplayTable()
        {
            for (int i = 0; i < m; i++)
            {
                Console.Write("[" + i + "] --> ");

                if (array[i] != null && array[i].getgroceryId() != -1)
                    Console.WriteLine(array[i].toString());
                else Console.WriteLine("___");
            }
        }

        public void DisplayTableAsc()
        {
            for (int i = 0; i < m; i++)
            {
                Console.Write("[" + i + "] --> ");

                if (array[i] != null && array[i].getgroceryId() != -1)
                    Console.WriteLine(array[i].toString());
                else Console.WriteLine("___");
            }
        }

        public void DisplayTableDesc()
        {
            for (int i = 0; i < m; i++)
            {
                Console.Write("[" + i + "] --> ");

                if (array[i] != null && array[i].getgroceryId() != -1)
                    Console.WriteLine(array[i].toString());
                else Console.WriteLine("___");
            }
        }

        public GroceryRecord Delete(int key)
        {
            int h = hash(key);
            int location = h;

            for (int i = 1; i < m; i++)
            {
                if (array[location] == null)
                    return null;
                if (array[location].getgroceryId() == key)
                {
                    GroceryRecord temp = array[location];
                    array[location].setgroceryId(-1);
                    n--;
                    return temp;
                }
                location = (h + i) % m;
            }
            return null;
        }
    }
}
