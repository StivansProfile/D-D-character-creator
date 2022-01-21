using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace Section_1_Character_Creation
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            ShowCharacters();
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

        // object to hold public data and methods, so we can use them across
        // all other functions
        public class PublicData
        {
            public int numberOfFiles;
            public List<string> characterRace = new List<string>();
            public List<int> characterStrenght = new List<int>();
            public List<int> characterCharisma = new List<int>();

            public List<int> characterConst = new List<int>();
            public List<int> characterDarkVision = new List<int>();
            public List<int> characterDexterity = new List<int>();

            public List<int> characterIntelligence = new List<int>();
            public List<string> characterClass = new List<string>();
            public List<int> characterD = new List<int>();

            public List<string> characterSavingThrows = new List<string>();
            public List<string> characterSkills = new List<string>();
            public List<int> characterLevel = new List<int>();

            public List<int> characterProficiency= new List<int>();
            public List<int> characterHP = new List<int>();
            public List<string> characterName = new List<string>();

            //This methods checks how many character files we have in a folder,
            //so we can use it to generate all character data
            public void getNumberOfFiles()
            {
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"\\svr-kn-file01\homedrives$\WS330893\Desktop\DD\D-D-Character-Program-master\Section 1 Character Creation\savedCharacters");
                numberOfFiles = dir.GetFiles().Length;
                //MessageBox.Show($"{numberOfFiles}");
            }

            //This method will allow us to read the json data from the files in the folder
            public void SerializeData()
            {
                // getting all txt files
                string[] files = Directory.GetFiles(@"\\svr-kn-file01\homedrives$\WS330893\Desktop\DD\D-D-Character-Program-master\Section 1 Character Creation\savedCharacters", "*.txt");

                //iterating through each file and deserializing it
                foreach (string file in files)
                {
                    string jsonString = File.ReadAllText(file);
                    CharacterData character = JsonSerializer.Deserialize<CharacterData>(jsonString);

                    //appending all the data to lists, so we can later display it
                    characterRace.Add(character.race);
                    characterStrenght.Add(character.strengthLevel);
                    characterCharisma.Add(character.charismaLevel);
                    characterConst.Add(character.constitutionLevel);
                    characterDarkVision.Add(character.darkvisionTraitLevel);
                    characterDexterity.Add(character.dexterityLevel);
                    characterIntelligence.Add(character.intelligenceLevel);

                    characterClass.Add(character.Class);
                    characterD.Add(character.d);
                    characterSavingThrows.Add(string.Join(",", character.savingThrows));
                    characterSkills.Add(string.Join(",", character.skills));

                    characterLevel.Add(character.level);
                    characterProficiency.Add(character.proficiency);
                    characterHP.Add(character.HP);
                    characterName.Add(character.charName);
                }
            }
        }

        //Function that generates all stored characters and their data
        // in their own panels
        void ShowCharacters()
        {
            // initalizing the public data object
            var publicData = new PublicData();
            publicData.getNumberOfFiles();
            publicData.SerializeData();
            int numberOfFiles = publicData.numberOfFiles;

            // generating as many panels as the number of text files in the characters
            // directory, so each character has its own panel
            for (int i = 0; i < numberOfFiles; i++)
            {
                //creating panel and label object
                Panel panel1 = new Panel();
                Label label1 = new Label();

                //initializing the panel and its props
                panel1.Location = new Point(190, 72 + i * 550);
                panel1.BackColor = Color.FromArgb(44, 209, 88);
                panel1.Size = new Size(494, 536); 
                this.Controls.Add(panel1);

                //initializing the label and its props
                label1.Location = new Point(0, 0);

                label1.Text = $"Name: {publicData.characterName[i]} \n" +
                $"Race: {publicData.characterRace[i]}\n" +
                $"Strenght: {publicData.characterStrenght[i]}\n" +
                $"Charisma: {publicData.characterCharisma[i]}\n" +
                $"Constitution: {publicData.characterConst[i]}\n" +
                $"Darkvision Trait: {publicData.characterDarkVision[i]}\n" +
                $"Dexterity: {publicData.characterDexterity[i]}\n" +
                $"Intelligence: {publicData.characterIntelligence[i]}\n" +
                $"\n" +
                $"Class: {publicData.characterClass[i]}\n" +
                $"D value: {publicData.characterD[i]}\n" +
                $"Saving Throws: {publicData.characterSavingThrows[i]}\n" +
                $"Skills: {publicData.characterSkills[i]}\n" +
                $"\n" +
                $"Level: {publicData.characterLevel[i]}\n" +
                $"Proficiency: {publicData.characterProficiency[i]}\n" +
                $"HP: {publicData.characterHP[i]}";
                
                label1.Size = new Size(490, 470);
                label1.ForeColor = Color.FromArgb(28, 33, 29);
                label1.Font = new Font("Halvetica", 15);
                panel1.Controls.Add(label1);
            }
        }
    }
}
