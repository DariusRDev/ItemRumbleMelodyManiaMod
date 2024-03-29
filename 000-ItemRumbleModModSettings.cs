using System.Collections.Generic;

// Add settings to your mod by implementing IModSettings.
// IModSettings extends IAutoBoundMod,
// which makes an object of the type available in other scripts via Inject attribute.
// Mod settings are saved to file when the app is closed.
public class ItemRumbleModModSettings : IModSettings
{
    public int percentChanceToSpawnItem = 25;
    public string activeItemList = "";

    public bool collectOnPerfectNote = true;

    public List<IModSettingControl> GetModSettingControls()
    {
        return new List<IModSettingControl>()
        {
            new BoolModSettingControl(() => collectOnPerfectNote, newValue => collectOnPerfectNote = newValue) { Label = "Collect item on perfect note (Not on correct pitch at item Position)" },
             new IntModSettingControl(() => percentChanceToSpawnItem, newValue => percentChanceToSpawnItem = newValue) { Label = "Spawn probability for item on each note (%)" }
        };
    }
}
