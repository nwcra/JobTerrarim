namespace JobTerrarium
{
    partial class MainForm
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
            this.workSpace = new System.Windows.Forms.DataGridView();
            this.logTalk = new System.Windows.Forms.TextBox();
            this.runTerrarium = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.workSpace)).BeginInit();
            this.SuspendLayout();
            // 
            // workSpace
            // 
            this.workSpace.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.workSpace.Location = new System.Drawing.Point(12, 12);
            this.workSpace.Name = "workSpace";
            this.workSpace.Size = new System.Drawing.Size(472, 289);
            this.workSpace.TabIndex = 0;
            // 
            // logTalk
            // 
            this.logTalk.Location = new System.Drawing.Point(540, 17);
            this.logTalk.Multiline = true;
            this.logTalk.Name = "logTalk";
            this.logTalk.Size = new System.Drawing.Size(195, 220);
            this.logTalk.TabIndex = 1;
            // 
            // runTerrarium
            // 
            this.runTerrarium.Location = new System.Drawing.Point(601, 278);
            this.runTerrarium.Name = "runTerrarium";
            this.runTerrarium.Size = new System.Drawing.Size(75, 23);
            this.runTerrarium.TabIndex = 2;
            this.runTerrarium.Text = "runTerrarium";
            this.runTerrarium.UseVisualStyleBackColor = true;
            this.runTerrarium.Click += new System.EventHandler(this.RunTerrarium_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 332);
            this.Controls.Add(this.runTerrarium);
            this.Controls.Add(this.logTalk);
            this.Controls.Add(this.workSpace);
            this.Name = "MainForm";
            this.Text = "JobTerrarium";
            ((System.ComponentModel.ISupportInitialize)(this.workSpace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView workSpace;
        private System.Windows.Forms.TextBox logTalk;
        private System.Windows.Forms.Button runTerrarium;
    }
}

