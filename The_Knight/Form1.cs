using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Knight
{
    public partial class Form1 : Form
    {
        private spalshscreen splash;
        private int[,] _board;
        private int[,] _colorBoard;
        private Point KnightPos;
        private Point Keypos;
        private Point Doorpos;
        private Point editPos;
        private bool keyPressed = false;
        private bool editMode = false;
        private bool isReversed;
        private bool isOpen;
        private Random _random = new Random();
        private List<PictureBox> PictureBoxes;

        public Form1()
        {
            bool done = false;
            ThreadPool.QueueUserWorkItem((x) =>
            {
                using (var splashForm = new spalshscreen())
                {
                    splashForm.Show();
                    while (!done)
                        Application.DoEvents();
                    splashForm.Close();
                }
            });
            Thread.Sleep(3000);
            done = true;
            Show();
            InitializeComponent();
            Activate();
            CenterToScreen();
            TopMost = false;
            StartNewGame(8);
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            keyPressed = false;
        }

        //start new game
        private void StartNewGame(int boardSize)
        {
            _board = new int[boardSize, boardSize];
            _colorBoard = new int[boardSize, boardSize];
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
                        Tag = new Point(i, j),
                        BorderStyle = BorderStyle.None,

                    };
                    SetMargin(pictureBox);
                    pictureBox.MouseClick += ClickOnPictureBox;
                    PictureBoxes.Add(pictureBox);
                    _pnlBoard.Controls.Add(pictureBox);
                    _colorBoard[i, j] = 0;
                }
            }
            RecolorBoard();
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
                    KnightPos = (Point) PictureBoxes.ElementAt(pos).Tag;
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
            //wyczyszczenie tablicy
            for (var i = 0; i < PictureBoxes.Count; ++i)
            {
                if ((Point) PictureBoxes.ElementAt(i).Tag == KnightPos)
                    PictureBoxes.ElementAt(i).Image = null;
                else if ((Point) PictureBoxes.ElementAt(i).Tag == Keypos)
                    PictureBoxes.ElementAt(i).Image = null;
                else if ((Point) PictureBoxes.ElementAt(i).Tag == Doorpos)
                    PictureBoxes.ElementAt(i).Image = null;
            }
            //odpowiednie kolorowanie tablicy
            for (var i = 0; i < _pnlBoard.ColumnCount; ++i)
            {
                for (var j = 0; j < _pnlBoard.ColumnCount; ++j)
                {
                    if (i > 0 && _colorBoard[i - 1, j] == 0 || j > 0 && _colorBoard[i, j - 1] == 0)
                    {
                        var colorValue = _random.Next(0, 2);
                        PictureBox currentbox = (PictureBox) _pnlBoard.GetControlFromPosition(j, i);
                        if (colorValue == 0)
                            currentbox.BackColor = Color.Maroon;
                        else
                        {
                            currentbox.BackColor = Color.ForestGreen;
                            _colorBoard[i, j] = 1;
                        }
                    }
                    else
                    {
                        var colorValue = _random.Next(0, 4);
                        PictureBox currentbox = (PictureBox) _pnlBoard.GetControlFromPosition(j, i);
                        if (colorValue == 0)
                            currentbox.BackColor = Color.Maroon;
                        else
                        {
                            currentbox.BackColor = Color.ForestGreen;
                            _colorBoard[i, j] = 1;
                        }
                    }
                }
            }
            PlaceKnight();
            PlaceKey();
            PlaceDoor();
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

        //place key random on board
        private void PlaceKey()
        {
            var pos = _random.Next(0, PictureBoxes.Count);
            var keyplaced = false;
            Keypos = (Point) PictureBoxes.ElementAt(pos).Tag;
            while (keyplaced == false)
            {
                if (PictureBoxes.ElementAt(pos).BackColor == Color.ForestGreen && Keypos != KnightPos)
                {
                    LoadKey(PictureBoxes.ElementAt(pos));
                    Keypos = (Point) PictureBoxes.ElementAt(pos).Tag;
                    keyplaced = true;
                    Console.WriteLine("Key placed at" + Keypos);
                }
                else
                {
                    pos = _random.Next(0, PictureBoxes.Count);
                    Keypos = (Point) PictureBoxes.ElementAt(pos).Tag;
                }
            }
        }

        //load key from resources
        private void LoadKey(PictureBox picturebox)
        {
            Bitmap src;
            src = Properties.Resources.key2;
            src.MakeTransparent();
            picturebox.Image = src;
            picturebox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        //load closed gate from resources
        private void LoadDoor(PictureBox picturebox)
        {
            Bitmap src;
            if (!isOpen)
                src = Properties.Resources.closed_door;
            else
                src = Properties.Resources.opened_door;
            src.MakeTransparent();
            picturebox.Image = src;
            picturebox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        //place key random on board
        private void PlaceDoor()
        {
            var pos = _random.Next(0, PictureBoxes.Count);
            var doorplaced = false;
            Doorpos = (Point) PictureBoxes.ElementAt(pos).Tag;
            while (doorplaced == false)
            {
                if (PictureBoxes.ElementAt(pos).BackColor == Color.ForestGreen && Doorpos != KnightPos &&
                    Doorpos != Keypos)
                {
                    LoadDoor(PictureBoxes.ElementAt(pos));
                    Doorpos = (Point) PictureBoxes.ElementAt(pos).Tag;
                    doorplaced = true;
                    Console.WriteLine("Door placed at" + Doorpos);
                }
                else
                {
                    pos = _random.Next(0, PictureBoxes.Count);
                    Doorpos = (Point) PictureBoxes.ElementAt(pos).Tag;
                }
            }
        }

        //move knight
        private void MoveKnight(int newcolumnpos, int newrowpos)
        {
            PictureBox knightbox = (PictureBox) _pnlBoard.GetControlFromPosition(KnightPos.Y, KnightPos.X);
            PictureBox newknightbox = (PictureBox) _pnlBoard.GetControlFromPosition(newcolumnpos, newrowpos);
            if (newknightbox.BackColor == Color.ForestGreen && (Point) newknightbox.Tag != Doorpos)
            {
                knightbox.Image = null;
                LoadKnight(newknightbox);
                KnightPos.Y = newcolumnpos;
                KnightPos.X = newrowpos;
            }
            else if ((Point) newknightbox.Tag == Doorpos && isOpen)
            {
                isOpen = false;
                RecolorBoard();
                Console.WriteLine("New level generated");
            }
            else
            {
                Console.WriteLine("There is a wall");
            }
            if ((Point) newknightbox.Tag == Keypos)
            {
                isOpen = true;
                PictureBox doorbox = (PictureBox) _pnlBoard.GetControlFromPosition(Doorpos.Y, Doorpos.X);
                LoadDoor(doorbox);
                Console.WriteLine("Key has been collected and doors are open");
            }
        }

        //destroying a wall while press spacebar
        private void Destroy()
        {
            PictureBox aboveknight;
            if (KnightPos.X - 1 >= 0)
            {
                aboveknight = (PictureBox) _pnlBoard.GetControlFromPosition(KnightPos.Y, KnightPos.X - 1);
                aboveknight.BackColor = Color.ForestGreen;
            }
            PictureBox underknight;
            if (KnightPos.X + 1 < _board.GetLength(0))
            {
                underknight = (PictureBox) _pnlBoard.GetControlFromPosition(KnightPos.Y, KnightPos.X + 1);
                underknight.BackColor = Color.ForestGreen;
            }
            PictureBox lefttoknight;
            if (KnightPos.Y - 1 >= 0)
            {
                lefttoknight = (PictureBox) _pnlBoard.GetControlFromPosition(KnightPos.Y - 1, KnightPos.X);
                lefttoknight.BackColor = Color.ForestGreen;
            }
            PictureBox righttoknight;
            if (KnightPos.Y + 1 < _board.GetLength(0))
            {
                righttoknight = (PictureBox) _pnlBoard.GetControlFromPosition(KnightPos.Y + 1, KnightPos.X);
                righttoknight.BackColor = Color.ForestGreen;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!editMode)
            {
                if (e.KeyCode == Keys.Down && !keyPressed)
                {
                    Console.WriteLine("w dol");
                    if (KnightPos.X + 1 < _board.GetLength(0))
                        MoveKnight(KnightPos.Y, KnightPos.X + 1);
                    Console.WriteLine(KnightPos);
                }
                if (e.KeyCode == Keys.Up && !keyPressed)
                {
                    Console.WriteLine("w góre");
                    if (KnightPos.X - 1 >= 0)
                        MoveKnight(KnightPos.Y, (KnightPos.X - 1));
                    Console.WriteLine(KnightPos);
                }
                if (e.KeyCode == Keys.Left && !keyPressed)
                {
                    Console.WriteLine("w lewo");
                    isReversed = true;
                    if (KnightPos.Y - 1 >= 0)
                        MoveKnight(KnightPos.Y - 1, KnightPos.X);
                    Console.WriteLine(KnightPos);
                }
                if (e.KeyCode == Keys.Right && !keyPressed)
                {
                    Console.WriteLine("w prawo");
                    isReversed = false;
                    if (KnightPos.Y + 1 < _board.GetLength(0))
                        MoveKnight(KnightPos.Y + 1, KnightPos.X);
                    Console.WriteLine(KnightPos);
                }
                if (e.KeyCode == Keys.Space)
                {
                    Console.WriteLine("DEEEESTROOOY");
                    Destroy();
                }
                keyPressed = true;
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
                Console.WriteLine("Zamykam");
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            editMode = true;
            toolStrip1.BackColor = Color.Gold;
            editmodebutton.Visible = false;
            gamemodebutton.Visible = true;
            leftclickbutton.Visible = true;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            editMode = false;
            toolStrip1.BackColor = Color.Empty;
            editmodebutton.Visible = true;
            gamemodebutton.Visible = false;
            leftclickbutton.Visible = false;
        }

        private void ClickOnPictureBox(object sender, MouseEventArgs e)
        {
           // Console.WriteLine("Cell chosen: " + _pnlBoard.GetPositionFromControl((PictureBox)sender));
            if (addWallButton.CheckState == CheckState.Checked && editMode && e.Button == MouseButtons.Left)
            {
                var cellpos =_pnlBoard.GetPositionFromControl((PictureBox) sender);
                var pos = new Point(cellpos.Row, cellpos.Column);
                var picbox = (PictureBox) _pnlBoard.GetControlFromPosition(cellpos.Column, cellpos.Row);
                if (picbox.BackColor == Color.ForestGreen && pos != Doorpos && pos != KnightPos && pos != Keypos)
                {
                    picbox.BackColor = Color.Maroon;
                    Console.WriteLine("Wall has been added at " + cellpos);
                }
                else
                    Console.WriteLine("Wall already exist");
            }
            else if (addGrasButton.CheckState == CheckState.Checked && editMode && e.Button == MouseButtons.Left)
            {
                var cellpos = _pnlBoard.GetPositionFromControl((PictureBox)sender);
                var pos = new Point(cellpos.Row, cellpos.Column);
                var picbox = (PictureBox)_pnlBoard.GetControlFromPosition(cellpos.Column, cellpos.Row);
                if (picbox.BackColor == Color.Maroon && pos != Doorpos && pos != KnightPos && pos != Keypos)
                {
                    picbox.BackColor = Color.ForestGreen;
                    Console.WriteLine("Grass has been added at " + cellpos);
                }
                else
                    Console.WriteLine("Grass already exist");
            }
            else if (e.Button == MouseButtons.Right && editMode)
            {
                Console.WriteLine("Cell chosen with right click: " + _pnlBoard.GetPositionFromControl((PictureBox)sender));
                var cellpos = _pnlBoard.GetPositionFromControl((PictureBox)sender);
                var pos = new Point(cellpos.Row, cellpos.Column);
                editPos = pos;
                contextMenuStrip1.Show(_pnlBoard.GetControlFromPosition(cellpos.Column, cellpos.Row), e.Location.X, e.Location.Y);
            }
        }

        private void addGrasButton_Click(object sender, EventArgs e)
        {
            addWallButton.Checked = false;
        }

        private void addWallButton_Click(object sender, EventArgs e)
        {
            addGrasButton.Checked = false;
        }

        private void knightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var picbox = (PictureBox)_pnlBoard.GetControlFromPosition(editPos.Y, editPos.X);
            if (picbox.BackColor == Color.ForestGreen)
            { 
                var cellpos = _pnlBoard.GetPositionFromControl(picbox);
                Console.WriteLine("Selected to place a Knight at " + cellpos);
                for (var i = 0; i < PictureBoxes.Count; ++i)
                {
                    if ((Point) PictureBoxes.ElementAt(i).Tag == KnightPos)
                        PictureBoxes.ElementAt(i).Image = null;
                }
                KnightPos.X = cellpos.Row;
                KnightPos.Y = cellpos.Column;
                LoadKnight(picbox);
            }
        }

        private void keyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var picbox = (PictureBox)_pnlBoard.GetControlFromPosition(editPos.Y, editPos.X);
            if (picbox.BackColor == Color.ForestGreen)
            {
                var cellpos = _pnlBoard.GetPositionFromControl(picbox);
                Console.WriteLine("Selected to place a key at " + cellpos);
                for (var i = 0; i < PictureBoxes.Count; ++i)
                {
                    if ((Point) PictureBoxes.ElementAt(i).Tag == Keypos)
                        PictureBoxes.ElementAt(i).Image = null;
                }
                Keypos.X = cellpos.Row;
                Keypos.Y = cellpos.Column;
                LoadKey(picbox);
            }
        }

        private void doorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var picbox = (PictureBox)_pnlBoard.GetControlFromPosition(editPos.Y, editPos.X);
            if (picbox.BackColor == Color.ForestGreen)
            {
                var cellpos = _pnlBoard.GetPositionFromControl(picbox);
                Console.WriteLine("Selected to place a closed door at " + cellpos);
                for (var i = 0; i < PictureBoxes.Count; ++i)
                {
                    if ((Point) PictureBoxes.ElementAt(i).Tag == Doorpos)
                        PictureBoxes.ElementAt(i).Image = null;
                }
                Doorpos.X = cellpos.Row;
                Doorpos.Y = cellpos.Column;
                LoadDoor(picbox);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}