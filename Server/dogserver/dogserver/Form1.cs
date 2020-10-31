using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Web;

namespace dogserver
{
    public partial class Form1 : Form
    {
        const int SECONDS = 60;
        const int ROOM_SPEED = 60;
        const int TIME_MAX = SECONDS * ROOM_SPEED;
        
        int Fastest = 0;
        HttpListener Listener;

        public Form1()
        {
            InitializeComponent();
        }

        private void LogLine(string line)
        {
            LogBox.Text += line + Environment.NewLine;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            HTTPBgWorker.RunWorkerAsync();
        }

        private void HTTPBgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker self = sender as BackgroundWorker;
            try
            {
                Listener = new HttpListener();
                Listener.Prefixes.Add("http://+:9009/");
                //Listener.Prefixes.Add("http://inversedog.ddns.net:9009/");
                Listener.Start();
                self.ReportProgress(int.MinValue + 1, "HttpListener is ready...");

                while (true)
                {
                    HttpListenerContext context = Listener.GetContext();
                    HttpListenerRequest request = context.Request;
                    HttpListenerResponse response = context.Response;

                    var reader = new StreamReader(request.InputStream);
                    string body = reader.ReadToEnd();

                    NameValueCollection collection = HttpUtility.ParseQueryString(body);
                    string name = collection["name"];
                    int time = -1;
                    if (!int.TryParse(collection["time"], out time))
                        self.ReportProgress(-1, "Unable to parse score for " + name + collection["time"]);
                    else
                        self.ReportProgress(time, name);

                    response.StatusCode = (int)HttpStatusCode.OK;
                    response.StatusDescription = "OK";
                    response.ProtocolVersion = new Version("1.1");
                    response.ContentEncoding = Encoding.UTF8;
                    response.ContentType = "application/x-www-form-urlencoded";
                    byte[] outstring = Encoding.UTF8.GetBytes("success=true");
                    response.ContentLength64 = outstring.Length;
                    response.OutputStream.Write(outstring, 0, outstring.Length);
                    response.OutputStream.Close();
                }
            }
            catch (Exception ex)
            {
                self.ReportProgress(int.MinValue, ex);
            }
        }

        private void HTTPBgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == int.MinValue + 1)
            {
                LogLine((string)e.UserState);
                return;
            }

            if (e.ProgressPercentage == int.MinValue)
            {
                var ex = e.UserState as Exception;
                MessageBox.Show(ex.ToString(), ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            int score = e.ProgressPercentage;
            decimal sec = (decimal)(TIME_MAX - score) / (decimal)ROOM_SPEED;
            string text = "NAME{" + (string)e.UserState + "}, TIME{" + (TIME_MAX - score).ToString() + "}, SECONDS{" + sec.ToString() + "}";
            if (e.ProgressPercentage > Fastest)
            {
                Fastest = e.ProgressPercentage;
                FastestTextBox.Text = text;
            }

            LogLine(text);
        }

        private void HTTPBgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Listener.Stop();
            Listener.Abort();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            HTTPBgWorker.CancelAsync();
        }
    }
}
