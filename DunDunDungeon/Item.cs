namespace DunDunDungeon
{

    internal partial class Program
    {
        class Item
        {
            public string Name { get; }
            public string Effect { get; }
            public string Description { get; }

            public Item(string newName, string newEffect, string newDescription)
            {
                Name = newName;
                Effect = newEffect;
                Description = newDescription;
            }
        }
    }
}