using System;

class FinancialForecast
{
    // Step 2: Recursive method to calculate future value
    static double ForecastFutureValue(double presentValue, double growthRate, int periods)
    {
        // Base case
        if (periods == 0)
            return presentValue;

        // Recursive step
        return (1 + growthRate) * ForecastFutureValue(presentValue, growthRate, periods - 1);
    }

    // Step 3: Implementation example
    static void Main()
    {
        double presentValue = 1000;
        double growthRate = 0.05;
        int periods = 3;

        double futureValue = ForecastFutureValue(presentValue, growthRate, periods);
        Console.WriteLine("Future Value: " + futureValue);
    }

    // Step 4: Time complexity analysis (in comment)
    // Time complexity: O(n), where n = number of periods.
    // Optimization: Use iteration or Math.Pow to reduce recursion overhead.
}
