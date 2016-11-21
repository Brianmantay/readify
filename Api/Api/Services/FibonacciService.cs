using System;
using System.Collections.Generic;

namespace Api.Services
{
    public class FibonacciService : IFibonacciService
    {
        public long GetNumberInSequenceFromIndex(int index)
        {
            bool isNegative = false;
            if (index < 0)
            {
                isNegative = true;
                index = index*-1;
            }
            
            var sequence = new List<long>() { 0, 1 };
            for (int i = 2; i <= index; i++)
            {
                long fib;
                checked
                {
                    fib = isNegative
                    ? sequence[i - 2] - sequence[i - 1]
                    : sequence[i - 2] + sequence[i - 1];
                }
                sequence.Add(fib);
            }

            return sequence[index];
        }
    }
}