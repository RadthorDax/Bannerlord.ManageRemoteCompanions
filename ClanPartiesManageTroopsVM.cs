//using System;
//using System.Collections.Generic;
//using System.Text;
//using TaleWorlds.CampaignSystem;
//using TaleWorlds.CampaignSystem.ViewModelCollection.ClanManagement.Categories;
//using TaleWorlds.Core;
//using TaleWorlds.Library;

//namespace ManageRemoteCompanions
//{
//    public class ClanPartiesManageTroopsVM : ClanPartiesVM
//    {
//        public ClanPartiesManageTroopsVM(Action onExpenseChange, Action<MobileParty> openPartyAsManage, Action onRefresh) :
//            base(onExpenseChange, openPartyAsManage, onRefresh)
//        { }

//        private bool _canManageTroops;

//        public void ExecuteManageTroops()
//        {
//            InformationManager.DisplayMessage(new InformationMessage("ClanPartiesMixin.ExecuteManageCurrentParty()"));
//            if (CanManageTroops)
//                PartyScreenManager.OpenScreenAsManageTroops(CurrentSelectedParty.Party.MobileParty);
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
//}
