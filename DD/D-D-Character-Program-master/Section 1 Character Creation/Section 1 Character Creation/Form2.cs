using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;

namespace Section_1_Character_Creation
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            previewCharacter();
        }

        public class CharacterData
        {
            public string race { get; set; }
            public int strengthLevel { get; set; }
            public int charismaLevel { get; set; }
            public int constitutionLevel { get; set; }
            public int darkvisionTraitLevel { get; set; }
            public int dexterityLevel { get; set; }
            public int intelligenceLevel { get; set; }
            public string Class { get; set; }
            public int d { get; set; }
            public string[] savingThrows { get; set; }
            public string[] skills { get; set; }
            public int level { get; set; }
            public int proficiency { get; set; }
            public int HP { get; set; }
            public string charName { get; set; }
        }

        void previewCharacter()
        {
            // getting all txt files
            string[] files = Directory.GetFiles(@"\\svr-kn-file01\homedrives$\WS330893\Desktop\DD\D-D-Character-Program-master\Section 1 Character Creation\characters", "*.txt");

            // json file and string based on it
            string jsonFile = files[0];
            string jsonString = File.ReadAllText(jsonFile);
            //grab current text file values and store them in memory
            CharacterData character = System.Text.Json.JsonSerializer.Deserialize<CharacterData>(jsonString);

            //creating panel and label object
            Label labelStats = new Label();
            Panel panel1 = new Panel();

            //customizing the panel which will help display the character data
            panel1.Location = new Point(86, 32);
            panel1.BackColor = Color.FromArgb(255, 255, 255);
            panel1.Size = new Size(490, 470);
            //preview.Controls.Add(panel1);

            this.Controls.Add(panel1);

            //initializing the label and its props
            labelStats.Text = $"Name: {character.charName} \n" +
            $"Race: {character.race} \n" +
            $"Strenght: {character.strengthLevel} \n" +
            $"Charisma: {character.charismaLevel} \n" +
            $"Constitution: {character.constitutionLevel} \n" +
            $"Darkvision Trait: {character.darkvisionTraitLevel} \n" +
            $"Dexterity: {character.dexterityLevel} \n" +
            $"Intelligence: {character.intelligenceLevel} \n" +
            $"\n" +
            $"Class: {character.Class} \n" +
            $"D value: {character.d} \n" +
            $"Saving Throws: {string.Join(",", character.savingThrows)} \n" +
            $"Skills: {string.Join(",", character.skills)} \n" +
            $"Level: {character.level} \n" +
            $"Proficiency: {character.proficiency} \n" +
            $"HP: {character.HP}";

            labelStats.Location = new Point(16, 16);
            labelStats.Size = new Size(494, 536);
            labelStats.ForeColor = Color.FromArgb(0, 0, 0);
            labelStats.Font = new Font("Halvetica", 15);
            panel1.Controls.Add(labelStats);
        }
    }
}
