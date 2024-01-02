using System;
using System.Collections.Generic;

public class RedBlackTree<T> where T : IComparable
{
    private enum NodeColor
    {
        Red,
        Black
    }

    private class Node
    {
        public T Value;
        public Node Left;
        public Node Right;
        public Node Parent;
        public NodeColor Color;

        public Node(T value)
        {
            Value = value;
            Left = null;
            Right = null;
            Parent = null;
            Color = NodeColor.Red; // New nodes are always red initially
        }
    }

    private Node root;
/// <summary>
/// The Insert method places a new node in the correct location,
/// then calls FixInsertion to ensure the tree remains balanced.
/// </summary>
/// <param name="value"></param>
    public void Insert(T value)
    {
        Node newNode = new Node(value);
        if (root == null)
        {
            root = newNode;
        }
        else
        {
            Node node = root;
            Node parent = null;
            while (node != null)
            {
                parent = node;
                node = newNode.Value.CompareTo(node.Value) < 0 ? node.Left : node.Right;
            }

            newNode.Parent = parent;
            if (newNode.Value.CompareTo(parent.Value) < 0)
            {
                parent.Left = newNode;
            }
            else
            {
                parent.Right = newNode;
            }
        }

        newNode.Color = NodeColor.Red;
        FixInsertion(newNode);
    }
/// <summary>
/// FixInsertion method adjusts the tree to maintain
/// Red-Black Tree properties after each insertion.
/// </summary>
/// <param name="node"></param>
    private void FixInsertion(Node node)
    {
        while (node != root && node.Parent.Color == NodeColor.Red)
        {
            if (node.Parent == node.Parent.Parent.Left)
            {
                Node uncle = node.Parent.Parent.Right;
                if (uncle != null && uncle.Color == NodeColor.Red)
                {
                    node.Parent.Color = NodeColor.Black;
                    uncle.Color = NodeColor.Black;
                    node.Parent.Parent.Color = NodeColor.Red;
                    node = node.Parent.Parent;
                }
                else
                {
                    if (node == node.Parent.Right)
                    {
                        node = node.Parent;
                        RotateLeft(node);
                    }
                    node.Parent.Color = NodeColor.Black;
                    node.Parent.Parent.Color = NodeColor.Red;
                    RotateRight(node.Parent.Parent);
                }
            }
            else
            {
                Node uncle = node.Parent.Parent.Left;
                if (uncle != null && uncle.Color == NodeColor.Red)
                {
                    node.Parent.Color = NodeColor.Black;
                    uncle.Color = NodeColor.Black;
                    node.Parent.Parent.Color = NodeColor.Red;
                    node = node.Parent.Parent;
                }
                else
                {
                    if (node == node.Parent.Left)
                    {
                        node = node.Parent;
                        RotateRight(node);
                    }
                    node.Parent.Color = NodeColor.Black;
                    node.Parent.Parent.Color = NodeColor.Red;
                    RotateLeft(node.Parent.Parent);
                }
            }
        }
        root.Color = NodeColor.Black;
    }
/// <summary>
/// RotateLeft and RotateRight are utility
/// methods to perform left and right rotations.
/// </summary>
/// <param name="node"></param>
    private void RotateLeft(Node node)
    {
        Node right = node.Right;
        node.Right = right.Left;
        if (right.Left != null)
        {
            right.Left.Parent = node;
        }
        right.Parent = node.Parent;
        if (node.Parent == null)
        {
            root = right;
        }
        else if (node == node.Parent.Left)
        {
            node.Parent.Left = right;
        }
        else
        {
            node.Parent.Right = right;
        }
        right.Left = node;
        node.Parent = right;
    }
/// <summary>
/// RotateLeft and RotateRight are utility
/// methods to perform left and right rotations.
/// </summary>
/// <param name="node"></param>
    private void RotateRight(Node node)
    {
        Node left = node.Left;
        node.Left = left.Right;
        if (left.Right != null)
        {
            left.Right.Parent = node;
        }
        left.Parent = node.Parent;
        if (node.Parent == null)
        {
            root = left;
        }
        else if (node == node.Parent.Right)
        {
            node.Parent.Right = left;
        }
        else
        {
            node.Parent.Left = left;
        }
        left.Right = node;
        node.Parent = left;
    }

    public List<T> InOrderTraversal()
    {
        var result = new List<T>();
        InOrderTraversal(root, result);
        return result;
    }
/// <summary>
/// The InOrderTraversal method is used to retrieve elements in sorted order.
/// </summary>
/// <param name="node"></param>
/// <param name="result"></param>
    private void InOrderTraversal(Node node, List<T> result)
    {
        if (node != null)
        {
            InOrderTraversal(node.Left, result);
            result.Add(node.Value);
            InOrderTraversal(node.Right, result);
        }
    }
}

