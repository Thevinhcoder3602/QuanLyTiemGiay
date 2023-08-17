using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTiemGIay
{
    public partial class SendMail : Form
    {
        private string result;
        private string email; // email cần gửi tin
        private string mK; // mật khẩu đăng nhập phần mềm
        private bool isUpdate;
        public SendMail(string email, string MK, bool isUpdate = false)
        {
            InitializeComponent();
            this.email = email;
            this.mK = MK;
            this.isUpdate = isUpdate;
        }
        public string Result { get => result; set => result = value; }
        
        private void Send()
        {
            // Thay email và password của tài khoản gmail dùng để gửi
            // Cho phép login ứng dụng kém an toàn (nếu tìm không thấy thì dùng mail edu)
            string MailGui = "thevinh1969.vt@gmail.com";
            string MatKhau = "waehyktiowzxpyje";
            // Tạo đối tượng để gửi mail truyền email, pass để login
            BLL_Mail mail = new BLL_Mail(MailGui, MatKhau);
            // Nếu là cập nhật mật khẩu thì true, còn nếu là mật khẩu thì false
            Result = mail.SendMail(email, mK, isUpdate);
            ptbAnhLoad.Invoke(new Action(() => Close()));
        }
        private void SendMail_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(Send);
            thread.IsBackground = true;
            thread.Start();
        }
    }
}
