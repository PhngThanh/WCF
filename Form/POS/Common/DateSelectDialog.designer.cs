using System.ComponentModel;
using System.Windows.Forms;
using POS.CustomControl;

namespace POS.Common
{
    partial class DateSelectDialog
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
            this.dayContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.d1 = new DayRadioButton();
            this.d2 = new DayRadioButton();
            this.d3 = new DayRadioButton();
            this.d4 = new DayRadioButton();
            this.d5 = new DayRadioButton();
            this.d6 = new DayRadioButton();
            this.d7 = new DayRadioButton();
            this.d8 = new DayRadioButton();
            this.d9 = new DayRadioButton();
            this.d10 = new DayRadioButton();
            this.d11 = new DayRadioButton();
            this.d12 = new DayRadioButton();
            this.d13 = new DayRadioButton();
            this.d14 = new DayRadioButton();
            this.d15 = new DayRadioButton();
            this.d16 = new DayRadioButton();
            this.d17 = new DayRadioButton();
            this.d18 = new DayRadioButton();
            this.d19 = new DayRadioButton();
            this.d20 = new DayRadioButton();
            this.d21 = new DayRadioButton();
            this.d22 = new DayRadioButton();
            this.d23 = new DayRadioButton();
            this.d24 = new DayRadioButton();
            this.d25 = new DayRadioButton();
            this.d26 = new DayRadioButton();
            this.d27 = new DayRadioButton();
            this.d28 = new DayRadioButton();
            this.d29 = new DayRadioButton();
            this.d30 = new DayRadioButton();
            this.d31 = new DayRadioButton();
            this.btnCancel = new FlexButton();
            this.btnOK = new FlexButton();
            this.txtYear = new RoundTextbox();
            this.txtMonth = new RoundTextbox();
            this.dayContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // dayContainer
            // 
            this.dayContainer.Controls.Add(this.d1);
            this.dayContainer.Controls.Add(this.d2);
            this.dayContainer.Controls.Add(this.d3);
            this.dayContainer.Controls.Add(this.d4);
            this.dayContainer.Controls.Add(this.d5);
            this.dayContainer.Controls.Add(this.d6);
            this.dayContainer.Controls.Add(this.d7);
            this.dayContainer.Controls.Add(this.d8);
            this.dayContainer.Controls.Add(this.d9);
            this.dayContainer.Controls.Add(this.d10);
            this.dayContainer.Controls.Add(this.d11);
            this.dayContainer.Controls.Add(this.d12);
            this.dayContainer.Controls.Add(this.d13);
            this.dayContainer.Controls.Add(this.d14);
            this.dayContainer.Controls.Add(this.d15);
            this.dayContainer.Controls.Add(this.d16);
            this.dayContainer.Controls.Add(this.d17);
            this.dayContainer.Controls.Add(this.d18);
            this.dayContainer.Controls.Add(this.d19);
            this.dayContainer.Controls.Add(this.d20);
            this.dayContainer.Controls.Add(this.d21);
            this.dayContainer.Controls.Add(this.d22);
            this.dayContainer.Controls.Add(this.d23);
            this.dayContainer.Controls.Add(this.d24);
            this.dayContainer.Controls.Add(this.d25);
            this.dayContainer.Controls.Add(this.d26);
            this.dayContainer.Controls.Add(this.d27);
            this.dayContainer.Controls.Add(this.d28);
            this.dayContainer.Controls.Add(this.d29);
            this.dayContainer.Controls.Add(this.d30);
            this.dayContainer.Controls.Add(this.d31);
            this.dayContainer.Location = new System.Drawing.Point(12, 56);
            this.dayContainer.Name = "dayContainer";
            this.dayContainer.Size = new System.Drawing.Size(462, 232);
            this.dayContainer.TabIndex = 0;
            // 
            // d1
            // 
            this.d1.Appearance = System.Windows.Forms.Appearance.Button;
            this.d1.FlatAppearance.BorderSize = 0;
            this.d1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d1.ForeColor = System.Drawing.Color.White;
            this.d1.Location = new System.Drawing.Point(3, 3);
            this.d1.Name = "d1";
            this.d1.Size = new System.Drawing.Size(60, 40);
            this.d1.TabIndex = 0;
            this.d1.TabStop = true;
            this.d1.Text = "1";
            this.d1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d1.UseVisualStyleBackColor = true;
            // 
            // d2
            // 
            this.d2.Appearance = System.Windows.Forms.Appearance.Button;
            this.d2.FlatAppearance.BorderSize = 0;
            this.d2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d2.ForeColor = System.Drawing.Color.White;
            this.d2.Location = new System.Drawing.Point(69, 3);
            this.d2.Name = "d2";
            this.d2.Size = new System.Drawing.Size(60, 40);
            this.d2.TabIndex = 2;
            this.d2.TabStop = true;
            this.d2.Text = "2";
            this.d2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d2.UseVisualStyleBackColor = true;
            // 
            // d3
            // 
            this.d3.Appearance = System.Windows.Forms.Appearance.Button;
            this.d3.FlatAppearance.BorderSize = 0;
            this.d3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d3.ForeColor = System.Drawing.Color.White;
            this.d3.Location = new System.Drawing.Point(135, 3);
            this.d3.Name = "d3";
            this.d3.Size = new System.Drawing.Size(60, 40);
            this.d3.TabIndex = 3;
            this.d3.TabStop = true;
            this.d3.Text = "3";
            this.d3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d3.UseVisualStyleBackColor = true;
            // 
            // d4
            // 
            this.d4.Appearance = System.Windows.Forms.Appearance.Button;
            this.d4.FlatAppearance.BorderSize = 0;
            this.d4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d4.ForeColor = System.Drawing.Color.White;
            this.d4.Location = new System.Drawing.Point(201, 3);
            this.d4.Name = "d4";
            this.d4.Size = new System.Drawing.Size(60, 40);
            this.d4.TabIndex = 4;
            this.d4.TabStop = true;
            this.d4.Text = "4";
            this.d4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d4.UseVisualStyleBackColor = true;
            // 
            // d5
            // 
            this.d5.Appearance = System.Windows.Forms.Appearance.Button;
            this.d5.FlatAppearance.BorderSize = 0;
            this.d5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d5.ForeColor = System.Drawing.Color.White;
            this.d5.Location = new System.Drawing.Point(267, 3);
            this.d5.Name = "d5";
            this.d5.Size = new System.Drawing.Size(60, 40);
            this.d5.TabIndex = 5;
            this.d5.TabStop = true;
            this.d5.Text = "5";
            this.d5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d5.UseVisualStyleBackColor = true;
            // 
            // d6
            // 
            this.d6.Appearance = System.Windows.Forms.Appearance.Button;
            this.d6.FlatAppearance.BorderSize = 0;
            this.d6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d6.ForeColor = System.Drawing.Color.White;
            this.d6.Location = new System.Drawing.Point(333, 3);
            this.d6.Name = "d6";
            this.d6.Size = new System.Drawing.Size(60, 40);
            this.d6.TabIndex = 6;
            this.d6.TabStop = true;
            this.d6.Text = "6";
            this.d6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d6.UseVisualStyleBackColor = true;
            // 
            // d7
            // 
            this.d7.Appearance = System.Windows.Forms.Appearance.Button;
            this.d7.FlatAppearance.BorderSize = 0;
            this.d7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d7.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d7.ForeColor = System.Drawing.Color.White;
            this.d7.Location = new System.Drawing.Point(399, 3);
            this.d7.Name = "d7";
            this.d7.Size = new System.Drawing.Size(60, 40);
            this.d7.TabIndex = 7;
            this.d7.TabStop = true;
            this.d7.Text = "7";
            this.d7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d7.UseVisualStyleBackColor = true;
            // 
            // d8
            // 
            this.d8.Appearance = System.Windows.Forms.Appearance.Button;
            this.d8.FlatAppearance.BorderSize = 0;
            this.d8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d8.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d8.ForeColor = System.Drawing.Color.White;
            this.d8.Location = new System.Drawing.Point(3, 49);
            this.d8.Name = "d8";
            this.d8.Size = new System.Drawing.Size(60, 40);
            this.d8.TabIndex = 8;
            this.d8.TabStop = true;
            this.d8.Text = "8";
            this.d8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d8.UseVisualStyleBackColor = true;
            // 
            // d9
            // 
            this.d9.Appearance = System.Windows.Forms.Appearance.Button;
            this.d9.FlatAppearance.BorderSize = 0;
            this.d9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d9.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d9.ForeColor = System.Drawing.Color.White;
            this.d9.Location = new System.Drawing.Point(69, 49);
            this.d9.Name = "d9";
            this.d9.Size = new System.Drawing.Size(60, 40);
            this.d9.TabIndex = 9;
            this.d9.TabStop = true;
            this.d9.Text = "9";
            this.d9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d9.UseVisualStyleBackColor = true;
            // 
            // d10
            // 
            this.d10.Appearance = System.Windows.Forms.Appearance.Button;
            this.d10.FlatAppearance.BorderSize = 0;
            this.d10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d10.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d10.ForeColor = System.Drawing.Color.White;
            this.d10.Location = new System.Drawing.Point(135, 49);
            this.d10.Name = "d10";
            this.d10.Size = new System.Drawing.Size(60, 40);
            this.d10.TabIndex = 10;
            this.d10.TabStop = true;
            this.d10.Text = "10";
            this.d10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d10.UseVisualStyleBackColor = true;
            // 
            // d11
            // 
            this.d11.Appearance = System.Windows.Forms.Appearance.Button;
            this.d11.FlatAppearance.BorderSize = 0;
            this.d11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d11.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d11.ForeColor = System.Drawing.Color.White;
            this.d11.Location = new System.Drawing.Point(201, 49);
            this.d11.Name = "d11";
            this.d11.Size = new System.Drawing.Size(60, 40);
            this.d11.TabIndex = 11;
            this.d11.TabStop = true;
            this.d11.Text = "11";
            this.d11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d11.UseVisualStyleBackColor = true;
            // 
            // d12
            // 
            this.d12.Appearance = System.Windows.Forms.Appearance.Button;
            this.d12.FlatAppearance.BorderSize = 0;
            this.d12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d12.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d12.ForeColor = System.Drawing.Color.White;
            this.d12.Location = new System.Drawing.Point(267, 49);
            this.d12.Name = "d12";
            this.d12.Size = new System.Drawing.Size(60, 40);
            this.d12.TabIndex = 12;
            this.d12.TabStop = true;
            this.d12.Text = "12";
            this.d12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d12.UseVisualStyleBackColor = true;
            // 
            // d13
            // 
            this.d13.Appearance = System.Windows.Forms.Appearance.Button;
            this.d13.FlatAppearance.BorderSize = 0;
            this.d13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d13.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d13.ForeColor = System.Drawing.Color.White;
            this.d13.Location = new System.Drawing.Point(333, 49);
            this.d13.Name = "d13";
            this.d13.Size = new System.Drawing.Size(60, 40);
            this.d13.TabIndex = 13;
            this.d13.TabStop = true;
            this.d13.Text = "13";
            this.d13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d13.UseVisualStyleBackColor = true;
            // 
            // d14
            // 
            this.d14.Appearance = System.Windows.Forms.Appearance.Button;
            this.d14.FlatAppearance.BorderSize = 0;
            this.d14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d14.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d14.ForeColor = System.Drawing.Color.White;
            this.d14.Location = new System.Drawing.Point(399, 49);
            this.d14.Name = "d14";
            this.d14.Size = new System.Drawing.Size(60, 40);
            this.d14.TabIndex = 14;
            this.d14.TabStop = true;
            this.d14.Text = "14";
            this.d14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d14.UseVisualStyleBackColor = true;
            // 
            // d15
            // 
            this.d15.Appearance = System.Windows.Forms.Appearance.Button;
            this.d15.FlatAppearance.BorderSize = 0;
            this.d15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d15.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d15.ForeColor = System.Drawing.Color.White;
            this.d15.Location = new System.Drawing.Point(3, 95);
            this.d15.Name = "d15";
            this.d15.Size = new System.Drawing.Size(60, 40);
            this.d15.TabIndex = 15;
            this.d15.TabStop = true;
            this.d15.Text = "15";
            this.d15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d15.UseVisualStyleBackColor = true;
            // 
            // d16
            // 
            this.d16.Appearance = System.Windows.Forms.Appearance.Button;
            this.d16.FlatAppearance.BorderSize = 0;
            this.d16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d16.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d16.ForeColor = System.Drawing.Color.White;
            this.d16.Location = new System.Drawing.Point(69, 95);
            this.d16.Name = "d16";
            this.d16.Size = new System.Drawing.Size(60, 40);
            this.d16.TabIndex = 16;
            this.d16.TabStop = true;
            this.d16.Text = "16";
            this.d16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d16.UseVisualStyleBackColor = true;
            // 
            // d17
            // 
            this.d17.Appearance = System.Windows.Forms.Appearance.Button;
            this.d17.FlatAppearance.BorderSize = 0;
            this.d17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d17.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d17.ForeColor = System.Drawing.Color.White;
            this.d17.Location = new System.Drawing.Point(135, 95);
            this.d17.Name = "d17";
            this.d17.Size = new System.Drawing.Size(60, 40);
            this.d17.TabIndex = 17;
            this.d17.TabStop = true;
            this.d17.Text = "17";
            this.d17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d17.UseVisualStyleBackColor = true;
            // 
            // d18
            // 
            this.d18.Appearance = System.Windows.Forms.Appearance.Button;
            this.d18.FlatAppearance.BorderSize = 0;
            this.d18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d18.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d18.ForeColor = System.Drawing.Color.White;
            this.d18.Location = new System.Drawing.Point(201, 95);
            this.d18.Name = "d18";
            this.d18.Size = new System.Drawing.Size(60, 40);
            this.d18.TabIndex = 18;
            this.d18.TabStop = true;
            this.d18.Text = "18";
            this.d18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d18.UseVisualStyleBackColor = true;
            // 
            // d19
            // 
            this.d19.Appearance = System.Windows.Forms.Appearance.Button;
            this.d19.FlatAppearance.BorderSize = 0;
            this.d19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d19.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d19.ForeColor = System.Drawing.Color.White;
            this.d19.Location = new System.Drawing.Point(267, 95);
            this.d19.Name = "d19";
            this.d19.Size = new System.Drawing.Size(60, 40);
            this.d19.TabIndex = 19;
            this.d19.TabStop = true;
            this.d19.Text = "19";
            this.d19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d19.UseVisualStyleBackColor = true;
            // 
            // d20
            // 
            this.d20.Appearance = System.Windows.Forms.Appearance.Button;
            this.d20.FlatAppearance.BorderSize = 0;
            this.d20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d20.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d20.ForeColor = System.Drawing.Color.White;
            this.d20.Location = new System.Drawing.Point(333, 95);
            this.d20.Name = "d20";
            this.d20.Size = new System.Drawing.Size(60, 40);
            this.d20.TabIndex = 20;
            this.d20.TabStop = true;
            this.d20.Text = "20";
            this.d20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d20.UseVisualStyleBackColor = true;
            // 
            // d21
            // 
            this.d21.Appearance = System.Windows.Forms.Appearance.Button;
            this.d21.FlatAppearance.BorderSize = 0;
            this.d21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d21.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d21.ForeColor = System.Drawing.Color.White;
            this.d21.Location = new System.Drawing.Point(399, 95);
            this.d21.Name = "d21";
            this.d21.Size = new System.Drawing.Size(60, 40);
            this.d21.TabIndex = 21;
            this.d21.TabStop = true;
            this.d21.Text = "21";
            this.d21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d21.UseVisualStyleBackColor = true;
            // 
            // d22
            // 
            this.d22.Appearance = System.Windows.Forms.Appearance.Button;
            this.d22.FlatAppearance.BorderSize = 0;
            this.d22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d22.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d22.ForeColor = System.Drawing.Color.White;
            this.d22.Location = new System.Drawing.Point(3, 141);
            this.d22.Name = "d22";
            this.d22.Size = new System.Drawing.Size(60, 40);
            this.d22.TabIndex = 22;
            this.d22.TabStop = true;
            this.d22.Text = "22";
            this.d22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d22.UseVisualStyleBackColor = true;
            // 
            // d23
            // 
            this.d23.Appearance = System.Windows.Forms.Appearance.Button;
            this.d23.FlatAppearance.BorderSize = 0;
            this.d23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d23.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d23.ForeColor = System.Drawing.Color.White;
            this.d23.Location = new System.Drawing.Point(69, 141);
            this.d23.Name = "d23";
            this.d23.Size = new System.Drawing.Size(60, 40);
            this.d23.TabIndex = 23;
            this.d23.TabStop = true;
            this.d23.Text = "23";
            this.d23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d23.UseVisualStyleBackColor = true;
            // 
            // d24
            // 
            this.d24.Appearance = System.Windows.Forms.Appearance.Button;
            this.d24.FlatAppearance.BorderSize = 0;
            this.d24.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d24.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d24.ForeColor = System.Drawing.Color.White;
            this.d24.Location = new System.Drawing.Point(135, 141);
            this.d24.Name = "d24";
            this.d24.Size = new System.Drawing.Size(60, 40);
            this.d24.TabIndex = 24;
            this.d24.TabStop = true;
            this.d24.Text = "24";
            this.d24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d24.UseVisualStyleBackColor = true;
            // 
            // d25
            // 
            this.d25.Appearance = System.Windows.Forms.Appearance.Button;
            this.d25.FlatAppearance.BorderSize = 0;
            this.d25.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d25.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d25.ForeColor = System.Drawing.Color.White;
            this.d25.Location = new System.Drawing.Point(201, 141);
            this.d25.Name = "d25";
            this.d25.Size = new System.Drawing.Size(60, 40);
            this.d25.TabIndex = 25;
            this.d25.TabStop = true;
            this.d25.Text = "25";
            this.d25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d25.UseVisualStyleBackColor = true;
            // 
            // d26
            // 
            this.d26.Appearance = System.Windows.Forms.Appearance.Button;
            this.d26.FlatAppearance.BorderSize = 0;
            this.d26.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d26.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d26.ForeColor = System.Drawing.Color.White;
            this.d26.Location = new System.Drawing.Point(267, 141);
            this.d26.Name = "d26";
            this.d26.Size = new System.Drawing.Size(60, 40);
            this.d26.TabIndex = 26;
            this.d26.TabStop = true;
            this.d26.Text = "26";
            this.d26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d26.UseVisualStyleBackColor = true;
            // 
            // d27
            // 
            this.d27.Appearance = System.Windows.Forms.Appearance.Button;
            this.d27.FlatAppearance.BorderSize = 0;
            this.d27.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d27.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d27.ForeColor = System.Drawing.Color.White;
            this.d27.Location = new System.Drawing.Point(333, 141);
            this.d27.Name = "d27";
            this.d27.Size = new System.Drawing.Size(60, 40);
            this.d27.TabIndex = 27;
            this.d27.TabStop = true;
            this.d27.Text = "27";
            this.d27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d27.UseVisualStyleBackColor = true;
            // 
            // d28
            // 
            this.d28.Appearance = System.Windows.Forms.Appearance.Button;
            this.d28.FlatAppearance.BorderSize = 0;
            this.d28.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d28.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d28.ForeColor = System.Drawing.Color.White;
            this.d28.Location = new System.Drawing.Point(399, 141);
            this.d28.Name = "d28";
            this.d28.Size = new System.Drawing.Size(60, 40);
            this.d28.TabIndex = 28;
            this.d28.TabStop = true;
            this.d28.Text = "28";
            this.d28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d28.UseVisualStyleBackColor = true;
            // 
            // d29
            // 
            this.d29.Appearance = System.Windows.Forms.Appearance.Button;
            this.d29.FlatAppearance.BorderSize = 0;
            this.d29.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d29.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d29.ForeColor = System.Drawing.Color.White;
            this.d29.Location = new System.Drawing.Point(3, 187);
            this.d29.Name = "d29";
            this.d29.Size = new System.Drawing.Size(60, 40);
            this.d29.TabIndex = 29;
            this.d29.TabStop = true;
            this.d29.Text = "29";
            this.d29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d29.UseVisualStyleBackColor = true;
            // 
            // d30
            // 
            this.d30.Appearance = System.Windows.Forms.Appearance.Button;
            this.d30.FlatAppearance.BorderSize = 0;
            this.d30.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d30.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d30.ForeColor = System.Drawing.Color.White;
            this.d30.Location = new System.Drawing.Point(69, 187);
            this.d30.Name = "d30";
            this.d30.Size = new System.Drawing.Size(60, 40);
            this.d30.TabIndex = 30;
            this.d30.TabStop = true;
            this.d30.Text = "30";
            this.d30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d30.UseVisualStyleBackColor = true;
            // 
            // d31
            // 
            this.d31.Appearance = System.Windows.Forms.Appearance.Button;
            this.d31.FlatAppearance.BorderSize = 0;
            this.d31.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d31.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d31.ForeColor = System.Drawing.Color.White;
            this.d31.Location = new System.Drawing.Point(135, 187);
            this.d31.Name = "d31";
            this.d31.Size = new System.Drawing.Size(60, 40);
            this.d31.TabIndex = 31;
            this.d31.TabStop = true;
            this.d31.Text = "31";
            this.d31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d31.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.BorderColor = System.Drawing.Color.White;
            this.btnCancel.BorderRadius = 2;
            this.btnCancel.BorderThick = 1;
            this.btnCancel.Caption = "Cancel";
            this.btnCancel.CenterImageDisable = null;
            this.btnCancel.CenterImageNormal = null;
            this.btnCancel.CenterImagePress = null;
            this.btnCancel.DisableColor = System.Drawing.Color.Empty;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.LeftImageDisable = null;
            this.btnCancel.LeftImageGap = 0;
            this.btnCancel.LeftImageNornal = null;
            this.btnCancel.LeftImagePress = null;
            this.btnCancel.Location = new System.Drawing.Point(366, 295);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormalColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
            this.btnCancel.PressColor = System.Drawing.Color.White;
            this.btnCancel.Size = new System.Drawing.Size(108, 40);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.BorderColor = System.Drawing.Color.White;
            this.btnOK.BorderRadius = 2;
            this.btnOK.BorderThick = 1;
            this.btnOK.Caption = "OK";
            this.btnOK.CenterImageDisable = null;
            this.btnOK.CenterImageNormal = null;
            this.btnOK.CenterImagePress = null;
            this.btnOK.DisableColor = System.Drawing.Color.Empty;
            this.btnOK.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.LeftImageDisable = null;
            this.btnOK.LeftImageGap = 0;
            this.btnOK.LeftImageNornal = null;
            this.btnOK.LeftImagePress = null;
            this.btnOK.Location = new System.Drawing.Point(251, 296);
            this.btnOK.Margin = new System.Windows.Forms.Padding(5);
            this.btnOK.Name = "btnOK";
            this.btnOK.NormalColor = System.Drawing.Color.White;
            this.btnOK.PressColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
            this.btnOK.Size = new System.Drawing.Size(106, 39);
            this.btnOK.TabIndex = 3;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtYear
            // 
            this.txtYear.BackColor = System.Drawing.Color.Transparent;
            this.txtYear.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.txtYear.BorderRadius = 3;
            this.txtYear.BorderThick = 1;
            this.txtYear.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYear.ForeColor = System.Drawing.Color.White;
            this.txtYear.Location = new System.Drawing.Point(251, 12);
            this.txtYear.Name = "txtYear";
            this.txtYear.PasswordChar = '\0';
            this.txtYear.ReadOnly = false;
            this.txtYear.Size = new System.Drawing.Size(77, 32);
            this.txtYear.TabIndex = 2;
            this.txtYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtYear.TextBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            // 
            // txtMonth
            // 
            this.txtMonth.BackColor = System.Drawing.Color.Transparent;
            this.txtMonth.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.txtMonth.BorderRadius = 3;
            this.txtMonth.BorderThick = 1;
            this.txtMonth.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonth.ForeColor = System.Drawing.Color.White;
            this.txtMonth.Location = new System.Drawing.Point(168, 12);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.PasswordChar = '\0';
            this.txtMonth.ReadOnly = false;
            this.txtMonth.Size = new System.Drawing.Size(77, 32);
            this.txtMonth.TabIndex = 1;
            this.txtMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMonth.TextBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            // 
            // DateSelectDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
            this.ClientSize = new System.Drawing.Size(488, 354);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.txtMonth);
            this.Controls.Add(this.dayContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DateSelectDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DateSelectDialog";
            this.TopMost = true;
            this.dayContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel dayContainer;
        private DayRadioButton d1;
        private DayRadioButton d2;
        private DayRadioButton d3;
        private DayRadioButton d4;
        private DayRadioButton d5;
        private DayRadioButton d6;
        private DayRadioButton d7;
        private DayRadioButton d8;
        private DayRadioButton d9;
        private DayRadioButton d10;
        private DayRadioButton d11;
        private DayRadioButton d12;
        private DayRadioButton d13;
        private DayRadioButton d14;
        private DayRadioButton d15;
        private DayRadioButton d16;
        private DayRadioButton d17;
        private DayRadioButton d18;
        private DayRadioButton d19;
        private DayRadioButton d20;
        private DayRadioButton d21;
        private DayRadioButton d22;
        private DayRadioButton d23;
        private DayRadioButton d24;
        private DayRadioButton d25;
        private DayRadioButton d26;
        private DayRadioButton d27;
        private DayRadioButton d28;
        private DayRadioButton d29;
        private DayRadioButton d30;
        private DayRadioButton d31;
        private RoundTextbox txtMonth;
        private RoundTextbox txtYear;
        private FlexButton btnOK;
        private FlexButton btnCancel;
    }
}