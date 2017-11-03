//using System;
//using System.Collections.Generic;

//namespace Interview
//{
//    public class BinaryTree
//    {
//        public BinaryTree()
//        {
//        }

//        public List<int> PreorderTraversal(TreeNode root)
//        {
//            Stack<int> result = new Stack<int>();
//            DopreorderTraversal(root, result);
//        }

//        public void DopreorderTraversal(TreeNode node, Stack<int> result)
//        {
//            if(node != null)
//            {
//                result.Push();
//            }
//        }
//    }

//    public class TreeNode
//    {
//        public int val;
//        public TreeNode left;
//        public TreeNode right;
//        public TreeNode(int x) { val = x; }
//    }
//}
