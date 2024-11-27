using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Office
{
    public partial class Main_form : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        public Main_form()
        {
            InitializeComponent();
            player.URL = "muzic1.mp3";
        }

        // Метод для музыкального таймера
        private void muzikTimer_function()
        {
            muzik_timer.Interval = 18000;
            muzik_timer.Start();
        }



        // !!!!!!!!!!!! Main !!!!!!!!!!!!
        private void Main_form_Load(object sender, EventArgs e)
        {
            player.controls.play();
            muzikTimer_function();
        }



        // Первый уровень
        private void button1_Click(object sender, EventArgs e)
        {
            
            Test_form settingsForm = new Test_form();
            settingsForm.ShowDialog();
            
        }

        // При завершение таймера запускается трек повторно
        private void muzik_timer_Tick(object sender, EventArgs e)
        {
            muzik_timer.Stop();
            player.controls.stop();
            player.controls.play();
            muzikTimer_function();
        }
    }
}
