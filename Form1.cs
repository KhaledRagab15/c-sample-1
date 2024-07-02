namespace Khaled_Sample_1
{
    public partial class Form1 : Form
    {
        public enum Player
        {
            X, O
        }

        Player currentPlayer;
        Random random = new Random();
        int player_Win_count = 0;
        int cpu_Win_count = 0;
        List<Button> buttons;


        public Form1()
        {
            InitializeComponent();
            restart_Game();
        }


        private void cpu_Move(object sender, EventArgs e)
        {
            if (buttons.Count > 0)
            {
                int index = random.Next(buttons.Count);
                buttons[index].Enabled = false;
                currentPlayer = Player.O;
                buttons[index].Text = currentPlayer.ToString();
                buttons[index].BackColor = Color.Aquamarine;
                buttons.RemoveAt(index);
                check_Game();
                cpuTimer.Stop();
            }
        }

        private void PlayerClickButton(object sender, EventArgs e)
        {
            var button = (Button)sender;
            currentPlayer = Player.X;
            button.Text = currentPlayer.ToString();
            button.Enabled = false;
            button.BackColor = Color.DarkOliveGreen;
            buttons.Remove(button);
            check_Game();
            cpuTimer.Start();
        }

        private void restart_Button(object sender, EventArgs e)
        {
            restart_Game();
        }

        private void check_Game()
        {
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
                || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
                || button7.Text == "X" && button8.Text == "X" && button9.Text == "X"
                || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
                || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
                || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
                || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
                || button3.Text == "X" && button5.Text == "X" && button7.Text == "X")
            {
                cpuTimer.Stop();
                MessageBox.Show("Congrats, You Win!", "Player Wins");
                player_Win_count++;
                label1.Text = "Player Wins: " + player_Win_count;
                restart_Game();
            }

            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
                || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
                || button7.Text == "O" && button8.Text == "O" && button9.Text == "O"
                || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
                || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
                || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
                || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
                || button3.Text == "O" && button5.Text == "O" && button7.Text == "O")
            {
                cpuTimer.Stop();
                MessageBox.Show("Sads You Lost :(", "CPU Wins");
                cpu_Win_count++;
                label2.Text = "CPU Wins: " + cpu_Win_count;
                restart_Game();
            }
        }

        private void restart_Game()
        {
            buttons = new List<Button> {button1, button2, button3, button4, button5,
                button6, button7, button8, button9 };

            foreach (Button x in buttons)
            {
                x.Enabled = true;
                x.Text = ".";
                x.BackColor = DefaultBackColor;
            }
        }
    }
}