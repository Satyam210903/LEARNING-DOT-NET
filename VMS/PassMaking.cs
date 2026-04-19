using AForge.Video;
using AForge.Video.DirectShow;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing;
using ZXing.Common;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.Rendering;
using ZXing.Windows.Compatibility;

namespace VMS
{
    public partial class PassMaking : Form
    {
        private SqlConnection conn = new SqlConnection("Data Source=ECARTESTECH\\SQLEXPRESS;Initial Catalog=VMS;User ID=sa;Password=sn;Trust Server Certificate=True");
        FilterInfoCollection cameras;
        VideoCaptureDevice videoSource;
        private int _adminId;
        public PassMaking(int AdminId)
        {
            _adminId = AdminId;
            InitializeComponent();
        }


        //Start the Camera
        private void StartCamera()
        {
            cameras = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (cameras == null || cameras.Count == 0)
            {
                MessageBox.Show(
                    "No camera detected.\nPlease connect a webcam and try again.",
                    "Camera Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            // Stop previous camera if running
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }

            videoSource = new VideoCaptureDevice(cameras[0].MonikerString);
            videoSource.NewFrame += VideoSource_NewFrame;
            videoSource.Start();
        }


        //Stop the Camera
        private void StopCamera()
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }
        }
        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBoxCamera.Image = (Bitmap)eventArgs.Frame.Clone();
        }



        Bitmap bmp;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Badge size
            e.PageSettings.PaperSize = new PaperSize("VisitorPass", 100, 150);

            string visitor = visitorName.Text.Trim();
            string mob = contactNo.Text.Trim();
            string purpose = visitPurpose.Text.Trim();
            string validity = checkinTime.Value.ToString("dd/MM/yyyy");

            Graphics g = e.Graphics;

            // Fonts
            Font headerFont = new Font("Arial", 18, FontStyle.Bold);
            Font labelFont = new Font("Arial", 10, FontStyle.Bold);
            Font textFont = new Font("Arial", 10);
            Font passFont = new Font("Arial", 14, FontStyle.Bold);

            // Brushes
            Brush black = Brushes.Black;
            Brush white = Brushes.White;
            Brush orange = new SolidBrush(Color.Orange);

            Pen borderPen = Pens.Black;

            int x = 10;
            int y = 10;
            int width = 360;

            /* HEADER */
            Rectangle headerRect = new Rectangle(x, y, width, 60);
            g.FillRectangle(orange, headerRect);
            g.DrawRectangle(borderPen, headerRect);

            g.DrawString("VISITOR", headerFont, white, headerRect,
                new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            y += 70;

            /* PHOTO + DETAILS */
            Rectangle bodyRect = new Rectangle(x, y, width, 220);
            g.DrawRectangle(borderPen, bodyRect);

            // Photo
            Rectangle photoRect = new Rectangle(x + 10, y + 10, 120, 150);
            g.DrawRectangle(borderPen, photoRect);

            if (pictureBoxPhoto.Image != null)
                g.DrawImage(pictureBoxPhoto.Image, photoRect);

            // Details
            int tx = photoRect.Right + 10;
            int ty = y + 20;
            int gap = 25;

            g.DrawString("Pass No:", labelFont, black, tx, ty);
            g.DrawString("0001", passFont, black, tx + 80, ty);

            ty += gap + 10;
            g.DrawString("Name:", labelFont, black, tx, ty);
            g.DrawString(visitor, textFont, black, tx + 80, ty);

            ty += gap;
            g.DrawString("Mobile:", labelFont, black, tx, ty);
            g.DrawString(mob, textFont, black, tx + 80, ty);

            ty += gap;
            g.DrawString("Purpose:", labelFont, black, tx, ty);
            g.DrawString(purpose, textFont, black, tx + 80, ty);

            ty += gap;
            g.DrawString("Validity:", labelFont, black, tx, ty);
            g.DrawString(validity, textFont, black, tx + 80, ty);

            y += 240;

            /* BARCODE */
            Rectangle barcodeRect = new Rectangle(x + 20, y, width - 40, 90);
            g.DrawRectangle(borderPen, barcodeRect);

            if (pictureBoxBarcode.Image != null)
                g.DrawImage(pictureBoxBarcode.Image, barcodeRect);

            y += 100;

            /* FOOTER TEXT */
            g.DrawString("Please return to reception upon leaving.",
                new Font("Arial", 8, FontStyle.Italic),
                black,
                new Rectangle(x, y, width, 40),
                new StringFormat { Alignment = StringAlignment.Center });
        }




        private void makePassBtn_Click(object sender, EventArgs e)
        {


            string visitor = visitorName.Text.Trim();
            string mob = contactNo.Text;
            string purpose = visitPurpose.Text.Trim(); 
            string validity = checkinTime.Value.ToString("dd/MM/yyyy");
            

            string currentdate = DateAndTime.Now.ToString("dd/MM/yyyy");


            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);

            if (string.IsNullOrEmpty(visitor) ||
                string.IsNullOrEmpty(mob) ||
                string.IsNullOrEmpty(purpose) ||
                string.IsNullOrEmpty(validity))
            {
                MessageBox.Show("Please provide all the details.", "error");
            }

            if (!Regex.IsMatch(mob, @"^\d{10}$"))
            {
                MessageBox.Show("Please provide a valid 10-digit mobile number.", "Error");
                return;
            }

            if (pictureBoxPhoto.Image == null)
            {
                MessageBox.Show("Please Capture Image First", "Error");
                return;
            }
            GenerateBarcode(mob);

            try
            {
                conn.Open();
                string CheckUser = "Select Count(*) from visit_pass where mob = @mob and Validity <= @validity";
                using (SqlCommand Cmd = new SqlCommand(CheckUser, conn))
                {
                    Cmd.Parameters.AddWithValue("@mob", mob);
                    Cmd.Parameters.AddWithValue("@validity", currentdate);
                    int result = (int)Cmd.ExecuteScalar();
                    if (result > 0)
                    {
                        MessageBox.Show("Pass Already Exist", "Success");
                        conn.Close();
                    }
                    else
                    {
                        string CheckUser1 = "Select Count(*) from visit_pass where mob = @mob";
                        using (SqlCommand Cmd1 = new SqlCommand(CheckUser1, conn))
                        {
                            Cmd1.Parameters.AddWithValue("@mob", mob);
                            Cmd1.Parameters.AddWithValue("@validity", currentdate);
                            int result1 = (int)Cmd1.ExecuteScalar();
                            if (result1 > 0)
                            {
                                MessageBox.Show("Pass Already Exist", "Success");
                                conn.Close();
                            }
                            else
                            {
                                string folderPath = Path.Combine("~/visitor_image");

                                if (!Directory.Exists(folderPath))
                                {
                                    Directory.CreateDirectory(folderPath);
                                }

                                string safeFile = visitor.Replace(" ", "_");
                                string fileName = $"{safeFile}_{DateTime.Now:yyyyMMdd_HHmmss}.jpg";

                                string fullPath = Path.Combine(folderPath, fileName);

                                pictureBoxPhoto.Image.Save(fullPath, ImageFormat.Jpeg);

                                //MessageBox.Show("Image Saved Successfully.\n" + fullPath);

                                string query = "Insert into visit_pass(Name,Mob,Purpose,Photo,Validity,Status,AdminId) values (@name,@mob,@purpose,@photo,@validity,0,@AdminId)";
                                SqlCommand cmd2 = new SqlCommand(query, conn);
                                cmd2.Parameters.AddWithValue("@name", visitor);
                                cmd2.Parameters.AddWithValue("@mob", mob);
                                cmd2.Parameters.AddWithValue("@purpose", purpose);
                                cmd2.Parameters.AddWithValue("@photo", fullPath);
                                cmd2.Parameters.AddWithValue("@validity", validity);
                                cmd2.Parameters.AddWithValue("@AdminId", 1);


                                int result3 = (int)cmd2.ExecuteNonQuery();
                                if (result3 > 0)
                                {
                                    MessageBox.Show("Pass created Successfully.", "success");
                                }
                            }
                        }
                    }
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Database Error:" + ex, "error");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured" + ex,"error");
            }
            finally
            {
                conn.Close();
            }
            
            //printing command

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();



        }

        private void captureBtn_Click(object sender, EventArgs e)
        {
            pictureBoxPhoto.Image = pictureBoxCamera.Image;
            videoSource.SignalToStop();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            StartCamera();
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            StopCamera();
        }

        private void PassMaking_Load(object sender, EventArgs e)
        {
        }

        //BarCode Generation  

        private void GenerateBarcode(string mob)
        {
            var writer = new BarcodeWriter<Bitmap>
            {
                Format = BarcodeFormat.CODE_128,
                Options = new EncodingOptions
                {
                    Height = 120,
                    Width = 300,
                    Margin = 1,
                    PureBarcode = true
                },
                Renderer = new BitmapRenderer()
            };

            pictureBoxBarcode.Image = writer.Write(mob);
        }

}
}
