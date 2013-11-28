namespace Snake
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
            this.canvasPB = new System.Windows.Forms.PictureBox();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.graphicsTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.canvasPB)).BeginInit();
            this.SuspendLayout();
            // 
            // canvasPB
            // 
            this.canvasPB.BackColor = System.Drawing.Color.Black;
            this.canvasPB.Location = new System.Drawing.Point(12, 12);
            this.canvasPB.Name = "canvasPB";
            this.canvasPB.Size = new System.Drawing.Size(320, 320);
            this.canvasPB.TabIndex = 0;
            this.canvasPB.TabStop = false;
            this.canvasPB.Paint += new System.Windows.Forms.PaintEventHandler(this.canvasPB_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 343);
            this.Controls.Add(this.canvasPB);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.canvasPB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox canvasPB;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Timer graphicsTimer;
    }
}

