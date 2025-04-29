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
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    internal class Node
    {
        public int Data {  get; set; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }

        public Node(int data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
        public Node(int data, Node? left, Node? right)
        {
            Data = data;
            Left = left;
            Right = right;
        }
    }
}
