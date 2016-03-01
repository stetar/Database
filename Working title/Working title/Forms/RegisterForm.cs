using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Working_title.Forms
{
    class RegisterForm
    {

        public static string ShowDialog()
        {
            Form input = new Form()
            {
                Width = 800,
                Height = 600,
                StartPosition = FormStartPosition.Manual,
                Location = new System.Drawing.Point(100, 100),
                BackgroundImage = Image.FromFile(@"Content/loginBg.jpg")
            };

            TextBox textBox1 = new TextBox() { Left = 350, Top = 150, Width = 200 };
            TextBox textBox2 = new TextBox() { Left = 350, Top = 180, Width = 200 };

            Label label1 = new Label();
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(210, 150);
            label1.Size = new System.Drawing.Size(120, 18);
            label1.Text = ("Wished Name: ");
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            Label label2 = new Label();
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(210, 180);
            label2.Size = new System.Drawing.Size(120, 18);
            label2.Text = ("Wished Password: ");
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            input.Controls.Add(textBox1);
            input.Controls.Add(textBox2);

            Button okCheck = new Button() { Text = "Check if OK", Left = 400, Width = 100, Top = 300, DialogResult = DialogResult.OK };
            LoginDBManager loginDBManager = new LoginDBManager();

            input.Controls.Add(okCheck);
            input.Controls.Add(label1);
            input.Controls.Add(label2);


        okCheck.Click += (sender, e) =>
            {

                string checkingWishedName = textBox1.Text;
                string checkingWishedPassword = textBox2.Text;

                loginDBManager.Register(checkingWishedName, checkingWishedPassword);

            };
            return input.ShowDialog() == DialogResult.OK ? textBox1.Text : ""; 
        }
    }
}
