namespace SampleCodeApp.Implemnetations.AvlTree;

using System;

public class Node
{
    public int Value { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }
    public int Height { get; set; }

    public Node(int value)
    {
        Value = value;
        Height = 1;
    }
}

public class AVLTree
{
    public Node Root { get; private set; }

    public void Insert(int value)
    {
        Root = Insert(Root, value);
    }

    private Node Insert(Node node, int value)
    {
        if (node == null)
            return new Node(value);

        if (value < node.Value)
            node.Left = Insert(node.Left, value);
        else if (value > node.Value)
            node.Right = Insert(node.Right, value);
        else
            return node;

        node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

        int balance = GetBalance(node);

        if (balance > 1 && value < node.Left.Value)
            return RightRotate(node);

        if (balance < -1 && value > node.Right.Value)
            return LeftRotate(node);

        if (balance > 1 && value > node.Left.Value)
        {
            node.Left = LeftRotate(node.Left);
            return RightRotate(node);
        }

        if (balance < -1 && value < node.Right.Value)
        {
            node.Right = RightRotate(node.Right);
            return LeftRotate(node);
        }

        return node;
    }

    private Node RightRotate(Node y)
    {
        Node x = y.Left;
        Node T2 = x.Right;

        x.Right = y;
        y.Left = T2;

        y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
        x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

        return x;
    }

    private Node LeftRotate(Node x)
    {
        Node y = x.Right;
        Node T2 = y.Left;

        y.Left = x;
        x.Right = T2;

        x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
        y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;

        return y;
    }

    private int GetHeight(Node node)
    {
        if (node == null)
            return 0;

        return node.Height;
    }

    private int GetBalance(Node node)
    {
        if (node == null)
            return 0;

        return GetHeight(node.Left) - GetHeight(node.Right);
    }
    
    public bool Search(int value)
    {
        return Search(Root, value);
    }

    private bool Search(Node node, int value)
    {
        if (node == null)
            return false;

        if (value < node.Value)
            return Search(node.Left, value);
        else if (value > node.Value)
            return Search(node.Right, value);
        else
            return true; // value found
    }
    
    public void InOrderTraversal()
    {
        InOrderTraversal(Root);
    }

    private void InOrderTraversal(Node node)
    {
        if (node != null)
        {
            InOrderTraversal(node.Left);
            Console.WriteLine(node.Value);
            InOrderTraversal(node.Right);
        }
    }
    
}
