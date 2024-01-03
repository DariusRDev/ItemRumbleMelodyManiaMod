using System;

public class Item
{
    public string Name { get; private set; }
    public string VisualElementName { get; private set; }

    public string ImagePath { get; private set; }

    // Has to be object, because of loading order of cs files.
    public Action<object, object> CustomAction { get; private set; }


    public Item(string name, string imagePath, string visualElementName, Action<object, object> customAction)
    {
        Name = name;
        VisualElementName = visualElementName;
        ImagePath = imagePath;
        CustomAction = customAction;
    }

    // Has to be object, because of loading order of cs files.
    public void OnCollect(object itemActions, object itemControl)
    {
        CustomAction?.Invoke(itemActions, itemControl);
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
