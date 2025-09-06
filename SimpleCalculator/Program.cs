// See https://aka.ms/new-console-template for more information
//Simple Calculator

/*Process

1. Display welcome message
2. Ask the user for the first number
3. Confirm that it's a valid number
4. If invalid, display an error message and ask continuously until valid (Everything will be in a while loop)
5. Ask the user to choose an operator
6. Confirm that it's one of the displayed symbols
7. If invalid, display an error message and ask continuously until valid
8. Ask the user for the second number
9. Confirm that it's a valid number
10. If invalid, display an error message and ask continuously until valid
11. If the chosen operator is / and the user enters 0, display an 'division by zero' error message and ask continuously until valid
12. Perform the calculation
13. Display the result
14. Ask if the user wants to perform another calculation
15. If yes, repeat the process from step 5
16. If no exit the program

 */

// Display welcome message
Console.WriteLine("Welcome to Arithmancy!");

bool keepGoing = true; // Controls whether we keep running the calculator

while (keepGoing)
{
    // Get first number with immediate validation (GetValidNumber method defined at the bottom)
    double num1 = GetValidNumber("Enter the first number: ");

    // Get operator with validation (Method defined at the bottom)
    string op = GetValidOperator("Pick an operator (+, -, *, /): ");

    // Get second number (extra check for division by zero if operator is /)
    /* Tenary operator used to modify message shown to user if division is chosen
     * "Enter the second number (non-zero):" or "Enter the second number:"
     */
    double num2 = GetValidNumber(
        $"Enter the second number{(op == "/" ? " (non-zero): " : ": ")}",
        op
    );

    // Perform the operation based on the chosen operator
    double result = 0; // Store calculation result
    switch (op)
    {
        case "+":
            result = num1 + num2;
            break;
        case "-":
            result = num1 - num2;
            break;
        case "*":
            result = num1 * num2;
            break;
        case "/":
            result = num1 / num2;
            break;
    }

    // Display the result in the format: num1 op num2 = result
    Console.WriteLine($"{num1} {op} {num2} = {result}");

    // Ask if user wants to perform another calculation (We use 'Console.Write' so that user's response is on the same line as prompt)
    Console.Write("\nDo you want to perform another calculation? (y/n): ");
    string? answer = Console.ReadLine()?.Trim().ToLower(); // Second '?' to call Trim only if input isn't null

    // If user enters anything other than 'y', exit the loop
    if (answer != "y")
    {
        keepGoing = false;
        Console.WriteLine("Goodbye!");
    }
}

//Methods for input validation

/// <summary>
/// Gets a valid number from the user, with optional division by zero prevention.
/// </summary>
/// <param name="prompt">The message to show to the user.</param>
/// <param name="op">The operator chosen (optional) to check for division by zero.</param>
/// <returns>A valid double number.</returns>
static double GetValidNumber(string prompt, string? op = null)
{
    double number; // Variable to store parsed number
    while (true) // Keep asking until valid
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();

        // Try to convert the input to a double
        if (double.TryParse(input, out number))
        {
            // If division is chosen and number is zero, reject
            if (op == "/" && number == 0)
            {
                Console.WriteLine("Error! Division by zero is not allowed.");
                continue;
            }
            return number; // Valid input, return it
        }
        else
        {
            // Invalid number input
            Console.WriteLine("Invalid input! Please enter a numeric value.");
        }
    }
}

/// <summary>
/// Gets a valid arithmetic operator (+, -, *, /) from the user.
/// </summary>
/// <param name="prompt">The message to show to the user.</param>
/// <returns>The valid operator as a string.</returns>
static string GetValidOperator(string prompt)
{
    while (true) // Keep asking until valid
    {
        Console.Write(prompt);
        string? op = Console.ReadLine()?.Trim();

        // Check if input is one of the 4 allowed operators
        if (op == "+" || op == "-" || op == "*" || op == "/")
        {
            return op;
        }
        else
        {
            Console.WriteLine("Invalid operator! Please choose +, -, *, or /.");
        }
    }
}