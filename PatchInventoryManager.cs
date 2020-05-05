using HarmonyLib;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

namespace ManageRemoteCompanions
{
    internal class PatchInventoryDefaults
    {
        public static Dictionary<CharacterObject, Equipment[]> DefaultCharacterEquipments = new Dictionary<CharacterObject, Equipment[]>();

        public static void SetDefault(CharacterObject character)
        {
            DefaultCharacterEquipments[character] = new Equipment[2] { new Equipment(character.Equipment), new Equipment(character.FirstCivilianEquipment) };
        }

        public static void ResetCharacter(CharacterObject character)
        {
            if (DefaultCharacterEquipments.ContainsKey(character))
            {
                character.Equipment.FillFrom(DefaultCharacterEquipments[character][0]);
                character.FirstCivilianEquipment.FillFrom(DefaultCharacterEquipments[character][1]);
            }
        }
    }

    [HarmonyPatch(typeof(InventoryLogic), "InitializeRosters")]
    internal class PatchInventoryInit
    {
        public static void Prefix(ref TroopRoster rightMemberRoster)
        {
            if (Settings.Instance.Enabled && Settings.Instance.ApplyInventoryPatch && rightMemberRoster.Contains(Hero.MainHero.CharacterObject))
            {
                TroopRoster newRoster = new TroopRoster();
                newRoster.Add(rightMemberRoster);
                PatchInventoryDefaults.DefaultCharacterEquipments.Clear();

                foreach (Hero hero in Clan.PlayerClan.Heroes)
                {
                    if (hero.IsAlive && !hero.IsChild && hero != Hero.MainHero && !newRoster.Contains(hero.CharacterObject))
                    {
                        newRoster.AddToCounts(hero.CharacterObject, 1);
                        PatchInventoryDefaults.SetDefault(hero.CharacterObject);
                    }
                }

                foreach (Hero hero in Clan.PlayerClan.Companions)
                {
                    if (hero.IsAlive && hero.IsPlayerCompanion && !newRoster.Contains(hero.CharacterObject))
                    {
                        newRoster.AddToCounts(hero.CharacterObject, 1);
                        PatchInventoryDefaults.SetDefault(hero.CharacterObject);
                    }
                }

                rightMemberRoster = newRoster;
            }
        }
    }

    [HarmonyPatch(typeof(InventoryLogic), "ResetLogic")]
    internal class PatchInventoryReset
    {
        public static void Prefix(InventoryLogic __instance)
        {
            if (Settings.Instance.Enabled && Settings.Instance.ApplyInventoryPatch)
                foreach (CharacterObject c in __instance.RightMemberRoster.Troops)
                    if (c.IsHero && !__instance.OwnerParty.MemberRoster.Contains(c))
                        PatchInventoryDefaults.ResetCharacter(c);
        }
    }
}
