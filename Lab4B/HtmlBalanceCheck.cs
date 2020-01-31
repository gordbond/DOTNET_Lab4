/// <summary>
/// Gord Bond - 000786196
/// Nov. 12, 2019
/// I, Gord Bond, 000786196 certify that this material is my original work. No other person's work 
/// has been used without due acknowledgement.
/// 
/// HtmlBalanceCheck controls the event listeners for this windows from app. 
/// Allows the user to load an html document and check whether the tags are 
/// balanced or not.
/// </summary>


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4B
{

    public partial class HtmlBalanceCheck : Form
    {
        /// <summary>
        /// Absolute path for the file being loaded
        /// </summary>
        String fullFileName;
        /// <summary>
        /// short file name for display in the app
        /// </summary>
        String shortFileName;
        /// <summary>
        /// List<> of HtmlTag Objects to be displayed in textbox
        /// </summary>
        List<HtmlTag> tags = new List<HtmlTag>();
        public HtmlBalanceCheck()
        {
            InitializeComponent();
            
        }
        

        /// <summary>
        /// Load option in the File menu. 
        /// Used to filter only html files and select one to be used for this app
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Hold split up file name
            String[] fullFileNameArray;

            //Sets checkTagTextBox back to no text
            checkTagTextBox.Text = "";
            //Sets parameters for open file dialog
            OpenFileDialog loadFile = new OpenFileDialog()
            {
                Filter = "HTML files (*.html)|*.html",
                Title = "Open HTML file"
            };

            //Launches Dialog box
            loadFile.ShowDialog();

            //Retrieves the file name from the Open File Dialog 
            fullFileName = loadFile.FileName;
            shortFileName = fullFileName;

            //Checks if it is an absolute path and breaks the 
            //path down to a more readable file name to be displayed
            //stores short file name to shortFileName
            if (fullFileName.Contains('\\'))
            {

                fullFileNameArray = fullFileName.Split('\\');
                shortFileName = fullFileNameArray[fullFileNameArray.Length - 1];
            }


            //Checks to see if a file has been loaded and displays
            //appropriate message
            if (fullFileName == "" || fullFileName == null)
            {
                statusLabel.Text = $"No File Loaded";
                checkTagsCtrlCToolStripMenuItem.Enabled = false;
            }else
            {
                statusLabel.Text = $"Loaded: {shortFileName}";
                checkTagsCtrlCToolStripMenuItem.Enabled = true;
            }
        }


        /// <summary>
        /// Read - reads the file name passed to it as an argument
        /// and pulls out all the html tags without any braces attached
        /// </summary>
        /// <param name="fullFileName">File to read</param>
        /// <returns>List of HtmlTag </returns>
        private static List<HtmlTag> Read(string fullFileName)
        {
            try
            {
                //create a new streamreader which is used to read the file from the parameters 
                StreamReader reader = new StreamReader(fullFileName);
                
                String htmlCode = "";
                //create a new List of HtmlTag objects 
                List<HtmlTag> tags = new List<HtmlTag>();

                while (!reader.EndOfStream)
                {
                    //holds string of current line
                    string line = reader.ReadLine();
                    //trims any white space
                    line = line.Trim();

                    //Retrieves the tag name and removes all extra information
                    //Pushes the tag to the list of HtmlTag objects

                    if (line.Contains("<"))
                    {
                        string[] lineOfHtml = line.Split('<');
                        foreach (string s in lineOfHtml)
                        {
                            if (s.Contains(">"))
                            {
                                String tempTag;
                                String[] tagInfo = s.Split(' ');
                                tempTag = tagInfo[0];
                                if (tempTag.Contains(">"))
                                {
                                    htmlCode += tempTag.Substring(0, s.IndexOf(">"));
                                    tags.Add(new HtmlTag(tempTag.Substring(0, s.IndexOf(">"))));
                                }
                                else
                                {
                                    htmlCode += tempTag;
                                    tags.Add(new HtmlTag(tempTag));
                                }
                            }
                        }
                    }

                }
                return tags;
            }
            //catch exceptions where file is not found
            catch (FileNotFoundException ex)
            {
                Console.Write($"File not found {fullFileName}");
                Console.ReadLine();
                return null;
            }
            //catches general exceptions
            catch (Exception ex)
            {//catches general exceptions
                Console.WriteLine($"Error Reading Data{ex.Message}");
                Console.ReadLine();
                return null;
            }
        }

        /// <summary>
        /// Writes all the tags along with whether it is an 
        /// open/close/non-container tag
        /// Also calls BalanaceTags CheckForBalance to determine if 
        /// the file has a balanced number of HTML tags
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckTagsCtrlCToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
            //Resets the text in checkTagTextBox to none
            checkTagTextBox.Text = "";
            //Retrieves the List of HtmlTag objects from whichever file was read
            tags = Read(fullFileName);

            //Displays the tags and associated info to checkTagTextBox
            foreach (HtmlTag tag in tags)
                {
                    checkTagTextBox.AppendText(tag.ToString() + "\r\n");
                }

            //Checks for balanced tags
            if (BalanceTags.CheckForBalance(tags))
                    statusLabel.Text = $"{shortFileName} has balanced tags";
                else
                    statusLabel.Text = $"{shortFileName} does not have balanced tags";
            //disables the checkTags menu item
            checkTagsCtrlCToolStripMenuItem.Enabled = false;

        }

        /// <summary>
        /// Closes the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Before closing dialog box asks if user really wants to exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            DialogResult result = MessageBox.Show("Exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                e.Cancel = false;
        }
    }
}
