using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class InstructionJump
    {
        public int[] arr = new int[10_000_000];

        [Benchmark]
        public void NormalInstructionJump()
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                count += C1(i);
            }
        }

        [Benchmark]
        public void NoInstructionJump()
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                count += C2(i);
            }
        }

        public int C1(int i)
        {
            if (i == 1)
            {
                return -1;
            }

            return i + 1;
        }

        public int C2(int i)
        {
            if (i != 1)
            {
                return i + 1;
            }

            return -1;
        }
    }
}
