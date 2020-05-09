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

namespace ManageRemoteCompanions
{
    public class ManageTroopsVM : ViewModel
    {
        private ClanPartyItemVM _currentSelectedParty;
        private bool _canManageTroops;
        [DataSourceProperty] public bool CanManageTroops => _canManageTroops;


        private bool calculateCanManageTroops(ClanPartyItemVM p)
        {
            if (p != null && p.Party != null && p.Party.MobileParty != null)
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

        public void 

        public void ExecuteManageTroops()
        {
            InformationManager.DisplayMessage(new InformationMessage("ClanPartiesMixin.ExecuteManageCurrentParty()"));
            if (CanManageTroops)
                PartyScreenManager.OpenScreenAsManageTroops(_currentSelectedParty.Party.MobileParty);
        }

    }


}