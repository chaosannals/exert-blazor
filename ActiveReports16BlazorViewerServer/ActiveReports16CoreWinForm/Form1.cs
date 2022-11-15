using GrapeCity.ActiveReports.Viewer.Win;

namespace ActiveReports16CoreWinForm;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        Viewer viewer = new Viewer();
        viewer.Dock = DockStyle.Fill;
        viewer.LoadDocument(Application.StartupPath + "Reports/DemoReport.rdlx");
        Controls.Add(viewer);
        
    }
}
