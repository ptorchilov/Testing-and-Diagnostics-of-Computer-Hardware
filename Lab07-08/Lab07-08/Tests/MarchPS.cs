namespace Lab07_08.Tests
{
    using System.Collections.Generic;
    using FaultModels;

    public class MarchPs
    {
        private List<List<int>> Faults { get; set; }

        private List<List<int>> CoveredFaults { get; set; }

        public MarchPs(List<List<int>> faults)
        {
            Faults = faults;
            CoveredFaults = new List<List<int>>(faults.Count);
        }

        public List<List<int>> Test(Memory memory, Faults faultType)
        {
            CoveredFaults.Clear();

            for (var i = 0; i < memory.Width; i++)
            {
                for (var j = 0; j < memory.Height; j++)
                {
                    //1. Write All 0
                    WriteAll(memory, 0, i, j, faultType);
                }
            }


            

            for (var i = 0; i < memory.Width; i++)
            {
                for (var j = 0; j < memory.Height; j++)
                {
                    var etalon = 0;
                    //2. Read Up 0 
                    var sell = ReadSingle(memory, i, j);

                    if (sell != etalon)
                    {
                        if (GetNumberOfFault(CoveredFaults, i, j) == -1)
                        {
                            var fault = new List<int> {i, j};

                            CoveredFaults.Add(fault);
                        }
                    }
                    //3. Write Up 1
                    WriteAll(memory, 1, i, j, faultType);
                    etalon = 1;

                    //4. Read Up 1
                    sell = ReadSingle(memory, i, j);

                    if (sell != etalon)
                    {
                        if (GetNumberOfFault(CoveredFaults, i, j) == -1)
                        {
                            var fault = new List<int> { i, j };

                            CoveredFaults.Add(fault);
                        }
                    }

                    //5. Write Up 0
                    WriteAll(memory, 0, i, j, faultType);
                    etalon = 0;

                    //6. Read Up 0
                    sell = ReadSingle(memory, i, j);

                    if (sell != etalon)
                    {
                        if (GetNumberOfFault(CoveredFaults, i, j) == -1)
                        {
                            var fault = new List<int> { i, j };

                            CoveredFaults.Add(fault);
                        }
                    }

                    //7. Write Up 1
                    WriteAll(memory, 1, i, j, faultType);
                }
            }

            for (var i = 0; i < memory.Width; i++)
            {
                for (var j = 0; j < memory.Height; j++)
                {
                    var etalon = 1;
                    //8. Read Up 1 
                    var sell = ReadSingle(memory, i, j);

                    if (sell != etalon)
                    {
                        if (GetNumberOfFault(CoveredFaults, i, j) == -1)
                        {
                            var fault = new List<int> {i, j};

                            CoveredFaults.Add(fault);
                        }
                    }
                    //9. Write Up 0
                    WriteAll(memory, 0, i, j, faultType);
                    etalon = 0;

                    //10. Read Up 0
                    sell = ReadSingle(memory, i, j);

                    if (sell != etalon)
                    {
                        if (GetNumberOfFault(CoveredFaults, i, j) == -1)
                        {
                            var fault = new List<int> {i, j};

                            CoveredFaults.Add(fault);
                        }
                    }

                    //11. Write Up 1
                    WriteAll(memory, 1, i, j, faultType);
                    etalon = 1;

                    //12. Read Up 1
                    sell = ReadSingle(memory, i, j);

                    if (sell != etalon)
                    {
                        if (GetNumberOfFault(CoveredFaults, i, j) == -1)
                        {
                            var fault = new List<int> {i, j};

                            CoveredFaults.Add(fault);
                        }
                    }
                }
            }

            for (var i = 0; i < memory.Width; i++)
            {
                for (var j = 0; j < memory.Height; j++)
                {
                    var etalon = 1;
                    //13. Read Up 1 
                    var sell = ReadSingle(memory, i, j);

                    if (sell != etalon)
                    {
                        if (GetNumberOfFault(CoveredFaults, i, j) == -1)
                        {
                            var fault = new List<int> { i, j };

                            CoveredFaults.Add(fault);
                        }
                    }
                    //14. Write Up 0
                    WriteAll(memory, 0, i, j, faultType);
                    etalon = 0;

                    //15. Read Up 0
                    sell = ReadSingle(memory, i, j);

                    if (sell != etalon)
                    {
                        if (GetNumberOfFault(CoveredFaults, i, j) == -1)
                        {
                            var fault = new List<int> { i, j };

                            CoveredFaults.Add(fault);
                        }
                    }

                    //16. Write Up 1
                    WriteAll(memory, 1, i, j, faultType);
                    etalon = 1;

                    //17. Read Up 1
                    sell = ReadSingle(memory, i, j);

                    if (sell != etalon)
                    {
                        if (GetNumberOfFault(CoveredFaults, i, j) == -1)
                        {
                            var fault = new List<int> { i, j };

                            CoveredFaults.Add(fault);
                        }
                    }

                    //18. Write Up 0
                    WriteAll(memory, 0, i, j, faultType);
                }
            }

            for (var i = 0; i < memory.Width; i++)
            {
                for (var j = 0; j < memory.Height; j++)
                {
                    var etalon = 0;
                    //19. Read Up 0 
                    var sell = ReadSingle(memory, i, j);

                    if (sell != etalon)
                    {
                        if (GetNumberOfFault(CoveredFaults, i, j) == -1)
                        {
                            var fault = new List<int> { i, j };

                            CoveredFaults.Add(fault);
                        }
                    }
                    //20. Write Up 1
                    WriteAll(memory, 1, i, j, faultType);
                    etalon = 1;

                    //21. Read Up 1
                    sell = ReadSingle(memory, i, j);

                    if (sell != etalon)
                    {
                        if (GetNumberOfFault(CoveredFaults, i, j) == -1)
                        {
                            var fault = new List<int> { i, j };

                            CoveredFaults.Add(fault);
                        }
                    }

                    //22. Write Up 0
                    WriteAll(memory, 0, i, j, faultType);
                    etalon = 0;

                    //23. Read Up 0
                    sell = ReadSingle(memory, i, j);

                    if (sell != etalon)
                    {
                        if (GetNumberOfFault(CoveredFaults, i, j) == -1)
                        {
                            var fault = new List<int> { i, j };

                            CoveredFaults.Add(fault);
                        }
                    }
                }
            }

           
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

        private void WriteAll(Memory memory, int value, int i, int j, Faults faultType)
        {
            switch (faultType)
            {
                case FaultModels.Faults.PNPSFK9:
                {
                    WritePnpsfk9(memory, value, i, j);
                    
                    break;
                }
                case FaultModels.Faults.ANPSFK3:
                {
                    WriteAnpsfk3(memory, value, i, j);

                    break;
                }
            }
        }

        private void WriteAnpsfk3(Memory memory, int value, int i, int j)
        {
            if (GetNumberOfFault(Faults, i, j - 1) != -1)
            {
                memory[i, j - 1] = value;
            }
            else if (GetNumberOfFault(Faults, i, j + 1) != -1)
            {
                memory[i, j + 1] = value;
            }

            memory[i, j] = value;
        }

        private void WritePnpsfk9(Memory memory, int value, int i, int j)
        {
            if (GetNumberOfFault(Faults, i, j) != -1)
            {
                if (!(memory[i - 1, j - 1] == 1 && memory[i, j - 1] == 1 && memory[i + 1, j - 1] == 1 &&
                          memory[i - 1, j] == 1 &&                              memory[i + 1, j] == 0 &&
                      memory[i - 1, j + 1] == 0 &&  memory[i, j+ 1] == 0 && memory[i + 1, j + 1] == 0))
                {
                    memory[i, j] = value;

                    return;
                }

                return;
            }

            memory[i, j] = value;
        }

        private int ReadSingle(Memory memory, int i, int j)
        {
            return memory[i, j];
        }
    }
}
