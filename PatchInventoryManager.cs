using HarmonyLib;
using TaleWorlds.CampaignSystem;

namespace ManageRemoteCompanions
{
    [HarmonyPatch(typeof(InventoryLogic), "InitializeRosters")]
    internal class PatchInventoryInit
    {
        public static void Prefix(ref TroopRoster rightMemberRoster)
        {
            if (Settings.Instance.Enabled && Settings.Instance.ApplyInventoryPatch && rightMemberRoster.Contains(Hero.MainHero.CharacterObject))
            {
                TroopRoster newRoster = new TroopRoster();
                newRoster.Add(rightMemberRoster);

                foreach (Hero hero in Clan.PlayerClan.Heroes)
                    if (hero.IsAlive && !hero.IsChild && hero != Hero.MainHero && !newRoster.Contains(hero.CharacterObject))
                        newRoster.AddToCounts(hero.CharacterObject, 1);

                foreach (Hero hero in Clan.PlayerClan.Companions)
                    if (hero.IsAlive && hero.IsPlayerCompanion && !newRoster.Contains(hero.CharacterObject))
                        newRoster.AddToCounts(hero.CharacterObject, 1);

                rightMemberRoster = newRoster;
            }
        }
    }
}
