//https://ru.stackoverflow.com/questions/589585/%D0%9D%D0%B0%D0%B1%D0%BB%D1%8E%D0%B4%D0%B5%D0%BD%D0%B8%D0%B5-%D0%B7%D0%B0-%D0%B1%D1%83%D1%84%D0%B5%D1%80%D0%BE%D0%BC-%D0%BE%D0%B1%D0%BC%D0%B5%D0%BD%D0%B0
using Newtonsoft.Json;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ExamusClipper
{
    public partial class Form1 : Form
    {
        public static string JSON = "";
        static Dictionary<string, string> mydictionary = new Dictionary<string, string>();
        string OldAnswer = "";
        bool isFirstStart = true;

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

        IntPtr nextClipboardViewer;

        public Form1()
        {
            InitializeComponent();

            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetName().Name + ".Resources.TOKB.json";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                JSON = reader.ReadToEnd();
            }
            //JSON = File.ReadAllText("Resources\\TOKB.json");
            mydictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(JSON);

            nextClipboardViewer = (IntPtr)SetClipboardViewer((int)
            this.Handle);
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
            if (clip == null && clip.ToString() == "") return;
            if (clip == OldAnswer) return;

            if (mydictionary.FirstOrDefault(x => x.Key.Contains(clip)).Value != "")
            {
                //Выводим показываем сообщение с текстом, скопированным из буфера обмена
                //MessageBox.Show(this, someText, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                OldAnswer = mydictionary.FirstOrDefault(x => x.Key.Contains(clip)).Value;
                if (OldAnswer != null)
                    Clipboard.SetText(OldAnswer);
                //label1.Text = OldAnswer;
                if (OldAnswer != null)
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
                Clipboard.SetText("НЕ НАЙДЕНО!)", TextDataFormat.UnicodeText);
            }
        }

    }
}