using System;

using System.Windows.Forms;

using NAudio.Wave;

namespace GUISurveyTool
{
    public partial class Form1 : Form
    {
        private bool recording = false;
        private WaveIn recorder;
        private BufferedWaveProvider bufferedWaveProvider;
        private SavingWaveProvider savingWaveProvider;
        private WaveOut player;



        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!recording)
            {
                if(player != null)
                {
                    player.Stop();
                }
                recording = true;

                button2.Visible = false;
                button1.Text = "Stop Recording";

                recorder = new WaveIn();
                recorder.DataAvailable += RecorderOnDataAvailable;
                bufferedWaveProvider = new BufferedWaveProvider(recorder.WaveFormat);

                recorder.StartRecording();

            }
            else
            {
                recorder.StopRecording();
                player = new WaveOut();
                player.Init(bufferedWaveProvider);

                button2.Visible = true;
                recording = false;
                button1.Text = "Start Recording";
            }
            
        }

        private void RecorderOnDataAvailable(object sender, WaveInEventArgs waveInEventArgs)
        {
            bufferedWaveProvider.AddSamples(waveInEventArgs.Buffer, 0, 
                waveInEventArgs.BytesRecorded);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            player.Play();
        }
    }
}
