using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty() => base.Count == 0;
        public Stack<string> AddRange() => new Stack<string>();
    }
}
