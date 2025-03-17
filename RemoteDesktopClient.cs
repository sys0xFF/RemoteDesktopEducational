using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace server
{

    public partial class RemoteDesktopClient: Form
    {

        private PictureBox pictureBox;
        private TcpClient client;
        private NetworkStream ns;
        private Thread receiveThread;

        public RemoteDesktopClient()
        {
            InitializeComponent();
            RemoteDesktop();
        }

        void RemoteDesktop()
        {

            this.Text = "Remote Desktop";
            this.ClientSize = new Size(800, 600);

            pictureBox = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            this.Controls.Add(pictureBox);

 
            ConnectToServer();
        }
        private void ConnectToServer()
        {
            try
            {
                
                client = new TcpClient("127.0.0.1", 9999);
                ns = client.GetStream();

                receiveThread = new Thread(ReceiveImages)
                {
                    IsBackground = true
                };
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ReceiveImages()
        {
            try
            {
                while (true)
                {
                  
                    byte[] sizeBytes = new byte[4];
                    int bytesRead = ns.Read(sizeBytes, 0, 4);
                    if (bytesRead < 4)
                        break;
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(sizeBytes);
                    int imageSize = BitConverter.ToInt32(sizeBytes, 0);

                 
                    byte[] imgBytes = new byte[imageSize];
                    int totalRead = 0;
                    while (totalRead < imageSize)
                    {
                        int read = ns.Read(imgBytes, totalRead, imageSize - totalRead);
                        if (read == 0)
                            break;
                        totalRead += read;
                    }

                    MemoryStream ms = new MemoryStream(imgBytes);
                    Image img = Image.FromStream(ms);
                    ms.Dispose();

                    this.Invoke((MethodInvoker)delegate {
                        pictureBox.Image = img;
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                ns?.Close();
                client?.Close();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (receiveThread != null && receiveThread.IsAlive)
                receiveThread.Abort();
            ns?.Close();
            client?.Close();
        }

    }
}
