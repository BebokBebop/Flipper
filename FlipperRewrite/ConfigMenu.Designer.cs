namespace FlipperRewrite
{
    partial class ConfigMenu
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
            _parent.Config = null;
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button Save;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.SetX = new System.Windows.Forms.TextBox();
            this.Seed = new System.Windows.Forms.TextBox();
            this.SetY = new System.Windows.Forms.TextBox();
            this.SeedUse = new System.Windows.Forms.CheckBox();
            Save = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Save
            // 
            Save.BackColor = System.Drawing.SystemColors.ControlLight;
            Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Save.Location = new System.Drawing.Point(12, 119);
            Save.Name = "Save";
            Save.Size = new System.Drawing.Size(100, 32);
            Save.TabIndex = 5;
            Save.Text = "Save";
            Save.UseVisualStyleBackColor = false;
            Save.Click += new System.EventHandler(this.Save_click);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            label1.Location = new System.Drawing.Point(12, 60);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(54, 13);
            label1.TabIndex = 6;
            label1.Text = "Use Seed";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            label2.Location = new System.Drawing.Point(12, 9);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(80, 13);
            label2.TabIndex = 7;
            label2.Text = "Map X/Y [3-18]";
            // 
            // SetX
            // 
            this.SetX.Location = new System.Drawing.Point(12, 28);
            this.SetX.Margin = new System.Windows.Forms.Padding(1);
            this.SetX.MaxLength = 2;
            this.SetX.Name = "SetX";
            this.SetX.Size = new System.Drawing.Size(49, 20);
            this.SetX.TabIndex = 0;
            // 
            // Seed
            // 
            this.Seed.Enabled = false;
            this.Seed.Location = new System.Drawing.Point(12, 80);
            this.Seed.Name = "Seed";
            this.Seed.Size = new System.Drawing.Size(100, 20);
            this.Seed.TabIndex = 2;
            // 
            // SetY
            // 
            this.SetY.Location = new System.Drawing.Point(63, 28);
            this.SetY.Margin = new System.Windows.Forms.Padding(1);
            this.SetY.MaxLength = 2;
            this.SetY.Name = "SetY";
            this.SetY.Size = new System.Drawing.Size(49, 20);
            this.SetY.TabIndex = 1;
            // 
            // SeedUse
            // 
            this.SeedUse.AutoSize = true;
            this.SeedUse.Location = new System.Drawing.Point(72, 60);
            this.SeedUse.Name = "SeedUse";
            this.SeedUse.Size = new System.Drawing.Size(15, 14);
            this.SeedUse.TabIndex = 8;
            this.SeedUse.UseVisualStyleBackColor = true;
            this.SeedUse.CheckedChanged += new System.EventHandler(this.SeedUseCheck_CheckedChanged);
            // 
            // ConfigMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(127, 163);
            this.ControlBox = false;
            this.Controls.Add(this.SeedUse);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Controls.Add(Save);
            this.Controls.Add(this.SetY);
            this.Controls.Add(this.Seed);
            this.Controls.Add(this.SetX);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigMenu";
            this.Text = "ConfigMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SetX;
        private System.Windows.Forms.TextBox SetY;
        private System.Windows.Forms.TextBox Seed;
        private System.Windows.Forms.CheckBox SeedUse;
    }
}