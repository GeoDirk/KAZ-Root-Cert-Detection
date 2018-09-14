using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KAZ_Root_Cert_Detector
{
    public partial class frmMain : Form
    {
        private List<string> _sCertThumb = new List<string>();
        private bool _Eng = true;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lvCerts.Columns[0].Width = 210;
            lvCerts.Columns[1].Width = 200;
            lvCerts.Columns[2].Width = 100;
            lvCerts.Columns[3].Width = 280;
            lvCerts.Columns[4].Width = 220;
            lvCerts.Columns[5].Width = 200;

            CultureInfo ci = CultureInfo.InstalledUICulture;
            if (ci.Name == "ru-RU")
            {
                _Eng = false;
            }
            SetGUIlang();
        }

        private void SetGUIlang()
        {
            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            if (_Eng == true)
            {
                this.Text = "Kazakhstan Root Cert Detection   Version: " + version.ToString();

                btnClose.Text = "Close";
                btnRemoveCerts.Text = "Remove KAZ Root Certificates";
                lvCerts.Columns[0].Text = "Friendly Name";
                lvCerts.Columns[1].Text = "Issuer";
                lvCerts.Columns[2].Text = "Expiration Date";
                lvCerts.Columns[3].Text = "Thumb Print";
                lvCerts.Columns[4].Text = "Serial Number";
                lvCerts.Columns[5].Text = "Store Location";
            }
            else
            {
                this.Text = "Kazakhstan Root Cert Detection   версия: " + version.ToString();

                btnClose.Text = "Закрыть";
                btnRemoveCerts.Text = "Удалить Казахстанские корневые сертификаты";
                lvCerts.Columns[0].Text = "Дружественное имя";
                lvCerts.Columns[1].Text = "Кем был выпущен";
                lvCerts.Columns[2].Text = "Дата окончания действия";
                lvCerts.Columns[3].Text = "Отпечаток";
                lvCerts.Columns[4].Text = "Серийный номер";
                lvCerts.Columns[5].Text = "Место хранения";
            }
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            DetectCerts();

            DetectAutoRun();
        }

        /// <summary>
        /// detect the NCALayer program in the auto run
        /// </summary>
        private void DetectAutoRun()
        {
            string s = Environment.GetFolderPath(Environment.SpecialFolder.Startup);

            string[] files = Directory.GetFiles(s);

            foreach (var f in files)
            {
                if (f.Contains("NCALayer"))
                {
                    if (_Eng == true)
                    {
                        MessageBox.Show("NCALayer detected on startup");
                    }
                    else
                    {
                        MessageBox.Show("NCALayer обнаружен при запуске");
                    }
                }
            }
        }

        private void DetectCerts(bool bMsg = true)
        {
            int iDetected = 0;

            lvCerts.Items.Clear();
            _sCertThumb = new List<string>();

            //open the ROOT store of the CurrentUser and iterate through the certs
            var store = new X509Store(StoreName.Root, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            foreach (X509Certificate2 c in store.Certificates)
            {
                ListViewItem item = new ListViewItem(c.FriendlyName);
                item.SubItems.Add(c.Issuer);
                item.SubItems.Add(c.NotAfter.Date.ToShortDateString());
                item.SubItems.Add(c.Thumbprint);
                item.SubItems.Add(c.SerialNumber);
                item.SubItems.Add(store.Location + "/" + store.Name);
                lvCerts.Items.Add(item);

                //check for KAZ CN
                if (c.Issuer.Contains("C=KZ,"))
                {
                    lvCerts.Items[lvCerts.Items.Count - 1].BackColor = Color.Red;
                    _sCertThumb.Add(c.Thumbprint);
                    iDetected++;
                }

            }
            store.Close();

            //KAZ certs found
            if (iDetected > 0 && bMsg)
            {
                this.btnRemoveCerts.Enabled = true;
            }
            else
            {
                string sTmp = "NO Kazakhstan Root Certificated detected";
                string sTmpHeader = "Root Certs NOT Detected";
                if (_Eng != true)
                {
                    sTmp = "Казахстанского корневого сертификата  обнаружено не было";
                    sTmpHeader = "Корневых сертификатов  обнаружено не было";
                }
                MessageBox.Show(sTmp, sTmpHeader, MessageBoxButtons.OK);
            }

        }

        /// <summary>
        /// Remove the KAZ certs
        /// </summary>
        private void RemoveKAZrootCerts()
        {
            var store = new X509Store(StoreName.Root, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadWrite);

            foreach (string sThumb in _sCertThumb)
            {
                X509Certificate2Collection col = store.Certificates.Find(X509FindType.FindByThumbprint, sThumb, false);

                X509Chain ch = new X509Chain();

                if (col.Count > 0)
                {
                    ch.Build(col[0]);
                    X509Certificate2Collection allCertsInChain = new X509Certificate2Collection();

                    foreach (X509ChainElement el in ch.ChainElements)
                    {
                        allCertsInChain.Add(el.Certificate);
                    }
                    store.RemoveRange(allCertsInChain);
                }
            }
            store.Close();

            DetectCerts(false);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRemoveCerts_Click(object sender, EventArgs e)
        {
            string sTmp = "Do you wish to remove the Kazakhstan Root Certificates and disable the launcher program for them?";
            string sTmpHeader = "Root Certs Detected";
            if (_Eng != true)
            {
                sTmp = "Вы хотите удалить Казахстанские корневые сертификаты и отключить программу их запуска?";
                sTmpHeader = "Обнаружены корневые сертификаты";
            }

            DialogResult dr = MessageBox.Show(sTmp, sTmpHeader, MessageBoxButtons.YesNo);
            if (dr == DialogResult.No)
            {
                return;
            }


            //kill NCALayer program in memory
            foreach (var process in Process.GetProcessesByName("NCALayer"))
            {
                process.Kill();
                if (_Eng)
                {
                    MessageBox.Show("NCALayer.exe program removed from memory");
                }
                else
                {
                    MessageBox.Show("Программа NCALayer.exe была удалена из памяти");
                }
                
            }

            //stop the java tray icon
            foreach (var process in Process.GetProcessesByName("javaw"))
            {
                process.Kill();
                if (_Eng)
                {
                    MessageBox.Show("NCALayer program removed from Window's Tray");
                }
                else
                {
                    MessageBox.Show("Программа NCALayer.exe была удалена из системного лотка Windows");
                }
            }


            //remove the startup link
            string[] files = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Startup));
            foreach (var f in files)
            {
                if (f.Contains("NCALayer"))
                {
                    File.Delete(f);
                }
            }


            //remove the KAZ certs
            RemoveKAZrootCerts();
            if (_Eng)
            {
                MessageBox.Show("Completed!");
            }
            else
            {
                MessageBox.Show("Завершено!");
            }
        }

        private void picRU_Click(object sender, EventArgs e)
        {
            _Eng = false;
            SetGUIlang();
        }

        private void picUS_Click(object sender, EventArgs e)
        {
            _Eng = true;
            SetGUIlang();
        }
    }
}
