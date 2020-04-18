using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection;
using TaleWorlds.CampaignSystem.ViewModelCollection.CharacterDeveloper;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace UpgradeRemoteCompanions
{
    [HarmonyPatch(typeof(SkillVM), "IsPerkAvailable")]
    internal class PatchIsPerkAvailable
    {
        public static void Postfix(SkillVM __instance, PerkObject perk, ref bool __result)
        {
            __result = perk.RequiredSkillValue <= __instance.Level;
        }
    }

    [HarmonyPatch(typeof(CampaignUIHelper), "GetAddFocusHintString")]
    internal class PatchRefreshCanAddFocus
    {
        public static void Prefix(ref bool isInSamePartyAsPlayer)
        {
            isInSamePartyAsPlayer = true;
        }
    }

    [HarmonyPatch(typeof(CharacterVM), "CanAddFocusToSkillWithFocusAmount")]
    internal class PatchSkillFocus
    {
        public static void Postfix(CharacterVM __instance, int currentFocusAmount, ref bool __result)
        {
            __result = currentFocusAmount < 5 && __instance.UnspentCharacterPoints > 0;
        }
    }

    [HarmonyPatch(typeof(CharacterAttributeItemVM), "RefreshWithCurrentValues")]
    internal class PatchAttributePoints
    {
        public static void Postfix(CharacterAttributeItemVM __instance)
        {
            __instance.CanAddPoint = __instance.AttributeValue < 10 && __instance.UnspentAttributePoints > 0;
        }
    }
}
