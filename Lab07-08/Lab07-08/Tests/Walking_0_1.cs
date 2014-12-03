namespace Lab07_08.Tests
{
    using System.Collections.Generic;
    using FaultModels;
    using Lab07_08;

    // ReSharper disable once InconsistentNaming
    public class Walking_0_1
    {
        private List<List<int>> Faults { get; set; }

        private List<List<int>> CoveredFaults { get; set; }
        
        public Walking_0_1(List<List<int>> faults)
        {
            Faults = faults;
            CoveredFaults = new List<List<int>>(faults.Count);
        }

        public List<List<int>> Test(Memory memory, Faults faultType, AFFaults mode = AFFaults.SellNotAvailable)
        {
            CoveredFaults.Clear();

            for (var i = 0; i < memory.Width; i++)
            {
                for (var j = 0; j < memory.Height; j++)
                {
                    MakeTest(memory, i, j, faultType, mode);
                }
            }

            return CoveredFaults;
        }

        private void MakeTest(Memory memory, int i, int j, Faults faultType, AFFaults mode)
        {
            //1. Read base
            var baseSell = ReadSingle(memory, i, j);

            //2. Write all not base
            WriteAll(memory, i, j, baseSell == 0 ? 1 : 0, faultType, mode);

            //3. Read all
            ReadAll(memory, i, j, baseSell == 0 ? 1 : 0);

            //4. Read base
            var newBaseSell = ReadSingle(memory, i, j);

            if (baseSell != newBaseSell)
            {
                if (GetNumberOfFault(CoveredFaults, i, j) == -1)
                {
                    var fault = new List<int> {i, j};

                    CoveredFaults.Add(fault);
                }
            }
        }

        private int GetNumberOfFault(List<List<int>> faultsList, int i, int j)
        {
            for (var k = 0; k < faultsList.Count; k++)
            {
                var item = faultsList[k];

                if (item[0] == i && item[1] == j)
                {
                    return k;
                }
            }

            return -1;
        }

        private void WriteAll(Memory memory, int baseI, int baseJ, int value, Faults faultType, AFFaults mode = AFFaults.SellNotAvailable)
        {
            for (var i = 0; i < memory.Width; i++)
            {
                for (var j = 0; j < memory.Height; j++)
                {
                    switch (faultType)
                    {
                        case Lab07_08.Faults.AF:
                        {
                            WriteAf(memory, baseI, baseJ, value, mode, i, j);

                            break;
                        }

                        case Lab07_08.Faults.SAF:
                        {
                            WriteSaf(memory, baseI, baseJ, value, i, j);

                            break;
                        }
                    }
                    
                }
            }
        }

        private void WriteSaf(Memory memory, int baseI, int baseJ, int value, int i, int j)
        {
            if (!(i == baseI && j == baseJ))
            {
                if (GetNumberOfFault(Faults, i, j) == -1)
                {
                    memory[i, j] = value;
                }
            }
        }

        private void WriteAf(Memory memory, int baseI, int baseJ, int value, AFFaults mode, int i, int j)
        {
            if (!(i == baseI && j == baseJ))
            {
                if (GetNumberOfFault(Faults, i, j) != -1)
                {
                    if (mode == AFFaults.SeveralAddress)
                    {
                        memory[i, j] = value;

                        if (i == 0)
                        {
                            memory[i + 1, j] = value;
                        }
                        else if (j == 0)
                        {
                            memory[i, j + 1] = value;
                        }
                        else
                        {
                            memory[i - 1, j - 1] = value;
                        }
                    }
                }
                else
                {
                    memory[i, j] = value;
                }
            }
        }

        private int ReadSingle(Memory memory, int i, int j)
        {
            return memory[i, j];
        }

        private void ReadAll(Memory memory, int baseI, int baseJ, int correctValue)
        {
            for (var i = 0; i < memory.Width; i++)
            {
                for (var j = 0; j < memory.Height; j++)
                {
                    if (!(i == baseI && j == baseJ))
                    {
                        var currentSell = memory[i, j];

                        if (currentSell != correctValue)
                        {
                            if (GetNumberOfFault(CoveredFaults, i, j) == -1)
                            {
                                var fault = new List<int> {i, j};

                                CoveredFaults.Add(fault);
                            }
                        }
                    }
                }
            }
        }
    }
}