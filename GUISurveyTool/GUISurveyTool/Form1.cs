using System;

using System.Windows.Forms;

using NAudio.Wave;
using System.IO;

namespace GUISurveyTool
{
    public partial class Form1 : Form
    {
        private bool recording = false;
        private WaveIn recorder;
        private WaveFileWriter waveWriter;

        private int deviceNumber;
        private int recordCount = 0;
        private string filePrefix = "recordFile";



        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!recording)
            {
                recordCount++;

                string filename = filePrefix + recordCount + ".wav";

                FileStream fs = File.OpenWrite(filename);
                fs.Close();

                recording = true;

                button2.Visible = false;
                button1.Text = "Stop Recording";

                recorder = new WaveIn();
                recorder.DeviceNumber = deviceNumber;
                recorder.WaveFormat = new WaveFormat(16000, WaveIn.GetCapabilities(deviceNumber).Channels);
                recorder.DataAvailable += RecorderOnDataAvailable;

                waveWriter = new WaveFileWriter(filename, recorder.WaveFormat);

                recorder.StartRecording();

            }
            else
            {
                recorder.StopRecording();
                waveWriter.Close();
                recorder.Dispose();
                //player = new WaveOut();
                //player.Init(bufferedWaveProvider);

                button2.Visible = true;
                recording = false;
                button1.Text = "Start Recording";
            }
            
        }

        private void RecorderOnDataAvailable(object sender, WaveInEventArgs e)
        {
            waveWriter.Write(e.Buffer, 0, e.BytesRecorded);
            waveWriter.Flush();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dynamic sample = SpeechSample.BingVoice.requestBingVoice(filePrefix+recordCount+".wav");
            textBoxSampleOutput.Text = sample["header"]["lexical"];
        }
    }
}
