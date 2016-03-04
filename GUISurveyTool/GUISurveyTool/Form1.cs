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

        private string gitFolderPath;
        private string interviewName;



        public Form1(string gitFolderPath, string interviewName)
        {
            this.gitFolderPath = gitFolderPath;
            this.interviewName = interviewName;
            runCmd(gitFolderPath, "mkdir " + interviewName);
            System.Diagnostics.Process.Start("Notepad++.exe", gitFolderPath + "\\" + interviewName + "\\" + interviewName + ".java");
            InitializeComponent();
        }

        private void runCmd(string dir, string commands)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C cd "+ dir +" & " + commands;
            process.StartInfo = startInfo;
            process.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!recording)
            {
                recordCount++;

                string filename = gitFolderPath +"\\"+interviewName+"\\"
                    + filePrefix + recordCount + ".wav";

                FileStream fs = File.OpenWrite(filename);
                fs.Close();

                recording = true;

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

                button1.Visible = false;

                recording = false;
                button1.Text = "Start Recording";

                dynamic sample = SpeechSample.BingVoice.requestBingVoice(gitFolderPath +"\\"+interviewName +"\\" +
                    filePrefix + recordCount + ".wav");
                textBoxSampleOutput.Text = sample["header"]["name"];

                commitBtn.Visible = true;
                cancelCommitBtn.Visible = true;
                
                for(int i = 0; i < Math.Min(1, sample["results"].Length); i++){
                    dynamic result = sample["results"][i];
                    foreach(dynamic token in result["tokens"])
                    {
                        Console.WriteLine("Lexical: " + token["token"]);
                        Console.WriteLine("Pronunciation: " + token["pronunciation"]);
                        Console.WriteLine();
                    }
                }
            }
            
        }

        private void RecorderOnDataAvailable(object sender, WaveInEventArgs e)
        {
            waveWriter.Write(e.Buffer, 0, e.BytesRecorded);
            waveWriter.Flush();
        }


        private void commitBtn_Click(object sender, EventArgs e)
        {
            runCmd(gitFolderPath, "git add -A & git commit -a -m \""+
                interviewName+"_edit"+recordCount+":Bing Transcript: "+textBoxSampleOutput.Text+"\"");
            commitBtn.Visible = false;
            cancelCommitBtn.Visible = false;
            button1.Visible = true;
        }

        private void cancelCommitBtn_Click(object sender, EventArgs e)
        {
            runCmd(gitFolderPath + "\\" + interviewName, "del "+filePrefix+recordCount+".wav" );
            recordCount--;
            commitBtn.Visible = false;
            cancelCommitBtn.Visible = false;
            button1.Visible = true;
        }
    }
}
