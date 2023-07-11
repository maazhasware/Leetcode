using Leetcode.BusinessLogic.Services;
using Leetcode.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var mergedListNode = MergeTwoLists_VisualTestCase1();
        Console.WriteLine(mergedListNode.ToString());
        Console.ReadKey();
    }

    public static ListNode MergeTwoLists_VisualTestCase1()
    {
        var listNodeService = new ListNodeService();

        var list1 = new ListNode(3, new ListNode(2, new ListNode(4)));
        var list2 = new ListNode(1, new ListNode(4, new ListNode(3)));

        var mergedListNode = listNodeService.MergeTwoListNodes(list1, list2);
        return mergedListNode;
    }
}