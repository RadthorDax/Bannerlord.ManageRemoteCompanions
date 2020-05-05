using HarmonyLib;
using System;
using System.Windows.Forms;
using TaleWorlds.MountAndBlade;
using UIExtenderLib;
using UIExtenderLib.Interface;

namespace ManageRemoteCompanions
{
    internal class Main : MBSubModuleBase
    {
        private UIExtender _extender;

        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();

            _extender = new UIExtender("ManageRemoteCompanions");
            _extender.Register();

            try
            {
                new Harmony("com.radthordax.bannerlord.ManageRemoteCompanions").PatchAll();
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("Exception applying ManageRemoteCompanions Harmony patch:\n{0}", e.ToString()));
            }
        }

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();
            _extender.Verify();
        }
    }
}
