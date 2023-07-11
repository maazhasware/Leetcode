using Leetcode.Models;

namespace Leetcode.BusinessLogic.Services
{
    public class ListNodeService
    {
        public ListNode MergeTwoListNodes(ListNode list1, ListNode list2)
        {
            if (list1 == null) return list2 ?? new ListNode();
            if (list2 is null) return list1;

            List<ListNode> masterList = new List<ListNode>();

            AddToMasterListAndAddNextIfNotNull(ref masterList, list1);
            AddToMasterListAndAddNextIfNotNull(ref masterList, list2);
            SortListOfListNodes(ref masterList);
            var mergedListNode = CreateListNodeFromSortedListOfListNodes(masterList);

            return mergedListNode;
        }

        private void AddToMasterListAndAddNextIfNotNull(ref List<ListNode> masterList, ListNode listNode)
        {
            masterList.Add(listNode);

            if (listNode.next != null)
            {
                AddToMasterListAndAddNextIfNotNull(ref masterList, listNode.next);
            }
        }

        private List<ListNode> SortListOfListNodes(ref List<ListNode> listOfListNodes)
        {
            if (listOfListNodes == null || listOfListNodes.Count() < 1) return new List<ListNode>();
            if (listOfListNodes.Count() == 1) return listOfListNodes;
            if (listOfListNodes.Count() == 2)
            {
                return 
                    listOfListNodes[0].val <= listOfListNodes[1].val ? 
                    listOfListNodes : 
                    new List<ListNode>() { listOfListNodes[1], listOfListNodes[0] };
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

        private ListNode CreateListNodeFromSortedListOfListNodes(List<ListNode> sortedList)
        {
            for (int i = 0; i < sortedList.Count() - 1; i++)
            {
                sortedList[i].next = sortedList[i + 1];
            }

            return sortedList[0];
        }
    }
}
