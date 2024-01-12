namespace SampleCodeApp.Implemnetations.AvlTree;

public class AvlTreeUsage
{
    public static void Run()
    {
        AVLTree avlTree = new AVLTree();

        // Insert values
        avlTree.Insert(30);
        avlTree.Insert(20);
        avlTree.Insert(40);
        avlTree.Insert(10);
        avlTree.Insert(25);
        avlTree.Insert(35);
        avlTree.Insert(50);

        // Search for a value
        Console.WriteLine("Searching for 25: " + avlTree.Search(25)); // Should return true
        Console.WriteLine("Searching for 60: " + avlTree.Search(60)); // Should return false

        // Print the tree in sorted order
        Console.WriteLine("In-Order Traversal (Sorted):");
        avlTree.InOrderTraversal();
    }
}