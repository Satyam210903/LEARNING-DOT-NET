using AForge.Video;
using AForge.Video.DirectShow;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    public partial class Out : Form
    {
        public SqlConnection conn = new SqlConnection("Data Source=ECARTESTECH\\SQLEXPRESS;Initial Catalog=VMS;User ID=sa;Password=sn;Trust Server Certificate=True");
        FilterInfoCollection cameras;
        VideoCaptureDevice videoSource;
        public Out()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string mob = maskedTextBox1.Text.Trim();
            string currentdate = DateAndTime.Now.ToString("dd/MM/yyyy");

            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);

            // Empty check
            if (!maskedTextBox1.MaskCompleted)
            {
                MessageBox.Show("Please fill all the details.", "Error");
                return;
            }

            // Mobile number validation
            if (!Regex.IsMatch(mob, @"^\d{10}$"))
            {
                MessageBox.Show("Please provide a valid 10-digit mobile number.", "Error");
                return;
            }

            // Database Insert 
            try
            {

                conn.Open();
                string CheckUser = "Select Count(*) from visit_pass where mob = @mob and Validity > @Validity ";
                using (SqlCommand Cmd = new SqlCommand(CheckUser, conn))
                {
                    Cmd.Parameters.AddWithValue("@mob", mob);
                    Cmd.Parameters.AddWithValue("@Validity", currentdate);
                    int result = (int)Cmd.ExecuteScalar();
                    if (result > 0)
                    {
                        MakeCheckOut(mob);
                    }
                    else
                    {
                        MessageBox.Show("Pass Not Found Or your pass have been expired.", "Error");
                        conn.Close();
                    }
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error");
            }
            finally
            {
                conn.Close();
            }

        }
        private void MakeCheckOut(string mob)
        {

            string currentdate = DateAndTime.Now.ToString();
            try
            {
                string CheckUser1 = "Select Count(*) from visit_pass where mob = @mob and status = 1 ";
                using (SqlCommand Cmd1 = new SqlCommand(CheckUser1, conn))
                {
                    Cmd1.Parameters.AddWithValue("@mob", mob);
                    int result1 = (int)Cmd1.ExecuteScalar();
                    if (result1 > 0)
                    {


                        string query = @"UPDATE visit_pass 
                                 SET status = 0, LastOut = @LastOut 
                                 WHERE Mob = @mob";

                        using (SqlCommand cmd2 = new SqlCommand(query, conn))
                        {
                            cmd2.Parameters.AddWithValue("@mob", mob);
                            cmd2.Parameters.AddWithValue("@LastOut", currentdate);
                            cmd2.ExecuteNonQuery();
                        }

                        MessageBox.Show("Now You Are Checked In.", "Success");
                    }
                    else
                    {
                        MessageBox.Show("You are already checkedOut.", "Error");
                        conn.Close();
                    }
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error");
            }
            finally
            {
                conn.Close();
            }
        }

        private void scanBarcode_Click(object sender, EventArgs e)
        {
            ScanBarcodeFromImage();
        }




        // Start the Camera (SAFE)
        private void StartCamera()
        {
            cameras = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            // Checking if any camera is available
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

            // Stopping previous camera instance if running
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
        private void ScanBarcodeFromImage()
        {
            if (pictureBoxCamera.Image == null) return;

            BarcodeReader reader = new BarcodeReader();
            var result = reader.Decode((Bitmap)pictureBoxCamera.Image);
            if (result != null)
            {
                string mob = result.ToString();
                videoSource.SignalToStop();
                CheckOUT(mob);
            }
            else
            {
                MessageBox.Show("No Barcode detected.", "error");
            }
        }

        //CheckIn Through Barcode
        private void CheckOUT(string mob)
        {
            string currentdate = DateAndTime.Now.ToString("dd/MM/yyyy");
            try
            {

                conn.Open();
                string CheckUser = "Select Count(*) from visit_pass where mob = @mob and Validity > @Validity ";
                using (SqlCommand Cmd = new SqlCommand(CheckUser, conn))
                {
                    Cmd.Parameters.AddWithValue("@mob", mob);
                    Cmd.Parameters.AddWithValue("@Validity", currentdate);
                    int result = (int)Cmd.ExecuteScalar();
                    if (result > 0)
                    {
                        MakeCheckOut(mob);
                    }
                    else
                    {
                        MessageBox.Show("Pass Not Found Or your pass have been expired.", "Error");
                        conn.Close();
                    }
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error");
            }
            finally
            {
                conn.Close();
            }
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            StartCamera();
        }
    }
}
