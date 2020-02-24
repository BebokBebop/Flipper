using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlipperRewrite
{
    public partial class flipper : Form
    {

        #region Public Variables
        public static int SizeX = 4;
        public static int SizeY = 4;
        public string Seed = "n.n.n.n.D.4x4";
        public ConfigMenu Config = null;
        #endregion

        #region Private Variables
        private int Moves = 0; 
        private bool SolutionSwitch = false;
        private bool[,] Solution;
        private static int[] SquareXY = { SizeX, SizeY };
        private System.Windows.Forms.Button[,] ButtonSquare;
        private System.Windows.Forms.TextBox SeedBox;
        #endregion

        public flipper()
        {
            InitializeComponent();
            GenerateMap();
            this.Config = new ConfigMenu(this);
            this.Config.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            this.Config = null;
            MovesTextBox.Text = "" + Moves;
        }

        public void RestartMap()
        {
            PrepareVariables();
            Clear();
            int i;
            for (i = 0; i < SquareXY[0]; i++)
                for (int j = 0; j < SquareXY[1]; j++)
                    ButtonSquare[i, j].Dispose();

            for (i = this.Controls.Count - 1; i >= 0; i--)
                this.Controls[i].Dispose();

            SquareXY = WhatDimensionIsIt(Seed);
            InitializeComponent();
            GenerateMap();
            UseSeedMethod();
        }

        private void GameButtonPress(object sender, EventArgs e)
        {
            System.Windows.Forms.Button button = sender as System.Windows.Forms.Button;
            int x = button.TabIndex % SquareXY[0];
            int y = button.TabIndex / SquareXY[0];
            baseChangeColor(x, y);

            if (MovesTextBox.BackColor == System.Drawing.SystemColors.ControlLight)
            {
                Moves++;
                MovesTextBox.Text = "" + Moves;
            }

            if(CreateSeedMode.Checked)
            {
                Extract();
                return;
            }

            for (int a = 0; a < SquareXY[0]; a++)
                for (int b = 0; b < SquareXY[1]; b++)
                    if (ButtonSquare[a, b].BackColor != System.Drawing.SystemColors.ControlLightLight)
                        return;

            string message = "";
                if (MovesTextBox.BackColor != System.Drawing.SystemColors.ControlLight)
                    message = "Plansza oczyszczona!\nRozwiązanie było pokazane\nSeed: " + Seed;
                else
                    message = "Plansza oczyszczona!\nUkończono w " + Moves + " ruchach\nSeed: " + Seed;
                string caption = "Wygrałeś iPada!";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, caption, buttons);
            Clear();
        }

        private void ShuffleMethod(object sender, EventArgs e) //"Tasuje" mape
        {
            PrepareVariables();
            Clear();
            Random taser = new Random();
            for (int i = 0; i < SquareXY[0] * SquareXY[1]; i++)
            {
                int X = taser.Next(0, SquareXY[0]);
                int Y = taser.Next(0, SquareXY[1]);
                baseChangeColor(X, Y);
            }
            Extract();
        }

        private void ShowSolutionBox_CheckedChanged(object sender, EventArgs e) //włącza i wyłącza pokazywanie rozwiązania 
        {

            if (ShowSolutionBox.Checked == true)
            {
                if (MovesTextBox.BackColor == System.Drawing.SystemColors.ControlLight && !CreateSeedMode.Checked)
                {
                    DialogResult dialogResult = MessageBox.Show("Pokazanie rozwiązanie wyłącza liczenie ruchów!\nTa funkcja włączy się po restarcie mapy lub stworzeniu nowej.\nContinue?", "Stay DETERMINED!", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                        ShowSolutionBox.Checked = false;
                        return;
                    }
                    MovesTextBox.BackColor = System.Drawing.Color.Firebrick;
                    Moves = 0;
                    MovesTextBox.Text = "" + Moves;
                }
                SolutionSwitch = true;
            }
            else
                SolutionSwitch = false;

            for (int a = 0; a < SquareXY[0]; a++)
                for (int b = 0; b < SquareXY[1]; b++)
                    if (Solution[a, b])
                        if (SolutionSwitch)
                            ButtonSquare[a, b].FlatAppearance.BorderSize = 3;
                        else
                            ButtonSquare[a, b].FlatAppearance.BorderSize = 0;

        }

        private void ResetMap(object sender, EventArgs e)
        {
            PrepareVariables();
            Clear();
            UseSeedMethod();
        }

        private void CopySeed_Click(object sender, EventArgs e) //kopiuje seed do schowka
        {
            Clipboard.SetText(SeedBox.Text);
        }

        private void CreateSeedMode_CheckedChanged(object sender, EventArgs e) //Po każdym kliknięciu odczytany jest nowo powstały Seed
        {
            if (CreateSeedMode.Checked == true)
            {
                DialogResult dialogResult = MessageBox.Show("Seed będzie teraz odczytywany na bieżąco\nWyzerować mapę?", "Uwaga!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Clear();
                    Moves = 0;
                    MovesTextBox.Text = "" + Moves;
                    Extract();
                }
                else
                    Extract();

                MovesTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            }
        }

        private void NewMapOptions(object sender, EventArgs e) //otwiera Config Menu
        {
            if (Config == null)
            {
                this.Config = new ConfigMenu(this, true);
                this.Config.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            }
            else
            {
                this.Config.Activate();
            }
        }

        private void baseChangeColor(int x, int y)
        {
            Solution[x, y] = !Solution[x, y];
            changeColor(x, y);
            if (x > 0 && x < SquareXY[0] - 1)
            {
                changeColor(x - 1, y);
                changeColor(x + 1, y);
            }
            else if (x == 0)
            {
                changeColor(x + 1, y);
            }
            else
            {
                changeColor(x - 1, y);
            }

            if (y > 0 && y < SquareXY[1] - 1)
            {
                changeColor(x, y - 1);
                changeColor(x, y + 1);
            }
            else if (y == 0)
            {
                changeColor(x, y + 1);
            }
            else
            {
                changeColor(x, y - 1);
            }
            if (SolutionSwitch)
            {
                if (ButtonSquare[x, y].FlatAppearance.BorderSize == 0)
                    ButtonSquare[x, y].FlatAppearance.BorderSize = 3;
                else
                    ButtonSquare[x, y].FlatAppearance.BorderSize = 0;
            }
        }

        private void changeColor(int x, int y)
        {
            if (ButtonSquare[x, y].BackColor == System.Drawing.Color.Indigo)
                ButtonSquare[x, y].BackColor = System.Drawing.SystemColors.ControlLightLight;
            else ButtonSquare[x, y].BackColor = System.Drawing.Color.Indigo;
        }

        private void Clear()
        {
            for (int a = 0; a < SquareXY[0]; a++)
                for (int b = 0; b < SquareXY[1]; b++)
                {
                    if (Solution[a, b])
                        baseChangeColor(a, b);
                    Solution[a, b] = false;
                }
        }

        private void PrepareVariables() // czyści niektóre zmienne przed zmianą mapy
        {
            CreateSeedMode.Checked = false;
            MovesTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            Moves = 0;
            MovesTextBox.Text = "" + Moves;
            ShowSolutionBox.Checked = false;
            SolutionSwitch = false;
        }

        private void Extract() //wyciąga Seed z mapy
        {
            Seed = "";
            for (int b = 0; b < SquareXY[1]; b++)
            {
                for (int a = 0; a < SquareXY[0]; a++)
                    if (Solution[a, b])
                        Seed += a + ".";
                Seed += "n.";
            }
            Seed += "D." + SquareXY[0] + "x" + SquareXY[1];

            this.SeedBox.Text = Seed;
        }

        private void UseSeedMethod()
        {
            string[] Coordinates = SeedBox.Text.Split('.');
            int b = 0;

            for (int i = 0; Coordinates[i] != "D"; i++)
            {
                if (Coordinates[i] == "n")
                {
                    b++;
                }
                else
                    baseChangeColor(int.Parse(Coordinates[i]), b);
            }
        }

        public int[] WhatDimensionIsIt(string Seed) //Sprawdza rozmiary mapy zapisane w Seed
        {
            int[] XY = new int[2];
            string Dimension = "";
            int k;
            for (k = 0; k < Seed.Length; k++)
                if (Seed[k] == 'D')
                    break;

            for (k += 2; Seed[k] != 'x'; k++)
                Dimension += Seed[k]; 

            XY[0] = Int32.Parse(Dimension);
            Dimension = "";

            for (k = k + 1; k < Seed.Length; k++)
                    Dimension += Seed[k];

            XY[1] = Int32.Parse(Dimension);
            return XY;
        }

        private void ConfigSticker(object sender, EventArgs e) //przylepia okienko Config menu, do głonego okna gry przy jego przesuwania 
        {
            if (this.Config != null) this.Config.Location = new Point(this.Location.X + this.Width, this.Location.Y);
        }

    }

}
