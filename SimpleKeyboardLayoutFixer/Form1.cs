using System;
using System.Windows.Forms;
using System.Management.Automation;
/// <summary>
///  NuGet package used -> https://www.nuget.org/packages/Cake.Powershell
///  Languages codes list -> http://www.lingoes.net/en/translator/langcode.htm
/// </summary>

namespace SimpleKeyboardLayoutFixer
{
    public partial class Form1 : Form
    {
        public PowerShell powerShell;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            powerShell = PowerShell.Create();
            while (true)
            {
                string userSpecifiedLanguageTwoLetterCode = InputLanguage.CurrentInputLanguage.Culture.TwoLetterISOLanguageName;
                switch (userSpecifiedLanguageTwoLetterCode)
                {
                    case "ru":
                        powerShell.AddScript("Set-WinUserLanguageList -LanguageList ru, en-US -Force").Invoke();
                        break;
                    case "en":
                        powerShell.AddScript("Set-WinUserLanguageList -LanguageList en-US, ru -Force").Invoke();
                        break;
                }
                System.Threading.Thread.Sleep(900000);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) => powerShell.Dispose();
    }
}
