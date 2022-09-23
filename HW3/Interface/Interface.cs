using System.Net.Http.Headers;
using System.Windows.Forms.Design;

namespace Interface
{
    /// <summary>
    /// The class representing the notepad user interface and it's functionality.
    /// </summary>
    public partial class Interface : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Interface"/> class.
        /// </summary>
        public Interface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When file > open is clicked, the open file dialogue is called. Then, a filestream is opened based on the file chosen.
        /// That stream is used to create a new streamreader object, which can be passed to the loadtext function.
        /// </summary>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var fileName = ofd.FileName;

                var fileStream = ofd.OpenFile();

                TextReader sr = new StreamReader(fileStream);

                this.LoadText(sr);
            }
        }

        /// <summary>
        /// When file > save is clicked, a new dialog is created for the user. After entering the save information, the function saves the file.
        /// </summary>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            StreamWriter sw;
            sfd.InitialDirectory = Application.StartupPath;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                sw = new StreamWriter(sfd.FileName);
            }
        }

        /// <summary>
        ///  Reads all text in TextReader object and adds it to the textbox in the interface.
        /// </summary>
        /// <param name="sr"> Takes a TextReader object. </param>
        private void LoadText(TextReader sr)
        {
            this.interfaceTextBox.AppendText(sr.ReadToEnd());
        }
    }
}