Console.WriteLine("Please enter name of file you want to read:");
var input = Console.ReadLine();

if (input == null)
{
    Console.WriteLine("File name cannot be null.");
}
else if ( input == "")
{
    Console.WriteLine("File name cannot be empty.");
}


Console.ReadLine();