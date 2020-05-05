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
using UIExtenderLib;
using UIExtenderLib.Prefab;
using UIExtenderLib.CodePatcher;
using UIExtenderLib.CodePatcher.StaticLibrary;
using UIExtenderLib.Interface;

namespace ManageRemoteCompanions
{
    [PrefabExtension("ClanParties", "descendant::ListPanel[@Id='ClanPartiesWidget']/Children/ListPanel/Children/Widget/Children/Widget/Children/ListPanel/Children/ListPanel[last()]/Children")]
    public class ClanPartyPrefab : PrefabExtensionInsertPatch
    {
        public override int Position => PositionFirst;
        public override string Name => "ManageRemoteCompanions";
    }

    [ViewModelMixin]
    public class ClanPartiesMixin : BaseViewModelMixin<ClanPartiesVM>
    {
        private ClanPartyItemVM _currentSelectedParty;
        private bool _canManageCurrentParty;
        [DataSourceProperty] public bool CanManageCurrentParty => _canManageCurrentParty;

        public ClanPartiesMixin(ClanPartiesVM vm) : base(vm)
        {
            InformationManager.DisplayMessage(new InformationMessage("ClanPartiesMixin.Constructor()"));
            _currentSelectedParty = vm.CurrentSelectedParty;
            _canManageCurrentParty = calculateCanManageParty(vm.CurrentSelectedParty);
        }

        public override void OnRefresh()
        {
            InformationManager.DisplayMessage(new InformationMessage("ClanPartiesMixin.OnRefresh()"));

            if (_vm.TryGetTarget(out ClanPartiesVM vm))
            {
                if (_currentSelectedParty != vm.CurrentSelectedParty)
                    _currentSelectedParty = vm.CurrentSelectedParty;

                bool permission = calculateCanManageParty(vm.CurrentSelectedParty);
                if (permission != _canManageCurrentParty)
                {
                    _canManageCurrentParty = permission;
                    vm.OnPropertyChanged(nameof(CanManageCurrentParty));
                }
            }
        }

        private bool calculateCanManageParty(ClanPartyItemVM p)
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

        [DataSourceMethod]
        public void ExecuteManageCurrentParty()
        {
            InformationManager.DisplayMessage(new InformationMessage("ClanPartiesMixin.ExecuteManageCurrentParty()"));
            if (CanManageCurrentParty)
                PartyScreenManager.OpenScreenAsManageTroops(_currentSelectedParty.Party.MobileParty);
        }

    }


    internal class ClanPartiesVMPatch
    {
        internal enum Result : int
        {
            Success = 1,
            Failure = 2,
            Partial = 3,
        }

        private static Result CharacterVMPatch(CodePatcherComponent comp)
        {
            var callsite = typeof(ClanPartiesVM).GetConstructor(new Type[] { typeof(Action) });
            if (callsite == null)
            {
                return Result.Failure;
            }

            var refresh = typeof(ClanPartiesVM).GetMethod(nameof(ClanPartiesVM.RefreshValues));
            if (refresh == null)
            {
                return Result.Failure;
            }

            comp.AddViewModelInstantiationPatch(callsite);
            comp.AddViewModelRefreshPatch(refresh);
            return Result.Success;
        }

    }

}