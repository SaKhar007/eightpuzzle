namespace Coursova
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            panel2 = new Panel();
            button9 = new Button();
            label1 = new Label();
            labelMoves = new Label();
            button13 = new Button();
            button12 = new Button();
            buttonSolve = new Button();
            button10 = new Button();
            buttonShuffle = new Button();
            button8 = new Button();
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.PaleTurquoise;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(872, 597);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.DarkSlateGray;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(button9);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(labelMoves);
            panel2.Controls.Add(button13);
            panel2.Controls.Add(button12);
            panel2.Controls.Add(buttonSolve);
            panel2.Controls.Add(button10);
            panel2.Controls.Add(buttonShuffle);
            panel2.Controls.Add(button8);
            panel2.Controls.Add(button7);
            panel2.Controls.Add(button6);
            panel2.Controls.Add(button5);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Location = new Point(17, 17);
            panel2.Name = "panel2";
            panel2.Size = new Size(840, 566);
            panel2.TabIndex = 0;
            // 
            // button9
            // 
            button9.BackColor = Color.Honeydew;
            button9.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button9.Location = new Point(722, 102);
            button9.Name = "button9";
            button9.Size = new Size(100, 50);
            button9.TabIndex = 17;
            button9.Text = "Play";
            button9.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 48F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.LightGoldenrodYellow;
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(470, 86);
            label1.TabIndex = 16;
            label1.Text = "8-puzzle Game";
            // 
            // labelMoves
            // 
            labelMoves.AutoSize = true;
            labelMoves.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelMoves.ForeColor = Color.Aquamarine;
            labelMoves.Location = new Point(472, 162);
            labelMoves.Name = "labelMoves";
            labelMoves.Size = new Size(111, 32);
            labelMoves.TabIndex = 15;
            labelMoves.Text = "Moves: 0";
            labelMoves.Click += label1_Click;
            // 
            // button13
            // 
            button13.BackColor = Color.Honeydew;
            button13.Font = new Font("Microsoft Tai Le", 12F, FontStyle.Bold);
            button13.Location = new Point(722, 446);
            button13.Name = "button13";
            button13.Size = new Size(100, 50);
            button13.TabIndex = 14;
            button13.Text = "Exit";
            button13.UseVisualStyleBackColor = false;
            button13.Click += button13_Click;
            // 
            // button12
            // 
            button12.BackColor = Color.Honeydew;
            button12.Font = new Font("Microsoft Tai Le", 12F, FontStyle.Bold);
            button12.Location = new Point(722, 275);
            button12.Name = "button12";
            button12.Size = new Size(100, 50);
            button12.TabIndex = 13;
            button12.Text = "RBFS";
            button12.UseVisualStyleBackColor = false;
            button12.Click += button12_Click;
            // 
            // buttonSolve
            // 
            buttonSolve.BackColor = Color.Honeydew;
            buttonSolve.Font = new Font("Microsoft Tai Le", 12F, FontStyle.Bold);
            buttonSolve.Location = new Point(722, 187);
            buttonSolve.Name = "buttonSolve";
            buttonSolve.Size = new Size(100, 50);
            buttonSolve.TabIndex = 12;
            buttonSolve.Text = "A*";
            buttonSolve.UseVisualStyleBackColor = false;
            buttonSolve.Click += buttonSolve_Click;
            // 
            // button10
            // 
            button10.BackColor = Color.Honeydew;
            button10.Font = new Font("Microsoft Sans Serif", 30F);
            button10.Location = new Point(313, 409);
            button10.Name = "button10";
            button10.Size = new Size(125, 125);
            button10.TabIndex = 9;
            button10.UseVisualStyleBackColor = false;
            button10.Click += button10_Click;
            // 
            // buttonShuffle
            // 
            buttonShuffle.BackColor = Color.Honeydew;
            buttonShuffle.Font = new Font("Microsoft Tai Le", 12F, FontStyle.Bold);
            buttonShuffle.Location = new Point(722, 360);
            buttonShuffle.Name = "buttonShuffle";
            buttonShuffle.Size = new Size(100, 50);
            buttonShuffle.TabIndex = 8;
            buttonShuffle.Text = "Shuffle";
            buttonShuffle.UseVisualStyleBackColor = false;
            buttonShuffle.Click += buttonShuffle_Click;
            // 
            // button8
            // 
            button8.BackColor = Color.Honeydew;
            button8.Font = new Font("Microsoft Sans Serif", 30F);
            button8.Location = new Point(188, 409);
            button8.Name = "button8";
            button8.Size = new Size(125, 125);
            button8.TabIndex = 7;
            button8.Text = "8";
            button8.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            button7.BackColor = Color.Honeydew;
            button7.Font = new Font("Microsoft Sans Serif", 30F);
            button7.Location = new Point(64, 409);
            button7.Name = "button7";
            button7.Size = new Size(125, 125);
            button7.TabIndex = 6;
            button7.Text = "7";
            button7.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            button6.BackColor = Color.Honeydew;
            button6.Font = new Font("Microsoft Sans Serif", 30F);
            button6.Location = new Point(313, 287);
            button6.Name = "button6";
            button6.Size = new Size(125, 125);
            button6.TabIndex = 5;
            button6.Text = "6";
            button6.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = Color.Honeydew;
            button5.Font = new Font("Microsoft Sans Serif", 30F);
            button5.Location = new Point(188, 286);
            button5.Name = "button5";
            button5.Size = new Size(125, 125);
            button5.TabIndex = 4;
            button5.Text = "5";
            button5.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.Honeydew;
            button4.Font = new Font("Microsoft Sans Serif", 30F);
            button4.Location = new Point(64, 285);
            button4.Name = "button4";
            button4.Size = new Size(125, 125);
            button4.TabIndex = 3;
            button4.Text = "4";
            button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.Honeydew;
            button3.Font = new Font("Microsoft Sans Serif", 30F);
            button3.Location = new Point(313, 163);
            button3.Name = "button3";
            button3.Size = new Size(125, 125);
            button3.TabIndex = 2;
            button3.Text = "3";
            button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.Honeydew;
            button2.Font = new Font("Microsoft Sans Serif", 30F);
            button2.Location = new Point(188, 162);
            button2.Name = "button2";
            button2.Size = new Size(125, 125);
            button2.TabIndex = 1;
            button2.Text = "2";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.Honeydew;
            button1.Font = new Font("Microsoft Sans Serif", 30F);
            button1.Location = new Point(64, 162);
            button1.Name = "button1";
            button1.Size = new Size(125, 125);
            button1.TabIndex = 0;
            button1.Text = "1";
            button1.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateGray;
            ClientSize = new Size(896, 621);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Goofyest 8-puzzle game";
            FormClosing += Form1_FormClosing;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button button10;
        private Button buttonShuffle;
        private Button button8;
        private Button button7;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private Button buttonSolve;
        private Button button13;
        private Button button12;
        private Label labelMoves;
        private Label label1;
        private Button button9;
    }
}
