using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class Tuple<T>
    {
        public Tuple(T item1, T item2)
        {
            this.item1 = item1;
            this.item2 = item2;
        }

        public T item1 {get; set;}

        public T item2 { get; set; }

        public override string ToString()
        {
            return $"{this.item1} -> {this.item2}";
        }
    }
}
