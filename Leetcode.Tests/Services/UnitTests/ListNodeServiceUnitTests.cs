using Leetcode.BusinessLogic.Services;
using Leetcode.Models;

namespace Leetcode.BusinessLogic.Tests.Services.UnitTests;

public class ListNodeServiceUnitTests
{
    private readonly ListNodeService _listNodeService;
    
    public ListNodeServiceUnitTests()
    {
        _listNodeService = new ListNodeService();
    }

    public static IEnumerable<object[]> ListNodeData =>
      new List<object[]>
      {
            new object[] { new ListNode(3, new ListNode(2, new ListNode(4))), new ListNode(1, new ListNode(4, new ListNode(3))) },
            new object[] { new ListNode(11, new ListNode(1, new ListNode(111))), new ListNode(10, new ListNode(31, new ListNode(64))) },
            new object[] { new ListNode(-110, new ListNode(167, new ListNode(-32))), new ListNode(12, new ListNode(4, new ListNode(6))) },
      };

    [Theory, MemberData(nameof(ListNodeData))]
    public void MergeTwoListNodes_WhenGivenTwoListNodes_ReturnsOneListNode(ListNode listNode1, ListNode listNode2)
    {
        //Arrange


        //Act
        var result = _listNodeService.MergeTwoListNodes(listNode1, listNode2);

        //Assert
        Assert.IsType<ListNode>(result);
    }

    [Fact]
    public void MergeTwoListNodes_WhenGivenTwoListNodes_ReturnsOneOrderedListNode()
    {

    }

    [Fact]
    public void MergeTwoListNodes_WhenFirstListNodeNull_ReturnsSecondList()
    {

    }

    [Fact]
    public void MergeTwoListNodes_WhenSecondListNodeNull_ReturnsFirstList()
    {

    }

    [Fact]
    public void MergeTwoListNodes_WhenBothListNodesNull_ReturnsListNode()
    {

    }

}