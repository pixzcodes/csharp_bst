/****************************
 *                          *
 *      Derek Kelley        *
 *      CPT 244             *
 *      Spring Semester     *
 *                          *
 ****************************/
namespace BinarySearchTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // making the tree
            // can also use another contructor:
            // Tree myTree = new([ 12, 9, 3, 14, 13, 41 ]);
            Console.WriteLine("New Tree Created:");
            Tree myTree = new();
            myTree.Append(12);
            myTree.Append(9);
            myTree.Append(3);
            myTree.Append(14);
            myTree.Append(13);
            myTree.Append(41);
            myTree.PrettyPrint(myTree.Root);
            DisplayTraversals(myTree);

            // deleting nodes
            Console.WriteLine();
            Console.WriteLine("Deleting node 13 . . .");
            myTree.Delete(13, myTree.Root);
            Console.WriteLine("Deleting node 9 . . .");
            myTree.Delete(9, myTree.Root);
            Console.WriteLine("Deleting node 3 . . .");
            myTree.Delete(3, myTree.Root);
            myTree.PrettyPrint(myTree.Root);
            DisplayTraversals(myTree);

            // adding more nodes
            Console.WriteLine("After adding 90, 44, 20, 15, and 65 . . .");
            myTree.Append(90);
            myTree.Append(44);
            myTree.Append(20);
            myTree.Append(15);
            myTree.Append(65);
            myTree.PrettyPrint(myTree.Root);
            DisplayTraversals(myTree);

            // finding nodes
            Node? num44 = myTree.Find(44, myTree.Root);
            Node? num100 = myTree.Find(100, myTree.Root);
            Node? num13 = myTree.Find(13, myTree.Root);
            
            Console.WriteLine();
            Console.WriteLine($"Find 44: {(num44 != null ? "Found" : "No match")}");
            Console.WriteLine($"Find 100: {(num100 != null ? "Found" : "No match")}");
            Console.WriteLine($"Find 13: {(num13 != null ? "Found" : "No match")}");

            // inserting after specific nodes
            myTree.InsertAfter( 38, num44 ); // by using a node
            myTree.InsertAfter( 37, 13 ); // or using a value
            Console.WriteLine();
            Console.WriteLine("After inserting 38 after 44 and 37 after 13 . . .");
            myTree.PrettyPrint(myTree.Root);
            DisplayTraversals(myTree);
            // always rebalance after inserting
            // otherwise it messes up other methods of
            // the tree because the node could have been inserted out of
            // order since we are inserting instead of appending.
            myTree.RebalanceTree(myTree.Root);
            Console.WriteLine();
            Console.WriteLine("After rebalancing . . .");
            myTree.PrettyPrint(myTree.Root);
            DisplayTraversals(myTree);


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("This project was submitted by Derek Kelley for CPT 244 Spring Semester");
        }

        static void DisplayTraversals(Tree myTree)
        {
            Console.WriteLine();
            // Inorder Traversal
            Console.Write("Inorder Traversal: ");
            myTree.InorderTraversal(myTree.Root);
            Console.WriteLine();

            // Preorder Travseral
            Console.Write("Preorder Traversal: ");
            myTree.PreorderTraversal(myTree.Root);
            Console.WriteLine();

            // Postorder Travseral
            Console.Write("Postorder Traversal: ");
            myTree.PostorderTraversal(myTree.Root);
            Console.WriteLine();


        }
    }
}
