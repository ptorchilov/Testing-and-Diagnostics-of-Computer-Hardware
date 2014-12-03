namespace Lab07_08
{
    using System;
    using FaultModels;
    
    public class Program
    {
        private const int MemorySize = 23;

        public static void Main(String[] args)
        {
            for (var i = 0; i < 10; i++)
            {

                var memory = new Memory(MemorySize, MemorySize);

                var errors = Utilities.GetRandomErrors(32, MemorySize);

                var tester = new Tester();

                Console.WriteLine("Тест Walking 0/1:");

                tester.RunWalking_0_1(Faults.AF, memory, errors);
                tester.RunWalking_0_1(Faults.AF, memory, errors, AFFaults.SeveralAddress);

                tester.RunWalking_0_1(Faults.SAF, memory, errors);
            }

            Console.ReadKey();

        }
    }
}
