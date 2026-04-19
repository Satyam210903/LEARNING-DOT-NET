namespace VMS
{
    public partial class Form1 : Form
    {
        int AdminId;
        public Form1(int AdminId)
        {
            AdminId=this.AdminId;
            InitializeComponent();
            loadView(new Home(AdminId));
        }

        private void hOMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadView(new Home(AdminId));
        }

        private void cHECKINCHECKOUTHISTORYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadView(new Status(AdminId));
        }

        private void sTATUSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lOGOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
           this.Close();
        }
    }
}
