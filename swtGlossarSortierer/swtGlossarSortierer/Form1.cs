namespace swtGlossarSortierer
{
    public partial class Form1 : Form
    {
        bool start;
        public Form1()
        {
            start = true;
            InitializeComponent();
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            EntryCompare comp = new EntryCompare();
            String input = richTextBox1.Text;
            string[] lines = input.Split("\n");
            List<string> output = new List<string>();
            bool b = false;
            List<string> temp = new List<string>();
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("GEntry"))
                {
                    b = true;
                    temp.Add(lines[i]);
                }
                else
                {
                    if (b)
                    {
                        b = false;
                        temp.Sort(comp);
                        foreach (string line in temp)
                        {
                            output.Add(line);
                        }
                        temp.Clear();
                    }
                    output.Add(lines[i]);
                }
                if (i == lines.Length - 1)
                {
                    b = false;
                    temp.Sort(comp);
                    foreach (string line in temp)
                    {
                        output.Add(line);
                    }
                    temp.Clear();
                }

            }
            string outputString = "";
            foreach (string line in output)
            {
                outputString += line + "\n";
            }
            richTextBox1.Text = outputString;
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.Text);
        }

        private void richTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                Clipboard.SetText(richTextBox1.Text);
            }
            if(e.Button == MouseButtons.Left && start)
            {
                start = false;
                richTextBox1.Text = "";
            }
        }
    }
}