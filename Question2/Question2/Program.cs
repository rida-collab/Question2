using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class VariableInfo
{
    public string VarName { get; set; }
    public string SpecialSymbol { get; set; }
    public string TokenType { get; set; }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter your mini-language code:");
        string input = Console.ReadLine();

        string pattern = @"\b([abc][a-zA-Z]*\d*)\s*=\s*(\d+(\.\d+)?)([^a-zA-Z0-9\s]+)";

        Regex regex = new Regex(pattern);
        var matches = regex.Matches(input);

        List<VariableInfo> variables = new List<VariableInfo>();

        foreach (Match match in matches)
        {
            string varName = match.Groups[1].Value;
            string numberValue = match.Groups[2].Value;
            string specialSymbol = match.Groups[4].Value;
            string tokenType = numberValue.Contains(".") ? "float" : "int";

            variables.Add(new VariableInfo
            {
                VarName = varName,
                SpecialSymbol = specialSymbol,
                TokenType = tokenType
            });
        }

        Console.WriteLine("\n{0,-10} | {1,-15} | {2,-10}", "VarName", "SpecialSymbol", "Token Type");
        Console.WriteLine(new string('-', 40));

        foreach (var v in variables)
        {
            Console.WriteLine("{0,-10} | {1,-15} | {2,-10}", v.VarName, v.SpecialSymbol, v.TokenType);
        }

        if (variables.Count == 0)
        {
            Console.WriteLine("No matching variables found.");
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
