namespace BattleField
{
    using System;
    using System.Linq;
    using System.Text;

    public class Renderer
    {
        private readonly Field field = null;
        private readonly StringBuilder renderer = new StringBuilder();

        private readonly string cellPadding = new string(' ', 1);
        private readonly int cellSize = 0;

        public Renderer(Field field)
        {
            this.field = field;

            this.cellSize = Field.MaxSize.ToString().Length + 2 * this.cellPadding.Length;
        }

        public void Render()
        {
            RenderHeader();
            RenderSeparatorRow();

            RenderField();
            RenderSeparatorRow();

            string result = FlushBuffer();
            Console.WriteLine(result);
        }

        private void RenderHeader()
        {
            this.renderer.Append(new string(' ', this.cellSize));
            this.renderer.Append("|");

            for (int row = 0; row < this.field.Rows; row++)
            {
                this.renderer.Append(cellPadding);
                this.renderer.Append(row);
                this.renderer.Append(cellPadding);
            }

            this.renderer.Append("|");

            this.renderer.AppendLine();
        }

        private void RenderSeparatorRow()
        {
            string cell = new string('-', this.cellSize);

            this.renderer.Append(cell);

            this.renderer.Append("┼");

            for (int col = 0; col < this.field.Cols; col++)
            {
                this.renderer.Append(cell);
            }

            this.renderer.Append("┤");

            this.renderer.AppendLine();
        }

        private void RenderField()
        {
            for (int row = 0; row < this.field.Rows; row++)
            {
                this.renderer.Append(cellPadding);
                this.renderer.Append(row);
                this.renderer.Append(cellPadding);

                this.renderer.Append("|");

                for (int col = 0; col < this.field.Cols; col++)
                {
                    this.renderer.Append(cellPadding);
                    this.renderer.Append(this.field[row, col]);
                    this.renderer.Append(cellPadding);
                }

                this.renderer.Append("|");

                this.renderer.AppendLine();
            }
        }

        private string FlushBuffer()
        {
            string result = this.renderer.ToString();
            this.renderer.Clear();

            return result;
        }
    }
}
