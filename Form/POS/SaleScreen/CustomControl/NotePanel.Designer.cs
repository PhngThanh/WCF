namespace POS.SaleScreen.CustomControl
{
    partial class NotePanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMain = new POS.CustomControl.BootstrapPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNotes = new POS.Common.LoginFlatTextBox();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.pnlMain.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.txtNotes);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(360, 650);
            this.pnlMain.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ghi chú";
            // 
            // txtNotes
            // 
            this.txtNotes.BackColor = System.Drawing.Color.DimGray;
            this.txtNotes.BorderRadius = 2;
            this.txtNotes.BorderSize = 1;
            this.txtNotes.ImageWidth = 0;
            this.txtNotes.ImageZoom = 4;
            this.txtNotes.Location = new System.Drawing.Point(25, 72);
            this.txtNotes.Logo = null;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.PasswordChar = '\0';
            this.txtNotes.Size = new System.Drawing.Size(263, 36);
            this.txtNotes.TabIndex = 1;
            this.txtNotes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNotes_KeyUp);
            // 
            // NotePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Name = "NotePanel";
            this.Size = new System.Drawing.Size(360, 650);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private POS.CustomControl.BootstrapPanel pnlMain;
        private Common.LoginFlatTextBox txtNotes;
        private System.Windows.Forms.Label label1;
    }
}
