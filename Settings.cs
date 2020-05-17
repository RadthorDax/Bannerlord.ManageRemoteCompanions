using MBOptionScreen.Attributes;
using MBOptionScreen.Attributes.v2;
using MBOptionScreen.Settings;

namespace ManageRemoteCompanions
{
    public class Settings : AttributeSettings<Settings>
    {
        public override string ModName => "Manage Remote Companions";
        public override string ModuleFolderName => "ManageRemoteCompanions";

        // Only update Id version when making changes to settings options that are not backwards compatible.
        public override string Id { get; set; } = "Dax.ManageRemoteCompanions_v2.0.0";


        [SettingPropertyBool("Enabled", Order = 1, RequireRestart = false, HintText = "Toggle this mod on or off.")]
        [SettingPropertyGroup("Enabled", isMainToggle: true)]
        public bool Enabled { get; set; } = true;

        [SettingPropertyBool("Charcter Upgrades", Order = 2, RequireRestart = false, HintText = "Allows allocating perks, attribute points and focus points for remote companions.")]
        [SettingPropertyGroup("Enabled")]
        public bool CharacterUpgrades { get; set; } = true;

        [SettingPropertyBool("Manage Equipment", Order = 3, RequireRestart = false, HintText = "Adds all remote companions and adult family members to the Inventory screen so their equipment can be managed.")]
        [SettingPropertyGroup("Enabled")]
        public bool ApplyInventoryPatch { get; set; } = false;

        [SettingPropertyBool("Enable Manage Troops", Order = 4, RequireRestart = false, HintText = "Enable the management of party troops from the Clan Parties screen. Just clicking on the party will open the management UI. A stable version will move this functionality to a separate button.")]
        [SettingPropertyGroup("Enabled/Manage Troops [EXPERIMENTAL]", isMainToggle: true)]
        public bool ManageTroops { get; set; } = false;

        [SettingPropertyBool("Manage Troops of Companion Parties", Order = 5, RequireRestart = false, HintText = "Enables troop management for Clan Parties.")]
        [SettingPropertyGroup("Enabled/Manage Troops [EXPERIMENTAL]")]
        public bool ManageParties { get; set; } = true;

        [SettingPropertyBool("Manage Troops of Companion Caravans", Order = 6, RequireRestart = false, HintText = "Enables troop management for Clan Caravans.")]
        [SettingPropertyGroup("Enabled/Manage Troops [EXPERIMENTAL]")]
        public bool ManageCaravans { get; set; } = true;

        [SettingPropertyBool("Manage Settlement Garrisons", Order = 7, RequireRestart = false, HintText = "Enables troop management for Clan Settlement Garrisons.")]
        [SettingPropertyGroup("Enabled/Manage Troops [EXPERIMENTAL]")]
        public bool ManageGarrisons { get; set; } = false;
    }
}
