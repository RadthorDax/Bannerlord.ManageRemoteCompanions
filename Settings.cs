using MBOptionScreen.Attributes;
using MBOptionScreen.Settings;

namespace ManageRemoteCompanions
{
    public class Settings : AttributeSettings<Settings>
    {
        public override string ModName => "Manage Remote Companions";
        public override string ModuleFolderName => "Dax.ManageRemoteCompanions";
        public override string Id { get; set; } = "Dax.ManageRemoteCompanions_v2.0.0";


        [SettingProperty("Enabled", false, "")]
        [SettingPropertyGroup("General")]
        public bool Enabled { get; set; } = true;

        [SettingProperty("Manage Remote Companion Equipment", false, "")]
        [SettingPropertyGroup("General")]
        public bool ApplyInventoryPatch { get; set; } = false;
    }
}
