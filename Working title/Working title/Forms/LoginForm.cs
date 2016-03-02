using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Working_title.Forms
{
    class LoginForm 
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
            label1.Text = ("Name: ");
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            Label label2 = new Label();
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(210, 180);
            label2.Size = new System.Drawing.Size(120, 18);
            label2.Text = ("Password: ");
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            input.Controls.Add(textBox1);
            input.Controls.Add(textBox2);

            Button logIn = new Button() { Text = "Log in", Left = 480, Width = 70, Top = 220, DialogResult = DialogResult.OK };
            Button register = new Button() { Text = "Register", Left = 350, Width = 70, Top = 220, DialogResult = DialogResult.OK };
            LoginDBManager loginDBManager = new LoginDBManager();

            input.Controls.Add(logIn);
            input.Controls.Add(register);
            input.Controls.Add(label1);
            input.Controls.Add(label2);


            logIn.Click += (sender, e) =>
            {

                string checkingName = textBox1.Text;
                string checkingPassword = textBox2.Text;

                loginDBManager.Login(checkingName, checkingPassword);

            };

            register.Click += (sender, e) =>
            {
                MessageBox.Show("Moving to registration page!");
                Game1.CurrentGameState = GameState.Register;
                input.Close();


            };
            return input.ShowDialog() == DialogResult.OK ? textBox1.Text : "";
        }
    }
}

