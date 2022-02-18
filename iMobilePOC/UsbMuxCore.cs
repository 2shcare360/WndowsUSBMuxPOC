using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iMobileDevice;
using iMobileDevice.iDevice;
using iMobileDevice.Lockdown;
using iMobileDevice.Usbmuxd;
namespace iMobilePOC2
{
    public class UsbmuxCore
    {
        private IiDeviceApi idevice;
        private ILockdownApi lockdown;
        private ReadOnlyCollection<string> udids;
        public string DeviceUDID;
        iDeviceHandle deviceHandle;
        iMobileDevice.Plist.PlistHandle pListHandle;
        public iDeviceConnectionHandle deviceConnHandle;
        LockdownClientHandle lockdownHandle;
        string deviceName;
        string pListXML;
        public string lastReceivedMessage;


        public UsbmuxCore()
        {
            iMobileDevice.NativeLibraries.Load();
            idevice = LibiMobileDevice.Instance.iDevice;
            lockdown = LibiMobileDevice.Instance.Lockdown;

        }


        private string SetDeviceAndLockdownHandles()
        {

            int count = 0;


            var ret = idevice.idevice_get_device_list(out udids, ref count);

            if (ret == iDeviceError.NoDevice)
            {
                // Not actually an error in our case
                return "Failed : No Device found";
            }

            ret.ThrowOnError();

            if (udids.Count > 1)
            {
                return "Failed : You have connected more thn one device. Please connect only one authorized device.";
            }
            else if (udids.Count == 1)
            // Get the device name
            //foreach (var udid in udids)
            {
                DeviceUDID = udids[0];
                idevice.idevice_new(out deviceHandle, DeviceUDID).ThrowOnError();
                lockdown.lockdownd_client_new_with_handshake(deviceHandle, out lockdownHandle, "PassLink").ThrowOnError();
                return "Success";
            }
            else
            {
                return "Failed: Unknown error.";
            }
        }


        public string GetDeviceName()
        {

            try
            {
                var error = SetDeviceAndLockdownHandles();
                if (error == "Success")
                {
                    lockdown.lockdownd_get_device_name(lockdownHandle, out deviceName).ThrowOnError();
                  
                    return deviceName + Environment.NewLine + Environment.NewLine + "Battery Info XML" + Environment.NewLine + Environment.NewLine + GetDeviceProps(lockdownHandle);

                }
                else
                {
                    return "Failed";
                }

            }
            catch
            {
                return "Failed";
            }

        }



        private string GetDeviceProps(LockdownClientHandle lckHandle)
        {
            uint xmlLen = 10000;
            lockdown.lockdownd_get_value(lckHandle, "com.apple.mobile.battery", null, out pListHandle);

            iMobileDevice.Plist.PlistNativeMethods.plist_to_xml(pListHandle, out pListXML, ref xmlLen);
            return pListXML;

        }



        public string DeviceConnect()
        {
            try
            {
                var error = idevice.idevice_connect(deviceHandle, 5050, out deviceConnHandle);

                if (error == iDeviceError.Success)
                {
                    return "Success";
                }
                else
                {
                    return "Unable to open communication. Please check if the iOS app is running usbmuxd socket on port 5050 for communication";
                }
            }
            catch
            {
                return "Unable to open communication. Please check if the iOS app is running usbmuxd socket on port 5050 for communication";

            }
            //Connect, Send and Recv

        }

        public string SendMsg(iDeviceConnectionHandle connHandle, string msg)
        {
            uint sentBytes = 0;

            // Convert a C# string to a byte array  
            byte[] sendBuffer = Encoding.ASCII.GetBytes(msg);

            var error = idevice.idevice_connection_send(connHandle, sendBuffer, (uint)sendBuffer.Length, ref sentBytes);

            if (sentBytes <= 0) return "Unable to Send";
            else return "Success";
        }

        public void RecvMsg(iDeviceConnectionHandle connHandle)
        {

            //Connect, Send and Recv
            Task.Run(() =>
            {
                while (true)
                {
                    uint receivedBytes = 0;
                    byte[] recvBuffer = null;
                    recvBuffer = new byte[1000];

                    var error = idevice.idevice_connection_receive(connHandle, recvBuffer, 1000, ref receivedBytes);

                    if (receivedBytes <= 0) continue;
                    else
                    {
                        // Do something with your received bytes
                        lastReceivedMessage = Encoding.ASCII.GetString(recvBuffer);
                    }
                }
            });
        }


        ~UsbmuxCore()
        {
            if (deviceHandle != null)
            {
                deviceHandle.Dispose();
                lockdownHandle.Dispose();
            }
        }


    }
}
