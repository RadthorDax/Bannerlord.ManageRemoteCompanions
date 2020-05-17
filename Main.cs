using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SandBox.GauntletUI;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.Engine.Screens;
using TaleWorlds.MountAndBlade;
using TaleWorlds.CampaignSystem.ViewModelCollection.ClanManagement;
using TaleWorlds.CampaignSystem.ViewModelCollection.ClanManagement.Categories;
using System.Reflection;
using TaleWorlds.Library;
using TaleWorlds.Core;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace ManageRemoteCompanions
{
    internal class Main : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();

            try
            {
                new Harmony("com.radthordax.bannerlord.ManageRemoteCompanions").PatchAll();
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("Exception applying ManageRemoteCompanions Harmony patch:\n{0}", e.ToString()));
            }

            //ScreenManager.OnPushScreen += new ScreenManager.OnPushScreenEvent(OnPushScreen);
        }

        //protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        //{
        //    if (!(game.GameType is Campaign))
        //        return;

        //    if (!(gameStarterObject.Models is IList<GameModel> models))
        //        return;

        //    for (int i = 0; i < models.Count; ++i)
        //        if (models[i] is ClanPartiesVM)
        //            models[i] = Activator.CreateInstance<ClanPartiesManageTroopsVM>();

        //}

        //private void OnPushScreen(ScreenBase screen)
        //{
        //    if (!(screen is GauntletClanScreen))
        //        return;

        //    ClanVM clanVM = (ClanVM)typeof(GauntletClanScreen).GetField("_dataSource", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(screen);
        //    ClanPartiesVM clanPartiesVM = (ClanPartiesVM)typeof(ClanVM).GetField("_clanParties", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(clanVM);
        //    ManageTroopsVM manageTroopsVM = new ManageTroopsVM(clanPartiesVM);

        //    GauntletLayer layer = new GauntletLayer(288);
        //    layer.Name = "ManageTroops";
        //    layer.LoadMovie("ManageTroops", manageTroopsVM);
        //    layer.InputRestrictions.SetInputRestrictions(false, InputUsageMask.MouseButtons);

        //    screen.AddLayer(layer);
        //}
    }
}
