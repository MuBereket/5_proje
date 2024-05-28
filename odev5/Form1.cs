namespace odev5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void Switch(Form form1)
        {

            Form f = form1;
            f.TopLevel = false;
            f.AutoScroll = true;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(f);
            f.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Switch(new Home());
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Switch(new user());
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Switch(new Film());
        }
    }
}
