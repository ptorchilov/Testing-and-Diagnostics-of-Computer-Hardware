namespace Lab07_08
{
    using System;
    using System.Collections.Generic;
    using FaultModels;
    using Tests;

    public class Tester
    {
        public void RunWalking_0_1(Faults type, Memory memory, List<List<int>> faults,
            AFFaults faultMode = AFFaults.SellNotAvailable)
        {
            var walkingTest = new Walking_0_1(faults);

            var coveredFaults = walkingTest.Test(memory, type, faultMode);

            ShowStatictics(type, coveredFaults.Count, faults.Count, faultMode);
        }

        private void ShowStatictics(Faults type, int coveredFaults, int faults,
            AFFaults faultMode = AFFaults.SellNotAvailable)
        {
            switch (type)
            {
                case Faults.AF:
                {
                    if (faultMode == AFFaults.SellNotAvailable)
                    {
                        Console.WriteLine("- Ошибки AF - ячейка не доступна - " + GetPercents(faults, coveredFaults) +
                                          " %");
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
            }
        }

        private String GetPercents(int faults, int coveredFaults)
        {
            var percents = (100*(double) coveredFaults)/faults;

            return String.Format("{0:0.00}", percents);
        }
    }
}