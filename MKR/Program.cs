using System;
using System.IO;

namespace MKR{
    public class Program
    {
        static void Main()
        {
            try
            {
                // Get the project root directory by navigating up three levels from the executable's location
                string rootDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\")); 

                // Define the paths for INPUT.txt and OUTPUT.txt relative to the project root directory
                string inputPath = Path.Combine(rootDirectory, "INPUT.txt");
                string outputPath = Path.Combine(rootDirectory, "OUTPUT.txt");

                // Debug print to ensure paths are correct
                Console.WriteLine($"Looking for INPUT.txt at: {inputPath}");
                Console.WriteLine($"Output will be saved to: {outputPath}");

                if (!File.Exists(inputPath))
                {
                    Console.WriteLine($"Error: The file {inputPath} was not found.");
                    return;
                }

                string input = File.ReadAllText(inputPath).Trim();

                if (long.TryParse(input, out long n))
                {
                    // Validate the input
                    if (!IsValid(n))
                    {
                        Console.WriteLine("Error: The value of N must be in the range from 1 to 100000.");
                        return;
                    }

                    // Calculate the result
                    long result = CalculateResult(n);

                    // Write the result to the output file
                    File.WriteAllText(outputPath, result.ToString());

                    Console.WriteLine("The result was successfully written to OUTPUT.txt");
                }
                else
                {
                    Console.WriteLine("Error: Invalid data in INPUT.txt.");
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Error: No access to the file. Please check the file permissions.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"I/O Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }

        // Function to check if the input value is valid
        public static bool IsValid(long n)
        {
            return n >= 1 && n <= 100000;
        }

        // Function to perform the calculation
        public static long CalculateResult(long n)
        {
            // The formula: (n * (n + 2) * (2n + 1)) / 8
            return n * (n + 2) * (2 * n + 1) / 8;
        }
}
}
