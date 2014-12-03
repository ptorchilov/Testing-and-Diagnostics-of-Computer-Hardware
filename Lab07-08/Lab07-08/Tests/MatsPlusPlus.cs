namespace Lab07_08.Tests
{
    using System.Collections.Generic;
    using FaultModels;

    public class MatsPlusPlus
    {
        private List<List<int>> Faults { get; set; }

        private List<List<int>> CoveredFaults { get; set; }

        private const int Condition = 10;

        public MatsPlusPlus(List<List<int>> faults)
        {
            Faults = faults;
            CoveredFaults = new List<List<int>>(faults.Count);
        }

        public List<List<int>> Test(Memory memory, Faults faultType, FaultsMode mode = FaultsMode.SellNotAvailable)
        {
            CoveredFaults.Clear();

            //1. Write All 0
            WriteAll(memory, 0, faultType, true, mode);

            //2. Read All Up 0 
            ReadAll(memory, 0, true);

            //3. Write All Up 1
            WriteAll(memory, 1, faultType, true, mode);

            //4. Read All Down 1
            ReadAll(memory, 1, false);

            //5. Write All Down 0
            WriteAll(memory, 0, faultType, false, mode);

            //6. Read All Down 0
            ReadAll(memory, 0, false);

            //TODO: это должно выполняться польностью на всей памяти на не в каждой итерации

            return CoveredFaults;
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

        private void WriteAll(Memory memory, int value, Faults faultType, bool direction,
            FaultsMode mode = FaultsMode.SellNotAvailable)
        {
            if (direction)
            {
                for (var i = 0; i < memory.Width; i++)
                {
                    for (var j = 0; j < memory.Height; j++)
                    {
                        switch (faultType)
                        {
                            case Lab07_08.Faults.AF:
                            {
                                WriteAf(memory, value, mode, i, j);

                                break;
                            }

                            case Lab07_08.Faults.SAF:
                            {
                                WriteSaf(memory, value, i, j);

                                break;
                            }
                            case Lab07_08.Faults.CFin:
                            {
                                WriteCfin(memory, value, i, j, mode);

                                break;
                            }
                            case Lab07_08.Faults.CFid:
                            {
                                WriteCfid(memory, value, i, j, mode);

                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                //TODO: здесь могут быть проблемы с адресацией
                for (var i = memory.Width - 1; i >= 0; i--)
                {
                    for (var j = memory.Height - 1; j >= 0; j--)
                    {
                        switch (faultType)
                        {
                            case Lab07_08.Faults.AF:
                            {
                                WriteAf(memory, value, mode, i, j);

                                break;
                            }

                            case Lab07_08.Faults.SAF:
                            {
                                WriteSaf(memory, value, i, j);

                                break;
                            }
                            case Lab07_08.Faults.CFin:
                            {
                                WriteCfin(memory, value, i, j, mode);

                                break;
                            }
                            case Lab07_08.Faults.CFid:
                            {
                                WriteCfid(memory, value, i, j, mode);

                                break;
                            }
                        }
                    }
                }
            }
        }

        private void WriteCfid(Memory memory, int value, int i, int j, FaultsMode mode)
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

        private void WriteCfin(Memory memory, int value, int i, int j, FaultsMode mode)
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

        private void WriteSaf(Memory memory, int value, int i, int j)
        {
            if (GetNumberOfFault(Faults, i, j) == -1)
            {
                memory[i, j] = value;
            }
        }

        private void WriteAf(Memory memory, int value, FaultsMode mode, int i, int j)
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

        private int ReadSingle(Memory memory, int i, int j)
        {
            return memory[i, j];
        }

        private void ReadAll(Memory memory, int correctValue, bool direction)
        {
            if (direction)
            {
                for (var i = 0; i < memory.Width; i++)
                {
                    for (var j = 0; j < memory.Height; j++)
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
            else
            {
                for (var i = memory.Width - 1; i >= 0; i--)
                {
                    for (var j = memory.Height - 1; j >= 0; j--)
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