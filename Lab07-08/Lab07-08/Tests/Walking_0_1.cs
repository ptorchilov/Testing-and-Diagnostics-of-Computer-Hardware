namespace Lab07_08.Tests
{
    using System.Collections.Generic;
    using FaultModels;

    public class Walking_0_1
    {
        /// <summary>
        /// The faults
        /// </summary>
        private List<List<int>> faults;

        private List<bool> coveredFaults;

        /// <summary>
        /// Initializes a new instance of the <see cref="Walking_0_1"/> class.
        /// </summary>
        /// <param name="faults">The faults.</param>
        public Walking_0_1(List<List<int>> faults)
        {
            this.faults = faults;
            coveredFaults = new List<bool>(faults.Count);
        }

        /// <summary>
        /// Tests the af.
        /// </summary>
        /// <param name="memory">The memory.</param>
        /// <param name="mode">The mode.</param>
        public void TestAF(Memory memory, AFFaults mode)
        {
            var maxErrors = 0;

            for (var i = 0; i < memory.Width; i++)
            {
                for (var j = 0; j < memory.Height; j++)
                {
                    MakeAFTest(memory, i, j, mode);
                }
            }
        }

        private void MakeAFTest(Memory memory, int i, int j, AFFaults mode)
        {
            switch (mode)
            {
                case AFFaults.SellNotAvailable:
                {
                    //1. Read base
                    var baseSell = ReadSingle(memory, i, j);

                    if (baseSell == -1)
                    {
                        var faultNumber = GetNumberOfFault(i, j);

                        coveredFaults[faultNumber] = true;
                        return;
                    }

                    //2. Write all not base
                    WriteAll(memory, i, j, baseSell == 0 ? 1 : 0);

                    //3. Read all
                    ReadAll(memory, i, j, baseSell == 0 ? 1 : 0);

                    //4. Read base
                    var newBaseSell = ReadSingle(memory, i, j);

                    if (baseSell != newBaseSell)
                    {
                        var faultNumber = GetNumberOfFault(i, j);

                        coveredFaults[faultNumber] = true;
                    }

                    break;
                }

                    
            }

            return;
        }

        private int GetNumberOfFault(int i, int j)
        {
            //TODO: Implement this
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Writes the operation.
        /// </summary>
        /// <param name="memory">The memory.</param>
        /// <param name="baseI">The base i.</param>
        /// <param name="baseJ">The base j.</param>
        /// <param name="value">The value.</param>
        private void WriteAll(Memory memory, int baseI, int baseJ, int value)
        {
            for (var i = 0; i < memory.Width; i++)
            {
                for (var j = 0; j < memory.Height; j++)
                {
                    if (i != baseI && j != baseJ)
                    {
                        memory[i, j] = value;
                    }
                }
            }
        }

        private int ReadSingle(Memory memory, int i, int j)
        {
            if (GetNumberOfFault(i, j) == -1)
            {
                return memory[i, j];
            }

            return -1;
        }

        /// <summary>
        /// Reads the operation.
        /// </summary>
        /// <param name="memory">The memory.</param>
        /// <param name="baseI">The base i.</param>
        /// <param name="baseJ">The base j.</param>
        /// <param name="correctValue">The correct value.</param>
        /// <returns></returns>
        private void ReadAll(Memory memory, int baseI, int baseJ, int correctValue)
        {
            for (var i = 0; i < memory.Width; i++)
            {
                for (var j = 0; j < memory.Height; j++)
                {
                    var currentSell = memory[i, j];

                    if (currentSell != correctValue)
                    {
                        var faultNumber = GetNumberOfFault(i, j);

                        coveredFaults[faultNumber] = true;
                    }
                }
            }
        }
    }
}
