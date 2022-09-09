
public class Input
{
    // Method of reading line from user.

    public string ReadLine() 
    {
        string stringList;

        Console.WriteLine("Enter series of numbers: "); //prompt
        stringList = Console.ReadLine(); //read as a string, to be converted into integers at a later step.

        return stringList ; //return as string
    }
}
