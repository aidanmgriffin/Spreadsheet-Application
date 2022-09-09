// Each  file should contain one class

using System.Collections.Specialized;

public class Node // Node to be inserted into BST
{
    public int val;
    public Node left, right;

    public Node(int data)
    {
        val = data;
        left = null;
        right = null;
    }
}

public class Tree //Tree class contains functions to insert node and print tree.
{

   public int numItems = 0; //Keep track of the number of Nodes in the BST

   public Node insertNode(Node root, int val)
    {

        if(root == null) //if tree is empty, set the root
        {
            numItems++;
            root = new Node(val);
            root.val = val;

        }
        else if(val < root.val) //if val is less than the current node, recursively enter left
        {
            root.left = insertNode(root.left, val);
        }
        else //if val is greater than the current node, recursively enter left
        {
            root.right = insertNode(root.right, val);
        }

        return root;
    }

    public void print(Node root) //print inorder
    {
        if(root != null) //recursively work from left to right side of tree
        {
            print(root.left);
            Console.WriteLine(root.val);
            print(root.right);
        }       
    }

    public int height(Node root) //recursively find depth of tree
    {
        if(root == null)
        {
            return 0;
        }
        else
        {
            return Math.Max(height(root.left), height(root.right)) + 1;
        }
    }
    
}