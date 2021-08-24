using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arraylib
{
    public class Arraylist
    {
        int[] _data;
        //public Arraylist(int size = 2)
        //{
        //    _data = new int[size];
            
        //}
        public Arraylist(IEnumerable<int> collection)
        {
            _data = new int[collection.Count()];
            int[] cdata = collection.ToArray();
            while(_current<cdata.Length)
            {
                _data[_current]=cdata[_current];
                _current++;
            }
           // _current = collection.Count();
        } 
        public Arraylist(int Growthfactor=2)
        {
           _data=new int[Growthfactor];
        }
        int _growthfactor=100;
       
       
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
            get
            {
                 return _data.Length; 
            }
        }
        public bool IsSorted 
        {
             get
            {

                for (int i = 0, j = 1; j < _current; i++, j++)
                {
                    if (_data[i]  > _data[j])
                    {
                        return false;
                    }
                    //    if (_data[i] <= _data[j])
                    //    {
                    //        acount++;
                    //    }

                }
                //if (acount == _current - 1)
                //{
                //    _issorted = true;
                //}

                return true ;
            }
        }
        public int Get(int index)
        {
            return _data[index];
        }
        public void Set(int index, int value)
        {
            _data[index] = value;

        }
        public void Insert(int index, int value)
        {

            if (_capacity ==_current)
            {
                Resize();
            }
                for (int i = _current-1, j =_current;i>=index; i--,j--)
                {
                    _data[j] = _data[i];
                }
           
                 _data[index] = value;
                 _current++;
        }
        public void delete(int index)
        {
            for (int i = index, j = index + 1; j < _current; i++, j++)
            {
                _data[i] = _data[j];
            }
            _current--;
        }
        public bool Contains(int value)
        {
            int end = _current;
            int start = 0;
               
            if (IsSorted == true)
            {
                int q = _current / 2;
                int x=_data[q];
                if (x > value)
                {
                    end = q-1;
                }
                else if(x<value)
                {
                    start = q + 1;
                }
                else
                {
                    return true;
                }
            }
            for (int i = start; i < end;i++ )
            {
                if (value == _data[i] )
                {
                    return true;
                }
            }
            return false;
        } 
        public void Add(int value)
        {
            _capacity = _data.Length;
            if (_current == _capacity)
            {
                Resize();
            }
                _data[_current] = value;
                _current++;
                _isempty = false;
        }
        public void Resize()
        {
            if (_capacity >1000)
            {
                _growthfactor = 50;
            }
            double gf=((double)_growthfactor/100)*_capacity;
            double len=_data.Length*gf;
            int[] newarr = new int[(int)len];
            for (int i = 0; i < _current; i++)
            {
                newarr[i] = _data[i];
            }
            _data = newarr;
            _capacity = _data.Length;
            
        }
        public void display()
        {
            for (int i = 0; i < _data.Length; i++)
            {
                Console.Write(_data[i]+" ");
            }
        }
        public int IndexOf(int value)
        {
            int start = 0;
            int end = _current;
            int ind = _current / 2;
            int x=_data[ind];
            if (IsSorted == true)
            {
                if (x > value)
                {
                    end = ind - 1;
                }
                else if (x < value)
                {
                    start = ind + 1;
                }
                else if (x == value)
                {
                    return ind;
                }
            }
            for (int i = start; i < end;i++ )
            {
                if(_data[i]==value)
                {
                    return i;
                }
            }
            return -1;
        }
        public void AddAll(IEnumerable<int> a)
        {
            int[] indata = a.ToArray();
            int[] arr =new int[indata.Length];

            for (int i = 0; i < arr.Length;i++ )
            {
                arr[i] = indata[i]; 
            }
            if (_current == _capacity||arr.Length>_capacity)
            {
                Resize(arr.Length);
            }
            int j=0;
            while(j<arr.Length)
            {
                _data[_current] = arr[j];
                _current++;
                j++;
            }

        }
        public void DeleteValue(int value,bool RemoveAll=false)
        {
            int i=0;
            int j=i+1;
            bool ispresent = false;
            if(RemoveAll==false)
            {
            while(j<=_current)
            {
                if(_data[i]==value)
                {
                    ispresent = true;
                }
                if(ispresent)
                {
                    _data[i] = _data[j];
                }
                i++;
                j++;

            }
            }
            else if(RemoveAll==true)
            {
                while(j<=_current)
                {
                    if (_data[i] == value)
                    {
                        ispresent = true;
                    }
                    if (_data[j] == value)
                    {
                        ispresent = true;
                        j++;
                    }
                    if(ispresent)
                    {
                        _data[i] = _data[j];
                    }
                    i++;
                    j++;
                }
            }
        }
        public void InsertAll(int index,IEnumerable<int> collection)
        {
            if(_current==_capacity||_data.Length<collection.Count())
            {
                Resize(collection.Count());
            }

            int[] newcoll =new int[collection.Count()];
            int y = 0;
            foreach(int x in collection)
            {
                newcoll[y] = x;
                y++;
            }
            int length=newcoll.Length;
            int i=_current-1;
            int j=_current+length-1;
            int k = 0;
            int l=index;
             while (i >= index)
                {

                    _data[j] = _data[i];
                    i--;
                    j--;

                }
             while(k<newcoll.Length)
            {
                
                    _data[l] = newcoll[k];
                    k++;
                    l++;

            }
            _current = _current + length;
        }
        public int Max()
            {
                if (IsSorted == true)
                {
                    return _data[_current - 1];
                   
                }
                else
                {

                    int Max = int.MinValue;
                    for (int i = 0; i < _current; i++)
                    {
                        if (Max < _data[i])
                        {
                            Max = _data[i];
                        }
                    }
                    return Max;
                }    
            }
        public int Min()
        {
            if (IsSorted == true)
            {
                return _data[0];
            }
            else
            {

                int Min = int.MaxValue;
                for (int i = 0; i < _current; i++)
                {
                    if (Min > _data[i])
                    {
                        Min = _data[i];
                    }
                }
                return Min;
            } 
        }
        public long Sum()
        {
            int sum = 0;
            for (int i = 0; i < _current;i++ )
            {
                sum += _data[i];
            }
            return sum;
        }
        public int[] Reverse()
        {
            int[] reversedata = new int[_data.Length];
            for (int i = _current - 1,j=0; i >= 0;i--,j++ )
            {
                reversedata[j] = _data[i];
            }
            return reversedata;
        }
        public int[] ToArray()
        {
            int[] newdata =new int[_capacity];
            for (int i = 0; i < _current;i++ )
            {
                newdata[i] = _data[i];
            }

            return newdata;
        }
        public int[] ToArray(int startindex)
        {
            int[] newdata = new int[_data.Length - startindex];
            for (int i = startindex, j = 0; i < _data.Length;i++,j++ )
            {
                newdata[j] = _data[i];
            }
            return newdata;
        }
        public int[] ToArray(int startindex,int endindex)
        {
            int[] newdata=new int[(endindex-startindex)+1];
            for (int i = startindex, j = 0; i <= endindex;i++,j++ )
            {
                newdata[j] = _data[i];
            }
            return newdata;
        }
        public int[] Distinct(bool InOrder=false)
        {
            int[] distinctdata=new int[_current];
            int i=0;
            int k=0;
            while(i<_current)
            {
                int c = 0;
           
                for (int j = 0; j < _current;j++ )
                {
                    if(_data[i]==_data[j])
                    {
                        c++;
                    }
                }
                if(c==1)
                {
                    distinctdata[k] = _data[i];
                    k++;
                }
                i++;
               
            }
            return distinctdata;
        }
        private void Resize(int size)
        {
          int[] newdata=new int[_capacity+size];
          for (int i = 0; i < _current;i++ )
          {
              newdata[i] = _data[i];
          }
          _data = newdata;

        }
        public int[] Sorting(bool InDescending=false)
        {
            int[] sortdata = new int[_current];
            for (int i = 0; i < _current; i++)
            {
                sortdata[i] = _data[i];
            }
            Array.Sort(sortdata);
            if (InDescending == true)
            {
                Array.Reverse(sortdata);
                return sortdata;
            }
            else
            {
                return sortdata;
            }
           
           
           
        }
        public void Clear()
        {
            int[] newdata=new int[2];
            _data = newdata;
            _current = 0;
        }
        
            
        
        


    }
}
