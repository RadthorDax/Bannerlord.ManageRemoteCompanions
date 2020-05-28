using HarmonyLib;
using System;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection.ClanManagement;
using TaleWorlds.CampaignSystem.ViewModelCollection.ClanManagement.Categories;

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
}