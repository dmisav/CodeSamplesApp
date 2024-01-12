namespace SampleCodeApp.Implemnetations.RedBlackTreeN;

public class UsageRedBlackTree
{
    public static void Run()
    {
        RedBlackTree tree = new RedBlackTree();

        // Insert elements into the tree
        tree.Insert(5);
        tree.Insert(3);
        tree.Insert(7);
        tree.Insert(2);
        tree.Insert(4);
        tree.Insert(6);
        tree.Insert(8);

        // Retrieve elements in sorted order
        List<int> sortedElements = tree.InOrderTraversal();

        Console.WriteLine("Sorted Elements:");
        foreach (int element in sortedElements)
        {
            Console.WriteLine(element);
        }
    }
}