using System;

public class Item
{
    public string Name { get; private set; }
    public string VisualElementName { get; private set; }

    public string ImagePath { get; private set; }

    public Action<ItemActions> CustomAction { get; private set; }


    public Item(string name, string imagePath, string visualElementName, Action<ItemActions> customAction)
    {
        Name = name;
        VisualElementName = visualElementName;
        ImagePath = imagePath;
        CustomAction = customAction;
    }

    public void OnCollect(ItemActions itemActions)
    {
        CustomAction?.Invoke(itemActions);
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
