using UnityEngine;
using UniInject;
using UniRx;
using System.Linq;

// Open the mod folder with Visual Studio Code and installed C# Dev Kit for IDE features such as
// code completion, error markers, parameter hints, go to definition, etc.
// ---
// Mods must implement subtypes of special mod interfaces.
// Available interfaces can be found by executing 'mod.interfaces' in the game's console.
public class ItemRumbleModLifeCycle : IOnLoadMod, IOnDisableMod
{

    [Inject]
    private ItemRumbleModModSettings modSettings;
    public void OnLoadMod()
    {
        // You can do anything here, for example ...

        Debug.Log($"{nameof(ItemRumbleModLifeCycle)}.OnLoadMod");

        /* if (modSettings.activeItemList == "")
        {
            modSettings.activeItemList = string.Join(",", Items.AllItems.Select(item => item.Name));
        } */
    }

    public void OnDisableMod()
    {
        Debug.Log($"{nameof(ItemRumbleModLifeCycle)}.OnDisableMod");
    }
}
