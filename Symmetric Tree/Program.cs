using System;
using System.Collections.Generic;

namespace Symmetric_Tree
{
  class Program
  {
    static void Main(string[] args)
    {
      TreeNode root = new TreeNode(1);
      root.left = new TreeNode(2);
      root.right= new TreeNode(2);
      root.left.left = new TreeNode(3);
      root.left.right = new TreeNode(4);
      root.right.left = new TreeNode(4);
      root.right.right = new TreeNode(3);
      Program p = new Program();
      var result = p.IsSymmetric(root);
      Console.WriteLine(result);
    }

    public class TreeNode
    {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val)
      {
        this.val = val;
        left = right = null;
      }
    }
    public bool IsSymmetric(TreeNode root)
    {
      if (root == null) return true;
      Queue<TreeNode> q = new Queue<TreeNode>();
      // if root not null, push left and right in the queue.
      q.Enqueue(root.left);
      q.Enqueue(root.right);
      List<int> lst = new List<int>();
      while (q.Count > 0)
      {
        // take the current count in the Queue, idea here is to perform level order.
        // Will do level order and collect all the nodes in a level into a list
        // compare the list first and last position and so on , if any mismatch we can say its not symmetric.
        int size = q.Count;
        while (size-- > 0)
        {
          var node = q.Dequeue();
          // if any node is null, add a dummy value in queue to mark it as a null node, so that while comparing with the symmetric position node we can check its a null as well
          int nodeVal = node == null ? int.MinValue : node.val;
          lst.Add(nodeVal);
          if (node != null)
          {
            q.Enqueue(node.left);
            q.Enqueue(node.right);
          }
        }
        // compare the symmetric or not for a level.
        int l = 0;
        int r = lst.Count - 1;
        while (l < r)
        {
          if (lst[l] != lst[r]) return false;
          l++; r--;
        }
        // reset the list to hold new values.
        lst = new List<int>();
      }
      return true;
    }
  }
}
