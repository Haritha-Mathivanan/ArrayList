using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arraylib
{
    public class Arraylist
    {
        int[] _arr;
        public Arraylist(int size = 2)
        {
            _arr = new int[size];
            
        }
        public int[] Arr
        {
            get {return _arr;}
        }
        //int _count;
        int _current=0;
        public int Count
        {
            get { return _current; }

        }
        Boolean _isempty=true;

        public Boolean Isempty
        {
            get { return _isempty; }
        }

        int _capacity;

        public int Capacity
        {
            get { return _arr.Length; }
        }
        

        public int Get(int index)
        {
            return _arr[index];
        }
        public void Set(int index, int value)
        {
            _arr[index] = value;

        }
        public void Insert(int index, int value)
        {
           
            
                for (int i = index, j = index + 1; j <= _current; i++, j++)
                {
                    _arr[j] = _arr[i];
                }
           
            _arr[index] = value;
        }
        public void delete(int index)
        {
            for (int i = index, j = index + 1; j < _current; i++, j++)
            {
                _arr[i] = _arr[j];
            }
        }
        public Boolean Contains(int value)
        {
            for (int i = 0; i < _arr.Length; i++)
            {
                if (value == _arr[i])
                {
                    return true;
                }
            }
            return false;
        }
        public void Add(int value)
        {
            if (_current + 1 == Capacity)
            {
                Resize();
            }
                _arr[_current] = value;
                _current++;
                _isempty = false;
        }
        public void Resize()
        {
            int[] newarr = new int[_arr.Length * 2];
            for (int i = 0; i < _arr.Length; i++)
            {
                newarr[i] = _arr[i];
            }
            _arr = newarr;
            
        }
        public void display()
        {
            for (int i = 0; i < _arr.Length; i++)
            {
                Console.Write(_arr[i]+" ");
            }
        }


    }
}
