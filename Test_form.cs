using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Office
{
    public partial class Test_form : Form
    {
        // Временный флаг для обозначения какую картинку выводить
        public bool flag = false;
        // Переменная для таймера окончания игры
        private int countdown = 60;
        // Переменная для отсчета ошибок
        private int mistake = 10;

        public Test_form()
        {
            InitializeComponent();
        }

        // метод перезапуска таймера инцидентов
        private void TimesIncident_function()
        {

            Random random = new Random();
            int randTime = random.Next(1000, 3001);

            Time_Incident.Interval = randTime; // 1-3 сек таймер
            Time_Incident.Start();

        }

        // метод запуска таймера игры
        private void gamesOver_timer_function()
        {

            GameOver.Interval = 1000;
            GameOver.Start();

        }

        // метод для таймера ошибок
        private void PrBar_Timer_function()
        {

            PrBar_Timer.Interval = 2000;
            PrBar_Timer.Start();

        }



        // !!LOAD!! не теряй =)
        private void Test_form_Load(object sender, EventArgs e)
        {
            
            gamesOver_timer_function();
            TimesIncident_function();
            
            //label2.Text = mistake.ToString();
            progressBar1.Value = mistake * 10;

        }


        // Когда останавливается таймер выбирается одна из двух картинок
        private void Time_Incident_Tick(object sender, EventArgs e)
        {
            Time_Incident.Stop();

            Random random = new Random();
            int randMan = random.Next(1, 3);
            if (randMan == 1)
            {
                flag = true;
                pictureBox1.Image = Image.FromFile("C:\\Users\\dmitr\\OneDrive\\Рабочий стол\\Office_game\\Office\\image\\lvl_1_1.jpg");
                PrBar_Timer_function();
            }
            else if (randMan == 2)
            {
                flag = false;
                pictureBox1.Image = Image.FromFile("C:\\Users\\dmitr\\OneDrive\\Рабочий стол\\Office_game\\Office\\image\\lvl_1_2.jpg");
                PrBar_Timer_function();
            }
        }

        //Ведется обратный отсчет до конца игры
        private void GameOver_Tick(object sender, EventArgs e)
        {
            if (countdown == 0)
            {
                GameOver.Stop();
                Time_Incident.Stop();
                MessageBox.Show("Вы победили!", "Поздравляю");
                this.Close();
            }
            else if (countdown > 0)
            {
                countdown--;
                label1.Text = countdown.ToString();
                if (mistake < 1)
                {
                    GameOver.Stop();
                    Time_Incident.Stop();
                    PrBar_Timer.Stop();
                    MessageBox.Show("Вы проиграли...", "Конец");
                    this.Close();
                }
            }
        }

        // Тамер ошибок
        private void PrBar_Timer_Tick(object sender, EventArgs e)
        {
            PrBar_Timer.Stop();
            mistake--;
            //label2.Text = mistake.ToString();
            progressBar1.Value = mistake * 10;
            pictureBox1.Image = Image.FromFile("C:\\Users\\dmitr\\OneDrive\\Рабочий стол\\Office_game\\Office\\image\\lvl_1.jpg");
            TimesIncident_function();

        }

        
        // если таймер остановился и картинка 1_1 => меняем картинку на исходную и запускаем таймер по новой
        private void button2_Click(object sender, EventArgs e)
        {
            if (Time_Incident.Enabled == false && flag == true)
            {
                pictureBox1.Image = Image.FromFile("C:\\Users\\dmitr\\OneDrive\\Рабочий стол\\Office_game\\Office\\image\\lvl_1.jpg");
                TimesIncident_function();
                PrBar_Timer.Stop();
            }

        }

        //если таймер остановлен и канртинка 1_2 => меняем картинку на исходную и запускаем таймер по новой
        private void button3_Click(object sender, EventArgs e)
        {
            if (Time_Incident.Enabled == false && flag == false)
            {
                pictureBox1.Image = Image.FromFile("C:\\Users\\dmitr\\OneDrive\\Рабочий стол\\Office_game\\Office\\image\\lvl_1.jpg");
                TimesIncident_function();
                PrBar_Timer.Stop();
            }

        }

    }
}
