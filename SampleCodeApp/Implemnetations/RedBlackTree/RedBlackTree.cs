namespace SampleCodeApp.Implemnetations.RedBlackTreeN;

public enum NodeColor { Red, Black }

public class Node
{
    public int Value { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }
    public Node Parent { get; set; }
    public NodeColor Color { get; set; }

    public Node(int value)
    {
        Value = value;
        Left = null;
        Right = null;
        Parent = null;
        Color = NodeColor.Red;
    }
}

public class RedBlackTree
{
    private Node root;

    public RedBlackTree()
    {
        root = null;
    }

    public void Insert(int value)
    {
        Node newNode = new Node(value);
        if (root == null)
        {
            root = newNode;
        }
        else
        {
            InsertNode(root, newNode);
        }
        FixInsertion(newNode);
    }

    private void InsertNode(Node current, Node newNode)
    {
        if (newNode.Value < current.Value)
        {
            if (current.Left == null)
            {
                current.Left = newNode;
                newNode.Parent = current;
            }
            else
            {
                InsertNode(current.Left, newNode);
            }
        }
        else
        {
            if (current.Right == null)
            {
                current.Right = newNode;
                newNode.Parent = current;
            }
            else
            {
                InsertNode(current.Right, newNode);
            }
        }
    }

    private void FixInsertion(Node node)
    {
        Node parent = null;
        Node grandparent = null;

        while (node != root && node.Color != NodeColor.Black && node.Parent.Color == NodeColor.Red)
        {
            parent = node.Parent;
            grandparent = node.Parent.Parent;

            // Case : Parent is left child of Grand-parent
            if (parent == grandparent.Left)
            {
                Node uncle = grandparent.Right;

                // Case : Uncle is red, only recoloring required
                if (uncle != null && uncle.Color == NodeColor.Red)
                {
                    grandparent.Color = NodeColor.Red;
                    parent.Color = NodeColor.Black;
                    uncle.Color = NodeColor.Black;
                    node = grandparent;
                }
                else
                {
                    // Left-Right (LR) case
                    if (node == parent.Right)
                    {
                        RotateLeft(parent);
                        node = parent;
                        parent = node.Parent;
                    }

                    // Left-Left (LL) case
                    RotateRight(grandparent);
                    SwapColors(parent, grandparent);
                    node = parent;
                }
            }
            // Case : Parent is right child of Grand-parent
            else
            {
                Node uncle = grandparent.Left;

                // Case : Uncle is red, only recoloring required
                if (uncle != null && uncle.Color == NodeColor.Red)
                {
                    grandparent.Color = NodeColor.Red;
                    parent.Color = NodeColor.Black;
                    uncle.Color = NodeColor.Black;
                    node = grandparent;
                }
                else
                {
                    // Right-Left (RL) case
                    if (node == parent.Left)
                    {
                        RotateRight(parent);
                        node = parent;
                        parent = node.Parent;
                    }

                    // Right-Right (RR) case
                    RotateLeft(grandparent);
                    SwapColors(parent, grandparent);
                    node = parent;
                }
            }
        }
        root.Color = NodeColor.Black;
    }

    private void RotateLeft(Node node)
    {
        Node rightNode = node.Right;
        node.Right = rightNode.Left;

        if (node.Right != null)
        {
            node.Right.Parent = node;
        }

        rightNode.Parent = node.Parent;

        if (node.Parent == null)
        {
            root = rightNode;
        }
        else if (node == node.Parent.Left)
        {
            node.Parent.Left = rightNode;
        }
        else
        {
            node.Parent.Right = rightNode;
        }

        rightNode.Left = node;
        node.Parent = rightNode;
    }

    private void RotateRight(Node node)
    {
        Node leftNode = node.Left;
        node.Left = leftNode.Right;

        if (node.Left != null)
        {
            node.Left.Parent = node;
        }

        leftNode.Parent = node.Parent;

        if (node.Parent == null)
        {
            root = leftNode;
        }
        else if (node == node.Parent.Right)
        {
            node.Parent.Right = leftNode;
        }
        else
        {
            node.Parent.Left = leftNode;
        }

        leftNode.Right = node;
        node.Parent = leftNode;
    }

    private void SwapColors(Node node1, Node node2)
    {
        NodeColor temp = node1.Color;
        node1.Color = node2.Color;
        node2.Color = temp;
    }

    public List<int> InOrderTraversal()
    {
        List<int> sortedList = new List<int>();
        InOrderTraversalHelper(root, sortedList);
        return sortedList;
    }

    private void InOrderTraversalHelper(Node node, List<int> result)
    {
        if (node != null)
        {
            InOrderTraversalHelper(node.Left, result);
            result.Add(node.Value);
            InOrderTraversalHelper(node.Right, result);
        }
    }
    
    
}

