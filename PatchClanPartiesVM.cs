using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection.Map;
using TaleWorlds.CampaignSystem.ViewModelCollection.ClanManagement;
using TaleWorlds.CampaignSystem.ViewModelCollection.ClanManagement.Categories;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using System.ComponentModel;

namespace ManageRemoteCompanions
{
    [HarmonyPatch(typeof(ClanPartiesVM), "OnPartySelection")]
    public class PatchClanPartiesVM
    {
        public static void Postfix(ClanPartiesVM __instance)
        {
            if (canManageTroops(__instance.CurrentSelectedParty))
                PartyScreenManager.OpenScreenAsManageTroops(__instance.CurrentSelectedParty.Party.MobileParty);
        }

        private static bool canManageTroops(ClanPartyItemVM p)
        {
            if (p != null && p.Party != null && p.Party.MobileParty != null && Settings.Instance.ManageTroops)
            {
                if (p.Party.MobileParty.IsGarrison)
                    return Settings.Instance.ManageGarrisons;
                else if (p.Party.MobileParty.IsCaravan)
                    return Settings.Instance.ManageCaravans;
                else if (p.Party.MobileParty.LeaderHero != Hero.MainHero)
                    return Settings.Instance.ManageParties;
            }
            return false;
        }
    }

//    [HarmonyPatch(typeof(ClanPartiesVM), "OnPartySelection")]
//    public class PatchClanPartiesVM
//    {
//        public static EventHandler<EventArgs> OnPartySelection;

//        public static void Postfix()
//        {
//            OnPartySelection?.Invoke(null, new EventArgs());
//        }
//    }

//    public class ManageTroopsVM : ViewModel
//    {
//        private ClanPartiesVM _clanPartiesVM;
//        private bool _canManageTroops;

//        public ManageTroopsVM(ClanPartiesVM clanPartiesVM)
//        {
//            _clanPartiesVM = clanPartiesVM;
//            PatchClanPartiesVM.OnPartySelection += new EventHandler<EventArgs>(Refresh);
//        }

//        public void Refresh(object sender, EventArgs e)
//        {
//            CanManageTroops = calculateCanManageTroops(_clanPartiesVM.CurrentSelectedParty);
//        }

//        private bool calculateCanManageTroops(ClanPartyItemVM p)
//        {
//            if (p != null && p.Party != null && p.Party.MobileParty != null && Settings.Instance.ManageTroops)
//            {
//                if (p.Party.MobileParty.IsGarrison)
//                    return Settings.Instance.ManageGarrisons;
//                else if (p.Party.MobileParty.IsCaravan)
//                    return Settings.Instance.ManageCaravans;
//                else if (p.Party.MobileParty.LeaderHero != Hero.MainHero)
//                    return Settings.Instance.ManageParties;
//            }
//            return false;
//        }

//        public void ExecuteManageTroops()
//        {
//            InformationManager.DisplayMessage(new InformationMessage("ClanPartiesMixin.ExecuteManageCurrentParty()"));
//            if (CanManageTroops)
//                PartyScreenManager.OpenScreenAsManageTroops(_clanPartiesVM.CurrentSelectedParty.Party.MobileParty);
//        }

//        [DataSourceProperty]
//        public bool CanManageTroops
//        {
//            get
//            {
//                return _canManageTroops;
//            }
//            set
//            {
//                if (value == _canManageTroops)
//                    return;
//                _canManageTroops = value;
//                OnPropertyChanged(nameof(CanManageTroops));
//            }
//        }
//    }
}