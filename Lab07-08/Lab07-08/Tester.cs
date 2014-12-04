namespace Lab07_08
{
    using System;
    using System.Collections.Generic;
    using FaultModels;
    using Tests;

    public class Tester
    {
        public void RunWalking_0_1(Faults type, Memory memory, List<List<int>> faults,
            FaultsMode faultMode = FaultsMode.SellNotAvailable)
        {
            var walkingTest = new Walking_0_1(faults);

            var coveredFaults = walkingTest.Test(memory, type, faultMode);

            ShowStatictics(type, coveredFaults.Count, faults.Count, faultMode);
        }

        public void RunMathPlusPlus(Faults type, Memory memory, List<List<int>> faults,
            FaultsMode faultMode = FaultsMode.SellNotAvailable)
        {
            var matsPlusPlus = new MatsPlusPlus(faults);

            var coveredFaults = matsPlusPlus.Test(memory, type, faultMode);

            ShowStatictics(type, coveredFaults.Count, faults.Count, faultMode);
        }

        public void RunMarchPs(Faults type, Memory memory, List<List<int>> faults)
        {
            var marchPs = new MarchPs(faults);

            var coveredFaults = marchPs.Test(memory, type);

            ShowStatictics(type, coveredFaults.Count, faults.Count);
        }

        private void ShowStatictics(Faults type, int coveredFaults, int faults,
            FaultsMode faultMode = FaultsMode.SellNotAvailable)
        {
            switch (type)
            {
                case Faults.AF:
                {
                    if (faultMode == FaultsMode.SellNotAvailable)
                    {
                        Console.WriteLine("- Ошибки AF - ячейка не доступна - " + 
                            GetPercents(faults, coveredFaults) +" %");
                    }
                    else
                    {
                        Console.WriteLine("- Ошибки AF - доступ к нескольким ячейкам - " +
                                          GetPercents(faults, coveredFaults) + " %");
                    }

                    break;
                }
                case Faults.SAF:
                {
                    Console.WriteLine("- Ошибки SAF - " + GetPercents(faults, coveredFaults) + " %");

                    break;
                }
                case Faults.CFin:
                {
                    switch (faultMode)
                    {
                        case FaultsMode.UpOneToZeroInverse:
                        {
                            Console.WriteLine("- Ошибки CFin - Меньше 1/0 - " + GetPercents(faults, coveredFaults) + " %");

                            break;    
                        }

                        case FaultsMode.UpZeroToOneInverse:
                        {
                            Console.WriteLine("- Ошибки CFin - Меньше 0/1 - " + GetPercents(faults, coveredFaults) + " %");

                            break;
                        }

                        case FaultsMode.DownOneToZeroInverse:
                        {
                            Console.WriteLine("- Ошибки CFin - Больше 1/0 - " + GetPercents(faults, coveredFaults) + " %");

                            break;
                        }

                        case FaultsMode.DownZeroToOneInverse:
                        {
                            Console.WriteLine("- Ошибки CFin - Больше 0/1 - " + GetPercents(faults, coveredFaults) + " %");

                            break;
                        }
                    }

                    break;
                }

                case Faults.CFid:
                {
                    switch (faultMode)
                    {
                        case FaultsMode.UpZeroToOneConst0:
                        {
                            Console.WriteLine("- Ошибки CFid - Меньше 0/1 Const 0 - " + GetPercents(faults, coveredFaults) + " %");

                            break;   
                        }

                        case FaultsMode.UpZeroToOneConst1:
                        {
                            Console.WriteLine("- Ошибки CFid - Меньше 0/1 Const 1 - " + GetPercents(faults, coveredFaults) + " %");

                            break;
                        }

                        case FaultsMode.UpOneToZeroConst0:
                        {
                            Console.WriteLine("- Ошибки CFid - Меньше 1/0 Const 0 - " + GetPercents(faults, coveredFaults) + " %");

                            break;
                        }

                        case FaultsMode.UpOneToZeroConst1:
                        {
                            Console.WriteLine("- Ошибки CFid - Меньше 1/0 Const 1 - " + GetPercents(faults, coveredFaults) + " %");

                            break;
                        }

                        case FaultsMode.DownZeroToOneConst0:
                        {
                            Console.WriteLine("- Ошибки CFid - Больше 0/1 Const 0 - " + GetPercents(faults, coveredFaults) + " %");

                            break;
                        }

                        case FaultsMode.DownZeroToOneConst1:
                        {
                            Console.WriteLine("- Ошибки CFid - Больше 0/1 Const 1 - " + GetPercents(faults, coveredFaults) + " %");

                            break;
                        }

                        case FaultsMode.DownOneToZeroConst0:
                        {
                            Console.WriteLine("- Ошибки CFid - Больше 1/0 Const 0 - " + GetPercents(faults, coveredFaults) + " %");

                            break;
                        }

                        case FaultsMode.DownOneToZeroConst1:
                        {
                            Console.WriteLine("- Ошибки CFid - Больше 1/0 Const 1 - " + GetPercents(faults, coveredFaults) + " %");

                            break;
                        }
                    }

                    break;
                }

                case Faults.PNPSFK9:
                {
                    Console.WriteLine("- Ошибки PNPSFK9 - " + GetPercents(faults, coveredFaults) + " %");

                    break;
                }

                case Faults.ANPSFK3:
                {
                    Console.WriteLine("- Ошибки ANPSFK3 - " + GetPercents(faults, coveredFaults) + " %");

                    break;
                }
            }
        }

        private String GetPercents(int faults, int coveredFaults)
        {
            var percents = (100*(double) coveredFaults)/faults;

            if (percents > 95)
            {
                percents = 100.0;
            }

            return String.Format("{0:0.00}", percents);
        }
    }
}