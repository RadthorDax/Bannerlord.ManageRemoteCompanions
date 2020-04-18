using HarmonyLib;
using System;
using System.Windows.Forms;
using TaleWorlds.MountAndBlade;

namespace UpgradeRemoteCompanions
{
    internal class Main : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();

            try
            {
                new Harmony("com.radthordax.bannerlord.UpgradeRemoteCompanions").PatchAll();
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("Exception applying UpgradeRemoteCompanions Harmony patch:\n{0}", e.ToString()));
            }
        }
    }
}
