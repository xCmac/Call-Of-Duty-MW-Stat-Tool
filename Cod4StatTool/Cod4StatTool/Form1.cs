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

            int m14_marksman = 0xC819C58;
            int m14_expert = 0xC819C5C;

            int g36c_marksman = 0xC819C60;
            int g36c_expert = 0xC819C64;

            int mp44_expert = 0xC819C68;
            //======ASSAULT======


            //======SMG======
            int mp5_marksman = 0xC819C88;
            int mp5_expert = 0xC819C8C;

            int skorpion_marksman = 0xC819C90;
            int skorpion_expert = 0xC819C94;

            int miniuzi_marksman = 0xC819C98;
            int miniuzi_expert = 0xC819C9C;

            int ak74u_marksman = 0xC819CA0;
            int aK74u_expert = 0xC819CA4;

            int p90_marksman = 0xC819CA8;
            int p90_expert = 0xC819CAC;
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

            int m1014_marksman = 0xC819D30;
            int m1014_expert = 0xC819D34;
            //======Shotgun======


            //======Sniper======
            int m40a3_marksman = 0xC819D80;
            int m40a3_expert = 0xC819D84;

            int m21_marksman = 0xC819D78;
            int m21_expert = 0xC819D7C;

            int dragunov_marksman = 0xC819D88;
            int dragunov_expert = 0xC819D8C;

            int r700_marksman = 0xC819D90;
            int r700_expert = 0xC819D94;

            int barrett_marksman = 0xC819D98;
            int barret_expert = 0xC819D9C;
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
            Current_M14_M.Text = MemoryReader.ReadUInt(BaseAddress + m14_marksman).ToString();
            Current_M14_E.Text = MemoryReader.ReadUInt(BaseAddress + m14_expert).ToString();
            Current_G36C_M.Text = MemoryReader.ReadUInt(BaseAddress + g36c_marksman).ToString();
            Current_G36C_E.Text = MemoryReader.ReadUInt(BaseAddress + g36c_expert).ToString();
            Current_MP44_E.Text = MemoryReader.ReadUInt(BaseAddress + mp44_expert).ToString();

            Current_MP5_M.Text = MemoryReader.ReadUInt(BaseAddress + mp5_marksman).ToString();
            Current_MP5_E.Text = MemoryReader.ReadUInt(BaseAddress + mp5_expert).ToString();
            Current_SKORP_M.Text = MemoryReader.ReadUInt(BaseAddress + skorpion_marksman).ToString();
            Current_SKORP_E.Text = MemoryReader.ReadUInt(BaseAddress + skorpion_expert).ToString();
            Current_UZI_M.Text = MemoryReader.ReadUInt(BaseAddress + miniuzi_marksman).ToString();
            Current_UZI_E.Text = MemoryReader.ReadUInt(BaseAddress + miniuzi_expert).ToString();
            Current_AK47U_M.Text = MemoryReader.ReadUInt(BaseAddress + ak74u_marksman).ToString();
            Current_AK47U_E.Text = MemoryReader.ReadUInt(BaseAddress + aK74u_expert).ToString();
            Current_P90_M.Text = MemoryReader.ReadUInt(BaseAddress + p90_marksman).ToString();
            Current_P90_E.Text = MemoryReader.ReadUInt(BaseAddress + p90_expert).ToString();

            Current_M249_M.Text = MemoryReader.ReadUInt(BaseAddress + m249_marksman).ToString();
            Current_M249_E.Text = MemoryReader.ReadUInt(BaseAddress + m249_expert).ToString();
            Current_RPD_M.Text = MemoryReader.ReadUInt(BaseAddress + rpd_marksman).ToString();
            Current_RPD_E.Text = MemoryReader.ReadUInt(BaseAddress + rpd_expert).ToString();
            Current_M60E4_M.Text = MemoryReader.ReadUInt(BaseAddress + m60e4_marksman).ToString();
            Current_M60E4_E.Text = MemoryReader.ReadUInt(BaseAddress + m60e4_expert).ToString();

            Current_W1200_M.Text = MemoryReader.ReadUInt(BaseAddress + w1200_marksman).ToString();
            Current_W1200_E.Text = MemoryReader.ReadUInt(BaseAddress + w1200_expert).ToString();
            Current_M1014_M.Text = MemoryReader.ReadUInt(BaseAddress + m1014_marksman).ToString();
            Current_M1014_E.Text = MemoryReader.ReadUInt(BaseAddress + m1014_expert).ToString();

            Current_M40A3_M.Text = MemoryReader.ReadUInt(BaseAddress + m40a3_marksman).ToString();
            Current_M40A3_E.Text = MemoryReader.ReadUInt(BaseAddress + m40a3_expert).ToString();
            Current_M21_M.Text = MemoryReader.ReadUInt(BaseAddress + m21_marksman).ToString();
            Current_M21_E.Text = MemoryReader.ReadUInt(BaseAddress + m21_expert).ToString();
            Current_DRAGUNOV_M.Text = MemoryReader.ReadUInt(BaseAddress + dragunov_marksman).ToString();
            Current_DRAGUNOV_E.Text = MemoryReader.ReadUInt(BaseAddress + dragunov_expert).ToString();
            Current_R700_M.Text = MemoryReader.ReadUInt(BaseAddress + r700_marksman).ToString();
            Current_R700_E.Text = MemoryReader.ReadUInt(BaseAddress + r700_expert).ToString();
            Current_BARRET_M.Text = MemoryReader.ReadUInt(BaseAddress + barrett_marksman).ToString();
            Current_BARRET_E.Text = MemoryReader.ReadUInt(BaseAddress + barret_expert).ToString();
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

        private void ValidateAndWriteToMemory(int addressToWriteTo, String textBoxText, KeyEventArgs e)
        {
            uint inputToWrite;
            bool isValidInput = true;
            if (e.KeyCode == Keys.Enter)
            {
                isValidInput = uint.TryParse(textBoxText, out inputToWrite);
                if (isValidInput)
                {
                    MemoryReader.WriteUInt(addressToWriteTo, inputToWrite);
                }
            }
            if (!isValidInput)
            {
                MessageBox.Show("Invalid Input");
                return;
            }
        }

        private void TB_M16_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + m16_marksman, TB_M16_M.Text, e);
        }

        private void TB_M16_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + m16_expert, TB_M16_E.Text, e);
        }

        private void TB_AK47_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + ak47_marksman, TB_AK47_M.Text, e);
        }

        private void TB_AK47_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + ak47_expert, TB_AK47_E.Text, e);
        }

        private void TB_G3_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + g3_marksman, TB_G3_M.Text, e);
        }

        private void TB_G3_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + g3_expert, TB_G3_E.Text, e);
        }

        private void TB_M4_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + m4_marksman, TB_M4_M.Text, e);
        }

        private void TB_M4_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + m4_expert, TB_M4_E.Text, e);
        }

        private void TB_M14_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + m14_marksman, TB_M14_M.Text, e);
        }

        private void TB_M14_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + m14_expert, TB_M14_E.Text, e);
        }

        private void TB_G36C_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + g36c_marksman, TB_G36C_M.Text, e);
        }

        private void TB_G36C_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + g36c_expert, TB_G36C_E.Text, e);
        }

        private void TB_MP44_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + mp44_expert, TB_MP44_E.Text, e);
        }

        private void TB_MP5_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + mp5_marksman, TB_MP5_M.Text, e);
        }

        private void TB_MP5_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + mp5_expert, TB_MP5_E.Text, e);
        }

        private void TB_SKORP_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + skorpion_marksman, TB_SKORP_M.Text, e);
        }

        private void TB_SKORP_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + skorpion_expert, TB_SKORP_E.Text, e);
        }

        private void TB_UZI_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + miniuzi_marksman, TB_UZI_M.Text, e);
        }

        private void TB_UZI_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + miniuzi_expert, TB_UZI_E.Text, e);
        }

        private void TB_AK47U_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + ak74u_marksman, TB_AK47U_M.Text, e);
        }

        private void TB_AK47U_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + aK74u_expert, TB_AK47U_E.Text, e);
        }

        private void TB_P90_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + p90_marksman, TB_P90_M.Text, e);
        }

        private void TB_P90_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + p90_expert, TB_P90_E.Text, e);
        }

        private void TB_M249_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + m249_marksman, TB_M249_M.Text, e);
        }

        private void TB_M249_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + m249_expert, TB_M249_E.Text, e);
        }

        private void TB_RPD_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + rpd_marksman, TB_RPD_M.Text, e);
        }

        private void TB_RPD_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + rpd_expert, TB_RPD_E.Text, e);
        }

        private void TB_M60E4_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + m60e4_marksman, TB_M60E4_M.Text, e);
        }

        private void TB_M60E4_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + m60e4_expert, TB_M60E4_E.Text, e);
        }

        private void TB_W1200_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + w1200_marksman, TB_W1200_M.Text, e);
        }

        private void TB_W1200_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + w1200_expert, TB_W1200_E.Text, e);
        }

        private void TB_M1014_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + m1014_marksman, TB_M1014_M.Text, e);
        }

        private void TB_M1014_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + m1014_expert, TB_M1014_E.Text, e);
        }

        private void TB_M40A3_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + m40a3_marksman, TB_M40A3_M.Text, e);
        }

        private void TB_M40A3_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + m40a3_expert, TB_M40A3_E.Text, e);
        }

        private void TB_M21_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + m21_marksman, TB_M21_M.Text, e);
        }

        private void TB_M21_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + m21_expert, TB_M21_E.Text, e);
        }

        private void TB_DRAGUNOV_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + dragunov_marksman, TB_DRAGUNOV_M.Text, e);
        }

        private void TB_DRAGUNOV_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + dragunov_expert, TB_DRAGUNOV_E.Text, e);
        }

        private void TB_R700_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + r700_marksman, TB_R700_M.Text, e);
        }

        private void TB_R700_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + r700_expert, TB_R700_E.Text, e);
        }

        private void TB_BARRET_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + barrett_marksman, TB_BARRET_M.Text, e);
        }

        private void TB_BARRET_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(BaseAddress + barret_expert, TB_BARRET_E.Text, e);
        }
    }
}
