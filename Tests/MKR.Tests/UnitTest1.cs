using NUnit.Framework;
using System;
using System.Numerics;

public class ProgramTests
{
    [TestCase("4", "27")]
    [TestCase("1", "1")]
    [TestCase("100000", "250006250025000")]
    [TestCase("10", "315")]
    [TestCase("50", "32825")]
    [TestCase("12345", "470436743383")]
    public void Test_CalculateResult_ValidInputs(string input, string expected)
    {
        // Act
        string result = CalculateResult(input);

        // Print the result to the console for debugging
        Console.WriteLine($"Input: {input}, Expected: {expected}, Result: {result}");

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("100001")] // Out of range
    [TestCase("-1")]     // Below valid range
    [TestCase("abc")]    // Non-numeric
    [TestCase("9999999999999999999")] // Exceedingly large number
    public void Test_CalculateResult_InvalidInputs(string input)
    {
        string result = CalculateResult(input);

        // Print the result to the console for debugging
        Console.WriteLine($"Input: {input}, Result: {result}");

        // Assert
        Assert.IsNull(result);
    }

    private string CalculateResult(string input)
    {
        if (BigInteger.TryParse(input, out BigInteger n))
        {
            if (n < 1 || n > 100000)
            {
                return null;
            }
            
            //BigInteger
            BigInteger result =  n * (n + 2) * (n * 2 + 1) / 8;
            return result.ToString();
        }
        return null;
    }
}
