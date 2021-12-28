//https://ru.stackoverflow.com/questions/589585/%D0%9D%D0%B0%D0%B1%D0%BB%D1%8E%D0%B4%D0%B5%D0%BD%D0%B8%D0%B5-%D0%B7%D0%B0-%D0%B1%D1%83%D1%84%D0%B5%D1%80%D0%BE%D0%BC-%D0%BE%D0%B1%D0%BC%D0%B5%D0%BD%D0%B0
using System.Text.Json;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ExamusClipper
{
    public partial class Form1 : Form
    {
        public static string JSON = "";
        public static string fileMap = "";
        static Dictionary<string, string> mydictionary = new Dictionary<string, string>();
        string OldAnswer = "";
        bool isFirstStart = true;
        //Перехват буфера
        [DllImport("User32.dll")]
        protected static extern int
               SetClipboardViewer(int hWndNewViewer);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool
               ChangeClipboardChain(IntPtr hWndRemove,
                                    IntPtr hWndNewNext);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hwnd, int wMsg,
                                             IntPtr wParam,
                                             IntPtr lParam);
        //Перемещение окна
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        IntPtr nextClipboardViewer;

        public Form1()
        {
            InitializeComponent();
            nextClipboardViewer = (IntPtr)SetClipboardViewer((int)
            this.Handle);

            this.ShowInTaskbar = true;

            openFileDialog1.Filter = "Answer(*.json)|*.json|All files(*.*)|*.*";
            firstOpenFile();
            //readJSON();
        }
        private void firstOpenFile()
        {
            BufCheck.Checked = (bool)Properties.Settings.Default["isBuffer"];
            NotifyCheck.Checked = (bool)Properties.Settings.Default["isNotify"];
            if (Properties.Settings.Default["fileMap"].ToString() == "")
            {
                MessageBox.Show("Выберите файл с ответами");
                return;
            }
            try
            {
                JSON = System.IO.File.ReadAllText(Properties.Settings.Default["fileMap"].ToString());
            }
            catch
            {
                MessageBox.Show("Файл битый");
            }
            //JSON = File.ReadAllText("Resources\\TOKB.json");
            mydictionary = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(JSON);
            if (mydictionary == null)
            {
                MessageBox.Show("Файл битый");
                //this.ShowInTaskbar = true;
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                MessageBox.Show("Открыт предыдущий файл");
                //this.ShowInTaskbar = false;
                this.WindowState = FormWindowState.Minimized;
            }
        }

        protected override void WndProc(ref Message m)

        {

            const int WM_DRAWCLIPBOARD = 0x308;
            const int WM_CHANGECBCHAIN = 0x030D;

            switch (m.Msg)
            {
                case WM_DRAWCLIPBOARD:
                    DisplayClipboardData();
                    SendMessage(nextClipboardViewer, m.Msg, m.WParam,
                                  m.LParam);
                    break;

                case WM_CHANGECBCHAIN:
                    if (m.WParam == nextClipboardViewer)
                        nextClipboardViewer = m.LParam;
                    else
                        SendMessage(nextClipboardViewer, m.Msg, m.WParam,
                                         m.LParam);
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        private void DisplayClipboardData()
        {
            string clip = Clipboard.GetText();
            if (clip == null || clip.ToString() == "") return;
            if (clip == OldAnswer) return;

            if (mydictionary.FirstOrDefault(x => x.Key.Contains(clip)).Value != "")
            {
                OldAnswer = mydictionary.FirstOrDefault(x => x.Key.Contains(clip)).Value;
                if (OldAnswer != null && (bool)Properties.Settings.Default["isBuffer"])
                    Clipboard.SetText(OldAnswer);
                if (OldAnswer != null && (bool)Properties.Settings.Default["isNotify"])
                    MessageBox.Show(OldAnswer);
                else
                {
                    if (isFirstStart)
                    {
                        MessageBox.Show("By NNCompany");
                        isFirstStart = false;
                    }
                    else
                        MessageBox.Show("НЕ НАЙДЕНО");
                }
            }
            else
            {
                //Выводим сообщение о том, что в буфере обмена нет текста
                //MessageBox.Show(this, "В буфере обмена нет текста", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Clipboard.SetText("Ошибка", TextDataFormat.UnicodeText);
            }
        }
        //Перемещение окна используя путую область
        private void Form1_MouseDown(object sender,
        System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void NotifyCheck_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["isNotify"] = (sender as CheckBox).Checked;
            Properties.Settings.Default.Save();
        }
        private void BufCheck_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["isBuffer"] = (sender as CheckBox).Checked;
            Properties.Settings.Default.Save();
        }

        private void icocheck_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["isIcon"] = (sender as CheckBox).Checked;
            Properties.Settings.Default.Save();
        }

        private void file_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;

            JSON = System.IO.File.ReadAllText(filename);
            //JSON = File.ReadAllText("Resources\\TOKB.json");
            mydictionary = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(JSON);
            if (mydictionary == null)
            {
                MessageBox.Show("Файл битый");
            }
            else
            {
                MessageBox.Show("Файл открыт");
                //this.ShowInTaskbar = false;
                this.WindowState = FormWindowState.Minimized;
                if ((bool)Properties.Settings.Default["isIcon"])
                    this.Icon = Icon.ExtractAssociatedIcon(@"C:\Users\shish\source\repos\ExamusClipper\ExamusClipper\Resources\shadow.ico");
                Properties.Settings.Default["fileMap"] = filename;
                Properties.Settings.Default.Save();
            }
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}