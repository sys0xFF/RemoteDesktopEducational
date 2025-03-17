using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace RemoteDesktopEducational
{
    class RemoteDesktopServer
    {
        static void Main()
        {
            int port = 9999;
            TcpListener server = new TcpListener(IPAddress.Any, port);
            server.Start();
            Console.WriteLine("Waiting for client connection...");

            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("Connected client: " + client.Client.RemoteEndPoint);

            NetworkStream ns = client.GetStream();

            
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

           
            int delay = 20; 

            
            while (true)
            {
              
                Bitmap bmp = new Bitmap(screenWidth, screenHeight);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(0, 0, 0, 0, new Size(screenWidth, screenHeight));
                }

              
                MemoryStream ms = new MemoryStream();
                ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                EncoderParameters encoderParams = new EncoderParameters(1);
                encoderParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 50L);
                bmp.Save(ms, jpgEncoder, encoderParams);

                byte[] imgBytes = ms.ToArray();

            
                byte[] sizeBytes = BitConverter.GetBytes(imgBytes.Length);
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(sizeBytes);
                ns.Write(sizeBytes, 0, sizeBytes.Length);

            
                ns.Write(imgBytes, 0, imgBytes.Length);

            
                ms.Dispose();
                bmp.Dispose();

              
                Thread.Sleep(delay);
            }
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                    return codec;
            }
            return null;
        }
    }
}
