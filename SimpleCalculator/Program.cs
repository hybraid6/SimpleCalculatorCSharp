// See https://aka.ms/new-console-template for more information
//Simple Calculator

/*Process
1. Take first input from user
2. Take operator from user 
3. Take second input from user
4. Convert inputs to numbers
5. Perform the operation based on the operator
6. Error handling for division by zero
7. Display the result
 */ 

// Welcome message
Console.WriteLine("Welcome to Arithmancy!");

//Take first input from user
Console.Write("Enter the first number: ");
string? input1 = Console.ReadLine();


//Take operator from user
Console.Write("Pick an operator (+, -, *, /):  ");
string? op = Console.ReadLine();

//Take second input from user
Console.Write("Enter the second number: ");
string? input2 = Console.ReadLine();

//Convert inputs to numbers
if (double.TryParse(input1, out double num1) && double.TryParse(input2, out double num2))
{
    // Perform the operation based on the operator
    switch (op)
    {
        case "+":
            double result = num1 + num2;
            Console.WriteLine($"{num1} {op} {num2} = {result}");
            break;

        case "-":
            result = num1 - num2;
            Console.WriteLine($"{num1} {op} {num2} = {result}");
            break;

        case "*":
            result = num1 * num2;
            Console.WriteLine($"{num1} {op} {num2} = {result}");
            break;

        case "/":
            // Error handling for division by zero
            if (num2 != 0)
            {
                result = num1 / num2;
                Console.WriteLine($"{num1} {op} {num2} = {result}");
            }
            else
            {
                Console.WriteLine("Error! The second number cannot be zero");
            }
            break;

        default:
            Console.WriteLine("Invalid input! Operator not recognized");
            break;
    }
}
else
{
    Console.WriteLine("Invalid input! Please enter numeric values");
}
