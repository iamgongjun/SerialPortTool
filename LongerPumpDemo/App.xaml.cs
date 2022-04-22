using System.Windows;

namespace SerialPortTool
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, 
            System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.GetType()+"\n"+e.Exception.Message + "\n" + e.Exception.StackTrace + "\n" + e.Exception.Source + "\n"+
                e.Exception.TargetSite+"\n");
        }
    }
}
