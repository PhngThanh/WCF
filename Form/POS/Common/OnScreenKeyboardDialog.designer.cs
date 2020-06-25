using System.ComponentModel;
using System.Windows.Forms;

namespace POS.Common
{
    partial class OnScreenKeyboardDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.lbQ = new System.Windows.Forms.Label();
            this.panelMainKeyboard = new System.Windows.Forms.FlowLayoutPanel();
            this.lbW = new System.Windows.Forms.Label();
            this.lbE = new System.Windows.Forms.Label();
            this.lbR = new System.Windows.Forms.Label();
            this.lbT = new System.Windows.Forms.Label();
            this.lbY = new System.Windows.Forms.Label();
            this.lbU = new System.Windows.Forms.Label();
            this.lbI = new System.Windows.Forms.Label();
            this.lbO = new System.Windows.Forms.Label();
            this.lbP = new System.Windows.Forms.Label();
            this.lbBackspace1 = new System.Windows.Forms.Label();
            this.lbA = new System.Windows.Forms.Label();
            this.lbS = new System.Windows.Forms.Label();
            this.lbD = new System.Windows.Forms.Label();
            this.lbF = new System.Windows.Forms.Label();
            this.lbG = new System.Windows.Forms.Label();
            this.lbH = new System.Windows.Forms.Label();
            this.lbJ = new System.Windows.Forms.Label();
            this.lbK = new System.Windows.Forms.Label();
            this.lbL = new System.Windows.Forms.Label();
            this.lbApostrophe = new System.Windows.Forms.Label();
            this.lbEnter1 = new System.Windows.Forms.Label();
            this.lbShiftLeft = new System.Windows.Forms.Label();
            this.lbZ = new System.Windows.Forms.Label();
            this.lbX = new System.Windows.Forms.Label();
            this.lbC = new System.Windows.Forms.Label();
            this.lbV = new System.Windows.Forms.Label();
            this.lbB = new System.Windows.Forms.Label();
            this.lbN = new System.Windows.Forms.Label();
            this.lbM = new System.Windows.Forms.Label();
            this.lbComma = new System.Windows.Forms.Label();
            this.lbDot1 = new System.Windows.Forms.Label();
            this.lbQuestion = new System.Windows.Forms.Label();
            this.lbShiftRight = new System.Windows.Forms.Label();
            this.lbSwitch1 = new System.Windows.Forms.Label();
            this.lbSpace1 = new System.Windows.Forms.Label();
            this.lbMoveLeft1 = new System.Windows.Forms.Label();
            this.lbMoveRight1 = new System.Windows.Forms.Label();
            this.lbBackspace2 = new System.Windows.Forms.Label();
            this.lbEnter2 = new System.Windows.Forms.Label();
            this.panelSubContainer = new System.Windows.Forms.Panel();
            this.panelSubKeyboard = new System.Windows.Forms.FlowLayoutPanel();
            this.lbTab = new System.Windows.Forms.Label();
            this.lbExclamation = new System.Windows.Forms.Label();
            this.lbAtSign = new System.Windows.Forms.Label();
            this.lbSharp = new System.Windows.Forms.Label();
            this.lbDollar = new System.Windows.Forms.Label();
            this.lbPercent = new System.Windows.Forms.Label();
            this.lbAnd = new System.Windows.Forms.Label();
            this.lbN1 = new System.Windows.Forms.Label();
            this.lbN2 = new System.Windows.Forms.Label();
            this.lbN3 = new System.Windows.Forms.Label();
            this.lbPrevious = new System.Windows.Forms.Label();
            this.lbOpenParenthesis = new System.Windows.Forms.Label();
            this.lbCloseParenthesis = new System.Windows.Forms.Label();
            this.lbHyphen = new System.Windows.Forms.Label();
            this.lbUnderscore = new System.Windows.Forms.Label();
            this.lbEqual = new System.Windows.Forms.Label();
            this.lbPlus = new System.Windows.Forms.Label();
            this.lbN4 = new System.Windows.Forms.Label();
            this.lbN5 = new System.Windows.Forms.Label();
            this.lbN6 = new System.Windows.Forms.Label();
            this.lbNext = new System.Windows.Forms.Label();
            this.lbBackslash = new System.Windows.Forms.Label();
            this.lbSemiColon = new System.Windows.Forms.Label();
            this.lbColon = new System.Windows.Forms.Label();
            this.lbDoubleQuote = new System.Windows.Forms.Label();
            this.lbStar = new System.Windows.Forms.Label();
            this.lbSlash = new System.Windows.Forms.Label();
            this.lbN7 = new System.Windows.Forms.Label();
            this.lbN8 = new System.Windows.Forms.Label();
            this.lbN9 = new System.Windows.Forms.Label();
            this.lbSwitch2 = new System.Windows.Forms.Label();
            this.lbMoveLeft2 = new System.Windows.Forms.Label();
            this.lbMoveRight2 = new System.Windows.Forms.Label();
            this.lbSpace2 = new System.Windows.Forms.Label();
            this.lbN0 = new System.Windows.Forms.Label();
            this.lbDot2 = new System.Windows.Forms.Label();
            this.panelMainKeyboard.SuspendLayout();
            this.panelSubContainer.SuspendLayout();
            this.panelSubKeyboard.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbQ
            // 
            this.lbQ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbQ.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQ.ForeColor = System.Drawing.Color.White;
            this.lbQ.Location = new System.Drawing.Point(5, 3);
            this.lbQ.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.lbQ.Name = "lbQ";
            this.lbQ.Size = new System.Drawing.Size(55, 45);
            this.lbQ.TabIndex = 0;
            this.lbQ.Text = "q";
            this.lbQ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbQ.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbQ.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // panelMainKeyboard
            // 
            this.panelMainKeyboard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMainKeyboard.Controls.Add(this.lbQ);
            this.panelMainKeyboard.Controls.Add(this.lbW);
            this.panelMainKeyboard.Controls.Add(this.lbE);
            this.panelMainKeyboard.Controls.Add(this.lbR);
            this.panelMainKeyboard.Controls.Add(this.lbT);
            this.panelMainKeyboard.Controls.Add(this.lbY);
            this.panelMainKeyboard.Controls.Add(this.lbU);
            this.panelMainKeyboard.Controls.Add(this.lbI);
            this.panelMainKeyboard.Controls.Add(this.lbO);
            this.panelMainKeyboard.Controls.Add(this.lbP);
            this.panelMainKeyboard.Controls.Add(this.lbBackspace1);
            this.panelMainKeyboard.Controls.Add(this.lbA);
            this.panelMainKeyboard.Controls.Add(this.lbS);
            this.panelMainKeyboard.Controls.Add(this.lbD);
            this.panelMainKeyboard.Controls.Add(this.lbF);
            this.panelMainKeyboard.Controls.Add(this.lbG);
            this.panelMainKeyboard.Controls.Add(this.lbH);
            this.panelMainKeyboard.Controls.Add(this.lbJ);
            this.panelMainKeyboard.Controls.Add(this.lbK);
            this.panelMainKeyboard.Controls.Add(this.lbL);
            this.panelMainKeyboard.Controls.Add(this.lbApostrophe);
            this.panelMainKeyboard.Controls.Add(this.lbEnter1);
            this.panelMainKeyboard.Controls.Add(this.lbShiftLeft);
            this.panelMainKeyboard.Controls.Add(this.lbZ);
            this.panelMainKeyboard.Controls.Add(this.lbX);
            this.panelMainKeyboard.Controls.Add(this.lbC);
            this.panelMainKeyboard.Controls.Add(this.lbV);
            this.panelMainKeyboard.Controls.Add(this.lbB);
            this.panelMainKeyboard.Controls.Add(this.lbN);
            this.panelMainKeyboard.Controls.Add(this.lbM);
            this.panelMainKeyboard.Controls.Add(this.lbComma);
            this.panelMainKeyboard.Controls.Add(this.lbDot1);
            this.panelMainKeyboard.Controls.Add(this.lbQuestion);
            this.panelMainKeyboard.Controls.Add(this.lbShiftRight);
            this.panelMainKeyboard.Controls.Add(this.lbSwitch1);
            this.panelMainKeyboard.Controls.Add(this.lbSpace1);
            this.panelMainKeyboard.Controls.Add(this.lbMoveLeft1);
            this.panelMainKeyboard.Controls.Add(this.lbMoveRight1);
            this.panelMainKeyboard.Location = new System.Drawing.Point(0, 30);
            this.panelMainKeyboard.Name = "panelMainKeyboard";
            this.panelMainKeyboard.Size = new System.Drawing.Size(735, 206);
            this.panelMainKeyboard.TabIndex = 1;
            // 
            // lbW
            // 
            this.lbW.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbW.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbW.ForeColor = System.Drawing.Color.White;
            this.lbW.Location = new System.Drawing.Point(66, 3);
            this.lbW.Margin = new System.Windows.Forms.Padding(3);
            this.lbW.Name = "lbW";
            this.lbW.Size = new System.Drawing.Size(55, 45);
            this.lbW.TabIndex = 1;
            this.lbW.Text = "w";
            this.lbW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbW.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbW.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbE
            // 
            this.lbE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbE.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbE.ForeColor = System.Drawing.Color.White;
            this.lbE.Location = new System.Drawing.Point(127, 3);
            this.lbE.Margin = new System.Windows.Forms.Padding(3);
            this.lbE.Name = "lbE";
            this.lbE.Size = new System.Drawing.Size(55, 45);
            this.lbE.TabIndex = 2;
            this.lbE.Text = "e";
            this.lbE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbE.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbE.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbR
            // 
            this.lbR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbR.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbR.ForeColor = System.Drawing.Color.White;
            this.lbR.Location = new System.Drawing.Point(188, 3);
            this.lbR.Margin = new System.Windows.Forms.Padding(3);
            this.lbR.Name = "lbR";
            this.lbR.Size = new System.Drawing.Size(55, 45);
            this.lbR.TabIndex = 3;
            this.lbR.Text = "r";
            this.lbR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbR.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbR.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbT
            // 
            this.lbT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbT.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbT.ForeColor = System.Drawing.Color.White;
            this.lbT.Location = new System.Drawing.Point(249, 3);
            this.lbT.Margin = new System.Windows.Forms.Padding(3);
            this.lbT.Name = "lbT";
            this.lbT.Size = new System.Drawing.Size(55, 45);
            this.lbT.TabIndex = 4;
            this.lbT.Text = "t";
            this.lbT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbT.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbT.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbY
            // 
            this.lbY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbY.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbY.ForeColor = System.Drawing.Color.White;
            this.lbY.Location = new System.Drawing.Point(310, 3);
            this.lbY.Margin = new System.Windows.Forms.Padding(3);
            this.lbY.Name = "lbY";
            this.lbY.Size = new System.Drawing.Size(55, 45);
            this.lbY.TabIndex = 5;
            this.lbY.Text = "y";
            this.lbY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbY.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbY.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbU
            // 
            this.lbU.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbU.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbU.ForeColor = System.Drawing.Color.White;
            this.lbU.Location = new System.Drawing.Point(371, 3);
            this.lbU.Margin = new System.Windows.Forms.Padding(3);
            this.lbU.Name = "lbU";
            this.lbU.Size = new System.Drawing.Size(55, 45);
            this.lbU.TabIndex = 6;
            this.lbU.Text = "u";
            this.lbU.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbU.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbU.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbI
            // 
            this.lbI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbI.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbI.ForeColor = System.Drawing.Color.White;
            this.lbI.Location = new System.Drawing.Point(432, 3);
            this.lbI.Margin = new System.Windows.Forms.Padding(3);
            this.lbI.Name = "lbI";
            this.lbI.Size = new System.Drawing.Size(55, 45);
            this.lbI.TabIndex = 7;
            this.lbI.Text = "i";
            this.lbI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbI.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbI.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbO
            // 
            this.lbO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbO.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbO.ForeColor = System.Drawing.Color.White;
            this.lbO.Location = new System.Drawing.Point(493, 3);
            this.lbO.Margin = new System.Windows.Forms.Padding(3);
            this.lbO.Name = "lbO";
            this.lbO.Size = new System.Drawing.Size(55, 45);
            this.lbO.TabIndex = 8;
            this.lbO.Text = "o";
            this.lbO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbO.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbO.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbP
            // 
            this.lbP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbP.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbP.ForeColor = System.Drawing.Color.White;
            this.lbP.Location = new System.Drawing.Point(554, 3);
            this.lbP.Margin = new System.Windows.Forms.Padding(3);
            this.lbP.Name = "lbP";
            this.lbP.Size = new System.Drawing.Size(55, 45);
            this.lbP.TabIndex = 9;
            this.lbP.Text = "p";
            this.lbP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbP.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbBackspace1
            // 
            this.lbBackspace1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbBackspace1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBackspace1.ForeColor = System.Drawing.Color.White;
            this.lbBackspace1.Image = Properties.Resources.erase2a;
            this.lbBackspace1.Location = new System.Drawing.Point(615, 3);
            this.lbBackspace1.Margin = new System.Windows.Forms.Padding(3);
            this.lbBackspace1.Name = "lbBackspace1";
            this.lbBackspace1.Size = new System.Drawing.Size(116, 45);
            this.lbBackspace1.TabIndex = 10;
            this.lbBackspace1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbBackspace1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.backspace_MouseDown);
            this.lbBackspace1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.backspace_MouseUp);
            // 
            // lbA
            // 
            this.lbA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbA.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbA.ForeColor = System.Drawing.Color.White;
            this.lbA.Location = new System.Drawing.Point(20, 54);
            this.lbA.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.lbA.Name = "lbA";
            this.lbA.Size = new System.Drawing.Size(55, 45);
            this.lbA.TabIndex = 11;
            this.lbA.Text = "a";
            this.lbA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbA.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbA.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbS
            // 
            this.lbS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbS.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbS.ForeColor = System.Drawing.Color.White;
            this.lbS.Location = new System.Drawing.Point(81, 54);
            this.lbS.Margin = new System.Windows.Forms.Padding(3);
            this.lbS.Name = "lbS";
            this.lbS.Size = new System.Drawing.Size(55, 45);
            this.lbS.TabIndex = 12;
            this.lbS.Text = "s";
            this.lbS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbS.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbS.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbD
            // 
            this.lbD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbD.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbD.ForeColor = System.Drawing.Color.White;
            this.lbD.Location = new System.Drawing.Point(142, 54);
            this.lbD.Margin = new System.Windows.Forms.Padding(3);
            this.lbD.Name = "lbD";
            this.lbD.Size = new System.Drawing.Size(55, 45);
            this.lbD.TabIndex = 13;
            this.lbD.Text = "d";
            this.lbD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbD.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbD.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbF
            // 
            this.lbF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbF.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbF.ForeColor = System.Drawing.Color.White;
            this.lbF.Location = new System.Drawing.Point(203, 54);
            this.lbF.Margin = new System.Windows.Forms.Padding(3);
            this.lbF.Name = "lbF";
            this.lbF.Size = new System.Drawing.Size(55, 45);
            this.lbF.TabIndex = 14;
            this.lbF.Text = "f";
            this.lbF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbF.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbF.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbG
            // 
            this.lbG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbG.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbG.ForeColor = System.Drawing.Color.White;
            this.lbG.Location = new System.Drawing.Point(264, 54);
            this.lbG.Margin = new System.Windows.Forms.Padding(3);
            this.lbG.Name = "lbG";
            this.lbG.Size = new System.Drawing.Size(55, 45);
            this.lbG.TabIndex = 15;
            this.lbG.Text = "g";
            this.lbG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbG.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbG.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbH
            // 
            this.lbH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbH.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbH.ForeColor = System.Drawing.Color.White;
            this.lbH.Location = new System.Drawing.Point(325, 54);
            this.lbH.Margin = new System.Windows.Forms.Padding(3);
            this.lbH.Name = "lbH";
            this.lbH.Size = new System.Drawing.Size(55, 45);
            this.lbH.TabIndex = 16;
            this.lbH.Text = "h";
            this.lbH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbH.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbH.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbJ
            // 
            this.lbJ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbJ.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbJ.ForeColor = System.Drawing.Color.White;
            this.lbJ.Location = new System.Drawing.Point(386, 54);
            this.lbJ.Margin = new System.Windows.Forms.Padding(3);
            this.lbJ.Name = "lbJ";
            this.lbJ.Size = new System.Drawing.Size(55, 45);
            this.lbJ.TabIndex = 17;
            this.lbJ.Text = "j";
            this.lbJ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbJ.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbJ.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbK
            // 
            this.lbK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbK.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbK.ForeColor = System.Drawing.Color.White;
            this.lbK.Location = new System.Drawing.Point(447, 54);
            this.lbK.Margin = new System.Windows.Forms.Padding(3);
            this.lbK.Name = "lbK";
            this.lbK.Size = new System.Drawing.Size(55, 45);
            this.lbK.TabIndex = 18;
            this.lbK.Text = "k";
            this.lbK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbK.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbK.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbL
            // 
            this.lbL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbL.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbL.ForeColor = System.Drawing.Color.White;
            this.lbL.Location = new System.Drawing.Point(508, 54);
            this.lbL.Margin = new System.Windows.Forms.Padding(3);
            this.lbL.Name = "lbL";
            this.lbL.Size = new System.Drawing.Size(55, 45);
            this.lbL.TabIndex = 19;
            this.lbL.Text = "l";
            this.lbL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbL.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbL.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbApostrophe
            // 
            this.lbApostrophe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbApostrophe.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbApostrophe.ForeColor = System.Drawing.Color.White;
            this.lbApostrophe.Location = new System.Drawing.Point(569, 54);
            this.lbApostrophe.Margin = new System.Windows.Forms.Padding(3);
            this.lbApostrophe.Name = "lbApostrophe";
            this.lbApostrophe.Size = new System.Drawing.Size(55, 45);
            this.lbApostrophe.TabIndex = 20;
            this.lbApostrophe.Text = "\'";
            this.lbApostrophe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbApostrophe.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbApostrophe.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbEnter1
            // 
            this.lbEnter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbEnter1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEnter1.ForeColor = System.Drawing.Color.White;
            this.lbEnter1.Location = new System.Drawing.Point(630, 54);
            this.lbEnter1.Margin = new System.Windows.Forms.Padding(3);
            this.lbEnter1.Name = "lbEnter1";
            this.lbEnter1.Size = new System.Drawing.Size(101, 45);
            this.lbEnter1.TabIndex = 21;
            this.lbEnter1.Text = "Enter";
            this.lbEnter1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbEnter1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbEnter1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbShiftLeft
            // 
            this.lbShiftLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            this.lbShiftLeft.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbShiftLeft.ForeColor = System.Drawing.Color.White;
            this.lbShiftLeft.Image = Properties.Resources.shift_w;
            this.lbShiftLeft.Location = new System.Drawing.Point(5, 105);
            this.lbShiftLeft.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.lbShiftLeft.Name = "lbShiftLeft";
            this.lbShiftLeft.Size = new System.Drawing.Size(55, 45);
            this.lbShiftLeft.TabIndex = 22;
            this.lbShiftLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbShiftLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.shift_Click);
            // 
            // lbZ
            // 
            this.lbZ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbZ.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbZ.ForeColor = System.Drawing.Color.White;
            this.lbZ.Location = new System.Drawing.Point(66, 105);
            this.lbZ.Margin = new System.Windows.Forms.Padding(3);
            this.lbZ.Name = "lbZ";
            this.lbZ.Size = new System.Drawing.Size(55, 45);
            this.lbZ.TabIndex = 23;
            this.lbZ.Text = "z";
            this.lbZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbZ.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbZ.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbX
            // 
            this.lbX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbX.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbX.ForeColor = System.Drawing.Color.White;
            this.lbX.Location = new System.Drawing.Point(127, 105);
            this.lbX.Margin = new System.Windows.Forms.Padding(3);
            this.lbX.Name = "lbX";
            this.lbX.Size = new System.Drawing.Size(55, 45);
            this.lbX.TabIndex = 24;
            this.lbX.Text = "x";
            this.lbX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbX.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbX.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbC
            // 
            this.lbC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbC.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbC.ForeColor = System.Drawing.Color.White;
            this.lbC.Location = new System.Drawing.Point(188, 105);
            this.lbC.Margin = new System.Windows.Forms.Padding(3);
            this.lbC.Name = "lbC";
            this.lbC.Size = new System.Drawing.Size(55, 45);
            this.lbC.TabIndex = 25;
            this.lbC.Text = "c";
            this.lbC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbC.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbC.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbV
            // 
            this.lbV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbV.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbV.ForeColor = System.Drawing.Color.White;
            this.lbV.Location = new System.Drawing.Point(249, 105);
            this.lbV.Margin = new System.Windows.Forms.Padding(3);
            this.lbV.Name = "lbV";
            this.lbV.Size = new System.Drawing.Size(55, 45);
            this.lbV.TabIndex = 26;
            this.lbV.Text = "v";
            this.lbV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbV.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbB
            // 
            this.lbB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbB.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbB.ForeColor = System.Drawing.Color.White;
            this.lbB.Location = new System.Drawing.Point(310, 105);
            this.lbB.Margin = new System.Windows.Forms.Padding(3);
            this.lbB.Name = "lbB";
            this.lbB.Size = new System.Drawing.Size(55, 45);
            this.lbB.TabIndex = 27;
            this.lbB.Text = "b";
            this.lbB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbB.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbN
            // 
            this.lbN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbN.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbN.ForeColor = System.Drawing.Color.White;
            this.lbN.Location = new System.Drawing.Point(371, 105);
            this.lbN.Margin = new System.Windows.Forms.Padding(3);
            this.lbN.Name = "lbN";
            this.lbN.Size = new System.Drawing.Size(55, 45);
            this.lbN.TabIndex = 28;
            this.lbN.Text = "n";
            this.lbN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbM
            // 
            this.lbM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbM.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbM.ForeColor = System.Drawing.Color.White;
            this.lbM.Location = new System.Drawing.Point(432, 105);
            this.lbM.Margin = new System.Windows.Forms.Padding(3);
            this.lbM.Name = "lbM";
            this.lbM.Size = new System.Drawing.Size(55, 45);
            this.lbM.TabIndex = 29;
            this.lbM.Text = "m";
            this.lbM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbM.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbM.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbComma
            // 
            this.lbComma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbComma.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbComma.ForeColor = System.Drawing.Color.White;
            this.lbComma.Location = new System.Drawing.Point(493, 105);
            this.lbComma.Margin = new System.Windows.Forms.Padding(3);
            this.lbComma.Name = "lbComma";
            this.lbComma.Size = new System.Drawing.Size(55, 45);
            this.lbComma.TabIndex = 30;
            this.lbComma.Text = ",";
            this.lbComma.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbComma.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbComma.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbDot1
            // 
            this.lbDot1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbDot1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDot1.ForeColor = System.Drawing.Color.White;
            this.lbDot1.Location = new System.Drawing.Point(554, 105);
            this.lbDot1.Margin = new System.Windows.Forms.Padding(3);
            this.lbDot1.Name = "lbDot1";
            this.lbDot1.Size = new System.Drawing.Size(55, 45);
            this.lbDot1.TabIndex = 31;
            this.lbDot1.Text = ".";
            this.lbDot1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbDot1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbDot1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbQuestion
            // 
            this.lbQuestion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbQuestion.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuestion.ForeColor = System.Drawing.Color.White;
            this.lbQuestion.Location = new System.Drawing.Point(615, 105);
            this.lbQuestion.Margin = new System.Windows.Forms.Padding(3);
            this.lbQuestion.Name = "lbQuestion";
            this.lbQuestion.Size = new System.Drawing.Size(55, 45);
            this.lbQuestion.TabIndex = 32;
            this.lbQuestion.Text = "?";
            this.lbQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbQuestion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbQuestion.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbShiftRight
            // 
            this.lbShiftRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            this.lbShiftRight.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbShiftRight.ForeColor = System.Drawing.Color.White;
            this.lbShiftRight.Image = Properties.Resources.shift_w;
            this.lbShiftRight.Location = new System.Drawing.Point(676, 105);
            this.lbShiftRight.Margin = new System.Windows.Forms.Padding(3);
            this.lbShiftRight.Name = "lbShiftRight";
            this.lbShiftRight.Size = new System.Drawing.Size(55, 45);
            this.lbShiftRight.TabIndex = 33;
            this.lbShiftRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbShiftRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.shift_Click);
            // 
            // lbSwitch1
            // 
            this.lbSwitch1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            this.lbSwitch1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSwitch1.ForeColor = System.Drawing.Color.White;
            this.lbSwitch1.Location = new System.Drawing.Point(5, 156);
            this.lbSwitch1.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.lbSwitch1.Name = "lbSwitch1";
            this.lbSwitch1.Size = new System.Drawing.Size(85, 45);
            this.lbSwitch1.TabIndex = 34;
            this.lbSwitch1.Text = "&&123";
            this.lbSwitch1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbSwitch1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbSwitch1_MouseDown);
            this.lbSwitch1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbSwitch1_MouseUp);
            // 
            // lbSpace1
            // 
            this.lbSpace1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbSpace1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSpace1.ForeColor = System.Drawing.Color.White;
            this.lbSpace1.Location = new System.Drawing.Point(96, 156);
            this.lbSpace1.Margin = new System.Windows.Forms.Padding(3);
            this.lbSpace1.Name = "lbSpace1";
            this.lbSpace1.Size = new System.Drawing.Size(483, 45);
            this.lbSpace1.TabIndex = 35;
            this.lbSpace1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbSpace1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbSpace1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbMoveLeft1
            // 
            this.lbMoveLeft1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            this.lbMoveLeft1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMoveLeft1.ForeColor = System.Drawing.Color.White;
            this.lbMoveLeft1.Image = Properties.Resources.key_move_left_w;
            this.lbMoveLeft1.Location = new System.Drawing.Point(585, 156);
            this.lbMoveLeft1.Margin = new System.Windows.Forms.Padding(3);
            this.lbMoveLeft1.Name = "lbMoveLeft1";
            this.lbMoveLeft1.Size = new System.Drawing.Size(70, 45);
            this.lbMoveLeft1.TabIndex = 36;
            this.lbMoveLeft1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbMoveLeft1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.moveLeft_MouseDown);
            this.lbMoveLeft1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.moveLeft_MouseUp);
            // 
            // lbMoveRight1
            // 
            this.lbMoveRight1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            this.lbMoveRight1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMoveRight1.ForeColor = System.Drawing.Color.White;
            this.lbMoveRight1.Image = Properties.Resources.key_move_right_w;
            this.lbMoveRight1.Location = new System.Drawing.Point(661, 156);
            this.lbMoveRight1.Margin = new System.Windows.Forms.Padding(3);
            this.lbMoveRight1.Name = "lbMoveRight1";
            this.lbMoveRight1.Size = new System.Drawing.Size(70, 45);
            this.lbMoveRight1.TabIndex = 37;
            this.lbMoveRight1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbMoveRight1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.moveRight_MouseDown);
            this.lbMoveRight1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.moveRight_MouseUp);
            // 
            // lbBackspace2
            // 
            this.lbBackspace2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            this.lbBackspace2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBackspace2.ForeColor = System.Drawing.Color.White;
            this.lbBackspace2.Image = Properties.Resources.erase2a;
            this.lbBackspace2.Location = new System.Drawing.Point(659, 3);
            this.lbBackspace2.Margin = new System.Windows.Forms.Padding(25, 3, 3, 3);
            this.lbBackspace2.Name = "lbBackspace2";
            this.lbBackspace2.Size = new System.Drawing.Size(72, 45);
            this.lbBackspace2.TabIndex = 10;
            this.lbBackspace2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbBackspace2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.backspace_MouseDown);
            this.lbBackspace2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.backspace_MouseUp);
            // 
            // lbEnter2
            // 
            this.lbEnter2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            this.lbEnter2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEnter2.ForeColor = System.Drawing.Color.White;
            this.lbEnter2.Location = new System.Drawing.Point(659, 54);
            this.lbEnter2.Margin = new System.Windows.Forms.Padding(25, 3, 3, 3);
            this.lbEnter2.Name = "lbEnter2";
            this.lbEnter2.Size = new System.Drawing.Size(72, 147);
            this.lbEnter2.TabIndex = 42;
            this.lbEnter2.Text = "Enter";
            this.lbEnter2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbEnter2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbEnter2_MouseDown);
            this.lbEnter2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbEnter2_MouseUp);
            // 
            // panelSubContainer
            // 
            this.panelSubContainer.Controls.Add(this.panelSubKeyboard);
            this.panelSubContainer.Controls.Add(this.lbBackspace2);
            this.panelSubContainer.Controls.Add(this.lbEnter2);
            this.panelSubContainer.Location = new System.Drawing.Point(0, 249);
            this.panelSubContainer.Name = "panelSubContainer";
            this.panelSubContainer.Size = new System.Drawing.Size(735, 206);
            this.panelSubContainer.TabIndex = 43;
            // 
            // panelSubKeyboard
            // 
            this.panelSubKeyboard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSubKeyboard.Controls.Add(this.lbTab);
            this.panelSubKeyboard.Controls.Add(this.lbExclamation);
            this.panelSubKeyboard.Controls.Add(this.lbAtSign);
            this.panelSubKeyboard.Controls.Add(this.lbSharp);
            this.panelSubKeyboard.Controls.Add(this.lbDollar);
            this.panelSubKeyboard.Controls.Add(this.lbPercent);
            this.panelSubKeyboard.Controls.Add(this.lbAnd);
            this.panelSubKeyboard.Controls.Add(this.lbN1);
            this.panelSubKeyboard.Controls.Add(this.lbN2);
            this.panelSubKeyboard.Controls.Add(this.lbN3);
            this.panelSubKeyboard.Controls.Add(this.lbPrevious);
            this.panelSubKeyboard.Controls.Add(this.lbOpenParenthesis);
            this.panelSubKeyboard.Controls.Add(this.lbCloseParenthesis);
            this.panelSubKeyboard.Controls.Add(this.lbHyphen);
            this.panelSubKeyboard.Controls.Add(this.lbUnderscore);
            this.panelSubKeyboard.Controls.Add(this.lbEqual);
            this.panelSubKeyboard.Controls.Add(this.lbPlus);
            this.panelSubKeyboard.Controls.Add(this.lbN4);
            this.panelSubKeyboard.Controls.Add(this.lbN5);
            this.panelSubKeyboard.Controls.Add(this.lbN6);
            this.panelSubKeyboard.Controls.Add(this.lbNext);
            this.panelSubKeyboard.Controls.Add(this.lbBackslash);
            this.panelSubKeyboard.Controls.Add(this.lbSemiColon);
            this.panelSubKeyboard.Controls.Add(this.lbColon);
            this.panelSubKeyboard.Controls.Add(this.lbDoubleQuote);
            this.panelSubKeyboard.Controls.Add(this.lbStar);
            this.panelSubKeyboard.Controls.Add(this.lbSlash);
            this.panelSubKeyboard.Controls.Add(this.lbN7);
            this.panelSubKeyboard.Controls.Add(this.lbN8);
            this.panelSubKeyboard.Controls.Add(this.lbN9);
            this.panelSubKeyboard.Controls.Add(this.lbSwitch2);
            this.panelSubKeyboard.Controls.Add(this.lbMoveLeft2);
            this.panelSubKeyboard.Controls.Add(this.lbMoveRight2);
            this.panelSubKeyboard.Controls.Add(this.lbSpace2);
            this.panelSubKeyboard.Controls.Add(this.lbN0);
            this.panelSubKeyboard.Controls.Add(this.lbDot2);
            this.panelSubKeyboard.Location = new System.Drawing.Point(0, 0);
            this.panelSubKeyboard.Name = "panelSubKeyboard";
            this.panelSubKeyboard.Size = new System.Drawing.Size(635, 206);
            this.panelSubKeyboard.TabIndex = 3;
            // 
            // lbTab
            // 
            this.lbTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            this.lbTab.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTab.ForeColor = System.Drawing.Color.White;
            this.lbTab.Location = new System.Drawing.Point(5, 3);
            this.lbTab.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.lbTab.Name = "lbTab";
            this.lbTab.Size = new System.Drawing.Size(55, 45);
            this.lbTab.TabIndex = 0;
            this.lbTab.Text = "Tab";
            this.lbTab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbTab.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbTab_MouseDown);
            this.lbTab.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbTab_MouseUp);
            // 
            // lbExclamation
            // 
            this.lbExclamation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbExclamation.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExclamation.ForeColor = System.Drawing.Color.White;
            this.lbExclamation.Location = new System.Drawing.Point(66, 3);
            this.lbExclamation.Margin = new System.Windows.Forms.Padding(3);
            this.lbExclamation.Name = "lbExclamation";
            this.lbExclamation.Size = new System.Drawing.Size(55, 45);
            this.lbExclamation.TabIndex = 1;
            this.lbExclamation.Text = "!";
            this.lbExclamation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbExclamation.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbExclamation.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbAtSign
            // 
            this.lbAtSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbAtSign.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAtSign.ForeColor = System.Drawing.Color.White;
            this.lbAtSign.Location = new System.Drawing.Point(127, 3);
            this.lbAtSign.Margin = new System.Windows.Forms.Padding(3);
            this.lbAtSign.Name = "lbAtSign";
            this.lbAtSign.Size = new System.Drawing.Size(55, 45);
            this.lbAtSign.TabIndex = 2;
            this.lbAtSign.Text = "@";
            this.lbAtSign.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbAtSign.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbAtSign.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbSharp
            // 
            this.lbSharp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbSharp.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSharp.ForeColor = System.Drawing.Color.White;
            this.lbSharp.Location = new System.Drawing.Point(188, 3);
            this.lbSharp.Margin = new System.Windows.Forms.Padding(3);
            this.lbSharp.Name = "lbSharp";
            this.lbSharp.Size = new System.Drawing.Size(55, 45);
            this.lbSharp.TabIndex = 3;
            this.lbSharp.Text = "#";
            this.lbSharp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbSharp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbSharp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbDollar
            // 
            this.lbDollar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbDollar.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDollar.ForeColor = System.Drawing.Color.White;
            this.lbDollar.Location = new System.Drawing.Point(249, 3);
            this.lbDollar.Margin = new System.Windows.Forms.Padding(3);
            this.lbDollar.Name = "lbDollar";
            this.lbDollar.Size = new System.Drawing.Size(55, 45);
            this.lbDollar.TabIndex = 4;
            this.lbDollar.Text = "$";
            this.lbDollar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbDollar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbDollar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbPercent
            // 
            this.lbPercent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbPercent.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPercent.ForeColor = System.Drawing.Color.White;
            this.lbPercent.Location = new System.Drawing.Point(310, 3);
            this.lbPercent.Margin = new System.Windows.Forms.Padding(3);
            this.lbPercent.Name = "lbPercent";
            this.lbPercent.Size = new System.Drawing.Size(55, 45);
            this.lbPercent.TabIndex = 5;
            this.lbPercent.Text = "%";
            this.lbPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbPercent.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbPercent.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbAnd
            // 
            this.lbAnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbAnd.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAnd.ForeColor = System.Drawing.Color.White;
            this.lbAnd.Location = new System.Drawing.Point(371, 3);
            this.lbAnd.Margin = new System.Windows.Forms.Padding(3);
            this.lbAnd.Name = "lbAnd";
            this.lbAnd.Size = new System.Drawing.Size(55, 45);
            this.lbAnd.TabIndex = 6;
            this.lbAnd.Text = "&&";
            this.lbAnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbAnd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbAnd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbN1
            // 
            this.lbN1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(68)))), ((int)(((byte)(76)))));
            this.lbN1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbN1.ForeColor = System.Drawing.Color.White;
            this.lbN1.Location = new System.Drawing.Point(454, 3);
            this.lbN1.Margin = new System.Windows.Forms.Padding(25, 3, 3, 3);
            this.lbN1.Name = "lbN1";
            this.lbN1.Size = new System.Drawing.Size(55, 45);
            this.lbN1.TabIndex = 7;
            this.lbN1.Text = "1";
            this.lbN1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbN1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.numChar_MouseDown);
            this.lbN1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.numChar_MouseUp);
            // 
            // lbN2
            // 
            this.lbN2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(68)))), ((int)(((byte)(76)))));
            this.lbN2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbN2.ForeColor = System.Drawing.Color.White;
            this.lbN2.Location = new System.Drawing.Point(515, 3);
            this.lbN2.Margin = new System.Windows.Forms.Padding(3);
            this.lbN2.Name = "lbN2";
            this.lbN2.Size = new System.Drawing.Size(55, 45);
            this.lbN2.TabIndex = 8;
            this.lbN2.Text = "2";
            this.lbN2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbN2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.numChar_MouseDown);
            this.lbN2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.numChar_MouseUp);
            // 
            // lbN3
            // 
            this.lbN3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(68)))), ((int)(((byte)(76)))));
            this.lbN3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbN3.ForeColor = System.Drawing.Color.White;
            this.lbN3.Location = new System.Drawing.Point(576, 3);
            this.lbN3.Margin = new System.Windows.Forms.Padding(3);
            this.lbN3.Name = "lbN3";
            this.lbN3.Size = new System.Drawing.Size(55, 45);
            this.lbN3.TabIndex = 9;
            this.lbN3.Text = "3";
            this.lbN3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbN3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.numChar_MouseDown);
            this.lbN3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.numChar_MouseUp);
            // 
            // lbPrevious
            // 
            this.lbPrevious.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            this.lbPrevious.Enabled = false;
            this.lbPrevious.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrevious.ForeColor = System.Drawing.Color.White;
            this.lbPrevious.Image = Properties.Resources.key_previous_b;
            this.lbPrevious.Location = new System.Drawing.Point(5, 54);
            this.lbPrevious.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.lbPrevious.Name = "lbPrevious";
            this.lbPrevious.Size = new System.Drawing.Size(55, 45);
            this.lbPrevious.TabIndex = 38;
            this.lbPrevious.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbPrevious.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbPrevious_MouseDown);
            this.lbPrevious.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbPrevious_MouseUp);
            // 
            // lbOpenParenthesis
            // 
            this.lbOpenParenthesis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbOpenParenthesis.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOpenParenthesis.ForeColor = System.Drawing.Color.White;
            this.lbOpenParenthesis.Location = new System.Drawing.Point(66, 54);
            this.lbOpenParenthesis.Margin = new System.Windows.Forms.Padding(3);
            this.lbOpenParenthesis.Name = "lbOpenParenthesis";
            this.lbOpenParenthesis.Size = new System.Drawing.Size(55, 45);
            this.lbOpenParenthesis.TabIndex = 12;
            this.lbOpenParenthesis.Text = "(";
            this.lbOpenParenthesis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbOpenParenthesis.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbOpenParenthesis.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbCloseParenthesis
            // 
            this.lbCloseParenthesis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbCloseParenthesis.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCloseParenthesis.ForeColor = System.Drawing.Color.White;
            this.lbCloseParenthesis.Location = new System.Drawing.Point(127, 54);
            this.lbCloseParenthesis.Margin = new System.Windows.Forms.Padding(3);
            this.lbCloseParenthesis.Name = "lbCloseParenthesis";
            this.lbCloseParenthesis.Size = new System.Drawing.Size(55, 45);
            this.lbCloseParenthesis.TabIndex = 13;
            this.lbCloseParenthesis.Text = ")";
            this.lbCloseParenthesis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbCloseParenthesis.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbCloseParenthesis.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbHyphen
            // 
            this.lbHyphen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbHyphen.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHyphen.ForeColor = System.Drawing.Color.White;
            this.lbHyphen.Location = new System.Drawing.Point(188, 54);
            this.lbHyphen.Margin = new System.Windows.Forms.Padding(3);
            this.lbHyphen.Name = "lbHyphen";
            this.lbHyphen.Size = new System.Drawing.Size(55, 45);
            this.lbHyphen.TabIndex = 14;
            this.lbHyphen.Text = "-";
            this.lbHyphen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbHyphen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbHyphen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbUnderscore
            // 
            this.lbUnderscore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbUnderscore.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUnderscore.ForeColor = System.Drawing.Color.White;
            this.lbUnderscore.Location = new System.Drawing.Point(249, 54);
            this.lbUnderscore.Margin = new System.Windows.Forms.Padding(3);
            this.lbUnderscore.Name = "lbUnderscore";
            this.lbUnderscore.Size = new System.Drawing.Size(55, 45);
            this.lbUnderscore.TabIndex = 15;
            this.lbUnderscore.Text = "_";
            this.lbUnderscore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbUnderscore.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbUnderscore.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbEqual
            // 
            this.lbEqual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbEqual.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEqual.ForeColor = System.Drawing.Color.White;
            this.lbEqual.Location = new System.Drawing.Point(310, 54);
            this.lbEqual.Margin = new System.Windows.Forms.Padding(3);
            this.lbEqual.Name = "lbEqual";
            this.lbEqual.Size = new System.Drawing.Size(55, 45);
            this.lbEqual.TabIndex = 16;
            this.lbEqual.Text = "=";
            this.lbEqual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbEqual.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbEqual.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbPlus
            // 
            this.lbPlus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbPlus.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPlus.ForeColor = System.Drawing.Color.White;
            this.lbPlus.Location = new System.Drawing.Point(371, 54);
            this.lbPlus.Margin = new System.Windows.Forms.Padding(3);
            this.lbPlus.Name = "lbPlus";
            this.lbPlus.Size = new System.Drawing.Size(55, 45);
            this.lbPlus.TabIndex = 17;
            this.lbPlus.Text = "+";
            this.lbPlus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbPlus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbPlus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbN4
            // 
            this.lbN4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(68)))), ((int)(((byte)(76)))));
            this.lbN4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbN4.ForeColor = System.Drawing.Color.White;
            this.lbN4.Location = new System.Drawing.Point(454, 54);
            this.lbN4.Margin = new System.Windows.Forms.Padding(25, 3, 3, 3);
            this.lbN4.Name = "lbN4";
            this.lbN4.Size = new System.Drawing.Size(55, 45);
            this.lbN4.TabIndex = 39;
            this.lbN4.Text = "4";
            this.lbN4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbN4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.numChar_MouseDown);
            this.lbN4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.numChar_MouseUp);
            // 
            // lbN5
            // 
            this.lbN5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(68)))), ((int)(((byte)(76)))));
            this.lbN5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbN5.ForeColor = System.Drawing.Color.White;
            this.lbN5.Location = new System.Drawing.Point(515, 54);
            this.lbN5.Margin = new System.Windows.Forms.Padding(3);
            this.lbN5.Name = "lbN5";
            this.lbN5.Size = new System.Drawing.Size(55, 45);
            this.lbN5.TabIndex = 40;
            this.lbN5.Text = "5";
            this.lbN5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbN5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.numChar_MouseDown);
            this.lbN5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.numChar_MouseUp);
            // 
            // lbN6
            // 
            this.lbN6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(68)))), ((int)(((byte)(76)))));
            this.lbN6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbN6.ForeColor = System.Drawing.Color.White;
            this.lbN6.Location = new System.Drawing.Point(576, 54);
            this.lbN6.Margin = new System.Windows.Forms.Padding(3);
            this.lbN6.Name = "lbN6";
            this.lbN6.Size = new System.Drawing.Size(55, 45);
            this.lbN6.TabIndex = 41;
            this.lbN6.Text = "6";
            this.lbN6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbN6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.numChar_MouseDown);
            this.lbN6.MouseUp += new System.Windows.Forms.MouseEventHandler(this.numChar_MouseUp);
            // 
            // lbNext
            // 
            this.lbNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            this.lbNext.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNext.ForeColor = System.Drawing.Color.White;
            this.lbNext.Image = Properties.Resources.key_next_w;
            this.lbNext.Location = new System.Drawing.Point(5, 105);
            this.lbNext.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.lbNext.Name = "lbNext";
            this.lbNext.Size = new System.Drawing.Size(55, 45);
            this.lbNext.TabIndex = 22;
            this.lbNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbNext.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbNext_MouseDown);
            this.lbNext.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbNext_MouseUp);
            // 
            // lbBackslash
            // 
            this.lbBackslash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbBackslash.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBackslash.ForeColor = System.Drawing.Color.White;
            this.lbBackslash.Location = new System.Drawing.Point(66, 105);
            this.lbBackslash.Margin = new System.Windows.Forms.Padding(3);
            this.lbBackslash.Name = "lbBackslash";
            this.lbBackslash.Size = new System.Drawing.Size(55, 45);
            this.lbBackslash.TabIndex = 23;
            this.lbBackslash.Text = "\\";
            this.lbBackslash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbBackslash.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbBackslash.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbSemiColon
            // 
            this.lbSemiColon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbSemiColon.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSemiColon.ForeColor = System.Drawing.Color.White;
            this.lbSemiColon.Location = new System.Drawing.Point(127, 105);
            this.lbSemiColon.Margin = new System.Windows.Forms.Padding(3);
            this.lbSemiColon.Name = "lbSemiColon";
            this.lbSemiColon.Size = new System.Drawing.Size(55, 45);
            this.lbSemiColon.TabIndex = 24;
            this.lbSemiColon.Text = ";";
            this.lbSemiColon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbSemiColon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbSemiColon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbColon
            // 
            this.lbColon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbColon.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbColon.ForeColor = System.Drawing.Color.White;
            this.lbColon.Location = new System.Drawing.Point(188, 105);
            this.lbColon.Margin = new System.Windows.Forms.Padding(3);
            this.lbColon.Name = "lbColon";
            this.lbColon.Size = new System.Drawing.Size(55, 45);
            this.lbColon.TabIndex = 25;
            this.lbColon.Text = ":";
            this.lbColon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbColon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbColon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbDoubleQuote
            // 
            this.lbDoubleQuote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbDoubleQuote.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDoubleQuote.ForeColor = System.Drawing.Color.White;
            this.lbDoubleQuote.Location = new System.Drawing.Point(249, 105);
            this.lbDoubleQuote.Margin = new System.Windows.Forms.Padding(3);
            this.lbDoubleQuote.Name = "lbDoubleQuote";
            this.lbDoubleQuote.Size = new System.Drawing.Size(55, 45);
            this.lbDoubleQuote.TabIndex = 26;
            this.lbDoubleQuote.Text = "\"";
            this.lbDoubleQuote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbDoubleQuote.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbDoubleQuote.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbStar
            // 
            this.lbStar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbStar.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStar.ForeColor = System.Drawing.Color.White;
            this.lbStar.Location = new System.Drawing.Point(310, 105);
            this.lbStar.Margin = new System.Windows.Forms.Padding(3);
            this.lbStar.Name = "lbStar";
            this.lbStar.Size = new System.Drawing.Size(55, 45);
            this.lbStar.TabIndex = 27;
            this.lbStar.Text = "*";
            this.lbStar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbStar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbStar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbSlash
            // 
            this.lbSlash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbSlash.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSlash.ForeColor = System.Drawing.Color.White;
            this.lbSlash.Location = new System.Drawing.Point(371, 105);
            this.lbSlash.Margin = new System.Windows.Forms.Padding(3);
            this.lbSlash.Name = "lbSlash";
            this.lbSlash.Size = new System.Drawing.Size(55, 45);
            this.lbSlash.TabIndex = 28;
            this.lbSlash.Text = "/";
            this.lbSlash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbSlash.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbSlash.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbN7
            // 
            this.lbN7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(68)))), ((int)(((byte)(76)))));
            this.lbN7.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbN7.ForeColor = System.Drawing.Color.White;
            this.lbN7.Location = new System.Drawing.Point(454, 105);
            this.lbN7.Margin = new System.Windows.Forms.Padding(25, 3, 3, 3);
            this.lbN7.Name = "lbN7";
            this.lbN7.Size = new System.Drawing.Size(55, 45);
            this.lbN7.TabIndex = 42;
            this.lbN7.Text = "7";
            this.lbN7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbN7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.numChar_MouseDown);
            this.lbN7.MouseUp += new System.Windows.Forms.MouseEventHandler(this.numChar_MouseUp);
            // 
            // lbN8
            // 
            this.lbN8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(68)))), ((int)(((byte)(76)))));
            this.lbN8.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbN8.ForeColor = System.Drawing.Color.White;
            this.lbN8.Location = new System.Drawing.Point(515, 105);
            this.lbN8.Margin = new System.Windows.Forms.Padding(3);
            this.lbN8.Name = "lbN8";
            this.lbN8.Size = new System.Drawing.Size(55, 45);
            this.lbN8.TabIndex = 43;
            this.lbN8.Text = "8";
            this.lbN8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbN8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.numChar_MouseDown);
            this.lbN8.MouseUp += new System.Windows.Forms.MouseEventHandler(this.numChar_MouseUp);
            // 
            // lbN9
            // 
            this.lbN9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(68)))), ((int)(((byte)(76)))));
            this.lbN9.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbN9.ForeColor = System.Drawing.Color.White;
            this.lbN9.Location = new System.Drawing.Point(576, 105);
            this.lbN9.Margin = new System.Windows.Forms.Padding(3);
            this.lbN9.Name = "lbN9";
            this.lbN9.Size = new System.Drawing.Size(55, 45);
            this.lbN9.TabIndex = 44;
            this.lbN9.Text = "9";
            this.lbN9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbN9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.numChar_MouseDown);
            this.lbN9.MouseUp += new System.Windows.Forms.MouseEventHandler(this.numChar_MouseUp);
            // 
            // lbSwitch2
            // 
            this.lbSwitch2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lbSwitch2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSwitch2.ForeColor = System.Drawing.Color.White;
            this.lbSwitch2.Location = new System.Drawing.Point(5, 156);
            this.lbSwitch2.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.lbSwitch2.Name = "lbSwitch2";
            this.lbSwitch2.Size = new System.Drawing.Size(86, 45);
            this.lbSwitch2.TabIndex = 34;
            this.lbSwitch2.Text = "&&123";
            this.lbSwitch2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbSwitch2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbSwitch2_MouseDown);
            this.lbSwitch2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbSwitch2_MouseUp);
            // 
            // lbMoveLeft2
            // 
            this.lbMoveLeft2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            this.lbMoveLeft2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMoveLeft2.ForeColor = System.Drawing.Color.White;
            this.lbMoveLeft2.Image = Properties.Resources.key_move_left_w;
            this.lbMoveLeft2.Location = new System.Drawing.Point(97, 156);
            this.lbMoveLeft2.Margin = new System.Windows.Forms.Padding(3);
            this.lbMoveLeft2.Name = "lbMoveLeft2";
            this.lbMoveLeft2.Size = new System.Drawing.Size(70, 45);
            this.lbMoveLeft2.TabIndex = 36;
            this.lbMoveLeft2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbMoveLeft2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.moveLeft_MouseDown);
            this.lbMoveLeft2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.moveLeft_MouseUp);
            // 
            // lbMoveRight2
            // 
            this.lbMoveRight2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            this.lbMoveRight2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMoveRight2.ForeColor = System.Drawing.Color.White;
            this.lbMoveRight2.Image = Properties.Resources.key_move_right_w;
            this.lbMoveRight2.Location = new System.Drawing.Point(173, 156);
            this.lbMoveRight2.Margin = new System.Windows.Forms.Padding(3);
            this.lbMoveRight2.Name = "lbMoveRight2";
            this.lbMoveRight2.Size = new System.Drawing.Size(70, 45);
            this.lbMoveRight2.TabIndex = 37;
            this.lbMoveRight2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbMoveRight2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.moveRight_MouseDown);
            this.lbMoveRight2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.moveRight_MouseUp);
            // 
            // lbSpace2
            // 
            this.lbSpace2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbSpace2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSpace2.ForeColor = System.Drawing.Color.White;
            this.lbSpace2.Location = new System.Drawing.Point(249, 156);
            this.lbSpace2.Margin = new System.Windows.Forms.Padding(3);
            this.lbSpace2.Name = "lbSpace2";
            this.lbSpace2.Size = new System.Drawing.Size(177, 45);
            this.lbSpace2.TabIndex = 35;
            this.lbSpace2.Text = "Space";
            this.lbSpace2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbSpace2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbSpace2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // lbN0
            // 
            this.lbN0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(68)))), ((int)(((byte)(76)))));
            this.lbN0.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbN0.ForeColor = System.Drawing.Color.White;
            this.lbN0.Location = new System.Drawing.Point(454, 156);
            this.lbN0.Margin = new System.Windows.Forms.Padding(25, 3, 3, 3);
            this.lbN0.Name = "lbN0";
            this.lbN0.Size = new System.Drawing.Size(116, 45);
            this.lbN0.TabIndex = 45;
            this.lbN0.Text = "0";
            this.lbN0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbN0.MouseDown += new System.Windows.Forms.MouseEventHandler(this.numChar_MouseDown);
            this.lbN0.MouseUp += new System.Windows.Forms.MouseEventHandler(this.numChar_MouseUp);
            // 
            // lbDot2
            // 
            this.lbDot2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.lbDot2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDot2.ForeColor = System.Drawing.Color.White;
            this.lbDot2.Location = new System.Drawing.Point(576, 156);
            this.lbDot2.Margin = new System.Windows.Forms.Padding(3);
            this.lbDot2.Name = "lbDot2";
            this.lbDot2.Size = new System.Drawing.Size(55, 45);
            this.lbDot2.TabIndex = 46;
            this.lbDot2.Text = ".";
            this.lbDot2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbDot2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseDown);
            this.lbDot2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChar_MouseUp);
            // 
            // KeypadDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(735, 236);
            this.Controls.Add(this.panelSubContainer);
            this.Controls.Add(this.panelMainKeyboard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "KeypadDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "KeypadDialog";
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.KeypadDialog_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KeypadDialog_FormClosing);
            this.panelMainKeyboard.ResumeLayout(false);
            this.panelSubContainer.ResumeLayout(false);
            this.panelSubKeyboard.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label lbQ;
        private FlowLayoutPanel panelMainKeyboard;
        private Label lbW;
        private Label lbE;
        private Label lbR;
        private Label lbT;
        private Label lbY;
        private Label lbU;
        private Label lbI;
        private Label lbO;
        private Label lbP;
        private Label lbBackspace1;
        private Label lbA;
        private Label lbS;
        private Label lbD;
        private Label lbF;
        private Label lbG;
        private Label lbH;
        private Label lbJ;
        private Label lbK;
        private Label lbL;
        private Label lbApostrophe;
        private Label lbEnter1;
        private Label lbShiftLeft;
        private Label lbZ;
        private Label lbX;
        private Label lbC;
        private Label lbV;
        private Label lbB;
        private Label lbN;
        private Label lbM;
        private Label lbComma;
        private Label lbDot1;
        private Label lbQuestion;
        private Label lbShiftRight;
        private Label lbSwitch1;
        private Label lbSpace1;
        private Label lbMoveLeft1;
        private Label lbMoveRight1;
        private Label lbBackspace2;
        private Label lbEnter2;
        private Panel panelSubContainer;
        private FlowLayoutPanel panelSubKeyboard;
        private Label lbTab;
        private Label lbExclamation;
        private Label lbAtSign;
        private Label lbSharp;
        private Label lbDollar;
        private Label lbPercent;
        private Label lbAnd;
        private Label lbN1;
        private Label lbN2;
        private Label lbN3;
        private Label lbPrevious;
        private Label lbOpenParenthesis;
        private Label lbCloseParenthesis;
        private Label lbHyphen;
        private Label lbUnderscore;
        private Label lbEqual;
        private Label lbPlus;
        private Label lbN4;
        private Label lbN5;
        private Label lbN6;
        private Label lbNext;
        private Label lbBackslash;
        private Label lbSemiColon;
        private Label lbColon;
        private Label lbDoubleQuote;
        private Label lbStar;
        private Label lbSlash;
        private Label lbN7;
        private Label lbN8;
        private Label lbN9;
        private Label lbSwitch2;
        private Label lbMoveLeft2;
        private Label lbMoveRight2;
        private Label lbSpace2;
        private Label lbN0;
        private Label lbDot2;
    }
}