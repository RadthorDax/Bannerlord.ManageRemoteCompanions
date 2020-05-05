using MBOptionScreen.Attributes;
using MBOptionScreen.Settings;

namespace ManageRemoteCompanions
{
    public class Settings : AttributeSettings<Settings>
    {
        public override string ModName => "Manage Remote Companions";
        public override string ModuleFolderName => "Dax.ManageRemoteCompanions";
        public override string Id { get; set; } = "Dax.ManageRemoteCompanions_v3.0.0";


        [SettingProperty("Enabled", false, "")]
        [SettingPropertyGroup("General")]
        public bool Enabled { get; set; } = true;

        [SettingProperty("Manage Remote Companion Equipment", false, "")]
        [SettingPropertyGroup("General")]
        public bool ApplyInventoryPatch { get; set; } = false;

        [SettingProperty("Manage Troops of Companion Parties", false, "")]
        [SettingPropertyGroup("General")]
        public bool ManageParties { get; set; } = true;

        [SettingProperty("Manage Troops of Companion Caravans", false, "")]
        [SettingPropertyGroup("General")]
        public bool ManageCaravans { get; set; } = true;

        [SettingProperty("Manage Settlement Garrisons", false, "")]
        [SettingPropertyGroup("General")]
        public bool ManageGarrisons { get; set; } = true;
    }
}
