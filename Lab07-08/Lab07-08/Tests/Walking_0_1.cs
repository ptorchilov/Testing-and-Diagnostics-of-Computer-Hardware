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

        private const int Condition = 10;

        public Walking_0_1(List<List<int>> faults)
        {
            Faults = faults;
            CoveredFaults = new List<List<int>>(faults.Count);
        }

        public List<List<int>> Test(Memory memory, Faults faultType, FaultsMode mode = FaultsMode.SellNotAvailable)
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

        private void MakeTest(Memory memory, int i, int j, Faults faultType, FaultsMode mode)
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

        private void WriteAll(Memory memory, int baseI, int baseJ, int value, Faults faultType, FaultsMode mode = FaultsMode.SellNotAvailable)
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
                        case Lab07_08.Faults.CFin:
                        {
                            WriteCfin(memory, baseI, baseJ, value, i, j, mode);

                            break;
                        }
                        case Lab07_08.Faults.CFid:
                        {
                            WriteCfid(memory, baseI, baseJ, value, i, j, mode);

                            break;
                        }
                    }
                    
                }
            }
        }

        private void WriteCfid(Memory memory, int baseI, int baseJ, int value, int i, int j, FaultsMode mode)
        {
            if (!(i == baseI && j == baseJ))
            {
                switch (mode)
                {
                    case FaultsMode.UpZeroToOneConst0:
                    {
                        var sell = ReadSingle(memory, i, j);

                        if (sell == 0 && value == 1 && GetNumberOfFault(Faults, i, j) != -1)
                        {
                            memory[i, j + Condition] = 0;
                        }

                        memory[i, j] = value;

                        break;
                    }

                    case FaultsMode.UpZeroToOneConst1:
                    {
                        var sell = ReadSingle(memory, i, j);

                        if (sell == 0 && value == 1 && GetNumberOfFault(Faults, i, j) != -1)
                        {
                            memory[i, j + Condition] = 1;
                        }

                        memory[i, j] = value;

                        break;
                    }

                    case FaultsMode.UpOneToZeroConst0:
                    {
                        var sell = ReadSingle(memory, i, j);

                        if (sell == 1 && value == 0 && GetNumberOfFault(Faults, i, j) != -1)
                        {
                            memory[i, j + Condition] = 0;
                        }

                        memory[i, j] = value;

                        break;
                    }

                    case FaultsMode.UpOneToZeroConst1:
                    {
                        var sell = ReadSingle(memory, i, j);

                        if (sell == 1 && value == 0 && GetNumberOfFault(Faults, i, j) != -1)
                        {
                            memory[i, j + Condition] = 1;
                        }

                        memory[i, j] = value;

                        break;
                    }

                    case FaultsMode.DownZeroToOneConst0:
                    {
                        var sell = ReadSingle(memory, i, j);

                        if (sell == 0 && value == 1 && GetNumberOfFault(Faults, i, j) != -1)
                        {
                            memory[i, j - Condition] = 0;
                        }

                        memory[i, j] = value;

                        break;
                    }

                    case FaultsMode.DownZeroToOneConst1:
                    {
                        var sell = ReadSingle(memory, i, j);

                        if (sell == 0 && value == 1 && GetNumberOfFault(Faults, i, j) != -1)
                        {
                            memory[i, j - Condition] = 1;
                        }

                        memory[i, j] = value;

                        break;
                    }

                    case FaultsMode.DownOneToZeroConst0:
                    {
                        var sell = ReadSingle(memory, i, j);

                        if (sell == 1 && value == 0 && GetNumberOfFault(Faults, i, j) != -1)
                        {
                            memory[i, j - Condition] = 0;
                        }

                        memory[i, j] = value;

                        break;
                    }

                    case FaultsMode.DownOneToZeroConst1:
                    {
                        var sell = ReadSingle(memory, i, j);

                        if (sell == 1 && value == 0 && GetNumberOfFault(Faults, i, j) != -1)
                        {
                            memory[i, j - Condition] = 1;
                        }

                        memory[i, j] = value;

                        break;
                    }
                }
            }
        }

        private void WriteCfin(Memory memory, int baseI, int baseJ, int value, int i, int j, FaultsMode mode)
        {
            if (!(i == baseI && j == baseJ))
            {
                switch (mode)
                {
                    case FaultsMode.UpOneToZeroInverse:
                    {
                        var sell = ReadSingle(memory, i, j);    

                        if (sell == 1 && value == 0 && GetNumberOfFault(Faults, i, j) != -1)
                        {
                            var victim = ReadSingle(memory, i, j + Condition);

                            if (victim == 0)
                            {
                                memory[i, j + Condition] = 1;    
                            }
                            else
                            {
                                memory[i, j + Condition] = 0;
                            }
                            
                        }

                        memory[i, j] = value;

                        break;
                    }

                    case FaultsMode.UpZeroToOneInverse:
                    {
                        var sell = ReadSingle(memory, i, j);

                        if (sell == 0 && value == 1 && GetNumberOfFault(Faults, i, j) != -1)
                        {
                            var victim = ReadSingle(memory, i, j - Condition);

                            if (victim == 0)
                            {
                                memory[i, j - Condition] = 1;
                            }
                            else
                            {
                                memory[i, j - Condition] = 0;
                            }
                        }

                        memory[i, j] = value;

                        break;
                    }

                    case FaultsMode.DownOneToZeroInverse:
                    {
                        var sell = ReadSingle(memory, i, j);

                        if (sell == 1 && value == 0 && GetNumberOfFault(Faults, i, j) != -1)
                        {
                            var victim = ReadSingle(memory, i, j + Condition);

                            if (victim == 0)
                            {
                                memory[i, j + Condition] = 1;
                            }
                            else
                            {
                                memory[i, j + Condition] = 0;
                            }
                        }

                        memory[i, j] = value;

                        break;
                    }

                    case FaultsMode.DownZeroToOneInverse:
                    {
                        var sell = ReadSingle(memory, i, j);

                        if (sell == 0 && value == 1 && GetNumberOfFault(Faults, i, j) != -1)
                        {
                            var victim = ReadSingle(memory, i, j - Condition);

                            if (victim == 0)
                            {
                                memory[i, j - Condition] = 1;
                            }
                            else
                            {
                                memory[i, j - Condition] = 0;
                            }
                        }

                        memory[i, j] = value;

                        break;
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

        private void WriteAf(Memory memory, int baseI, int baseJ, int value, FaultsMode mode, int i, int j)
        {
            if (!(i == baseI && j == baseJ))
            {
                if (GetNumberOfFault(Faults, i, j) != -1)
                {
                    if (mode == FaultsMode.SeveralAddress)
                    {
                        memory[i, j] = value;

                        memory[i, j - 1] = value;
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