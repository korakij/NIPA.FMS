using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace MNG.UI
{
    public partial class frmLogIn : Form
    {
        public User User { get; set; }
        private List<User> users { get; set; }
        public frmLogIn()
        {
            InitializeComponent();
            Load_Users();
        }
        public User LogOn(string name, string password)
        {
            User userLogOn = users.FindAll(x => x.Name == name).FirstOrDefault();

            if (userLogOn == null)
                return null;
            if (VerifyHashedPassword(userLogOn.Password, password))
            {
                return userLogOn;
            }
            else
            {
                return null;
            }
        }

        void Load_Users()
        {
            users = new List<User>();
            users.Add(new User() { Id = 1, Name = "Ana", Password = HashPassword("1234"), Department = 1, Inactive = true, Position = 1, Register_Date = Convert.ToDateTime("2024/02/13") });
            users.Add(new User() { Id = 2, Name = "Bando", Password = HashPassword("ABCD"), Department = 2, Inactive = true, Position = 1, Register_Date = Convert.ToDateTime("2024/02/02") });
            users.Add(new User() { Id = 3, Name = "Cana", Password = HashPassword("WTN_MT_W"), Department = 3, Inactive = true, Position = 1, Register_Date = Convert.ToDateTime("2024/01/20") });
            users.Add(new User() { Id = 4, Name = "Deep", Password = HashPassword("ABC123"), Department = 4, Inactive = true, Position = 2, Register_Date = Convert.ToDateTime("2023/12/13") });
            users.Add(new User() { Id = 5, Name = "Ethan", Password = HashPassword("Mychin007"), Department = 5, Inactive = true, Position = 3, Register_Date = Convert.ToDateTime("2023/10/20") });
        }

        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }

        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 0x31) || (src[0] != 0))
            {
                return false;
            }
            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }
            return ByteArraysEqual(buffer3, buffer4);
        }

        private static bool ByteArraysEqual(byte[] a, byte[] b)
        {
            if (a == null && b == null)
            {
                return true;
            }
            if (a == null || b == null || a.Length != b.Length)
            {
                return false;
            }
            var areSame = true;
            for (var i = 0; i < a.Length; i++)
            {
                areSame &= (a[i] == b[i]);
            }
            return areSame;
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            var userLogIn = LogOn(tbxName.Text, tbxPassword.Text);
            if (userLogIn != null)
            {
                User = LogOn(tbxName.Text, tbxPassword.Text);
                Close();
            }
            else
            {
                lblText.ForeColor = Color.Red;
                lblText.Text = "User name or Password is wrong.";
            }
        }
    }
}
