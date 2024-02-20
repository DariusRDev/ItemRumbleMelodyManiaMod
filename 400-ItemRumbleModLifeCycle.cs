using UnityEngine;
using UniInject;
using UniRx;
using System.Linq;
using System.IO;

// Open the mod folder with Visual Studio Code and installed C# Dev Kit for IDE features such as
// code completion, error markers, parameter hints, go to definition, etc.
// ---
// Mods must implement subtypes of special mod interfaces.
// Available interfaces can be found by executing 'mod.interfaces' in the game's console.
public class ItemRumbleModLifeCycle : IOnLoadMod, IOnDisableMod, IOnModInstanceBecomesObsolete
{

    [Inject]
    private ItemRumbleModModSettings modSettings;

    [Inject]
    private ModObjectContext modContext;

    [Inject]
    private NonPersistentSettings nonPersistentSettings;

    public void OnLoadMod()
    {
        // You can do anything here, for example ...

        if (!File.Exists(Path.Combine(modContext.ModPersistentDataFolder, "SpawnProbabilities.csv")))
        {
            File.Copy(Path.Combine(modContext.ModFolder, "SpawnProbabilities.csv"), Path.Combine(modContext.ModPersistentDataFolder, "SpawnProbabilities.csv"));
        }

    }

    public void OnDisableMod()
    {
        Debug.Log($"{nameof(ItemRumbleModLifeCycle)}.OnDisableMod");
    }

    public void OnModInstanceBecomesObsolete()
    {
        nonPersistentSettings.GameRoundSettings.modifiers.Clear();
    }
}
