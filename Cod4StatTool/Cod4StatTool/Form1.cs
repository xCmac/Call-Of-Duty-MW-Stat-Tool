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
            int m16_marksman;
            int m16_expert;

            int ak47_marksman;
            int ak47_expert;

            int g3_marksman;
            int g3_expert;

            int m4_marksman;
            int m4_expert;

            int m14_marksman;
            int m14_expert;

            int g36c_marksman;
            int g36c_expert;

            int mp44_expert;
            //======ASSAULT======


            //======SMG======
            int mp5_marksman;
            int mp5_expert;

            int skorpion_marksman;
            int skorpion_expert;

            int miniuzi_marksman;
            int miniuzi_expert;

            int ak74u_marksman;
            int aK74u_expert;

            int p90_marksman;
            int p90_expert;
            //======SMG======


            //======LMG======
            int m249_marksman;
            int m249_expert;

            int rpd_marksman;
            int rpd_expert;

            int m60e4_marksman;
            int m60e4_expert;
            //======LMG======


            //======Shotgun======
            int w1200_marksman;
            int w1200_expert;

            int m1014_marksman;
            int m1014_expert;
            //======Shotgun======


            //======Sniper======
            int m40a3_marksman;
            int m40a3_expert;

            int m21_marksman;
            int m21_expert;

            int dragunov_marksman;
            int dragunov_expert;

            int r700_marksman;
            int r700_expert;

            int barrett_marksman;
            int barret_expert;
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
            Current_M16_M.Text = MemoryReader.ReadUInt(m16_marksman).ToString();
            Current_M16_E.Text = MemoryReader.ReadUInt(m16_expert).ToString();
            Current_AK47_M.Text = MemoryReader.ReadUInt(ak47_marksman).ToString();
            Current_AK47_E.Text = MemoryReader.ReadUInt(ak47_expert).ToString();
            Current_G3_M.Text = MemoryReader.ReadUInt(g3_marksman).ToString();
            Current_G3_E.Text = MemoryReader.ReadUInt(g3_expert).ToString();
            Current_M4_M.Text = MemoryReader.ReadUInt(m4_marksman).ToString();
            Current_M4_E.Text = MemoryReader.ReadUInt(m4_expert).ToString();
            Current_M14_M.Text = MemoryReader.ReadUInt(m14_marksman).ToString();
            Current_M14_E.Text = MemoryReader.ReadUInt(m14_expert).ToString();
            Current_G36C_M.Text = MemoryReader.ReadUInt(g36c_marksman).ToString();
            Current_G36C_E.Text = MemoryReader.ReadUInt(g36c_expert).ToString();
            Current_MP44_E.Text = MemoryReader.ReadUInt(mp44_expert).ToString();

            Current_MP5_M.Text = MemoryReader.ReadUInt(mp5_marksman).ToString();
            Current_MP5_E.Text = MemoryReader.ReadUInt(mp5_expert).ToString();
            Current_SKORP_M.Text = MemoryReader.ReadUInt(skorpion_marksman).ToString();
            Current_SKORP_E.Text = MemoryReader.ReadUInt(skorpion_expert).ToString();
            Current_UZI_M.Text = MemoryReader.ReadUInt(miniuzi_marksman).ToString();
            Current_UZI_E.Text = MemoryReader.ReadUInt(miniuzi_expert).ToString();
            Current_AK47U_M.Text = MemoryReader.ReadUInt(ak74u_marksman).ToString();
            Current_AK47U_E.Text = MemoryReader.ReadUInt(aK74u_expert).ToString();
            Current_P90_M.Text = MemoryReader.ReadUInt(p90_marksman).ToString();
            Current_P90_E.Text = MemoryReader.ReadUInt(p90_expert).ToString();

            Current_M249_M.Text = MemoryReader.ReadUInt(m249_marksman).ToString();
            Current_M249_E.Text = MemoryReader.ReadUInt(m249_expert).ToString();
            Current_RPD_M.Text = MemoryReader.ReadUInt(rpd_marksman).ToString();
            Current_RPD_E.Text = MemoryReader.ReadUInt(rpd_expert).ToString();
            Current_M60E4_M.Text = MemoryReader.ReadUInt(m60e4_marksman).ToString();
            Current_M60E4_E.Text = MemoryReader.ReadUInt(m60e4_expert).ToString();

            Current_W1200_M.Text = MemoryReader.ReadUInt(w1200_marksman).ToString();
            Current_W1200_E.Text = MemoryReader.ReadUInt(w1200_expert).ToString();
            Current_M1014_M.Text = MemoryReader.ReadUInt(m1014_marksman).ToString();
            Current_M1014_E.Text = MemoryReader.ReadUInt(m1014_expert).ToString();

            Current_M40A3_M.Text = MemoryReader.ReadUInt(m40a3_marksman).ToString();
            Current_M40A3_E.Text = MemoryReader.ReadUInt(m40a3_expert).ToString();
            Current_M21_M.Text = MemoryReader.ReadUInt(m21_marksman).ToString();
            Current_M21_E.Text = MemoryReader.ReadUInt(m21_expert).ToString();
            Current_DRAGUNOV_M.Text = MemoryReader.ReadUInt(dragunov_marksman).ToString();
            Current_DRAGUNOV_E.Text = MemoryReader.ReadUInt(dragunov_expert).ToString();
            Current_R700_M.Text = MemoryReader.ReadUInt(r700_marksman).ToString();
            Current_R700_E.Text = MemoryReader.ReadUInt(r700_expert).ToString();
            Current_BARRET_M.Text = MemoryReader.ReadUInt(barrett_marksman).ToString();
            Current_BARRET_E.Text = MemoryReader.ReadUInt(barret_expert).ToString();
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

                SetUpChallengeAddresses();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Could not read process " + exception.Message);
            }

            ReadMemoryButton.Enabled = false;
        }

        private void SetUpChallengeAddresses()
        {
            m16_marksman = BaseAddress + 0xC819C38;
            m16_expert = BaseAddress + 0xC819C3C;
            ak47_marksman = BaseAddress + 0xC819C40;
            ak47_expert = BaseAddress + 0xC819C44;
            g3_marksman = BaseAddress + 0xC819C48;
            g3_expert = BaseAddress + 0xC819C4C;
            m4_marksman = BaseAddress + 0xC819C50;
            m4_expert = BaseAddress + 0xC819C54;
            m14_marksman = BaseAddress + 0xC819C58;
            m14_expert = BaseAddress + 0xC819C5C;
            g36c_marksman = BaseAddress + 0xC819C60;
            g36c_expert = BaseAddress + 0xC819C64;
            mp44_expert = BaseAddress + 0xC819C68;
            mp5_marksman = BaseAddress + 0xC819C88;
            mp5_expert = BaseAddress + 0xC819C8C;
            skorpion_marksman = BaseAddress + 0xC819C90;
            skorpion_expert = BaseAddress + 0xC819C94;
            miniuzi_marksman = BaseAddress + 0xC819C98;
            miniuzi_expert = BaseAddress + 0xC819C9C;
            ak74u_marksman = BaseAddress + 0xC819CA0;
            aK74u_expert = BaseAddress + 0xC819CA4;
            p90_marksman = BaseAddress + 0xC819CA8;
            p90_expert = BaseAddress + 0xC819CAC;                        
            m249_marksman = BaseAddress + 0xC819CD8;
            m249_expert = BaseAddress + 0xC819CDC;
            rpd_marksman = BaseAddress + 0xC819CE0;
            rpd_expert = BaseAddress + 0xC819CE4;
            m60e4_marksman = BaseAddress + 0xC819CE8;
            m60e4_expert = BaseAddress + 0xC819CEC;            
            w1200_marksman = BaseAddress + 0xC819D28;
            w1200_expert = BaseAddress + 0xC819D2C;
            m1014_marksman = BaseAddress + 0xC819D30;
            m1014_expert = BaseAddress + 0xC819D34;
            m40a3_marksman = BaseAddress + 0xC819D80;
            m40a3_expert = BaseAddress + 0xC819D84;
            m21_marksman = BaseAddress + 0xC819D78;
            m21_expert = BaseAddress + 0xC819D7C;
            dragunov_marksman = BaseAddress + 0xC819D88;
            dragunov_expert = BaseAddress + 0xC819D8C;
            r700_marksman = BaseAddress + 0xC819D90;
            r700_expert = BaseAddress + 0xC819D94;
            barrett_marksman = BaseAddress + 0xC819D98;
            barret_expert = BaseAddress + 0xC819D9C;
        }

        private void ValidateAndWriteToMemory(int addressToWriteTo, TextBox textBox, KeyEventArgs e)
        {
            uint inputToWrite;
            bool isValidInput = true;
            if (e.KeyCode == Keys.Enter)
            {
                isValidInput = uint.TryParse(textBox.Text, out inputToWrite);
                if (isValidInput)
                {
                    MemoryReader.WriteUInt(addressToWriteTo, inputToWrite);
                }

                textBox.Clear();
            }
            if (!isValidInput)
            {
                MessageBox.Show("Invalid Input");
                textBox.Clear();
                return;
            }
        }

        private void TB_M16_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(m16_marksman, TB_M16_M, e);        
        }

        private void TB_M16_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(m16_expert, TB_M16_E, e);
        }

        private void TB_AK47_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(ak47_marksman, TB_AK47_M, e);
        }

        private void TB_AK47_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(ak47_expert, TB_AK47_E, e);
        }

        private void TB_G3_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(g3_marksman, TB_G3_M, e);
        }

        private void TB_G3_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(g3_expert, TB_G3_E, e);
        }

        private void TB_M4_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(m4_marksman, TB_M4_M, e);
        }

        private void TB_M4_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(m4_expert, TB_M4_E, e);
        }

        private void TB_M14_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(m14_marksman, TB_M14_M, e);
        }

        private void TB_M14_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(m14_expert, TB_M14_E, e);
        }

        private void TB_G36C_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(g36c_marksman, TB_G36C_M, e);
        }

        private void TB_G36C_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(g36c_expert, TB_G36C_E, e);
        }

        private void TB_MP44_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(mp44_expert, TB_MP44_E, e);
        }

        private void TB_MP5_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(mp5_marksman, TB_MP5_M, e);
        }

        private void TB_MP5_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(mp5_expert, TB_MP5_E, e);
        }

        private void TB_SKORP_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(skorpion_marksman, TB_SKORP_M, e);
        }

        private void TB_SKORP_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(skorpion_expert, TB_SKORP_E, e);
        }

        private void TB_UZI_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(miniuzi_marksman, TB_UZI_M, e);
        }

        private void TB_UZI_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(miniuzi_expert, TB_UZI_E, e);
        }

        private void TB_AK47U_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(ak74u_marksman, TB_AK47U_M, e);
        }

        private void TB_AK47U_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(aK74u_expert, TB_AK47U_E, e);
        }

        private void TB_P90_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(p90_marksman, TB_P90_M, e);
        }

        private void TB_P90_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(p90_expert, TB_P90_E, e);
        }

        private void TB_M249_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(m249_marksman, TB_M249_M, e);
        }

        private void TB_M249_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(m249_expert, TB_M249_E, e);
        }

        private void TB_RPD_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(rpd_marksman, TB_RPD_M, e);
        }

        private void TB_RPD_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(rpd_expert, TB_RPD_E, e);
        }

        private void TB_M60E4_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(m60e4_marksman, TB_M60E4_M, e);
        }

        private void TB_M60E4_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(m60e4_expert, TB_M60E4_E, e);
        }

        private void TB_W1200_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(w1200_marksman, TB_W1200_M, e);
        }

        private void TB_W1200_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(w1200_expert, TB_W1200_E, e);
        }

        private void TB_M1014_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(m1014_marksman, TB_M1014_M, e);
        }

        private void TB_M1014_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(m1014_expert, TB_M1014_E, e);
        }

        private void TB_M40A3_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(m40a3_marksman, TB_M40A3_M, e);
        }

        private void TB_M40A3_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(m40a3_expert, TB_M40A3_E, e);
        }

        private void TB_M21_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(m21_marksman, TB_M21_M, e);
        }

        private void TB_M21_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(m21_expert, TB_M21_E, e);
        }

        private void TB_DRAGUNOV_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(dragunov_marksman, TB_DRAGUNOV_M, e);
        }

        private void TB_DRAGUNOV_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(dragunov_expert, TB_DRAGUNOV_E, e);
        }

        private void TB_R700_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(r700_marksman, TB_R700_M, e);
        }

        private void TB_R700_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(r700_expert, TB_R700_E, e);
        }

        private void TB_BARRET_M_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(barrett_marksman, TB_BARRET_M, e);
        }

        private void TB_BARRET_E_KeyDown(object sender, KeyEventArgs e)
        {
            ValidateAndWriteToMemory(barret_expert, TB_BARRET_E, e);
        }
    }
}
