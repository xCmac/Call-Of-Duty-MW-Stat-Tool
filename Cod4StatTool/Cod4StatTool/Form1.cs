using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProcessMemoryReaderLib;
using System.Diagnostics;

namespace Cod4StatTool
{
    public partial class Form1 : Form
    {
        ProcessMemoryReader MemoryReader = new ProcessMemoryReader();
        Process[] CallOfDutyProcess;
        ProcessModule MainModule;
        int BaseAddress;
        bool gamefound = false;

        #region
            //======ASSAULT======
            int m16_marksman = 0xC819C38;
            int m16_expert = 0xC819C3C;

            int ak47_marksman = 0xC819C40;
            int ak47_expert = 0xC819C44;

            int g3_marksman = 0xC819C48;
            int g3_expert = 0xC819C4C;

            int m4_marksman = 0xC819C50;
            int m4_expert = 0xC819C54;

            //int m14_marksman =;
            //int m14_expert =;

            //int g36c_marksman =;
            //int g36c_expert =;

            //int mp44_expert =;
            //======ASSAULT======


            //======SMG======
            int mp5_marksman = 0xC819C88;
            int mp5_expert = 0xC819C8C;

            int skoprion_marksman = 0xC819C90;
            int skoprion_expert = 0xC819C94;

            int miniuzi_marksman = 0xC819C98;
            int miniuzi_expert = 0xC819C9C;

            int ak74u_marksman = 0xC819CA0;
            int aK74u_expert = 0xC819CA4;

            //int p90_marksman =;
            //int p90_expert =;
            //======SMG======


            //======LMG======
            int m249_marksman = 0xC819CD8;
            int m249_expert = 0xC819CDC;

            int rpd_marksman = 0xC819CE0;
            int rpd_expert = 0xC819CE4;

            int m60e4_marksman = 0xC819CE8;
            int m60e4_expert = 0xC819CEC;
            //======LMG======


            //======Shotgun======
            int w1200_marksman = 0xC819D28;
            int w1200_expert = 0xC819D2C;

            //int m1014_marksman =;
            //int m1014_expert =;
            //======Shotgun======


            //======Sniper======
            int m40a3_marksman = 0xC819D80;
            int m40a3_expert = 0xC819D84;

            int m21_marksman = 0xC819D78;
            int m21_expert = 0xC819D7C;

            int dragunov_marksman = 0xC819D88;
            //int dragunov_expert = 0xC819D8C;

            //int r700_marksman =;
            //int r700_expert =;

            //int barrett_marksman =;
            //int barret_expert =;
            //======Sniper======
        #endregion
        public Form1()
        {
            InitializeComponent();      
        }

        private void ProcessTimer_Tick(object sender, EventArgs e)
        {
            if(gamefound)
            {
                ReadChallengeAddresses();
            }
        }

        private void ReadChallengeAddresses()
        {
            Current_M16_M.Text = MemoryReader.ReadUInt(BaseAddress + m16_marksman).ToString();
            Current_M16_E.Text = MemoryReader.ReadUInt(BaseAddress + m16_expert).ToString();
            Current_AK47_M.Text = MemoryReader.ReadUInt(BaseAddress + ak47_marksman).ToString();
            Current_AK47_E.Text = MemoryReader.ReadUInt(BaseAddress + ak47_expert).ToString();
            Current_G3_M.Text = MemoryReader.ReadUInt(BaseAddress + g3_marksman).ToString();
            Current_G3_E.Text = MemoryReader.ReadUInt(BaseAddress + g3_expert).ToString();
            Current_M4_M.Text = MemoryReader.ReadUInt(BaseAddress + m4_marksman).ToString();
            Current_M4_E.Text = MemoryReader.ReadUInt(BaseAddress + m4_expert).ToString();
            //Current_G36C_M.Text = MemoryReader.ReadUInt(BaseAddress + g36c_marksman).ToString();
            //Current_G36C_E.Text = MemoryReader.ReadUInt(BaseAddress + g36c_expert).ToString();
            //Current_MP44_E.Text = MemoryReader.ReadUInt(BaseAddress + mp44_expert).ToString();

            Current_MP5_M.Text = MemoryReader.ReadUInt(BaseAddress + mp5_marksman).ToString();
            Current_MP5_E.Text = MemoryReader.ReadUInt(BaseAddress + mp5_expert).ToString();
            Current_SKORP_M.Text = MemoryReader.ReadUInt(BaseAddress + skoprion_marksman).ToString();
            Current_SKORP_E.Text = MemoryReader.ReadUInt(BaseAddress + skoprion_expert).ToString();
            Current_UZI_M.Text = MemoryReader.ReadUInt(BaseAddress + miniuzi_marksman).ToString();
            Current_UZI_E.Text = MemoryReader.ReadUInt(BaseAddress + miniuzi_expert).ToString();
            Current_AK47U_M.Text = MemoryReader.ReadUInt(BaseAddress + ak74u_marksman).ToString();
            Current_AK47U_E.Text = MemoryReader.ReadUInt(BaseAddress + aK74u_expert).ToString();
            //Current_P90_M.Text = MemoryReader.ReadUInt(BaseAddress + p90_marksman).ToString();
            //Current_P90_E.Text = MemoryReader.ReadUInt(BaseAddress + p90_expert).ToString();
        }

        private void ReadMemory_Click(object sender, EventArgs e)
        {
            try
            {
                CallOfDutyProcess = Process.GetProcessesByName("iw3mp");
                MainModule = CallOfDutyProcess[0].MainModule;
                BaseAddress = CallOfDutyProcess[0].MainModule.BaseAddress.ToInt32();
                MemoryReader.ReadProcess = CallOfDutyProcess[0];
                MemoryReader.OpenProcess();

                gamefound = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Could not read process " + exception.Message);
            }

            ReadMemoryButton.Enabled = false;
        }
    }
}
