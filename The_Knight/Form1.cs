using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Knight
{
    public partial class Form1 : Form
    {
        private int[,] _board;
        private Random _random = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void StartNewGame(int boardSize)
        {
            _board = new int[boardSize, boardSize];
            GenerateBoardView();
            _pnlBoard.Enabled = true;
        }


        private void GenerateBoardView()
        {
            _pnlBoard.Controls.Clear();
            _pnlBoard.ColumnStyles.Clear();
            _pnlBoard.RowStyles.Clear();

            _pnlBoard.ColumnCount = _board.GetLength(0);
            _pnlBoard.RowCount = _board.GetLength(1);

            for (int i = 0; i < _pnlBoard.ColumnCount; ++i)
            {
                _pnlBoard.RowStyles.Add(new RowStyle(SizeType.Percent, (float)100.0 / _board.GetLength(0)));
                _pnlBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, (float)100.0 / _board.GetLength(1)));
            }
        }

        private void toolStripDropDownButton1_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
          // StartNewGame(int.Parse(e.ClickedItem.Tag.ToString()));
        }


        private int setRandom()
        {
            int random = _random.Next(0, 2);
            return random;
        }

        private void _pnlBoard_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if ((e.Column + e.Row) % 2 == 1)
            {
                int colorValue = setRandom();
                if (colorValue == 0)
                {
                    e.Graphics.FillRectangle(Brushes.Maroon, e.CellBounds);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.ForestGreen, e.CellBounds);
                }
            }
            else
            {
                int colorValue = setRandom();
                if (colorValue == 0)
                {
                    e.Graphics.FillRectangle(Brushes.Maroon, e.CellBounds);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.ForestGreen, e.CellBounds);
                }
            }
        }
        protected Boolean CanClose(Boolean CanIt)
        {
            if (MessageBox.Show("Wanna close?", "Cancel game", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Yes, they want to close.
                CanIt = true;
            }
            else
            {
                // No, they don't want to close.
                CanIt = false;
            }

            return CanIt;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (CanClose(false) == true)
            {
                this.Dispose(true);
            }
            else
            {
                e.Cancel = true;
            }
        }

        public void Settings()
        {
            var setupBox = new Form2();
            DialogResult result = setupBox.ShowDialog(this);
            if (result == DialogResult.Abort)
                setupBox.Dispose();
            else
            {
               if(setupBox.comboBox1.SelectedIndex == 0)
                {
                    StartNewGame(8);
                }
                if (setupBox.comboBox1.SelectedIndex == 1)
                {
                    StartNewGame(10);
                }
                if (setupBox.comboBox1.SelectedIndex == 2)
                {
                    StartNewGame(12);
                }
            }
        }


        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            StartNewGame(8);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.N))
            {
                StartNewGame(8);
                return true;
            }
            if (keyData == (Keys.Control | Keys.M))
            {
                Settings();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

