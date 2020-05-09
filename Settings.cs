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


        [SettingPropertyBool("Enabled", RequireRestart = false, HintText = "Enables all features of this mod.")]
        [SettingPropertyGroup("General")]
        public bool Enabled { get; set; } = true;

        [SettingPropertyBool("Manage Remote Companion Equipment", RequireRestart = false, HintText = "Adds all remote companions and adult family members to the Inventory screen so their equipment can be managed.")]
        [SettingPropertyGroup("General")]
        public bool ApplyInventoryPatch { get; set; } = false;
    }
}
