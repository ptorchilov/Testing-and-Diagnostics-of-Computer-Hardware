namespace Lab07_08
{
    using System;
    using System.Runtime.ConstrainedExecution;
    using FaultModels;
    
    public class Program
    {
        private const int MemorySize = 24;

        private const int ErrorNumber = 32;

        private const int ErrorLength = 10;

        private const int AfLength = 1;

        public static void Main(String[] args)
        {

            for (var i = 0; i < 10; i++)
            {

                var memory = new Memory(MemorySize, MemorySize);

                var errors = Utilities.GetRandomErrors(ErrorNumber, MemorySize);

                var tester = new Tester();

                Console.WriteLine("Тест Walking 0/1:");

                //AF
                tester.RunWalking_0_1(Faults.AF, memory, errors, FaultsMode.SellNotAvailable);

                errors = Utilities.GetRandomErrors(ErrorNumber, MemorySize, true, AfLength);
                tester.RunWalking_0_1(Faults.AF, memory, errors, FaultsMode.SeveralAddress);

                //SAF
                tester.RunWalking_0_1(Faults.SAF, memory, errors);

                //CFin
                errors = Utilities.GetRandomErrors(ErrorNumber, MemorySize, false, ErrorLength);
                tester.RunWalking_0_1(Faults.CFin, memory, errors, FaultsMode.UpOneToZeroInverse);
                tester.RunWalking_0_1(Faults.CFin, memory, errors, FaultsMode.DownOneToZeroInverse);

                errors = Utilities.GetRandomErrors(ErrorNumber, MemorySize, true, ErrorLength);
                tester.RunWalking_0_1(Faults.CFin, memory, errors, FaultsMode.UpZeroToOneInverse);
                tester.RunWalking_0_1(Faults.CFin, memory, errors, FaultsMode.DownZeroToOneInverse);

                //CFid
                errors = Utilities.GetRandomErrors(ErrorNumber, MemorySize, false, ErrorLength);
                memory = Memory.InitMemory(memory, 1);
                tester.RunWalking_0_1(Faults.CFid, memory, errors, FaultsMode.UpZeroToOneConst0);
                tester.RunWalking_0_1(Faults.CFid, memory, errors, FaultsMode.UpZeroToOneConst1);
                tester.RunWalking_0_1(Faults.CFid, memory, errors, FaultsMode.UpOneToZeroConst0);
                memory = Memory.InitMemory(memory, 1);
                tester.RunWalking_0_1(Faults.CFid, memory, errors, FaultsMode.UpOneToZeroConst1);

                errors = Utilities.GetRandomErrors(ErrorNumber, MemorySize, true, ErrorLength);
                tester.RunWalking_0_1(Faults.CFid, memory, errors, FaultsMode.DownZeroToOneConst0);
                tester.RunWalking_0_1(Faults.CFid, memory, errors, FaultsMode.DownZeroToOneConst1);
                tester.RunWalking_0_1(Faults.CFid, memory, errors, FaultsMode.DownOneToZeroConst0);
                tester.RunWalking_0_1(Faults.CFid, memory, errors, FaultsMode.DownOneToZeroConst1);


                Console.WriteLine();
                
            }

            Console.ReadKey();

        }
    }
}
