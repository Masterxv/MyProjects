﻿using System;
using Microsoft.Win32;
using System.Windows.Forms;
using NvAPIWrapper.GPU;
using System.Text;

namespace CommonInfo
{
    public partial class FormInfoPC : Form
    {
        private readonly StringBuilder sb = new StringBuilder();
        private readonly object[] GPU_Info = PhysicalGPU.GetPhysicalGPUs();
        public FormInfoPC()
        {
            InitializeComponent();
        }

        private void FormInfoPC_Load(object sender, EventArgs e)
        {
            var infoPC = new PCInformation();
            string releaseId = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ReleaseId", "").ToString(); // ~1809 version windows
            label_totalRam.Text = "TotalRAM: " + infoPC.totalRAMGlobal + " Mb";
            label_useRam.Text = "UseRAM: " + infoPC.useRAMGlobal + " Mb" + " (" + infoPC.percentUseRAMGlobal + "%)";
            label_captionWin.Text = infoPC.captionWindowsGlobal + " (" + infoPC.OSArchitectureGlobal + ")" + " | Version: " + releaseId + " | Build(" + infoPC.versionGlobal + ")";
            label_totalVirtualMemory.Text = "TotalVirtualMemory: " + infoPC.totalVirtualMemoryGlobal + " Mb";
            label_selectedVirtualMemory.Text = "SelectedVirtualMemory: " + infoPC.selectedVirtualMemoryGlobal + 
                " Mb" + " (" + infoPC.percentUseVirtualMemoryGlobal + "%)";
            label_captionProcessor.Text = "CPU Name: " + infoPC.captionProcessorGlobal;
            label_numCores.Text = "Count Cores: " + infoPC.numberOfCoresGlobal;
            label_nameUser.Text = "User Name: " + infoPC.nameUserGlobal;
            label_nameComputer.Text = "Computer Name: " + infoPC.nameComputerGlobal;
            label_productKey.Text = "Product-key: " + infoPC.serialNumberGlobal;
            label_captionMotherBoard.Text = "Model: " + infoPC.captionMotherBoardGlobal;
            label_companyMotherBoard.Text = infoPC.companyMotherBoardGlobal;
            label_captionVideoCard.Text = infoPC.captionVideoAdapterGlobal;
            if (infoPC.captionVideoAdapterGlobal.Contains("NVIDIA"))
            {
                object[] a = { 1 };
                label_CoolerInforamtion.Text = GPU_Info[0].GetType().GetProperty("CoolerInformation").GetValue(GPU_Info[0], null) + "\n";
                label_BusInfromation.Text = GPU_Info[0].GetType().GetProperty("BusInformation").GetValue(GPU_Info[0], null) + "\n";
                label_MemoryInformation.Text = GPU_Info[0]
                    .GetType()
                    .GetProperty("MemoryInformation")
                    .GetType()
                    .GetProperty("AvailableDedicatedVideoMemoryInkB")
                    .GetValue(GPU_Info[0], null)
                    + "\n";
            }
            else
            {
                MessageBox.Show("///Work only NVIDIA-family///", "Err0R");
            }
        }

        private void btn_exitFormPCInfo_Click(object sender, EventArgs e)
        {
            var F_Main = new MainForm();
            F_Main.Show();
            this.Hide();
        }
    }
}
