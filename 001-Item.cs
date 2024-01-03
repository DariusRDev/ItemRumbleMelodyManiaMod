using System;
using System.Collections.Generic;

public class Item
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";

    public string VisualElementName { get; set; } = "";

    public string ImagePath { get; set; } = "";

    // Has to be object, because of loading order of cs files.
    public Action<object, object> OnCollectAction { get; set; } = (object itemActionsObject, object itemControlObject) => { };

    // Dictionary to store spawn probability thresholds and probabilities
    public Dictionary<int, float> SpawnProbabilities { get; set; } = new Dictionary<int, float>();


    public Item(string name, string description = "")
    {
        Name = name;
        Description = description;

    }

    // Has to be object, because of loading order of cs files.
    public void OnCollect(object itemActions, object itemControl)
    {
        OnCollectAction?.Invoke(itemActions, itemControl);
    }



    public override string ToString()
    {
        return Name;
    }

    public override bool Equals(object obj)
    {
        return obj is Item item &&
               Name == item.Name;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}
