using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using OpenCvSharp;

namespace Sabır
{
    public partial class Form1 : Form
    {
        IplImage img;
        UInt16 uCurrentFrameNo;
        UInt16 uLastFrame;
        CvCapture cap;
        SelectedRectangle rect = new SelectedRectangle();
        List<SelectedRectangle> list = new List<SelectedRectangle>();
        Boolean mbdown;
        //SolidBrush hbr = new SolidBrush(Color.Red);
        Pen hbr = new Pen(Color.Red, 4);
        Rectangle re;
        String fileName;
        Boolean newVideoOpened;

        public Form1()
        {
            InitializeComponent();
        }

        private void videoAçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            if (opd.ShowDialog() == DialogResult.OK && opd.FileName.Length > 3)
            {
                cap = CvCapture.FromFile(opd.FileName);
                img = cap.QueryFrame();
                uLastFrame = (UInt16)cap.FrameCount;

                Size newSize = new Size(img.Width, img.Height);
                ekran.Size = newSize;
                
                ekran.Image = img.ToBitmap();
                uCurrentFrameNo = 1;
                frameText.Text = uCurrentFrameNo.ToString();
                newVideoOpened = true; 
            }
        }

        private void next_Click(object sender, EventArgs e)
        {
            if (uCurrentFrameNo < uLastFrame)
            {
                uCurrentFrameNo++;
                frameText.Text = uCurrentFrameNo.ToString();
                cap.SetCaptureProperty(CaptureProperty.PosFrames, (Double)uCurrentFrameNo);
                img = cap.QueryFrame();
                ekran.Image = img.ToBitmap();
                
            }
            else
            {
                MessageBox.Show("Tebrikler! Video sonu!");
            }
        }

        private void prev_Click(object sender, EventArgs e)
        {
            if (uCurrentFrameNo > 1)
            {
                uCurrentFrameNo--;
                frameText.Text = uCurrentFrameNo.ToString();
                cap.SetCaptureProperty(CaptureProperty.PosFrames, (Double)uCurrentFrameNo);
                img = cap.QueryFrame();
                ekran.Image = img.ToBitmap();            
            }
            else
            {
                MessageBox.Show("Video başı!");
            }
        }

        private void frameText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UInt16 enteredFrame = (UInt16)Convert.ToInt16(frameText.Text);

                if ((enteredFrame >= 1) && (enteredFrame <= uLastFrame))
                {
                    uCurrentFrameNo = (UInt16)Convert.ToInt16(frameText.Text);
                    cap.SetCaptureProperty(CaptureProperty.PosFrames, (Double)uCurrentFrameNo);
                    img = cap.QueryFrame();
                    ekran.Image = img.ToBitmap();
                }
                else
                {
                    frameText.Text = uCurrentFrameNo.ToString(); 
                    MessageBox.Show("Geçersiz Frame No");
                }
            }
        }

        private void ekran_MouseDown(object sender, MouseEventArgs e)
        {
            rect.xValue = e.X;
            rect.yValue = e.Y;
            rect.frameNum = uCurrentFrameNo;
            
            mbdown = true;
            re.X = e.X;
            re.Y = e.Y;
            re.Width = 0;
            re.Height = 0;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("Frame", "Frame");
            dataGridView1.Columns.Add("X", "X");
            dataGridView1.Columns.Add("Y", "Y");
            dataGridView1.Columns.Add("Width", "Width");
            dataGridView1.Columns.Add("Height", "Height");
            
        }

        private void ekran_MouseUp(object sender, MouseEventArgs e)
        {
            int temp;
            int xValue = e.X;
            int yValue = e.Y;

            if (xValue < rect.xValue)
            {
                temp = rect.xValue;
                rect.xValue = xValue;
                xValue = temp;
            }

            if (yValue < rect.yValue)
            {
                temp = rect.yValue;
                rect.yValue = yValue;
                yValue = temp;
            }

            rect.width = xValue - rect.xValue;
            rect.height = yValue - rect.yValue;

            if (newVideoOpened == false)
            {
                dataGridView1.Rows.Add(uCurrentFrameNo, rect.xValue, rect.yValue, rect.width, rect.height);
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
            }
            else
            {
                newVideoOpened = false;
            }

            mbdown = false;
        }

        private void ekran_MouseMove(object sender, MouseEventArgs e)
        {
            if (mbdown == true)
            {
                Rectangle nr = re;
                re.Width = e.X - re.X;
                re.Height = e.Y - re.Y;

                if (re.Width > nr.Width)
                {
                    nr.Width = re.Width;
                }
                if (re.Height > nr.Height)
                {
                    nr.Height = re.Height;
                }
                ekran.Invalidate(nr);
            }
        }

        private void ekran_Paint(object sender, PaintEventArgs e)
        {
            if( mbdown == true )
            {
                //e.Graphics.FillRectangle(hbr, re);
                e.Graphics.DrawRectangle(hbr, re);
            }
        }

        private void videoBiçimlendirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            if (opd.ShowDialog() == DialogResult.OK && opd.FileName.Length > 3)
            {
                fileName = opd.FileName;
                Thread thread1 = new Thread(new ThreadStart(FormatVideo));
                thread1.Start();

            }

        }

        delegate void setProgressBarMarginsCallback(int min, int max);
        private void setProgressBarMargins(int min, int max)
        {

            if (progressBar1.InvokeRequired)
            {
                setProgressBarMarginsCallback d = new setProgressBarMarginsCallback(setProgressBarMargins);
                Invoke(d, new object[] { min, max });
            }
            else
            {
                progressBar1.Maximum = max;
                progressBar1.Minimum = min;
            }

            
        }


        delegate void SetProgressbarCallback(int value);

        private void setProgressBarValue(int value)
        {
            if (progressBar1.InvokeRequired)
            {
                SetProgressbarCallback d = new SetProgressbarCallback(setProgressBarValue);
                Invoke(d, new object[] { value });
            }
            else
            {
                progressBar1.Value = value;
            }

            
        }

        private void FormatVideo()
        {
            
            cap = CvCapture.FromFile(fileName);
            uLastFrame = (UInt16)cap.FrameCount;
            img = cap.QueryFrame();

            CvVideoWriter newVideo = new CvVideoWriter("videoFormated.avi", FourCC.Default ,cap.Fps, img.Size);

            setProgressBarMargins(0, uLastFrame);
            

            for (int i = 1; i < uLastFrame; i++ )
            {
                img = cap.QueryFrame();
                
                if (img == null) break;

                newVideo.WriteFrame(img);
                setProgressBarValue(i);
                
            }

            newVideo.Dispose();
            setProgressBarValue(0);

        }

    }
}
