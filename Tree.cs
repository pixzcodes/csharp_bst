/****************************
 *                          *
 *      Derek Kelley        *
 *      CPT 244             *
 *      Spring Semester     *
 *                          *
 ****************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    internal class Tree
    {
        public Node? Root { get; set; } = null;
        private readonly List<int> DataList = [];

        // contructor overloading to support both list and array data types
        public Tree()
        {
        }
        public Tree(List<int> data)
        {
            // need to sort and remove all duplicates from the data
            List<int> unpreppedData = [.. data];
            List<int> cleanedData = [];
            unpreppedData.Sort();
            for (int i = 1; i < unpreppedData.Count; i++)
            {
                if (unpreppedData[i] != unpreppedData[i - 1])
                {
                    cleanedData.Add(unpreppedData[i]);
                }
            }
            Root = BuildTree([.. cleanedData]); // build the tree as soon as the class is initialized
        }
        public Tree(int[] data)
        {
            // need to sort and remove all duplicates from the data
            List<int> unpreppedData = [.. data];
            List<int> cleanedData = [];
            unpreppedData.Sort();
            for (int i = 1; i < unpreppedData.Count; i++)
            {
                if (unpreppedData[i] != unpreppedData[i - 1])
                {
                    cleanedData.Add(unpreppedData[i]);
                }
            }
            Root = BuildTree([.. cleanedData]); // build the tree as soon as the class is initialized
        }

        // This is a recursive method that builds out the tree
        // by splitting the array into left and right halfs 
        // and taking the middle as the data for the node
        // we build the tree starting from the top
        private Node? BuildTree(int[] arr)
        {
            // this is our base case
            if (arr.Length == 0) return null;

            int mid = (arr.Length / 2);

            // our root node starts from the middle of the array
            int data = arr[mid];
            // create the split arrays for our left and right sides
            List<int> left = [];
            List<int> right = [];
            for (int i = 0; i < arr.Length; i++)
            {
                if (i < mid)
                    left.Add(arr[i]);
                if (i > mid)
                    right.Add(arr[i]);
            }

            // here is where the recursion happens
            Node rootNode = new(data);
            rootNode.Left = BuildTree([..left]);
            rootNode.Right = BuildTree([..right]);

            return rootNode;
        }
        public void Append(int value, Node? node = null)
        {
            // make a root node if one does not exist
            Root ??= new Node(value);
            node ??= Root;
            // return if the value exists already
            if(Find(value, Root) != null) return;
            // transverse throught the tree looking for the right 
            // place to put the node
            if (value < node.Data)
            {
                if (node.Left == null)
                    node.Left = new Node(value);
                else
                    Append(value, node.Left);
            }
            else 
            {
                if (node.Right == null)
                    node.Right = new Node(value);
                else
                    Append(value, node.Right);
            }

        }
        public void InsertAfter(int value, Node? node = null)
        {
            // make root the node if root is doesnt exist yet
            Root ??= new Node(value);
            node ??= Root;
            // first check if node is null or already exists
            if(Find(value, Root) != null) return;
            // create the new node
            Node newNode = new (value);

            if (newNode.Data < node.Data)
            {
                newNode.Left = node.Left;
                node.Left = newNode;
            }
            else
            {
                newNode.Right = node.Right;
                node.Right = newNode;
            }
        }
        public void InsertAfter(int value, int? targetNodeValue = null)
        {
            // find the node that we are looking for and
            // set it as the node to insert after
            Node? node = Find(targetNodeValue, Root);
            // make root the node if root is doesnt exist yet
            Root ??= new Node(value);
            node ??= Root;
            // first check if node is null or already exists
            if(Find(value, Root) != null) return;
            // create the new node
            Node newNode = new (value);

            if (newNode.Data < node.Data)
            {
                newNode.Left = node.Left;
                node.Left = newNode;
            }
            else
            {
                newNode.Right = node.Right;
                node.Right = newNode;
            }
        }

        public Node? Find(int? value, Node? node)
        {
            if (value == null) return null;
            if (node == null || node.Data == value)
                return node;

            if(value < node.Data)
                return Find(value, node.Left);
            else
                return Find(value, node.Right);
        }

        public Node? Delete(int value,  Node? node)
        {
            if (node == null) return node;

            if (value < node.Data)
                node.Left = Delete(value, node.Left);
            else if ( value > node.Data)
            {
                node.Right = Delete(value, node.Right);
            }
            else
            {
                if (node.Left == null) return node.Right;
                if (node.Right == null) return node.Left;

                Node? farLeftNode = FindFarLeftLeaf(node.Right);
                if(farLeftNode != null) node.Data = farLeftNode.Data;
                if(farLeftNode != null) node.Right = Delete(farLeftNode.Data, node.Right);
            }

            return node;
        }
        public Node? FindFarLeftLeaf(Node? node)
        {
            while (node != null) { node = node.Left; }
            return node;
        }

        public void RebalanceTree(Node? node)
        {
            // grab all nodes and add them to the data list
            if (node == null) return;
            RebalanceTree(node.Left);
            RebalanceTree(node.Right);
            DataList.Add(node.Data);

            // rebuild the tree
            List<int> unpreppedData = [.. DataList];
            List<int> cleanedData = [];
            unpreppedData.Sort();
            for (int i = 1; i < unpreppedData.Count; i++)
            {
                if (unpreppedData[i] != unpreppedData[i - 1])
                {
                    cleanedData.Add(unpreppedData[i]);
                }
            }
            Root = BuildTree([.. cleanedData]); 
        }

        public void InorderTraversal(Node? node)
        {
            if(node == null) return;
            InorderTraversal(node.Left);
            Console.Write($" {node.Data} ");
            InorderTraversal(node.Right);
        }
        public void PreorderTraversal(Node? node)
        {
            if (node == null) return;
            Console.Write($" {node.Data} ");
            PreorderTraversal(node.Left);
            PreorderTraversal(node.Right);
        }
        public void PostorderTraversal(Node? node)
        {
            if(node == null) return;
            PostorderTraversal(node.Left);
            PostorderTraversal(node.Right);
            Console.Write($" {node.Data} ");
        }

        // this is just to make it look nice and readable in the CLI
        public void PrettyPrint(Node? node, string prefix = "", bool is_left = true)
        {
            if (node == null) return;
            if (node.Right != null) PrettyPrint(node.Right, $"{prefix}{(is_left ? "|   " : "    ")}", false);
            Console.WriteLine($"{prefix}{(is_left ? "└── " : "┌── ")}{node.Data}");
            if (node.Left != null) PrettyPrint(node.Left, $"{prefix}{(is_left ? "    " : "|   ")}", true);
        }
    }
}
