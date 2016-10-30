using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MiniTextEditor
{
    public partial class MiniTextEditor : Form
    {
        bool bolSaved;

        public MiniTextEditor()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle; // This stops the user from resizing the box.
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog(); // Creates method called 'fileDialog' which opens up the file explorer when called.
            fileDialog.ShowDialog(); // Opens the file dialog.            

            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK && fileDialog.FileName.Contains(".txt")) // Makes sure that everything is ok, as well as the filename contains .txt so can be used within the editor.
            {
                string openFile = File.ReadAllText(fileDialog.FileName); // This reads in all text from the selected file.
                rtxAll.Text = openFile;
            }

            else
            {
                MessageBox.Show(""); // If something goes wrong, the messagebox will appear.
            }
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowDialog(); //Shows the font dialog.
            if (fontDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                rtxAll.Font = fontDialog.Font; // Sets the font of the text box to what's selected in font dialog.
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                DefaultExt = ".txt",
                Filter = "Text Files|*.txt|XML Files|*.xml"
            };

            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, rtxAll.Text); //Write all text in the texbox into the file.
                bolSaved = true;
            }
        }

        private void tmrAutoShadow_Tick(object sender, EventArgs e)
        {
            if (bolSaved == true)
            {
                // This is where I'll start implementing the autosaving.
            }

            else
            {
                
            }
        }
    }
}
