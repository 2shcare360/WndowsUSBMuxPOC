using iMobileDevice;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iMobileDevice.iDevice;
using iMobileDevice.Lockdown;
using iMobileDevice.Usbmuxd;


namespace iMobilePOC2
{
    public partial class Form1 : Form
    {
        UsbmuxCore usbmux = new UsbmuxCore();
        public Form1()
        {
            InitializeComponent();
            btnRecv.Enabled = false;
            btnSend.Enabled = false;
            btnConnect.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("test");

            iMobileDevice.NativeLibraries.Load();
            var idevice = LibiMobileDevice.Instance.iDevice;
            var lockdown = LibiMobileDevice.Instance.Lockdown;



        }

        private void btnDeviceInfo_Click(object sender, EventArgs e)
        {
            var devicename = usbmux.GetDeviceName();
            if (devicename != "Failed")
            {
                txtDisplay.Text = "Device Found : " + devicename;
                lblStatus.Text = "Status : Device Found : " + devicename;
                btnConnect.Enabled = true;
                lblStatus.Text = "Status : Device Detected";


            }
            else
            {
                MessageBox.Show("Unable to get device info. Please make sure you plugged in an iOS device");
            }

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            var error = usbmux.DeviceConnect();
            if (error == "Success")
            {
                MessageBox.Show("Device Connected Successfully");
                lblStatus.Text = "Device reeady for communication";
                btnRecv.Enabled = true;
                btnSend.Enabled = true;
                txtSend.Enabled = true;
            }
            else
            {
                MessageBox.Show("Device Connection failed for communication" + Environment.NewLine + error);
            }

        }

        private void btnRecv_Click(object sender, EventArgs e)
        {
            usbmux.RecvMsg(usbmux.deviceConnHandle);
            // usbmux.lastReceivedMessage
            txtDisplay.Clear();
            txtRecv.Text = usbmux.lastReceivedMessage;

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            var error = usbmux.SendMsg(usbmux.deviceConnHandle, txtSend.Text);
            if (error == "Success")
            {
                MessageBox.Show("Message sent successfully");
            }
            else
            {
                MessageBox.Show("Failed to send message");
            }

        }
    }
}
