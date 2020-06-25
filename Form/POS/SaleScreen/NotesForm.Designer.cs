using POS.CustomControl;

namespace POS.SaleScreen
{
    partial class NotesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotesForm));
            this.lblFormName = new System.Windows.Forms.Label();
            this.txtNotes = new POS.Common.LoginFlatTextBox();
            this.btnCancel = new POS.Common.FlexButton();
            this.btnSave = new POS.Common.FlexButton();
            this.pnlMain = new POS.CustomControl.BootstrapPanel();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFormName
            // 
            resources.ApplyResources(this.lblFormName, "lblFormName");
            this.lblFormName.ForeColor = System.Drawing.Color.White;
            this.lblFormName.Name = "lblFormName";
            // 
            // txtNotes
            // 
            this.txtNotes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(66)))), ((int)(((byte)(67)))));
            this.txtNotes.BorderRadius = 2;
            this.txtNotes.BorderSize = 1;
            this.txtNotes.ImageWidth = 0;
            this.txtNotes.ImageZoom = 4;
            resources.ApplyResources(this.txtNotes, "txtNotes");
            this.txtNotes.Logo = null;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.PasswordChar = '\0';
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.BorderColor = System.Drawing.Color.White;
            this.btnCancel.BorderRadius = 4;
            this.btnCancel.BorderThick = 4;
            this.btnCancel.Caption = "Hủy";
            this.btnCancel.CenterImageDisable = null;
            this.btnCancel.CenterImageNormal = null;
            this.btnCancel.CenterImagePress = null;
            this.btnCancel.DisableColor = System.Drawing.Color.Empty;
            this.btnCancel.IsActivated = false;
            this.btnCancel.LeftImageDisable = null;
            this.btnCancel.LeftImageGap = 0;
            this.btnCancel.LeftImageNornal = null;
            this.btnCancel.LeftImagePress = null;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnCancel.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.BorderColor = System.Drawing.Color.White;
            this.btnSave.BorderRadius = 4;
            this.btnSave.BorderThick = 4;
            this.btnSave.Caption = "Lưu";
            this.btnSave.CenterImageDisable = null;
            this.btnSave.CenterImageNormal = null;
            this.btnSave.CenterImagePress = null;
            this.btnSave.DisableColor = System.Drawing.Color.Empty;
            this.btnSave.IsActivated = false;
            this.btnSave.LeftImageDisable = null;
            this.btnSave.LeftImageGap = 0;
            this.btnSave.LeftImageNornal = null;
            this.btnSave.LeftImagePress = null;
            this.btnSave.Name = "btnSave";
            this.btnSave.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnSave.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlMain
            // 
            resources.ApplyResources(this.pnlMain, "pnlMain");
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.pnlMain.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.pnlMain.Controls.Add(this.txtNotes);
            this.pnlMain.Controls.Add(this.lblFormName);
            this.pnlMain.Controls.Add(this.btnSave);
            this.pnlMain.Controls.Add(this.btnCancel);
            this.pnlMain.Name = "pnlMain";
            // 
            // NotesForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.Name = "NotesForm";
            this.ShowInTaskbar = false;
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblFormName;
        private Common.FlexButton btnCancel;
        private Common.LoginFlatTextBox txtNotes;
        private Common.FlexButton btnSave;
        private BootstrapPanel pnlMain;
    }
}
