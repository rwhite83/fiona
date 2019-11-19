﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIONA
{
    public partial class Form1 : Form

    {
        private FolderBrowserDialog rootPicker;


        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelMainMenu.BringToFront();
        }

        private void buttonConnectMain_Click(object sender, EventArgs e)
        {
            panelConnect.BringToFront();
        }

        private void buttonShareMain_Click(object sender, EventArgs e)
        {
            panelShare.BringToFront();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            panelMainMenu.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panelMainMenu.BringToFront();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            panelEntry.BringToFront();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            panelMainMenu.BringToFront();

            //////////////////////////////////////////////////////////////////////////////
            // depracated until we develop more core functionality
            //////////////////////////////////////////////////////////////////////////////
            
            /*
            SqlConnection conn = new SqlConnection(@"Data Source=fiona.database.windows.net;Initial Catalog=FIONA_db;User ID=team_fiona;Password=#Wubbalubbadubdub;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            conn.Open();

            Console.WriteLine(conn.State);

            // i know i need to hash the password, this is early going
            //string new_username = username_txtbx.Text;
            //string new_password = password_txtbx.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            //SqlDataAdapter sda = new SqlDataAdapter();
            //adapter.InsertCommand = new SqlCommand("INSERT INTO users (username, password) VALUES ('" +  new_username + "', '" + new_password + "')", conn);
            adapter.InsertCommand.ExecuteNonQuery();
            */
        }

        private void ButtonShareStart_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.rootAppVar == "null")
            {
                string message = "Sorry, no share folder selected.  Please select a share folder before serving.";
                MessageBox.Show(message);
            }
            else
            {
                FtpServer test_server = new FtpServer();
                test_server.Start();
                ////////////////////////////////////////////////////////////////////////////////////
                // counting on Kyle here to reference the application variable in the FtpServer class
                /////////////////////////////////////////////////////////////////////////////////////
            }
        }

        private void ButtonAddShared_Click(object sender, EventArgs e)
        {

            if (Properties.Settings.Default.rootAppVar != "null")
            {
                string folderAlreadySelectedMessage = "Sorry, only one folder can be shared currently.  Would you like to change your current share folder?";
                string areYouSure = "Are you sure?";
                DialogResult dialogResult = MessageBox.Show(folderAlreadySelectedMessage, areYouSure, MessageBoxButtons.YesNo);
                if(dialogResult == DialogResult.Yes)
                {
                    FolderBrowserDialog rootPicker = new FolderBrowserDialog();
                    DialogResult result = rootPicker.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(rootPicker.SelectedPath))
                    {
                        // below used for testing a good path
                        // MessageBox.Show(rootPicker.SelectedPath);

                        Properties.Settings.Default.rootAppVar = rootPicker.SelectedPath;
                        labelFolderList.Text = Properties.Settings.Default.rootAppVar;
                    }
                }
            }
            else
            {
                FolderBrowserDialog rootPicker = new FolderBrowserDialog();
                DialogResult result = rootPicker.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(rootPicker.SelectedPath))
                {
                    // below used for testing a good path
                    // MessageBox.Show(rootPicker.SelectedPath);

                    Properties.Settings.Default.rootAppVar = rootPicker.SelectedPath;
                    labelFolderList.Text = Properties.Settings.Default.rootAppVar;
                }
            }
        }
    }
}
