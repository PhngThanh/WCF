using POS.CustomControl;
using System.ComponentModel;
using System.Windows.Forms;

namespace POS.Common
{
    partial class MessageDialogWithMultipleInput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageDialogWithMultipleInput));
            this.lbMessage = new System.Windows.Forms.Label();
            this.txtNote = new Thn.Interface.Vcl.TextBox();
            this.btnTakeNote = new POS.CustomControl.BootstrapButton();
            this.pnlMain = new POS.CustomControl.BootstrapPanel();
            this.bootstrapButton1 = new POS.CustomControl.BootstrapButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnTakeNote)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bootstrapButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbMessage
            // 
            this.lbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMessage.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbMessage.ForeColor = System.Drawing.Color.Black;
            this.lbMessage.Location = new System.Drawing.Point(2, 0);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(412, 62);
            this.lbMessage.TabIndex = 2;
            this.lbMessage.Text = "Nhập ghi chú";
            this.lbMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNote
            // 
            this.txtNote.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtNote.ControlSize = new System.Drawing.Size(361, 77);
            this.txtNote.CornerRadius = 8;
            this.txtNote.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNote.ForeColor = System.Drawing.Color.Black;
            this.txtNote.IsAnimating = false;
            this.txtNote.Location = new System.Drawing.Point(29, 67);
            this.txtNote.Name = "txtNote";
            this.txtNote.OriginX = 180F;
            this.txtNote.OriginY = 38F;
            this.txtNote.Size = new System.Drawing.Size(361, 77);
            this.txtNote.TabIndex = 3;
            this.txtNote.Text = "test nè";
            // 
            // btnTakeNote
            // 
            this.btnTakeNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(186)))));
            this.btnTakeNote.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Primary;
            this.btnTakeNote.Image = ((System.Drawing.Image)(resources.GetObject("btnTakeNote.Image")));
            this.btnTakeNote.ImageColor = System.Drawing.Color.Black;
            this.btnTakeNote.ImageCss = "pencil";
            this.btnTakeNote.ImageFontSize = 20F;
            this.btnTakeNote.ImageTextPadding = 0;
            this.btnTakeNote.IsVerticalImageText = false;
            this.btnTakeNote.Location = new System.Drawing.Point(48, 170);
            this.btnTakeNote.Name = "btnTakeNote";
            this.btnTakeNote.Size = new System.Drawing.Size(142, 50);
            this.btnTakeNote.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnTakeNote.TabIndex = 4;
            this.btnTakeNote.TabStop = false;
            this.btnTakeNote.TextColor = System.Drawing.Color.Black;
            this.btnTakeNote.TextFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.btnTakeNote.TextValue = "Ghi chú";
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.pnlMain.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.pnlMain.Controls.Add(this.lbMessage);
            this.pnlMain.Controls.Add(this.bootstrapButton1);
            this.pnlMain.Controls.Add(this.btnTakeNote);
            this.pnlMain.Controls.Add(this.txtNote);
            this.pnlMain.Location = new System.Drawing.Point(3, 3);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(414, 245);
            this.pnlMain.TabIndex = 5;
            // 
            // bootstrapButton1
            // 
            this.bootstrapButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.bootstrapButton1.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.bootstrapButton1.Image = ((System.Drawing.Image)(resources.GetObject("bootstrapButton1.Image")));
            this.bootstrapButton1.ImageColor = System.Drawing.Color.Black;
            this.bootstrapButton1.ImageCss = "close";
            this.bootstrapButton1.ImageFontSize = 20F;
            this.bootstrapButton1.ImageTextPadding = 0;
            this.bootstrapButton1.IsVerticalImageText = false;
            this.bootstrapButton1.Location = new System.Drawing.Point(225, 170);
            this.bootstrapButton1.Name = "bootstrapButton1";
            this.bootstrapButton1.Size = new System.Drawing.Size(142, 50);
            this.bootstrapButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.bootstrapButton1.TabIndex = 4;
            this.bootstrapButton1.TabStop = false;
            this.bootstrapButton1.TextColor = System.Drawing.Color.Black;
            this.bootstrapButton1.TextFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.bootstrapButton1.TextValue = "Đóng";
            // 
            // MessageDialogWithMultipleInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(420, 250);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(420, 250);
            this.MinimumSize = new System.Drawing.Size(420, 250);
            this.Name = "MessageDialogWithMultipleInput";
            this.ShowInTaskbar = false;
            this.Text = "MessageDialog";
            ((System.ComponentModel.ISupportInitialize)(this.btnTakeNote)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bootstrapButton1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label lbMessage;
        private Thn.Interface.Vcl.TextBox txtNote;
        private BootstrapButton btnTakeNote;
        private BootstrapPanel pnlMain;
        private BootstrapButton bootstrapButton1;
    }
}