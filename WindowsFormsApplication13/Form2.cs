using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication13
{
    public partial class Form2 : Form
    {
        int[] burst_time = new int[100];
        private int n=0;
        float[] arrival_time = new float[100];
        float avg_waiting_time;
        float[] start_time = new float[100];
        float avg_finish_time;

        public Form2()
        {
            InitializeComponent();
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox3.Text) != 0)
            {
                if (n != 0)
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (arrival_time[i] > float.Parse(textBox2.Text))
                        {
                            for (int j = n; j > i; j--)
                            {
                                arrival_time[j] = arrival_time[j - 1];
                                burst_time[j] = burst_time[j - 1];
                            }
                            arrival_time[i] = float.Parse(textBox2.Text);
                            burst_time[i] = int.Parse(textBox3.Text);
                            break;
                        }
                        else
                        {
                            arrival_time[n] = float.Parse(textBox2.Text);
                            burst_time[n] = int.Parse(textBox3.Text);
                        }
                    }
                }
                else
                {
                    arrival_time[0] = float.Parse(textBox2.Text);
                    burst_time[0] = int.Parse(textBox3.Text);
                }
                n++;
                textBox2.Clear();
                textBox3.Clear();
            }
            else
            {
                MessageBox.Show("Error");
                textBox3.Clear();
                textBox2.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            textBox2.Clear();
            textBox3.Clear();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        public void FCFS()
        { 
        
        
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ss = "Arrival time   Burst time   Start time   Waiting time   Finish time\n";
            string line;
            float z;
            float f;
            for (int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    start_time[i] = arrival_time[i];
                }
                else if (start_time[i - 1] + burst_time[i - 1] > arrival_time[i])
                {
                    start_time[i] = start_time[i - 1] + burst_time[i - 1];
                }
                else
                {
                    start_time[i] = arrival_time[i];
                }
            }
            for (int i = 0; i < n; i++)
            {
                z = start_time[i] - arrival_time[i];
                f = start_time[i] + burst_time[i];
                line = arrival_time[i]+ "                       "+burst_time[i]+"                     "+start_time[i]+"                     "+z+"                      "+f+"\n";
                ss += line;
                avg_waiting_time += z;
                avg_finish_time += f;
            }
            if (n != 0)
            {
                avg_finish_time = avg_finish_time / n;
                avg_waiting_time = avg_waiting_time / n;
                line = "AVG wating time = " + avg_waiting_time + "\n AVG total time = " + avg_finish_time;
                ss += line;
            }
            MessageBox.Show(ss);

            n = 0;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9') && (!char.IsControl(e.KeyChar)))
            {
                e.KeyChar = '\0';
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9') && (!char.IsControl(e.KeyChar)))
            {
                e.KeyChar = '\0';
            }
        }
    }
}
