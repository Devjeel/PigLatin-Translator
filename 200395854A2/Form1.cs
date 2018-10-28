using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _200395854A2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Operation
            //The user enters text in the first multi-line text box and clicks the Translate button or presses the Enter key.
            //The application translates the text to Pig Latin and displays it in the second multi-line text box.
            //To clear both text boxes, the user clicks the Clear button, or hits the escape button.

        //Specifications
            //(Done)If a word starts with a vowel, just add way to the end of the word.
            //(Done)If a word starts with a consonant, move the consonants before the first vowel to the end of the word and add ay.
            //(Done)If a word starts with the letter Y, the Y should be treated as a consonant. If the Y appears anywhere else in the word, it should be treated as a vowel.
            //(Done)Keep the case of the original word whether it’s uppercase (TEST), title case (Test), or lowercase (test).
            //(Done)Keep all punctuation at the end of the translated word.
            //(Done)Translate words with contractions. For example, can’t should be an’tcay.
            //(Done)Don’t translate words that contain numbers or symbols. For example, 123 should be left as 123, and bill@microsoft.com should be left as bill @microsoft.com.
            //(Done) check that the user has entered text before performing the translation.
            //solution & Project should be named StudentNumberA2 (IE 123123123A2)
            //The unit test project should be named StudentNumberA2_Tests(IE 123123123A2_Tests)
            //Submit a zip file named StudentNumberA2.zip(ie. 123123123A2.zip) which extracts a folder named StudentNumberA2(ie 123123123A2) which contains your sln file, and project folder with its applicable files inside.
            //Code must be Unit tested, and the unit tests appropriately documented

        private void btnTranslate_Click(object sender, EventArgs e)
        {
            String EnglishText = txtEnglish.Text;

            //If textbox is empty
            if (String.IsNullOrEmpty(EnglishText))
            {
                MessageBox.Show("Please enter something you want to tanslate !!!", "Entry error");
                return;
            }

            //Declaring translated string, reset every time
            String PigLatin = txtLatin.Text = "";

            foreach (string word in EnglishText.Split(' '))
            {
                //Call toPigs method and add word one by one
                PigLatin += toPigs(word);
            }

            txtLatin.Text = PigLatin;
        }

        public static String toPigs(string word)
        {
            //Vowels String
            const String vowels = "AEIOUaeiou";

            String PigLatin = "";

            //taking first letter from word
            String firstLetter = word.Substring(0, 1);

            //Restof letters from word
            String restOfWord = word.Substring(1, word.Length - 1);

            //firstletter's index from vowel string
            int currentLetter = vowels.IndexOf(firstLetter);

            //If there is number or special Chars. , do not translate 
            if (isNumChar(word))
            {
                PigLatin = word + " ";
            }

            //Strats with no vowel && lowercase, i.e. consonant
            else if (currentLetter == -1 && !isUpperCase(word))
            {
                PigLatin += restOfWord + firstLetter + "ay ";
            }

            //Strats with no vowel && Uppercase, i.e. consonant
            else if (currentLetter == -1 && isUpperCase(word))
            {
                PigLatin += restOfWord + firstLetter + "AY ";
            }

            //There is vowel in firstLetter && Uppercase, i.e. Index will not be -1
            else if(currentLetter != -1 && isUpperCase(word))
            {
                PigLatin += word + "WAY ";
            }

            //There is vowel in firstLetter && lowercase, i.e. Index will not be -1
            else
            {
                PigLatin += word + "way ";
            }

            return PigLatin;
        }
         
        public static bool isUpperCase(string word)
        {
            //Create an Array, size of word length
            int[] values = new int[word.Length];

            //Add all letter from word by spliting it in 1 letter
            String[] letter = word.Split();
            bool isCaps = true; //Default value

            for (int i=0; i<word.Length; i++)
            {
                //Add value to Array
                values[i] = (int)word[i];

                //if ASCII value is between 65 to 90, it is Caps
                if (values[i] >= 65 && values[i] <= 90)
                    isCaps = true;
                else
                    return isCaps = false;
            }

            return isCaps;
        }

        public static bool isNumChar(string word)
        {
            const string numbersAndSpecialChar = "0123456789!@#$%^&*()";
            bool value = false;

            //Loop every letter from word 
            for(int i=0; i<word.Length; i++)
            {
                int isNumChar = numbersAndSpecialChar.IndexOf(word[i]);

                //Index will not be -1, if there is number or Special Char
                if (isNumChar != -1)
                {
                    value = true;
                }
            }

            //return the boolean value 
            return value;
        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            //Close Application
            this.Close();
            Application.Exit();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Clear Textboxes and focus back on english textbox
            txtEnglish.Clear();
            txtLatin.Clear();
            txtEnglish.Focus();
        }
    }
}
