namespace Lab07_08
{
    using System;
    
    public class Program
    {
        private const int MemorySize = 16;

        public static void Main(String[] args)
        {
            var memory = new Memory(MemorySize, MemorySize);

            Memory.ShowMemoryState(memory);
        }
    }
}
