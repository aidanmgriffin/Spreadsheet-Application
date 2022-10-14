using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    /// <summary>
    /// The summary for the fib text reader.
    /// </summary>
    public class FibonacciTextReader : TextReader
    {
        /// <summary>
        /// Length of fibonacci sequence (determined 50/100 by user)
        /// </summary>
        private int maxLines;

        /// <summary>
        /// Integers which keep track of the previous values in the fibonacci sequence.
        /// </summary>
        private BigInteger a = 0;
        private BigInteger b = 0;
        private BigInteger c = 0;

        /// <summary>
        /// Keeps track of the current length of the fib. sequence to make sure it doesn't exceed maxlines.
        /// </summary>
        private int n = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="FibonacciTextReader"/> class.
        /// </summary>
        /// <param name="maxLines"> The maximum number of numbers in the sequence that can be generated. </param>
        public FibonacciTextReader(int maxValue)
        {
            this.maxLines = maxValue;
        }

        /// <summary>
        /// Overrides ReadLine. Instead spits out the fibonacci sequence up to a maximum number (n). 
        /// Once n is reached, it will return null and end the sequence.
        /// </summary>
        /// <returns> Location in fib. seq.: number in fib. seq. </returns>
        public override string? ReadLine()
        {
            this.n++;

            if (this.n > this.maxLines)
            {
                return null;
            }

            if ((this.a == 0) && (this.b == 0))
            {
                this.b = 1;
                return "1: " + this.a;
            }
            else if ((this.a == 0) && (this.b == 1))
            {
                this.a = 1;
                return "2: " + this.b;
            }
            else
            {
                this.c = this.a + this.b;
                this.a = this.b;
                this.b = this.c;
                return this.n + ": " + this.c;
            }
        }

        /// <summary>
        /// Loop readline function and combines them into a string which will be loaded on to the interface.
        /// </summary>
        /// <returns> String of combined fibonacci lines. </returns>
        public override string ReadToEnd()
        {
            string display = string.Empty;

            StringBuilder sb = new StringBuilder();

            while (display != null)
            {

                display = ReadLine();

                sb.AppendLine(display);

            }

            return sb.ToString();
        }
    }
}
