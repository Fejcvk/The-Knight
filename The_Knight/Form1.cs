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
        private Point KnightPos;
        private bool isReversed = false;
        private Random _random = new Random();
        private List<PictureBox> PictureBoxes;

        public Form1()
        {
            InitializeComponent();
            StartNewGame(8);
            KeyDown += Form1_KeyDown;
        }


        //start new game
        private void StartNewGame(int boardSize)
        {
            _board = new int[boardSize, boardSize];
            GenerateBoardView();
            _pnlBoard.Enabled = true;
        }

        //generate game board with dynamically added pictureboxes
        private void GenerateBoardView()
        {
            PictureBoxes = new List<PictureBox>();
            _pnlBoard.Controls.Clear();
            _pnlBoard.ColumnStyles.Clear();
            _pnlBoard.RowStyles.Clear();

            _pnlBoard.ColumnCount = _board.GetLength(0);
            _pnlBoard.RowCount = _board.GetLength(1);

            for (var i = 0; i < _pnlBoard.ColumnCount; ++i)
            {
                _pnlBoard.RowStyles.Add(new RowStyle(SizeType.Percent, (float) 100.0 / _board.GetLength(0)));
                _pnlBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, (float) 100.0 / _board.GetLength(1)));
                for (var j = 0; j < _pnlBoard.RowCount; ++j)
                {
                    var pictureBox = new PictureBox
                    {
                        Dock = DockStyle.Fill,
                        Tag = new Point (i,j),
                        BorderStyle = BorderStyle.None,
                    };
                    SetMargin(pictureBox);
                    var colorVal = _random.Next(0, 2);
                    PictureBoxes.Add(pictureBox);
                    pictureBox.BackColor = (colorVal == 0 ? Color.Maroon : Color.ForestGreen);
                    _pnlBoard.Controls.Add(pictureBox);
                }
            }
            PlaceKnight();
        }
        
        
        //look for non maroon cell and place the knight, also grab the position 
        private void PlaceKnight()
        {
            var pos = 0;
            var knightPlaced = false;
            while (knightPlaced == false)
            {
                if (PictureBoxes.ElementAt(pos).BackColor == Color.ForestGreen)
                {
                    LoadKnight(PictureBoxes.ElementAt(pos));
                    KnightPos = (Point)PictureBoxes.ElementAt(pos).Tag;
                    knightPlaced = true;
                    Console.WriteLine("Knight placed at" + KnightPos);
                }
                else
                    pos += 1;
            }
        }
        
        //for shortcut ctrl+n to avoid clearing whole form
        private void RecolorBoard()
        {
            for (var i = 0; i < PictureBoxes.Count; ++i)
            {
                var colorVal = _random.Next(0, 2);
                if ((Point)PictureBoxes.ElementAt(i).Tag == KnightPos)
                    PictureBoxes.ElementAt(i).Image = null;
                PictureBoxes.ElementAt(i).BackColor = (colorVal == 0 ? Color.Maroon : Color.ForestGreen);
            }
            PlaceKnight();
        }
        
        //for setup marigin to avoid ugly padding
        private static void SetMargin(Control myControl)
        {
            var Margin = myControl.Margin;
            Margin.Top = 0;
            Margin.Bottom = 0;
            Margin.Left = 0;
            Margin.Right = 0;
            myControl.Margin = Margin;
        }
        
        
        //move knight
        private void MoveKnight(int newcolumnpos, int newrowpos)
        {
            PictureBox knightbox = (PictureBox) _pnlBoard.GetControlFromPosition(KnightPos.Y, KnightPos.X);
            PictureBox newknightbox = (PictureBox)_pnlBoard.GetControlFromPosition(newcolumnpos, newrowpos);
            if (newknightbox.BackColor == Color.ForestGreen)
            {
                knightbox.Image = null;
                LoadKnight(newknightbox);
                KnightPos.Y = newcolumnpos;
                KnightPos.X = newrowpos;
            }
            else
            {
                Console.WriteLine("There is a wall");
            }
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                Console.WriteLine("w dol");
                if(KnightPos.X + 1 < 8)
                    MoveKnight(KnightPos.Y,KnightPos.X + 1);
                Console.WriteLine(KnightPos);

            }
            if (e.KeyCode == Keys.Up)
            {
                Console.WriteLine("w góre");
                if(KnightPos.X - 1 >= 0)
                    MoveKnight(KnightPos.Y, (KnightPos.X - 1));
                Console.WriteLine(KnightPos);
            }
            if (e.KeyCode == Keys.Left)
            {
                Console.WriteLine("w lewo");
                isReversed = true;
                if (KnightPos.Y - 1 >= 0)
                    MoveKnight(KnightPos.Y - 1, KnightPos.X);
                Console.WriteLine(KnightPos);
            }
            if (e.KeyCode == Keys.Right)
            {
                Console.WriteLine("w prawo");
                isReversed = false;
                if (KnightPos.Y + 1 < 8)
                    MoveKnight(KnightPos.Y + 1, KnightPos.X);
                Console.WriteLine(KnightPos);
            }
        }

        //load knight image and make it transparent
        public void LoadKnight(PictureBox picturebox)
        {
            Bitmap src;
            if (isReversed)
                src = Properties.Resources.knight2;
            else
                src = Properties.Resources.knight;
            src.MakeTransparent();
            picturebox.Image = src;
            picturebox.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        protected Boolean CanClose(Boolean CanIt)
        {
            if (MessageBox.Show("Wanna close?", "Cancel game", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
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


        //calling setting combobox
        public void Settings()
        {
            var setupBox = new Form2();
            DialogResult result = setupBox.ShowDialog(this);
            if (result == DialogResult.Abort)
                setupBox.Close();
            else
            {
                if (setupBox.comboBox1.SelectedIndex == 0)
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
            switch (keyData)
            {
                case (Keys.Control | Keys.N):
                    RecolorBoard();
                    return true;
                case (Keys.Control | Keys.M):
                    Settings();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}