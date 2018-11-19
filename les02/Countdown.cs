using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace les02
{
    class Countdown : IEnumerator
    {
    int _count = 11;
    public bool MoveNext() { return _count-- > 0;}// Здесь count-- и сравнение получившегося значения с 0 
    public void Reset()  {_count = 0;}

    public object Current { get { return _count; } }
    }
}
