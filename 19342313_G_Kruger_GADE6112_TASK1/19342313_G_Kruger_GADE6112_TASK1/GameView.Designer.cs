namespace _19342313_G_Kruger_GADE6112_TASK1
{
    partial class GameView
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
            this.map_label = new System.Windows.Forms.Label();
            this.playerstats_label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // map_label
            // 
            this.map_label.AutoSize = true;
            this.map_label.Location = new System.Drawing.Point(217, 99);
            this.map_label.Name = "map_label";
            this.map_label.Size = new System.Drawing.Size(0, 17);
            this.map_label.TabIndex = 0;
            // 
            // playerstats_label
            // 
            this.playerstats_label.AutoSize = true;
            this.playerstats_label.Location = new System.Drawing.Point(895, 99);
            this.playerstats_label.Name = "playerstats_label";
            this.playerstats_label.Size = new System.Drawing.Size(0, 17);
            this.playerstats_label.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(872, 300);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 34);
            this.label3.TabIndex = 2;
            this.label3.Text = "Use Arrow Keys \r\nfor Movement";
            // 
            // GameView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 520);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.playerstats_label);
            this.Controls.Add(this.map_label);
            this.Name = "GameView";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label map_label;
        private System.Windows.Forms.Label playerstats_label;
        private System.Windows.Forms.Label label3;
    }
}

