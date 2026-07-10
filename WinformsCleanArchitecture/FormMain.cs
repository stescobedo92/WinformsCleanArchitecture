namespace WinformsCleanArchitecture
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void brandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formBrand = new FormBrand();
            formBrand.ShowDialog();
        }
    }
}
