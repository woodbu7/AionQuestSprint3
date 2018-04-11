using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAionProject
{
    public static partial class UniverseObjects
    {
        public static List<GameObject> gameObjects = new List<GameObject>()
        {
            new TravelerObject
            {
                Id = 1,
                Name = "Bag of Gold",
                SpaceTimeLocationId = 2,
                Description = "A small leather pouch filled with 9 gold coins.",
                Type = TravelerObjectType.Treasure,
                Value = 45,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true,
                ExperiencePoints = 5
            },

            new TravelerObject
            {
                Id = 2,
                Name = "Ruby of Saron",
                SpaceTimeLocationId = 3,
                Description = "A bright red jewel, roughly the size of a robin's egg.",
                Type = TravelerObjectType.Treasure,
                Value = 45,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true,
                ExperiencePoints = 5
            },
            new TravelerObject
            {
                Id = 3,
                Name = "Rotogenic Medicine",
                SpaceTimeLocationId = 3,
                Description = "A wooden box containing a small vial filled with a blue liquid.",
                Type = TravelerObjectType.Medicine,
                Value = 45,
                CanInventory = false,
                IsConsumable = true,
                IsVisible = true,
                ExperiencePoints = 5
            },
            new TravelerObject
            {
                Id = 4,
                Name = "Norlan Document ND-3075",
                SpaceTimeLocationId = 3,
                Description =
                    "Memo: Origin Errata" + "\n" +
                    "Universal Date: 378597" + "\n" +
                    "\n" +
                    "It appears a potential origin for the technology is based on Plenatia 5 in the Star Reach Galaxy.",
                Type = TravelerObjectType.Information,
                Value = 0,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true,
                ExperiencePoints = 0,
            },
            new TravelerObject
            {
                Id = 5,
                Name = "Aion Tracker",
                SpaceTimeLocationId = 0,
                Description = "Standard issue device worn around the wrist that allows for tracking and messaging.",
                Type = TravelerObjectType.Information,
                Value = 0,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true,
                ExperiencePoints = 0

            },
            new TravelerObject
            {
                Id = 6,
                Name = "RatPak 47",
                SpaceTimeLocationId = 0,
                Description = "Standard issue ration package contain nutrient for 72 hours.",
                Type = TravelerObjectType.Food,
                Value = 0,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true,
                ExperiencePoints = 0

            },
            new TravelerObject
            {
                Id = 7,
                Name = "Space Diamond",
                SpaceTimeLocationId = 2,
                Description = "A unique diamond only found in space",
                Type = TravelerObjectType.Treasure,
                Value = 50,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true,
                ExperiencePoints = 10
            },
            new TravelerObject
            {
                Id = 8,
                Name = "Lazer Sword",
                SpaceTimeLocationId = 1,
                Description = "Super cool lazer sword to cut through the tension",
                Type = TravelerObjectType.Weapon,
                Value = 25,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true,
                ExperiencePoints = 5
            },
            new TravelerObject
            {
                Id = 9,
                Name = "Canned tomatoes",
                SpaceTimeLocationId = 3,
                Description = "Tomatoes stays fresh until can is opened",
                Type = TravelerObjectType.Food,
                Value = 5,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true,
                ExperiencePoints = 0
            },
            new TravelerObject
            {
                Id = 10,
                Name = "Super key",
                SpaceTimeLocationId = 1,
                Description = "No location is off limits",
                Type = TravelerObjectType.Information,
                Value = 15,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true,
                ExperiencePoints = 10
            },
            new TravelerObject
            {
                Id = 11,
                Name = "Heart stone A",
                SpaceTimeLocationId = 3,
                Description = "One of two heart stones, find both and get an extra life.",
                Type = TravelerObjectType.Treasure,
                Value = 25,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true,
                ExperiencePoints = 10
            },
            new TravelerObject
            {
                Id = 12,
                Name = "Heart stone B",
                SpaceTimeLocationId = 2,
                Description = "One of two heart stones, find both and get an extra life.",
                Type = TravelerObjectType.Treasure,
                Value = 25,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true,
                ExperiencePoints = 10
            },
            new TravelerObject
            {
                Id = 13,
                Name = "Mysterious bottle",
                SpaceTimeLocationId = 3,
                Description = "Mysterious bottle of green liquid. It may not be a good idea to pick up this item",
                Type = TravelerObjectType.Medicine,
                Value = 0,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true,
                ExperiencePoints = 0
            },
            new TravelerObject
            {
                Id = 14,
                Name = "Old grenade",
                SpaceTimeLocationId = 1,
                Description = "An old rusty grenade, looks like someone tried to detonate it.",
                Value = 5,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true,
                ExperiencePoints = 0,
            },
            new TravelerObject
            {
                Id = 15,
                Name = "Transporter",
                SpaceTimeLocationId = 4,
                Description = "Transporter device, pick it up and you will transport to a new location.",
                Value = 20,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true,
                ExperiencePoints = 25
            }


        };
    }
}
