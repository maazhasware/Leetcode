using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class AlgorithmService
    {
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            List<ListNode> masterList = new List<ListNode>();

            AddToListIfNextNotNull(ref masterList, list1);
            AddToListIfNextNotNull(ref masterList, list2);
            SortListOfListNodes(ref masterList);
            var listNodeFromListOfListNodes = CreateListNodeFromSortedListOfListNodes(masterList);
            return listNodeFromListOfListNodes;
        }

        public void AddToListIfNextNotNull(ref List<ListNode> masterList, ListNode listNode)
        {
            masterList.Add(listNode);

            if (listNode.next != null)
            {
                AddToListIfNextNotNull(ref masterList, listNode.next);
            }
        }

        public List<ListNode> SortListOfListNodes(ref List<ListNode> listOfListNodes)
        {
            if (listOfListNodes == null || listOfListNodes.Count() < 1) return new List<ListNode>();
            if (listOfListNodes.Count() == 1) return listOfListNodes;
            if (listOfListNodes.Count() == 2)
            {
                if (listOfListNodes[0].val <= listOfListNodes[1].val) return listOfListNodes;
                return new List<ListNode>() { listOfListNodes[1], listOfListNodes[0] };
            }

            ListNode tempListNode = new ListNode();
            for (int i = 0; i < listOfListNodes.Count() - 1; i++)
            {
                for (int j = i + 1; j < listOfListNodes.Count(); j++)
                {
                    if (listOfListNodes[i].val > listOfListNodes[j].val)
                    {
                        tempListNode = listOfListNodes[i];
                        listOfListNodes[i] = listOfListNodes[j];
                        listOfListNodes[j] = tempListNode;
                    }
                }
            }

            return listOfListNodes;
        }

        public ListNode CreateListNodeFromSortedListOfListNodes(List<ListNode> sortedList)
        {
            for (int i = 0; i < sortedList.Count() - 1; i++)
            {
                sortedList[i].next = sortedList[i + 1];
            }

            return sortedList[0];
        }
    }
}
