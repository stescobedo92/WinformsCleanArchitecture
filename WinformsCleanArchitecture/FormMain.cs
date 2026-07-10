using Microsoft.Extensions.DependencyInjection;

namespace WinformsCleanArchitecture
{
    public partial class FormMain : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public FormMain(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
        }

        private void brandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formBrand = _serviceProvider.GetRequiredService<FormBrand>();
            formBrand.ShowDialog();
        }
    }
}
