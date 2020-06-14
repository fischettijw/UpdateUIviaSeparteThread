using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpdateUIviaSeparteThread
{
    public partial class FrmTesting : Form
    {
        public delegate void DelegateTxtboxUI(string str); // Delegate with Signature
        ThreadStart threadStart;
        Thread updateTxtboxUI;

        public FrmTesting()
        {
            InitializeComponent();
        }

        private void FrmTesting_Load(object sender, EventArgs e)
        {
            Thread.CurrentThread.Name = "PrimaryThread";

            threadStart = new ThreadStart(GetTheThreadStarted); //ThreadStart object defining Method to call
            updateTxtboxUI = new Thread(threadStart);           //Thread object defining ThreadStart object
            updateTxtboxUI.Name = "SecondaryThread";
        }

        private void GetTheThreadStarted()
        {
            DelegateTxtboxUI myDelegateUI = new DelegateTxtboxUI(UpdateTextbox);
            this.Txt01.BeginInvoke(myDelegateUI, $"Updated from THREAD:TBX {Thread.CurrentThread.Name}");
            CheckForIllegalCrossThreadCalls = false;
            this.LbxOutput.Items.Add("CheckForIllegalCrossThreadCalls = false");
            this.LbxOutput.Items.Add($"Updated from THREAD:LBX {Thread.CurrentThread.Name}");
            CheckForIllegalCrossThreadCalls = true;
            //this.LbxOutput.Items.Add("CheckForIllegalCrossThreadCalls = true");
        }

        private void UpdateTextbox(string str)
        {
            LbxOutput.Items.Add($"Updated from THREAD: {Thread.CurrentThread.Name}");
            LbxOutput.Items.Add(str);
            this.Txt01.Text = str;
        }

        private void BtnClick_Click(object sender, EventArgs e)
        {
            updateTxtboxUI.Start();
            Txt03.Text = Thread.CurrentThread.Name;
        }
    }

}

// C# Quick Tip - Update UI Elements via Separate Thread
// https://www.youtube.com/watch?v=9AIApJmbulY
