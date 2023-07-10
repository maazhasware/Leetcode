using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class ListNode
    {
        private StringBuilder _stringBuilder = new StringBuilder();
        
        public int val;
        
        public ListNode next;
        
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

        public override string ToString() 
        {
            _stringBuilder.AppendLine(val.ToString());
            
            if (next != null) 
            {
                _stringBuilder.AppendLine(next.ToString());
            }

            return _stringBuilder.ToString();
        }
    }
}
