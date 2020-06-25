using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace POS.SaleScreen.OrderPropertyScreen
{
    partial class MembershipTypePanel
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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Le Nguyen";
            // 
            // MembershipTypePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            LoadMemberShipType();
            this.Controls.Add(this.label1);
            this.Height = 500;this.Width = 500;
           // this.CenterToScreen();
            this.Name = "MembershipTypePanel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        public void LoadMemberShipType()
        {
            var currentDir = Environment.CurrentDirectory;
            var pathStoreInfo = currentDir + @"\Configuration\posConfig.json";
            string config = System.IO.File.ReadAllText(pathStoreInfo);
            var json = JObject.Parse(config);
            var list = json["CustomerTypeList"].ToObject<List<MembershipType>>();
            int posX = 0,posY=0;
            int i = 0;
            foreach(MembershipType item in list)
            {
                Label l = new Label();
                l.Name = item.Id.ToString();
                l.Text = item.Name;
                l.AutoSize = true;
                l.Location = new System.Drawing.Point(i*80, 20);
                l.Size = new System.Drawing.Size(59, 13);
                l.TabIndex = 0;
                this.Controls.Add(l);
                i++;
            }
        }
        #endregion

        private System.Windows.Forms.Label label1;
    }
}
