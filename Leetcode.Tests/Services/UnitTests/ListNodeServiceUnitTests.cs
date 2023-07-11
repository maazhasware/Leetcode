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
        //Arrange
        var listNode1 = new ListNode(3, new ListNode(2, new ListNode(4)));
        var listNode2 = new ListNode(1, new ListNode(4, new ListNode(3)));

        //Act
        var result = _listNodeService.MergeTwoListNodes(listNode1, listNode2);

        //Assert
        Assert.False(ListIsNotOrdered(result));
    }

    [Fact]
    public void MergeTwoListNodes_WhenFirstListNodeNull_ReturnsSecondList()
    {
        //Arrange
        var listNode2 = new ListNode(1, new ListNode(4, new ListNode(3)));

        //Act
        var result = _listNodeService.MergeTwoListNodes(null, listNode2);

        //Assert
        Assert.Equal(result, listNode2);
    }

    [Fact]
    public void MergeTwoListNodes_WhenSecondListNodeNull_ReturnsFirstList()
    {
        //Arrange
        var listNode1 = new ListNode(1, new ListNode(4, new ListNode(3)));

        //Act
        var result = _listNodeService.MergeTwoListNodes(listNode1, null);

        //Assert
        Assert.Equal(result, listNode1);
    }

    [Fact]
    public void MergeTwoListNodes_WhenBothListNodesNull_ReturnsListNode()
    {
        //Arrange

        //Act
        var result = _listNodeService.MergeTwoListNodes(null, null);

        //Assert
        Assert.IsType<ListNode>(result);
    }

    private bool ListIsNotOrdered(ListNode listNode) 
    {
        // had to invert the check rather than checking for IsOrdered due to last evaluation (int <= null) resulting in false
        var isNotOrdered = listNode.val > listNode.next?.val;

        if (isNotOrdered) return isNotOrdered;

        if (listNode.next != null) 
        {
            isNotOrdered = ListIsNotOrdered(listNode.next);
        }

        return isNotOrdered;
    }

}