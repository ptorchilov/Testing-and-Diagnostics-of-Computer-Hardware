namespace Lab07_08
{
    using System;
    using System.Text;

    /// <summary>
    /// Class for store binary Memory.
    /// </summary>
    public class Memory
    {
        #region Fields

        /// <summary>
        /// The Memory
        /// </summary>
        private readonly int[,] memory;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Memory"/> class.
        /// </summary>
        /// <param name="dim1">The dim1.</param>
        /// <param name="dim2">The dim2.</param>
        public Memory(int dim1, int dim2)
        {
            memory = new int[dim1, dim2];
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        public int Height
        {
            get { return memory.GetLength(0); }
        }

        /// <summary>
        /// Gets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        public int Width
        {
            get { return memory.GetLength(1); }

        }

        /// <summary>
        /// Gets or sets the <see cref="System.Int32"/> with the specified x.
        /// </summary>
        /// <value>
        /// The <see cref="System.Int32"/>.
        /// </value>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        public int this[int x, int y]
        {
            get { return memory[x, y]; }
            set { memory[x, y] = value; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Shows the Memory.
        /// </summary>
        /// <param name="memory">The Memory.</param>
        public static void ShowMemoryState(Memory memory)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < memory.Width; i++)
            {
                for (var j = 0; j < memory.Height; j++)
                {
                    sb.Append(memory[i, j]).Append(" ");
                }

                sb.Append(Environment.NewLine);
            }

            Console.WriteLine(sb.ToString());
        }

        #endregion
    }
}
