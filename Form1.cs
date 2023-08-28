using Windows.Devices.Enumeration;
using Windows.Devices.WiFiDirect;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Windows.Foundation;
using System.Security.Cryptography;
using Microsoft.VisualBasic.Logging;
using System.Diagnostics;
using System.Xml.Linq;
using System.Runtime.InteropServices;

namespace FeildBalancing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var LoginForm = new Form2();
            LoginForm.LoginHandler += AllowedUseForm;
            LoginForm.ShowDialog();
            Form3._Staff = new Staff();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            server = new Server(8080, 1);
            server.Receive += ReceiveMessage;

            MessageBox.Show("pause");
            server.Receive -= ReceiveMessage;
            server.Close();
        }
        private void ReceiveMessage(string Message)
        {
            if (Message.Contains("Online"))
            {
                var Device = Message.Split(',');
                Log log = new Log(Device[1]);
                switch ((int)log.GetDeviceName())
                {
                    case 0:
                        label_FeildBalancingNo1.InvokeIfRequired(() => { label_FeildBalancingNo1.Text = String.Format("平衡校正機1：上線中"); });
                        label_FeildBalancingNo1.InvokeIfRequired(() => { label_FeildBalancingNo1.ForeColor = Color.Green; });
                        textBox_LogTexts.InvokeIfRequired(() => { textBox_LogTexts.Text += String.Format("[{0}] [INFO]: 平衡校正機 1 上線中\r\n", log.GetDateTime()); });
                        break;
                    default:
                        textBox_LogTexts.InvokeIfRequired(() => { textBox_LogTexts.Text += String.Format("[{0}] [WARN]: 不明裝置 {1} 嘗試連線進物聯網系統中\r\n", log.GetDateTime(), log.DeviceID); });
                        break;
                }
            }
            if (Message.Contains("Login"))
            {
                var User = Message.Split(',');
                string StaffInfo = "";
                List<Staff> staff = new List<Staff>();
                bool isLoginAccessed = false;
                using (FileStream fs = new FileStream("StaffInfo.txt", FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string EncryptStaffInfo = sr.ReadToEnd();
                        StaffInfo = aesDecryptBase64(EncryptStaffInfo, Password);
                    }
                }
                if (String.IsNullOrEmpty(StaffInfo) == false)
                {
                    var NewStaffInfo = StaffInfo.Replace("\r\n", ";");
                    var staffInfo = NewStaffInfo.Split(';');
                    foreach (string staffinfo in staffInfo)
                    {
                        var info = staffinfo.Split(',');
                        List<Object> AllowedMachine = new List<Object>();
                        if (staffinfo.Contains(Machine.FieldBalancing.ToString()))
                            AllowedMachine.Add(Machine.FieldBalancing);
                        if (staffinfo.Contains(Machine.etc.ToString()))
                            AllowedMachine.Add(Machine.etc);
                        Staff _staff = new Staff(info[0], info[1], info[2], info[3], AllowedMachine);
                        staff.Add(_staff);
                    }
                    foreach (Staff _staff in staff)
                    {
                        if (User[2] == _staff.Account && User[3] == _staff.Password)
                        {
                            Log log = new Log(_staff.Name, _staff.Password);
                            log.DeviceID = User[0];
                            foreach (object obj in _staff.AllowedMachine)
                            {
                                switch ((int)log.GetDeviceName())
                                {
                                    case 0 when (int)log.GetDeviceType() == (int)obj:
                                        isLoginAccessed = true;
                                        UserList.Add(log);
                                        switch ((int)log.GetDeviceName())
                                        {
                                            case 0:
                                                textBox_LogTexts.InvokeIfRequired(() => { textBox_LogTexts.Text += String.Format("[{0}] [INFO]: {1} 已登入使用 平行校正機 1\r\n", log.GetDateTime(), log.UserName); });
                                                break;
                                        }
                                        break;
                                }
                            }
                        }
                    }
                }
                if (isLoginAccessed)
                {
                    isLoginAccessed = false;
                    server.Send(User[0], "true");
                }
                else
                {
                    server.Send(User[0], "false");
                    textBox_LogTexts.InvokeIfRequired(() => { textBox_LogTexts.Text += String.Format("[{0}] [WARN]: 有不明的使用者或嘗試使用未授權權限的機台\r\n", DateTime.Now); });
                    Log log = new Log(User[0]);
                    switch ((int)log.GetDeviceName())
                    {
                        case 0:
                            label_FeildBalancingNo1.InvokeIfRequired(() => { label_FeildBalancingNo1.Text = String.Format("平衡校正機1：已離線"); });
                            label_FeildBalancingNo1.InvokeIfRequired(() => { label_FeildBalancingNo1.ForeColor = Color.Black; });
                            break;
                    }
                }
            }
            if (Message.Contains("Offline"))
            {
                var Device = Message.Split(',');
                Log log = new Log(Device[1]);
                foreach (Log _log in UserList)
                {
                    switch ((int)log.GetDeviceName())
                    {
                        case 0 when _log.GetDeviceName() == log.GetDeviceName():
                            textBox_LogTexts.InvokeIfRequired(() => { textBox_LogTexts.Text += String.Format("[{0}] [INFO]: {1} 已登出\r\n", log.GetDateTime(), _log.UserName); });
                            label_FeildBalancingNo1.InvokeIfRequired(() => { label_FeildBalancingNo1.Text = String.Format("平衡校正機1：已離線"); });
                            label_FeildBalancingNo1.InvokeIfRequired(() => { label_FeildBalancingNo1.ForeColor = Color.Black; });
                            textBox_LogTexts.InvokeIfRequired(() => { textBox_LogTexts.Text += String.Format("[{0}] [INFO]: 平衡校正機 1 已離線\r\n", log.GetDateTime()); });
                            log = _log;
                            break;
                    }
                }
                UserList.Remove(log);
                server.Close();
                server = new Server(8080, 1);
                server.Receive += ReceiveMessage;
            }
            if (Message.Contains("Log"))
            {
                var Log = Message.Split(',');
                foreach (Log log in UserList)
                {
                    if (log.DeviceID == Log[1])
                    {
                        textBox_LogTexts.InvokeIfRequired(() => { textBox_LogTexts.Text += String.Format("[{0}] [INFO]: {1} 於 {2} 中{3}\r\n", log.GetDateTime(), log.UserName, log.GetDeviceChName(), aesDecryptBase64(Log[2], log.UserPassword)); });
                    }
                }
            }
        }
        private void AllowedUseForm(object sender, LoginArgs e)
        {
            if (e.isLoginSuccessed)
            {
                tabControl.Visible = true;
                tabControl.Enabled = true;
                Account = e.account;
                Password = e.password;
                server = new Server(8080, 1);
                server.Receive += ReceiveMessage;
            }
        }

        private void button_NewStaff_Click(object sender, EventArgs e)
        {
            var AddStaffForm = new Form3();
            AddStaffForm.ShowDialog();
            if (Administrator.aesEncryptBase64(Account, Password) == Administrator.VerifyKey)
            {
                if (Form3._Staff.isComplete)
                {
                    listBox_StaffList.Items.Add(WriteListBox());
                    WriteFile();
                    Form3._Staff.isComplete = false;
                }
            }
        }
        private void WriteFile()
        {
            File.SetAttributes("StaffInfo.txt", File.GetAttributes("StaffInfo.txt") & ~FileAttributes.ReadOnly);
            using (FileStream fs = new FileStream("StaffInfo.txt", FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    string info = "";
                    for (int i = 0; i < listBox_StaffList.Items.Count; i++)
                    {
                        if (i != listBox_StaffList.Items.Count - 1)
                        {
                            var infoArray = listBox_StaffList.Items[i].ToString().Split('：', '；', '、');
                            info += String.Format("{0},{1},{2},{3},", infoArray[1], infoArray[3], infoArray[5], infoArray[7]);
                            for (int j = 9; j < infoArray.Length; j++)
                            {
                                info += infoArray[j].Replace(" ", "");
                            }
                            info += String.Format("\r\n");
                        }
                        else
                        {
                            var infoArray = listBox_StaffList.Items[i].ToString().Split('：', '；', '、');
                            info += String.Format("{0},{1},{2},{3},", infoArray[1], infoArray[3], infoArray[5], infoArray[7]);
                            for (int j = 9; j < infoArray.Length; j++)
                            {
                                info += infoArray[j].Replace(" ", "");
                            }
                        }
                    }
                    info = Administrator.aesEncryptBase64(info, Password);
                    sw.Write(info);
                }
            }
            File.SetAttributes("StaffInfo.txt", FileAttributes.ReadOnly);
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_StaffList.Items.Clear();
            string StaffInfo = "";
            if (tabControl.SelectedIndex == 1)
            {
                using (FileStream fs = new FileStream("StaffInfo.txt", FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string EncryptStaffInfo = sr.ReadToEnd();
                        StaffInfo = aesDecryptBase64(EncryptStaffInfo, Password);
                    }
                }
            }
            if (String.IsNullOrEmpty(StaffInfo) == false)
            {
                var NewStaffInfo = StaffInfo.Replace("\r\n", ",");
                var staffInfo = NewStaffInfo.Split(',');
                int i = 0; string Info = "";
                foreach (string staffinfo in staffInfo)
                {
                    switch (i)
                    {
                        case 0:
                            Info = String.Format("工作人員：{0}；", staffinfo);
                            break;
                        case 1:
                            Info += String.Format("身分字號：{0}；", staffinfo);
                            break;
                        case 2:
                            Info += String.Format("帳號：{0}；", staffinfo);
                            break;
                        case 3:
                            Info += String.Format("密碼：{0}；", staffinfo);
                            break;
                        case 4:
                            Info += String.Format("機台：");
                            if (staffinfo.Contains(Machine.FieldBalancing.ToString()))
                                Info += String.Format("Field Balancing、");
                            if (staffinfo.Contains(Machine.etc.ToString()))
                                Info += String.Format("etc、");
                            else if (!staffinfo.Contains(Machine.FieldBalancing.ToString()) && !staffinfo.Contains(Machine.etc.ToString()))
                                Info += String.Format("沒有權限、");
                            var info = Info.TrimEnd('、');
                            listBox_StaffList.Items.Add(info);
                            i = -1;
                            break;
                    }
                    i++;
                }
            }
        }
        private static string aesDecryptBase64(string account, string password)
        {
            string decrypt = "";
            try
            {
                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
                byte[] key = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                byte[] iv = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
                aes.Key = key;
                aes.IV = iv;

                byte[] dataByteArray = Convert.FromBase64String(account);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(dataByteArray, 0, dataByteArray.Length);
                        cs.FlushFinalBlock();
                        decrypt = Encoding.UTF8.GetString(ms.ToArray());
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return decrypt;
        }

        private void button_RemoveStaff_Click(object sender, EventArgs e)
        {
            List<Object> remove = new List<Object>();
            foreach (object rem in listBox_StaffList.SelectedItems)
            {
                remove.Add(rem);
            }
            for (int i = 0; i < remove.Count; i++)
            {
                listBox_StaffList.Items.Remove(remove[i]);
            }
            WriteFile();
        }

        private void button_ChangeWorkContent_Click(object sender, EventArgs e)
        {
            if (listBox_StaffList.SelectedItems.Count == 1)
            {
                string info = "";
                var infoArray = listBox_StaffList.SelectedItem.ToString().Split('：', '；', '、');
                for (int j = 9; j < infoArray.Length; j++)
                {
                    info += infoArray[j].Replace(" ", "");
                }
                var EditStaffForm = new Form3(infoArray[1], infoArray[3], infoArray[5], infoArray[7], info);
                EditStaffForm.ShowDialog();
                if (Administrator.aesEncryptBase64(Account, Password) == Administrator.VerifyKey)
                {
                    if (Form3._Staff.isComplete)
                    {
                        listBox_StaffList.Items[listBox_StaffList.SelectedIndex] = WriteListBox();
                        WriteFile();
                        Form3._Staff.isComplete = false;
                    }
                }
            }
            else
                MessageBox.Show("請選擇一個項目");
        }
        private string WriteListBox()
        {
            string Info = String.Format("工作人員：{0}；身分字號：{1}；帳號：{2}；密碼：{3}；機台：", Form3._Staff.Name, Form3._Staff.ID, Form3._Staff.Account, Form3._Staff.Password);
            for (int i = 0; i < Form3._Staff.AllowedMachine.Count; i++)
            {
                switch ((int)Form3._Staff.AllowedMachine[i])
                {
                    case 0:
                        Info += String.Format("Field Balancing、");
                        break;
                    case 1:
                        Info += String.Format("etc、");
                        break;
                }
            }
            if (Form3._Staff.AllowedMachine.Count == 0)
                Info += String.Format("沒有權限、");
            Info = Info.TrimEnd('、');
            return Info;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox_LogTexts.Text) == false)
            {
                var dateTime = DateTime.Now;
                string FileName = String.Format("{0}-{1}-{2} {3}-{4}-{5}.txt", dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second);
                using (FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        string info = "";
                        info = Administrator.aesEncryptBase64(textBox_LogTexts.Text, Password);
                        sw.Write(info);
                    }
                }
                File.SetAttributes(FileName, FileAttributes.ReadOnly);
            }
            try
            {
                server.Receive -= ReceiveMessage;
            }
            catch { }
            if (server != null)
                server.Close();
        }

        private void button_SelectFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (StreamReader sr = new StreamReader(fs))
                        {
                            string EncryptStaffInfo = sr.ReadToEnd();
                            textBox_LogFile.Text = aesDecryptBase64(EncryptStaffInfo, Password);
                        }
                    }
                }
            }
        }
    }

    //設定封包格式。不一定要用struct，這邊選它只是為了讓資料結構更好看
    public class PacketProtocol
    {
        //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types
        public int Length;//4 Bytes
        public byte[] Data;//因為Length使用int型態，所以最大允許的資料數是2,147,483,647
    }
    public class Server
    {
        //使用委派和事件把接收到的資料傳遞出去
        public delegate void DReceive(string Message);
        public event DReceive Receive;

        private Socket server;//建立Server端的開口
        private Socket socket;//一旦有目標連到server的開口，就分配給這個物件
        private Thread threadAccept;//因為程式會在等待連線中停住，所以需要使用Thread等非同步方式去處理
        private Thread threadReceive;
        private bool FLAG_RECEIVE = true;
        private bool isOperating;

        public Server(int port, int allowNumber)
        {
            //InterNetwork: IPv4
            //Stream: 因為TCP是串流方式傳輸，所以這邊要選擇Stream
            //TCP: 建立TCP連線
            try
            {
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                var IP = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress iP in IP.AddressList)
                {
                    if (iP.ToString().Contains("192.168"))
                    {
                        server.Bind(new IPEndPoint(iP, port));//綁定連線參數
                        break;
                    }
                }
                server.Listen(allowNumber);//傳入的參數代表允許多少個目標連入
                threadAccept = new Thread(Accept);
                threadAccept.Start();
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.ToString());
            }
        }

        ~Server()
        {
            Close();
        }

        private void Accept()
        {
            try
            {
                socket = server.Accept();
                server.Close();//若不需要再接收其他連線則可以關掉server這個socket物件
                //準備接收資料
                threadReceive = new Thread(ReceiveMessage);
                threadReceive.Start();
                isOperating = true;
            }
            catch (SocketException se)
            {
                if (isOperating)
                    MessageBox.Show(se.ToString());
            }
        }

        public void Close()
        {
            isOperating = false;
            server.Close();
            if (socket != null)
                socket.Close();
            FLAG_RECEIVE = false;
        }

        public bool IsConnected
        {
            get
            {
                if (socket == null) return false;
                else return socket.Connected;
            }
        }

        private void ReceiveMessage()
        {
            while (FLAG_RECEIVE)
            {
                try
                {
                    if (Receive == null) continue;//只有設定Receive事件後才開始處理接收事件
                    PacketProtocol data = new PacketProtocol();

                    //先接收資料長度資訊
                    byte[] length = new byte[4];//因為int是4bytes大小
                    socket.Receive(length);
                    data.Length = BitConverter.ToInt32(length, 0);

                    //接收數據資料
                    data.Data = new byte[data.Length];
                    socket.Receive(data.Data);

                    //將接收的資料轉為字串後，透過事件發送出去
                    Receive(Encoding.UTF8.GetString(data.Data));
                }
                catch
                {
                    break;
                }
            }
        }
        public void Send(string DeviceID, string message)
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var IP = Dns.GetHostEntry(DeviceID);
            foreach (IPAddress iP in IP.AddressList)
            {
                if (iP.ToString().Contains("192.168") && iP.ToString().Contains("192.168.137") == false)
                {
                    server.Connect(iP, 8080);
                    break;
                }
            }
            //只有連線成功才開始傳遞資料
            if (server.Connected)
            {
                PacketProtocol packet = new PacketProtocol();
                packet.Data = Encoding.UTF8.GetBytes(message);
                packet.Length = packet.Data.Length;
                byte[] data = PacketProtocolToBytes(packet);
                server.Send(data);
            }
        }
        private byte[] PacketProtocolToBytes(PacketProtocol data)
        {
            //將封包資料轉換為Byte陣列
            byte[] bytes;
            using (MemoryStream ms = new MemoryStream())
            {
                using (BinaryWriter bw = new BinaryWriter(ms))
                {
                    //先寫入資料長度，再寫入資料
                    //寫入順序錯誤會導致解析失敗
                    bw.Write(data.Length);
                    bw.Write(data.Data);
                    bytes = ms.ToArray();
                }
            }
            return bytes;
        }
    }
}