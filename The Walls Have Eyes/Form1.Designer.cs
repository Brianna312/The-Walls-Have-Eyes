namespace The_Walls_Have_Eyes
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
            this.gameEngine = new System.Windows.Forms.Timer(this.components);
            this.debugLabel = new System.Windows.Forms.Label();
            this.dialogueLabel = new System.Windows.Forms.Label();
            this.inventoryLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.npcPictureBox1 = new System.Windows.Forms.PictureBox();
            this.npcPictureBox2 = new System.Windows.Forms.PictureBox();
            this.characterPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.npcPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npcPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // gameEngine
            // 
            this.gameEngine.Enabled = true;
            this.gameEngine.Interval = 20;
            this.gameEngine.Tick += new System.EventHandler(this.gameEngine_Tick);
            // 
            // debugLabel
            // 
            this.debugLabel.AutoSize = true;
            this.debugLabel.Location = new System.Drawing.Point(640, 11);
            this.debugLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.debugLabel.Name = "debugLabel";
            this.debugLabel.Size = new System.Drawing.Size(37, 13);
            this.debugLabel.TabIndex = 0;
            this.debugLabel.Text = "debug";
            // 
            // dialogueLabel
            // 
            this.dialogueLabel.BackColor = System.Drawing.Color.Bisque;
            this.dialogueLabel.Font = new System.Drawing.Font("MV Boli", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dialogueLabel.Location = new System.Drawing.Point(75, 577);
            this.dialogueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dialogueLabel.Name = "dialogueLabel";
            this.dialogueLabel.Size = new System.Drawing.Size(900, 65);
            this.dialogueLabel.TabIndex = 1;
            this.dialogueLabel.Text = "Dialogue";
            this.dialogueLabel.Visible = false;
            // 
            // inventoryLabel
            // 
            this.inventoryLabel.AutoSize = true;
            this.inventoryLabel.Location = new System.Drawing.Point(656, 54);
            this.inventoryLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.inventoryLabel.Name = "inventoryLabel";
            this.inventoryLabel.Size = new System.Drawing.Size(51, 13);
            this.inventoryLabel.TabIndex = 2;
            this.inventoryLabel.Text = "Inventory";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(828, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // textBox
            // 
            this.textBox.Enabled = false;
            this.textBox.Font = new System.Drawing.Font("MV Boli", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox.Location = new System.Drawing.Point(893, 612);
            this.textBox.Margin = new System.Windows.Forms.Padding(2);
            this.textBox.MaxLength = 12;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(76, 24);
            this.textBox.TabIndex = 4;
            this.textBox.TabStop = false;
            this.textBox.Visible = false;
            // 
            // npcPictureBox1
            // 
            this.npcPictureBox1.Location = new System.Drawing.Point(930, 214);
            this.npcPictureBox1.Name = "npcPictureBox1";
            this.npcPictureBox1.Size = new System.Drawing.Size(80, 102);
            this.npcPictureBox1.TabIndex = 7;
            this.npcPictureBox1.TabStop = false;
            this.npcPictureBox1.Visible = false;
            // 
            // npcPictureBox2
            // 
            this.npcPictureBox2.Location = new System.Drawing.Point(930, 362);
            this.npcPictureBox2.Name = "npcPictureBox2";
            this.npcPictureBox2.Size = new System.Drawing.Size(80, 102);
            this.npcPictureBox2.TabIndex = 6;
            this.npcPictureBox2.TabStop = false;
            this.npcPictureBox2.Visible = false;
            // 
            // characterPictureBox
            // 
            this.characterPictureBox.Location = new System.Drawing.Point(930, 54);
            this.characterPictureBox.Name = "characterPictureBox";
            this.characterPictureBox.Size = new System.Drawing.Size(80, 102);
            this.characterPictureBox.TabIndex = 5;
            this.characterPictureBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 687);
            this.Controls.Add(this.npcPictureBox1);
            this.Controls.Add(this.npcPictureBox2);
            this.Controls.Add(this.characterPictureBox);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inventoryLabel);
            this.Controls.Add(this.dialogueLabel);
            this.Controls.Add(this.debugLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "The Walls Have Eyes";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.npcPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npcPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameEngine;
        private System.Windows.Forms.Label debugLabel;
        private System.Windows.Forms.Label dialogueLabel;
        private System.Windows.Forms.Label inventoryLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.PictureBox characterPictureBox;
        private System.Windows.Forms.PictureBox npcPictureBox2;
        private System.Windows.Forms.PictureBox npcPictureBox1;
    }
}

