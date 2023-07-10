// See https://aka.ms/new-console-template for more information
using Leetcode;

internal class Program
{
    private static void Main(string[] args)
    {
        var mergedListNode = MergeTwoLists_TestCase1();
        Console.WriteLine(mergedListNode.ToString());
        Console.ReadKey();
    }

    public static ListNode MergeTwoLists_TestCase1()
    {
        var algorithmService = new AlgorithmService();

        var list1 = new ListNode(3, new ListNode(2, new ListNode(4)));
        var list2 = new ListNode(1, new ListNode(4, new ListNode(3)));

        var mergedListNode = algorithmService.MergeTwoLists(list1, list2);
        return mergedListNode;
    }
}