﻿namespace The_Knight
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editmodebutton = new System.Windows.Forms.ToolStripButton();
            this.gamemodebutton = new System.Windows.Forms.ToolStripButton();
            this.leftclickbutton = new System.Windows.Forms.ToolStripDropDownButton();
            this.addGrasButton = new System.Windows.Forms.ToolStripMenuItem();
            this.addWallButton = new System.Windows.Forms.ToolStripMenuItem();
            this._pnlBoard = new System.Windows.Forms.TableLayoutPanel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.knightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.editmodebutton,
            this.gamemodebutton,
            this.leftclickbutton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(818, 25);
            this.toolStrip1.TabIndex = 2;
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(78, 22);
            this.toolStripDropDownButton1.Text = "New Game";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem4.Tag = "14";
            this.toolStripMenuItem4.Text = "New Game";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // editmodebutton
            // 
            this.editmodebutton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.editmodebutton.Image = ((System.Drawing.Image)(resources.GetObject("editmodebutton.Image")));
            this.editmodebutton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editmodebutton.Name = "editmodebutton";
            this.editmodebutton.Size = new System.Drawing.Size(65, 22);
            this.editmodebutton.Text = "Edit mode";
            this.editmodebutton.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // gamemodebutton
            // 
            this.gamemodebutton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.gamemodebutton.Image = ((System.Drawing.Image)(resources.GetObject("gamemodebutton.Image")));
            this.gamemodebutton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.gamemodebutton.Name = "gamemodebutton";
            this.gamemodebutton.Size = new System.Drawing.Size(76, 22);
            this.gamemodebutton.Text = "Game mode";
            this.gamemodebutton.Visible = false;
            this.gamemodebutton.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // leftclickbutton
            // 
            this.leftclickbutton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.leftclickbutton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addGrasButton,
            this.addWallButton});
            this.leftclickbutton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.leftclickbutton.Name = "leftclickbutton";
            this.leftclickbutton.ShowDropDownArrow = false;
            this.leftclickbutton.Size = new System.Drawing.Size(58, 22);
            this.leftclickbutton.Text = "Left click";
            this.leftclickbutton.Visible = false;
            // 
            // addGrasButton
            // 
            this.addGrasButton.CheckOnClick = true;
            this.addGrasButton.Name = "addGrasButton";
            this.addGrasButton.Size = new System.Drawing.Size(152, 22);
            this.addGrasButton.Text = "Grass";
            this.addGrasButton.Click += new System.EventHandler(this.addGrasButton_Click);
            // 
            // addWallButton
            // 
            this.addWallButton.Checked = true;
            this.addWallButton.CheckOnClick = true;
            this.addWallButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.addWallButton.Name = "addWallButton";
            this.addWallButton.Size = new System.Drawing.Size(152, 22);
            this.addWallButton.Text = "Wall";
            this.addWallButton.Click += new System.EventHandler(this.addWallButton_Click);
            // 
            // _pnlBoard
            // 
            this._pnlBoard.ColumnCount = 8;
            this._pnlBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this._pnlBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this._pnlBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this._pnlBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this._pnlBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this._pnlBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this._pnlBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this._pnlBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this._pnlBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlBoard.Location = new System.Drawing.Point(0, 25);
            this._pnlBoard.Name = "_pnlBoard";
            this._pnlBoard.RowCount = 8;
            this._pnlBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this._pnlBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this._pnlBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this._pnlBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this._pnlBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this._pnlBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this._pnlBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this._pnlBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this._pnlBoard.Size = new System.Drawing.Size(818, 586);
            this._pnlBoard.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.knightToolStripMenuItem,
            this.keyToolStripMenuItem,
            this.doorToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(110, 70);
            // 
            // knightToolStripMenuItem
            // 
            this.knightToolStripMenuItem.Name = "knightToolStripMenuItem";
            this.knightToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.knightToolStripMenuItem.Tag = "1";
            this.knightToolStripMenuItem.Text = "Knight";
            this.knightToolStripMenuItem.Click += new System.EventHandler(this.knightToolStripMenuItem_Click);
            // 
            // keyToolStripMenuItem
            // 
            this.keyToolStripMenuItem.Name = "keyToolStripMenuItem";
            this.keyToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.keyToolStripMenuItem.Tag = "2";
            this.keyToolStripMenuItem.Text = "Key";
            this.keyToolStripMenuItem.Click += new System.EventHandler(this.keyToolStripMenuItem_Click);
            // 
            // doorToolStripMenuItem
            // 
            this.doorToolStripMenuItem.Name = "doorToolStripMenuItem";
            this.doorToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.doorToolStripMenuItem.Tag = "3";
            this.doorToolStripMenuItem.Text = "Door";
            this.doorToolStripMenuItem.Click += new System.EventHandler(this.doorToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 611);
            this.Controls.Add(this._pnlBoard);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The Knight";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        public System.Windows.Forms.TableLayoutPanel _pnlBoard;
        private System.Windows.Forms.ToolStripButton editmodebutton;
        private System.Windows.Forms.ToolStripMenuItem addGrasButton;
        private System.Windows.Forms.ToolStripMenuItem addWallButton;
        private System.Windows.Forms.ToolStripButton gamemodebutton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem knightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doorToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton leftclickbutton;
    }
}

