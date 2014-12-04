namespace Lab07_08
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.ConstrainedExecution;
    using FaultModels;

    public class Program
    {
        private const int MemorySize = 23;

        private const int ErrorNumber = 32;

        private const int ErrorLength = 10;

        private const int SingleErrorLength = 1;

        public static void Main(String[] args)
        {
            var memory = new Memory(MemorySize, MemorySize);

            var errors = Utilities.GetRandomErrors(ErrorNumber, MemorySize);

            var tester = new Tester();

            RunWalkingTests(tester, memory, errors);

            RunMatsPlusPlusTests(tester, memory, errors);

            RunMarchPsTests(tester, memory, errors);


            Console.ReadKey();
        }

        private static void RunMarchPsTests(Tester tester, Memory memory, List<List<int>> errors)
        {
            Console.WriteLine("Тест MarchPS:");

            //PNPSFK9
            errors = Utilities.GetRandomErrors(ErrorNumber, MemorySize, true, true, SingleErrorLength, SingleErrorLength);
            tester.RunMathPlusPlus(Faults.PNPSFK9, memory, errors);

            //ANPSFK3
            tester.RunMathPlusPlus(Faults.ANPSFK3, memory, errors);


            Console.WriteLine();
        }

        private static void RunMatsPlusPlusTests(Tester tester, Memory memory, List<List<int>> errors)
        {
            Console.WriteLine("Тест MATS++:");

            //AF
            tester.RunMathPlusPlus(Faults.AF, memory, errors, FaultsMode.SellNotAvailable);

            errors = Utilities.GetRandomErrors(ErrorNumber, MemorySize, true, false, SingleErrorLength);
            tester.RunMathPlusPlus(Faults.AF, memory, errors, FaultsMode.SeveralAddress);

            //SAF
            tester.RunMathPlusPlus(Faults.SAF, memory, errors);

            //CFin
            errors = Utilities.GetRandomErrors(ErrorNumber, MemorySize, false, false, ErrorLength);
            tester.RunMathPlusPlus(Faults.CFin, memory, errors, FaultsMode.UpOneToZeroInverse);
            tester.RunMathPlusPlus(Faults.CFin, memory, errors, FaultsMode.DownOneToZeroInverse);

            errors = Utilities.GetRandomErrors(ErrorNumber, MemorySize, true, false, ErrorLength);
            tester.RunMathPlusPlus(Faults.CFin, memory, errors, FaultsMode.UpZeroToOneInverse);
            tester.RunMathPlusPlus(Faults.CFin, memory, errors, FaultsMode.DownZeroToOneInverse);

            //CFid
            errors = Utilities.GetRandomErrors(ErrorNumber, MemorySize, false, false, ErrorLength);
            tester.RunMathPlusPlus(Faults.CFid, memory, errors, FaultsMode.UpZeroToOneConst0);
            tester.RunMathPlusPlus(Faults.CFid, memory, errors, FaultsMode.UpZeroToOneConst1);
            tester.RunMathPlusPlus(Faults.CFid, memory, errors, FaultsMode.UpOneToZeroConst0);
            tester.RunMathPlusPlus(Faults.CFid, memory, errors, FaultsMode.UpOneToZeroConst1);

            errors = Utilities.GetRandomErrors(ErrorNumber, MemorySize, true, false, ErrorLength);
            tester.RunMathPlusPlus(Faults.CFid, memory, errors, FaultsMode.DownZeroToOneConst0);
            tester.RunMathPlusPlus(Faults.CFid, memory, errors, FaultsMode.DownZeroToOneConst1);
            tester.RunMathPlusPlus(Faults.CFid, memory, errors, FaultsMode.DownOneToZeroConst0);
            tester.RunMathPlusPlus(Faults.CFid, memory, errors, FaultsMode.DownOneToZeroConst1);

            //PNPSFK9
            errors = Utilities.GetRandomErrors(ErrorNumber, MemorySize, true, true, SingleErrorLength, SingleErrorLength);
            tester.RunMathPlusPlus(Faults.PNPSFK9, memory, errors);

            //ANPSFK3
            tester.RunMathPlusPlus(Faults.ANPSFK3, memory, errors);


            Console.WriteLine();
        }

        private static void RunWalkingTests(Tester tester, Memory memory, List<List<int>> errors)
        {
            Console.WriteLine("Тест Walking 0/1:");

            //AF
            tester.RunWalking_0_1(Faults.AF, memory, errors, FaultsMode.SellNotAvailable);

            errors = Utilities.GetRandomErrors(ErrorNumber, MemorySize, true, false, SingleErrorLength);
            tester.RunWalking_0_1(Faults.AF, memory, errors, FaultsMode.SeveralAddress);

            //SAF
            tester.RunWalking_0_1(Faults.SAF, memory, errors);

            //CFin
            errors = Utilities.GetRandomErrors(ErrorNumber, MemorySize, false, false, ErrorLength);
            tester.RunWalking_0_1(Faults.CFin, memory, errors, FaultsMode.UpOneToZeroInverse);
            tester.RunWalking_0_1(Faults.CFin, memory, errors, FaultsMode.DownOneToZeroInverse);

            errors = Utilities.GetRandomErrors(ErrorNumber, MemorySize, true, false, ErrorLength);
            tester.RunWalking_0_1(Faults.CFin, memory, errors, FaultsMode.UpZeroToOneInverse);
            tester.RunWalking_0_1(Faults.CFin, memory, errors, FaultsMode.DownZeroToOneInverse);

            //CFid
            errors = Utilities.GetRandomErrors(ErrorNumber, MemorySize, false, false, ErrorLength);
            tester.RunWalking_0_1(Faults.CFid, memory, errors, FaultsMode.UpZeroToOneConst0);
            tester.RunWalking_0_1(Faults.CFid, memory, errors, FaultsMode.UpZeroToOneConst1);
            tester.RunWalking_0_1(Faults.CFid, memory, errors, FaultsMode.UpOneToZeroConst0);
            tester.RunWalking_0_1(Faults.CFid, memory, errors, FaultsMode.UpOneToZeroConst1);

            errors = Utilities.GetRandomErrors(ErrorNumber, MemorySize, true, false, ErrorLength);
            tester.RunWalking_0_1(Faults.CFid, memory, errors, FaultsMode.DownZeroToOneConst0);
            tester.RunWalking_0_1(Faults.CFid, memory, errors, FaultsMode.DownZeroToOneConst1);
            tester.RunWalking_0_1(Faults.CFid, memory, errors, FaultsMode.DownOneToZeroConst0);
            tester.RunWalking_0_1(Faults.CFid, memory, errors, FaultsMode.DownOneToZeroConst1);


            Console.WriteLine();
        }
    }
}