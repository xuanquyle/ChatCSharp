using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.IO;

namespace Client
{
    //The commands for interaction between the server and the client
    enum Command
    {
        Login,      //Log into the server
        Logout,     //Logout of the server
        Message,    //Send a text message to all the chat clients
        File,
        List,       //Get a list of users in the chat room from the server
        Null        //No command
    }
    
    public partial class Client : Form
    {
        public Socket clientSocket; //The main client socket
        public string strName;      //Name by which the user logs into the room
        public static string userName;

        private byte[] byteData = new byte[1024 * 5];
        List<string> List_File =new List<string>();
        string fileName;
        String files;
        public Client()
        {
            InitializeComponent();
        }

        //Broadcast the message typed by the user to everyone
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                //Fill the info for the message to be send
                Data msgToSend = new Data();

                msgToSend.strName = strName;
                msgToSend.strMessage = txtMessage.Text;
                msgToSend.cmdCommand = Command.Message;

                byte[] byteData = msgToSend.ToByte();

                //Send it to the server
                clientSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnSend), null);

                txtMessage.Text = null;
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to send message to the server.", "clientTCP: " + strName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnSend(IAsyncResult ar)
        {
            try
            {
                clientSocket.EndSend(ar);
            }
            catch (ObjectDisposedException)
            { }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ClientTCP: " + strName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                clientSocket.EndReceive(ar);

                Data msgReceived = new Data(byteData);
                //Accordingly process the message received
                switch (msgReceived.cmdCommand)
                {
                    case Command.Login:
                        lstChatters.Items.Add(msgReceived.strName);
                        break;

                    case Command.Logout:
                        lstChatters.Items.Remove(msgReceived.strName);
                        break;

                    case Command.Message:

                        if (msgReceived.fileName != null && msgReceived.fileName.Trim(' ').Length > 0)
                        {
                            List_File.Add(msgReceived.fileName.Trim(' '));
                            lbx_File.Items.Add(msgReceived.fileName);
                        }
                        break;

                    case Command.List:
                        lstChatters.Items.AddRange(msgReceived.strMessage.Split('*'));
                        lstChatters.Items.RemoveAt(lstChatters.Items.Count - 1);
                        txtChatBox.Text += "<<<" + strName + " has joined the room>>>\r\n";
                        break;
                }

                if (msgReceived.strMessage != null && msgReceived.cmdCommand != Command.List)
                    txtChatBox.Text += msgReceived.strMessage + "\r\n";
                byteData = new byte[1024 * 5];

                clientSocket.BeginReceive(byteData,
                                          0,
                                          byteData.Length,
                                          SocketFlags.None,
                                          new AsyncCallback(OnReceive),
                                          null);

            }
            catch (ObjectDisposedException)
            { }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ClientTCP: " + strName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.Text = strName;

            //The user has logged into the system so we now request the server to send
            //the names of all users who are in the chat room
            Data msgToSend = new Data();
            msgToSend.cmdCommand = Command.List;
            msgToSend.strName = strName;
            userName = strName;
            msgToSend.strMessage = null;
            msgToSend.fileName = null;

            byteData = msgToSend.ToByte();

            clientSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnSend), null);

            byteData = new byte[1024 * 5];
            //Start listening to the data asynchronously
            clientSocket.BeginReceive(byteData,
                                       0,
                                       byteData.Length,
                                       SocketFlags.None,
                                       new AsyncCallback(OnReceive),
                                       null);

        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            if (txtMessage.Text.Length == 0)
                btnSend.Enabled = false;
            else
                btnSend.Enabled = true;
        }

        private void SGSClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to leave the chat room?", "Client: " + strName,
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            try
            {
                //Send a message to logout of the server
                Data msgToSend = new Data();
                msgToSend.cmdCommand = Command.Logout;
                msgToSend.strName = strName;
                msgToSend.strMessage = null;
                msgToSend.fileName = null;
                msgToSend.fileData = null;


                byte[] b = msgToSend.ToByte();
                clientSocket.Send(b, 0, b.Length, SocketFlags.None);
                clientSocket.Close();
            }
            catch (ObjectDisposedException)
            { }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "clientTCP: " + strName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend_Click(sender, null);
            }
        }

        private void sendFile()
        {
            if (this.files != null && this.files.Length != 0)
            {
                try
                {
                    //Fill the info for the message to be send
                    Data msgToSend = new Data();

                    msgToSend.strName = strName;
                    msgToSend.fileName = Data.splitPath(this.files);
                    msgToSend.fileData = File.ReadAllBytes(this.files);
                    msgToSend.strMessage = Data.splitPath(this.files);
                    msgToSend.cmdCommand = Command.Message;
                    //for(int i=0;i<msgToSend.fileData.Length;i++)
                    //{
                    //    MessageBox.Show(msgToSend.fileData[i].ToString());
                    //}
                    //return;
                    byte[] byteData = msgToSend.ToByte();

                    //Send it to the server
                    clientSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnSend), null);

                    txtMessage.Text = null;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Unable to send message to the server.", "ClientTCP: " + strName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show(ex.ToString());
                    return;
                }

            }
            txtMessage.Text = "";           
        }

        private void txtChatBox_DragDrop(object sender, DragEventArgs e)
        {

            String[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            this.files = files[0];
            sendFile();

        }

        private void txtChatBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            txtMessage.Text = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Select file",
                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (* .txt) | * .txt | All files (*. *) | *. *",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtMessage.Text = Data.splitPath(openFileDialog1.FileName);
                btn_Send2.Visible = true;
                this.files = openFileDialog1.FileName;
            }
        }

        private void lbx_File_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lbx_File.SelectedItem!=null)
            {
                fileName = lbx_File.SelectedItem.ToString();
                ContextMenu news = new ContextMenu();
                news.MenuItems.Add("Openfile", new EventHandler(openFile_Click));
                lbx_File.ContextMenu = news;

            }
            
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            string collection = Directory.GetCurrentDirectory() + @"\" + this.strName + "-" +
                DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString();
            System.Diagnostics.Process.Start(collection);

        }

        private void btn_Send2_Click(object sender, EventArgs e)
        {
            sendFile();
            btn_Send2.Visible = false;
            txtMessage.Text = "";
        }
    }

    //The data structure by which the server and the client interact with 
    //each other
    class Data
    {
        //Default constructor
        public Data()
        {
            this.cmdCommand = Command.Null;
            this.strMessage = null;
            this.strName = null;
            this.fileName = null;
            this.fileData = null;
        }

        //Converts the bytes into an object of type Data
        public Data(byte[] data)
        {
            byte[] fData = new byte[1024 * 5];
            //The first four bytes are for the Command
            this.cmdCommand = (Command)BitConverter.ToInt32(data, 0);

            //The next four store the length of the name
            int nameLen = BitConverter.ToInt32(data, 4);

            //The next four store the length of the message
            int msgLen = BitConverter.ToInt32(data, 8);

            int fNameLen = BitConverter.ToInt32(data, 12);

            int dataLen = BitConverter.ToInt32(data, 16);

            //This check makes sure that strName has been passed in the array of bytes
            if (nameLen > 0)
                this.strName = Encoding.UTF8.GetString(data, 20, nameLen);
            else
                this.strName = null;

            //This checks for a null message field
            if (msgLen > 0)
                this.strMessage = Encoding.UTF8.GetString(data, 20 + nameLen, msgLen);
            else
                this.strMessage = null;

            if (fNameLen > 0)
                this.fileName = Encoding.UTF8.GetString(data, 20 + nameLen+ msgLen, fNameLen);
            else
                this.fileName = null;

            if (dataLen > 0)
            {
                int i = 20 + nameLen + msgLen + fNameLen - 1;
                fileData = new byte[i + dataLen + 1];
                Buffer.BlockCopy(data, i, fileData, 0, dataLen + 1);
                string collection = Directory.GetCurrentDirectory() + @"\"+ Client.userName +"-"+
                    DateTime.Now.Day.ToString() +"-"+ DateTime.Now.Month.ToString();
                bool exists = System.IO.Directory.Exists(collection);
                if (!exists)
                    System.IO.Directory.CreateDirectory(collection);
                int t = 1;
                string tempFileName = fileName;
                while (File.Exists(collection+"/"+tempFileName))
                {
                    string temp ="("+t.ToString()+")"+ fileName;
                    tempFileName = temp;
                    t++;
                }
                fileName = tempFileName;
                BinaryWriter bWrite = new BinaryWriter(File.Open(collection + "/" + fileName, FileMode.Create));
                bWrite.Write(fileData, 1, dataLen);
                bWrite.Close();
            }
            else
                this.fileData = null;
        }
            

        //Converts the Data structure into an array of bytes
        public byte[] ToByte()
        {
            List<byte> result = new List<byte>();

            //First four are for the Command
            result.AddRange(BitConverter.GetBytes((int)cmdCommand));

            //Add the length of the name
            if (strName != null)
                result.AddRange(BitConverter.GetBytes(strName.Length));
            else
                result.AddRange(BitConverter.GetBytes(0));

            //Length of the message
            if (strMessage != null)
                result.AddRange(BitConverter.GetBytes(strMessage.Length));
            else
                result.AddRange(BitConverter.GetBytes(0));

            if (fileName != null)
                result.AddRange(BitConverter.GetBytes(fileName.Length));
            else
                result.AddRange(BitConverter.GetBytes(0));

            if (fileData != null)
                result.AddRange(BitConverter.GetBytes(fileData.Length));
            else
                result.AddRange(BitConverter.GetBytes(0));

            //Add the name
            if (strName != null)
                result.AddRange(Encoding.UTF8.GetBytes(strName));

            //And, lastly we add the message text to our array of bytes
            if (strMessage != null)
                result.AddRange(Encoding.UTF8.GetBytes(strMessage));

            if (fileName != null)
            {
                result.AddRange(Encoding.UTF8.GetBytes(fileName));
                result.AddRange(fileData);
            }


            return result.ToArray();
        }
        public static string splitPath(string fileName)
        {
            string a = @"\";
            char[] b = new char[1];
            b[0] = a[0];
            String[] fName = fileName.Split(b);
            return fName[fName.Length - 1];
        }
        public string strName;      //Name by which the client logs into the room
        public Command cmdCommand;
        public string strMessage;   //Message text  
        public string fileName;
        public byte []fileData= new byte[2*1024];
    }
}