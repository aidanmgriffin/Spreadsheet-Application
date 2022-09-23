using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotepadApplication
{
    /// <summary>
    /// The summary for the fib text reader.
    /// </summary>
    internal class FibonacciTextReader : TextReader
    {
        private int maxLines;

        private int a = 0;
        private int b = 0;
        private int c = 0;
        private int n = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="FibonacciTextReader"/> class.
        /// </summary>
        /// <param name="maxLines"> The maximum number of numbers in the sequence that can be generated. </param>
        public FibonacciTextReader(int maxValue)
        {
            int maxLines = maxValue;
        }

        public override string ReadLine()
        {
            // number of lines.

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
        /// Loop readline function.
        /// </summary>
        /// <returns> CHANGE---THIS---. </returns>
        public override string ReadToEnd()
        {
            return base.ReadToEnd();
        }
    }
}
