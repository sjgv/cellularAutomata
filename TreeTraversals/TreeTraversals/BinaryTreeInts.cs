using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeTraversals
{
    /// <summary>
    /// This is a public static class that demonstrates some basic traversals. 
    /// This was a good review of stuff I haven't seen in a while. 
    /// Please feel free to play around with it and leave any comments. 
    /// All the methods are public and static. 
    /// 
    /// Written by: Salvador Gutierrez 
    /// </summary>
    class BinaryTreeInts
    {
        public class Node
        {
            int val;
            public Node left;
            public Node right;
            public Node()
            {

            }
            public int Value
            {
                get { return val; }
                set { val = value; }
            }
        }

        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7,8,9};
            int[] arr2 = { 9, 8, 7, 6, 5, 6, 4, 2, 3 };
            Node[] nodeArr = CreateTreeFromArray(arr);
            //BFS(nodeArr[0]);
            //BFSRecursiveComplex(nodeArr[0], 0, 3);
            //DFSPre(nodeArr[0]);
            //inOrder(nodeArr[0]);
            PostOrder(nodeArr[0]);
            //BFSRecursive(nodeArr);
            //Node rootNode = nodeArr[0];
            //BFSRecursive(rootNode, 0, 2);
            Console.Read();
        }
        /// <summary>
        /// Post Order binary tree traversal
        /// </summary>
        /// <param name="node">Root Node</param>
        public static void PostOrder(Node node)
        {
            if(node == null) { return; }
            PostOrder(node.left);
            PostOrder(node.right);
            Console.WriteLine(node.Value);
        }
        /// <summary>
        /// In Order Binary tree traversal
        /// </summary>
        /// <param name="node">Root Node</param>
        public static void InOrder(Node node)
        {
            if(node == null) { return; }
            InOrder(node.left);
            Console.WriteLine(node.Value);
            InOrder(node.right);
        }
        /// <summary>
        /// Pre Order tree traversal
        /// </summary>
        /// <param name="node">Root Node</param>
        public static void PreOrder(Node node)
        {
            if(node == null) { return; }
            Console.WriteLine(node.Value);
            PreOrder(node.left);
            PreOrder(node.right);
        }
        /// <summary>
        /// Breath-First Traversal
        /// </summary>
        /// <param name="rootNode">Root Node</param>
        public static void BFS(Node rootNode)
        {
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(rootNode);
            while (q.Count != 0)
            {
                rootNode = q.Dequeue();
                Console.WriteLine("Visited {0}!", rootNode.Value);
                if (rootNode.left != null) { q.Enqueue(rootNode.left); }
                if (rootNode.right != null) { q.Enqueue(rootNode.right); }
            }
        }
        
        /// <summary>
        /// BFS with level control 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="currentLevel"></param>
        /// <param name="desired"></param>
        public static void BFSRecursiveComplex(Node node, int currentLevel, int desired)
        {
            //if base case 
            if(node == null || currentLevel > desired) { return; }
            //if what we want is true do what we want 
            if(currentLevel == desired) { Console.Write(node.Value + " "); }
            //else call yourself recursively 
            else
            {
                BFSRecursiveComplex(node.left, currentLevel + 1, desired);
                BFSRecursiveComplex(node.right, currentLevel + 1, desired);
            }
        }
        /// <summary>
        /// BreathFirst Iterative with level control
        /// </summary>
        /// <param name="node"></param>
        /// <param name="currentLevel"></param>
        /// <param name="desired"></param>
        public static void BFSComplex(Node node, int currentLevel, int desired)
        {
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(node);
            while (q.Count != 0)
            {

                if (desired == 0)
                {
                    node = q.Dequeue();
                    Console.WriteLine(node.Value);
                }
                else
                {
                    node = q.Dequeue();
                    if (node.left != null) { q.Enqueue(node.left); }
                    if (node.right != null) { q.Enqueue(node.right); }
                    currentLevel++;
                    if (currentLevel == desired)
                    {
                        if (desired != 1)
                        {
                            node = q.Dequeue();
                            if (node.left != null) { q.Enqueue(node.left); }
                            if (node.right != null) { q.Enqueue(node.right); }
                        }
                        foreach (Node el in q)
                        {
                            Console.Write(el.Value);
                        }
                    }

                }

            }

        }

        /// <summary>
        /// This was a question someone posted online, can you create
        /// a binary tree out of an array. Of course I can! 
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static Node[] CreateTreeFromArray(int[] arr)
        {
            //List<Node> nodeList = new List<Node>();
            Node[] nodeArr = new Node[arr.Length];
            Node currentNode = new Node();
            for (int i = 0; i < arr.Length; i++)
            {
                Node temp = new Node();
                temp.Value = arr[i];
                nodeArr[i] = temp;
            }
            for (int i = 0; i < nodeArr.Length; i++)
            {
                int leftNodeValue = (i * 2) + 1;
                int rightNodeValue = (i * 2) + 2;
                currentNode = nodeArr[i];
                if (leftNodeValue < nodeArr.Length)
                {
                    currentNode.left = nodeArr[leftNodeValue];
                    if (rightNodeValue < arr.Length)
                    {
                        currentNode.right = nodeArr[rightNodeValue];
                    }
                }
            }
            return nodeArr;
        }
    }
}
