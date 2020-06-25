﻿using System.ComponentModel;

namespace POS.Common
{
    partial class BaseTableControl
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
            if (disposing && (_pen != null))
            {
                _pen.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CircleButton
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Size = new System.Drawing.Size(115, 96);
            this.Click += new System.EventHandler(this.CircleButton_Click);
            this.ResumeLayout(false);

        }

        #endregion
    }
}