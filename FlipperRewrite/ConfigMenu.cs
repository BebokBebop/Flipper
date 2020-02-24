using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace FlipperRewrite
{
    public partial class ConfigMenu : Form
    {
        private flipper _parent;
        private Dictionary<string, int> MinMax = new Dictionary<string, int>();

        private void ConfigMenuLoad()
        {
            InitializeComponent();
            SetUpDictionary();
        }

        public ConfigMenu(flipper parent)
        {
            _parent = parent;
            ConfigMenuLoad();
            if (File.Exists("flipperConfig"))  readConfigFile();
            //else readBaseConfig();
        }

        private void SetUpDictionary()
        {
            MinMax.Add("SizeXMax", 18);
            MinMax.Add("SizeXMin", 3);
            MinMax.Add("SizeYMax", 18);
            MinMax.Add("SizeYMin", 3);
        }

        private string RemoveWhitespace(string input)
        {
            StringBuilder sb = new StringBuilder(input.Length);
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (c!=' ')
                    sb.Append(c);
            }
            return sb.ToString();
        }

        public ConfigMenu(flipper parent, bool EditMode)
        {
            _parent = parent;
            ConfigMenuLoad();
            this.ControlBox = true;
            readBaseConfig(); 
        }


        private void readBaseConfig()
        {
            SetX.Text = flipper.SizeX.ToString();
            SetY.Text = flipper.SizeY.ToString();
            this.Show();
        }

        private void readConfigFile()
        {
            StreamReader SR = new StreamReader("flipperConfig");
            FieldInfo fieldInfo;
            while (!SR.EndOfStream)
            {
                string variableName = RemoveWhitespace(SR.ReadLine());
                string[] Conf = variableName.Split('=');
                if (Conf.GetLength(0) != 2 || Conf[1] == "") continue;
                try
                {
                    fieldInfo = _parent.GetType().GetField(Conf[0]);
                    var value = fieldInfo.GetValue(_parent);
                    if (value.GetType() == typeof(string))
                    {
                        fieldInfo.SetValue(_parent, Conf[1]);
                    }
                    else if(value.GetType() == typeof(bool))
                    {
                        fieldInfo.SetValue(_parent, bool.Parse(Conf[1]));
                    }
                    else
                    {
                        int isItRightNum = int.Parse(Conf[1]);
                        int MinMaxValue = 0;
                        if (MinMax.TryGetValue(Conf[0]+"Max", out MinMaxValue))
                        {
                            if (isItRightNum > MinMaxValue)
                            {
                                DialogResult Odp = MessageBox.Show(String.Format("Ustawione wartości dla {0} są większe niż dozwolone\nWczytać ustawienia mimo to?", Conf[0]), "FlipperConfig", MessageBoxButtons.YesNo);
                                if (Odp == DialogResult.No) isItRightNum = MinMaxValue;
                            }
                        }
                        if (MinMax.TryGetValue(Conf[0] + "Min", out MinMaxValue))
                        {
                            if (isItRightNum < MinMaxValue)
                            {
                                DialogResult Odp = MessageBox.Show(String.Format("Ustawione wartości dla {0} są mniejsze niż dozwolone\nWczytać ustawienia mimo to?", Conf[0]), "FlipperConfig", MessageBoxButtons.YesNo);
                                if (Odp == DialogResult.No) isItRightNum = MinMaxValue;
                            }
                        }
                        fieldInfo.SetValue(_parent, isItRightNum);
                    }
                }
                catch (Exception Error)
                {
                    if (Error is System.NullReferenceException || Error is System.FormatException)
                    {
                        MessageBox.Show("W pliku FlipperConfig znajdują się błędy");
                        DialogResult repair = MessageBox.Show("Spróbować naprawić plik?", Error.GetType().ToString(), MessageBoxButtons.YesNo);
                        if (repair == DialogResult.Yes)
                        {
                            SR.Close();
                            RunConfigCheck();
                            return;
                        }
                    }
                    else if (Error is Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
                    {
                        //nie udało mi się wywołać tego błędu, ale na wszelki wypadek...
                    }
                    else
                    {
                        SR.Close();
                        MessageBox.Show(String.Format("Unhandled exception: {0}", Error.GetType().ToString()));
                        Environment.Exit(1);
                    }
                }
            }
            SR.Close();
            this.Dispose();
            _parent.RestartMap();
        }

        private void RunConfigCheck()
        {
            String FailLines = "";
            String FailedFile = "";
            using(StreamReader SR = new StreamReader("flipperConfig"))
            {
                int i = 0;
                while(!SR.EndOfStream)
                {
                    string variableName = RemoveWhitespace(SR.ReadLine());
                    string[] Conf = variableName.Split('=');
                    if (Conf.GetLength(0) != 2 || Conf[1] == "")
                    {
                        FailLines += i.ToString() + '-';
                        continue;
                    }
                    try
                    {

                        var IsTypeError = _parent.GetType().GetField(Conf[0]).GetValue(_parent);
                        if (IsTypeError.GetType() == typeof(int))
                            IsTypeError = int.Parse(Conf[1]);
                        else if(IsTypeError.GetType() == typeof(bool))
                            IsTypeError = bool.Parse(Conf[1]);
                    }
                    catch(System.NullReferenceException NullRef)
                    {
                        FailLines += i.ToString() + '-';
                    }
                    catch(System.FormatException TypeError)
                    {
                        FailLines += i.ToString() + '-';
                    }
                    i++;
                    if(FailedFile == "")
                        FailedFile += variableName;
                    else
                        FailedFile += "-" + variableName;
                }
            }
            using (StreamWriter stream = new StreamWriter("flipperConfig"))
            {
                int line = 0;
                string[] Repair = FailLines.Split('-');
                string[] RepairedFile = FailedFile.Split('-');
                for (int i = 0; i < RepairedFile.Length; i++)
                    if (line < Repair.Length - 1 && i == int.Parse(Repair[line])) { line++; continue; }
                    else stream.WriteLine(RepairedFile[i]);
            }
            readConfigFile();
        }

        private void Save_click(object sender, EventArgs e)
        {
            int SizeX = 0;
            int SizeY = 0;
            bool isNumeric;
            string SeedString = Seed.Text;
            StreamWriter file;
            using(file = new StreamWriter("flipperConfig"))
            {
                if (!SeedUse.Checked)
                {
                    if ((isNumeric = int.TryParse(SetX.Text, out SizeX)) && (isNumeric = int.TryParse(SetY.Text, out SizeY)) && ((SizeX > 2 && SizeX <= 18) && (SizeY > 2 && SizeY <= 18)))
                    {
                        file.WriteLine(String.Format("SizeX={0}\nSizeY={1}", SizeX, SizeY));
                        SeedString = "";
                        for (int i = 0; i < SizeY; i++)
                            SeedString += "n.";
                        SeedString += "D." + SizeX + "x" + SizeY;
                        file.WriteLine(String.Format("Seed={0}\n", SeedString));
                    }
                    else { System.Windows.Forms.MessageBox.Show("Proszę wprowadzić liczby z przedziału od 3 do 18"); return; }
                }
                else
                {
                    if (!CheckSeed(SeedString))
                    { System.Windows.Forms.MessageBox.Show("ZŁY SEED #$%^#$"); return; }

                    int[] XY = _parent.WhatDimensionIsIt(SeedString);
                    file.WriteLine(String.Format("SizeX={0}\nSizeY={1}", XY[0], XY[1]));

                    file.WriteLine(String.Format("Seed={0}\n", SeedString));
                }
            }

            readConfigFile();

        }
        public bool CheckSeed(string Seed)
        {
            int temp = 0;
            int temp2 = 0;
            int i,k;
            int Count_n=0;

            if (Seed == "")
                return false;

            for (i = 0; i < Seed.Length; i++)
            {
                if (Seed[i] != 'n' && !char.IsNumber(Seed[i]) && Seed[i] != 'D' && Seed[i] != 'x' && Seed[i] != '.')
                    return false;
            }

            for (i = 0; i < Seed.Length; i++)
            {
                if (Seed[i] == 'D')
                    for (k = i+1; k < Seed.Length; k++)
                        if ((Seed[k] == 'D' || Seed[k] == 'n') && Seed[k] != 'x')
                            return false;
                if (Seed[i] == 'x')
                    for (k = i+1; k < Seed.Length; k++)
                        if (Seed[k] == 'D' || Seed[k] == 'x' || Seed[k] == 'n')
                            return false;
                if (Seed[i] == '.' && Seed[i+1] == '.')
                            return false;
            }

            int[] XY = _parent.WhatDimensionIsIt(Seed);
            string[] Coordinates = Seed.Split('.');

            for (i = 0; Coordinates[i] != "D"; i++)
            {
                if (Coordinates[i] == "n") { Count_n++; }
            
                if (int.TryParse(Coordinates[i], out temp) && temp >= XY[0])
                    return false;
                if (int.TryParse(Coordinates[i], out temp) && int.TryParse(Coordinates[i + 1], out temp2))
                    if (temp >= temp2)
                        return false;
            }
            if (Count_n != XY[1])
                return false;

            return true;
        }
        private void SeedUseCheck_CheckedChanged(object sender, EventArgs e)
        {
            Seed.Enabled = !Seed.Enabled;
            SetX.Enabled = !SetX.Enabled;
            SetY.Enabled = !SetY.Enabled;
        }
    }
}
