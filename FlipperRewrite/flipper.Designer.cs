namespace FlipperRewrite
{
    partial class flipper
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

        //New Game Buttons Generator
        private void GenerateMap()
        {
            ButtonSquare = new System.Windows.Forms.Button[SquareXY[0], SquareXY[1]];
            Solution = new bool[SquareXY[0], SquareXY[1]];
            System.Drawing.Size ButtonSize = new System.Drawing.Size(50, 50);

            //Generate Game Buttons
            for (int x = 0; x < SquareXY[0]; x++)
                for (int y = 0; y < SquareXY[1]; y++)
                {
                    ButtonSquare[x, y] = new System.Windows.Forms.Button();
                    System.Windows.Forms.Button button = ButtonSquare[x, y];
                    button.BackColor = System.Drawing.SystemColors.ControlLightLight;
                    button.FlatAppearance.BorderSize = 0;
                    button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    button.Location = new System.Drawing.Point(12 + x * (ButtonSize.Width + 4), 12 + y * (ButtonSize.Height + 4));
                    button.Margin = new System.Windows.Forms.Padding(11);
                    button.Size = ButtonSize;
                    button.TabIndex = (SquareXY[0] * y) + (x);
                    /*Generowane:           Indexowane:
                            [1][4][7]               [1][2][3]
                            [2][5][8]               [4][5][6]
                            [3][6][9]               [7][8][9]    */
                    button.TabStop = false;

                    button.Name = "Button" + button.TabIndex.ToString();
                    button.UseVisualStyleBackColor = false;
                    button.FlatAppearance.BorderColor = System.Drawing.Color.Red;
                    button.Click += new System.EventHandler(this.GameButtonPress);
                    this.Controls.Add(button);
                }

            ButtonSquare[SquareXY[0]-1, SquareXY[1]-1].Margin = new System.Windows.Forms.Padding(12, 12, SeedBox.Width + 24, 12);

            this.SeedBox.Text = Seed;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button Shuffle;
            System.Windows.Forms.Button NewMapOptions;
            System.Windows.Forms.Button CopySeed;
            this.SeedBox = new System.Windows.Forms.TextBox();
            this.ShowSolutionBox = new System.Windows.Forms.CheckBox();
            this.Reset = new System.Windows.Forms.Button();
            this.MovesTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CreateSeedMode = new System.Windows.Forms.CheckBox();
            this.Trademark = new System.Windows.Forms.Label();
            Shuffle = new System.Windows.Forms.Button();
            NewMapOptions = new System.Windows.Forms.Button();
            CopySeed = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Shuffle
            // 
            Shuffle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            Shuffle.BackColor = System.Drawing.SystemColors.ControlLight;
            Shuffle.FlatAppearance.BorderSize = 0;
            Shuffle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Shuffle.Location = new System.Drawing.Point(226, 15);
            Shuffle.Name = "Shuffle";
            Shuffle.Size = new System.Drawing.Size(114, 25);
            Shuffle.TabIndex = 1;
            Shuffle.Text = "Shuffle";
            Shuffle.UseVisualStyleBackColor = false;
            Shuffle.Click += new System.EventHandler(this.ShuffleMethod);
            // 
            // NewMapOptions
            // 
            NewMapOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            NewMapOptions.BackColor = System.Drawing.SystemColors.ControlLight;
            NewMapOptions.FlatAppearance.BorderSize = 0;
            NewMapOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            NewMapOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            NewMapOptions.Location = new System.Drawing.Point(226, 197);
            NewMapOptions.Margin = new System.Windows.Forms.Padding(3, 3, 3, 12);
            NewMapOptions.Name = "NewMapOptions";
            NewMapOptions.Size = new System.Drawing.Size(114, 25);
            NewMapOptions.TabIndex = 8;
            NewMapOptions.Text = "New Map Options";
            NewMapOptions.UseVisualStyleBackColor = false;
            NewMapOptions.Click += new System.EventHandler(this.NewMapOptions);
            // 
            // CopySeed
            // 
            CopySeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            CopySeed.BackColor = System.Drawing.SystemColors.ControlLight;
            CopySeed.FlatAppearance.BorderSize = 0;
            CopySeed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            CopySeed.Location = new System.Drawing.Point(226, 120);
            CopySeed.Name = "CopySeed";
            CopySeed.Size = new System.Drawing.Size(114, 27);
            CopySeed.TabIndex = 5;
            CopySeed.Text = "Copy Seed";
            CopySeed.UseVisualStyleBackColor = false;
            CopySeed.Click += new System.EventHandler(this.CopySeed_Click);
            // 
            // SeedBox
            // 
            this.SeedBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SeedBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.SeedBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SeedBox.Location = new System.Drawing.Point(226, 142);
            this.SeedBox.Name = "SeedBox";
            this.SeedBox.ReadOnly = true;
            this.SeedBox.Size = new System.Drawing.Size(114, 20);
            this.SeedBox.TabIndex = 6;
            // 
            // ShowSolutionBox
            // 
            this.ShowSolutionBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowSolutionBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ShowSolutionBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowSolutionBox.Location = new System.Drawing.Point(226, 77);
            this.ShowSolutionBox.Name = "ShowSolutionBox";
            this.ShowSolutionBox.Size = new System.Drawing.Size(114, 17);
            this.ShowSolutionBox.TabIndex = 3;
            this.ShowSolutionBox.Text = "Show Solution";
            this.ShowSolutionBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ShowSolutionBox.UseVisualStyleBackColor = false;
            this.ShowSolutionBox.CheckedChanged += new System.EventHandler(this.ShowSolutionBox_CheckedChanged);
            // 
            // Reset
            // 
            this.Reset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Reset.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Reset.FlatAppearance.BorderSize = 0;
            this.Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Reset.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Reset.Location = new System.Drawing.Point(226, 46);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(114, 25);
            this.Reset.TabIndex = 2;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = false;
            this.Reset.Click += new System.EventHandler(this.ResetMap);
            // 
            // MovesTextBox
            // 
            this.MovesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MovesTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.MovesTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MovesTextBox.Location = new System.Drawing.Point(271, 101);
            this.MovesTextBox.Name = "MovesTextBox";
            this.MovesTextBox.ReadOnly = true;
            this.MovesTextBox.Size = new System.Drawing.Size(69, 13);
            this.MovesTextBox.TabIndex = 4;
            this.MovesTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(223, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Moves:";
            // 
            // CreateSeedMode
            // 
            this.CreateSeedMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateSeedMode.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CreateSeedMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateSeedMode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CreateSeedMode.Location = new System.Drawing.Point(226, 168);
            this.CreateSeedMode.Name = "CreateSeedMode";
            this.CreateSeedMode.Size = new System.Drawing.Size(114, 17);
            this.CreateSeedMode.TabIndex = 7;
            this.CreateSeedMode.Text = "Create Seed Mode";
            this.CreateSeedMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CreateSeedMode.UseVisualStyleBackColor = false;
            this.CreateSeedMode.CheckedChanged += new System.EventHandler(this.CreateSeedMode_CheckedChanged);
            // 
            // Trademark
            // 
            this.Trademark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Trademark.BackColor = System.Drawing.Color.Black;
            this.Trademark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Trademark.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Trademark.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Trademark.Location = new System.Drawing.Point(224, 220);
            this.Trademark.Name = "Trademark";
            this.Trademark.Size = new System.Drawing.Size(117, 23);
            this.Trademark.TabIndex = 10;
            this.Trademark.Text = "Hubisoft 25.08.2016";
            this.Trademark.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // flipper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(352, 252);
            this.Controls.Add(this.Trademark);
            this.Controls.Add(this.CreateSeedMode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MovesTextBox);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.ShowSolutionBox);
            this.Controls.Add(Shuffle);
            this.Controls.Add(this.SeedBox);
            this.Controls.Add(CopySeed);
            this.Controls.Add(NewMapOptions);
            this.MaximizeBox = false;
            this.Name = "flipper";
            this.Text = "Flipper";
            this.LocationChanged += new System.EventHandler(this.ConfigSticker);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ShowSolutionBox;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.TextBox MovesTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CreateSeedMode;
        private System.Windows.Forms.Label Trademark;
    }
}

