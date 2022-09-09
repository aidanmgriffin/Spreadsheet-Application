using System;


public class BSTProgram
{ 
    public static void Main()
    {
       
        Input newInput = new Input(); //Create input object to collect response from user

        string stringList = newInput.ReadLine(); //Read line from user

        string[] splitList = stringList.Split(' '); //Split list by ' ' delimitor

        Node Root = null; //Create base for BST

        Tree newTree = new Tree(); //New BST

        Dictionary<int, int> valDict = new Dictionary<int, int>(); //Create a dictionary to hold inputted values and prevent duplicates.

        foreach (var val in splitList) //Iterate through user inputs
        {
            int num = Int32.Parse(val); //Convert from string to int

            if (!valDict.ContainsKey(num)) // Prevent Duplicates by checking if dictionary contains key
            {
                valDict.Add(num, 1); //Add to dictionary to prevent future duplicates.
                Root = newTree.insertNode(Root, num); //Add to BST. Return root 
            }
        }

        newTree.print(Root); //Print tree inorder
        Console.WriteLine("Num Items = " + newTree.numItems); // print number of items in tree
        Console.WriteLine("Height = " + newTree.height(Root)) ; //print height of tree
        Console.WriteLine("Theoretical Minimun # of Nodes = " + (Convert.ToInt32(Math.Floor(Math.Log2(newTree.numItems + 1))))); // floor ( log base 2 (num items + 1) )

    }
}