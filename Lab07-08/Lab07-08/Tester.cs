namespace Lab07_08
{
    using Tests;

    public class Tester
    {
        // ReSharper disable once InconsistentNaming
        public void RunWalking_0_1(Faults type, Memory memory)
        {
            switch (type)
            {
                case Faults.AF:
                {
                    Walking_0_1.TestAF(memory);
                }
            }

            
        }
    }
}
