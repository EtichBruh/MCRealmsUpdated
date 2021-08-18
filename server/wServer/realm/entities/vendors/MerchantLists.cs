using System;
using System.Collections.Generic;
using System.Linq;
using common;
using common.resources;
using log4net;
using wServer.realm.terrain;

namespace wServer.realm.entities.vendors
{
    public class ShopItem : ISellableItem
    {
        public ushort ItemId { get; private set; }
        public int Price { get; }
        public int Count { get; }
        public string Name { get; }

        public ShopItem(string name, ushort price, int count = -1)
        {
            ItemId = ushort.MaxValue;
            Price = price;
            Count = count;
            Name = name;
        }

        public void SetItem(ushort item)
        {
            if (ItemId != ushort.MaxValue)
                throw new AccessViolationException("Can't change item after it has been set.");

            ItemId = item;
        }
    }
    
    internal static class MerchantLists
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(MerchantLists));

            /*
             * 20 Fame = 1 Gold    
             */

        private static readonly List<ISellableItem> Weapons = new List<ISellableItem>
        {
        };

        private static readonly List<ISellableItem> Abilities = new List<ISellableItem>
        {
        };

        private static readonly List<ISellableItem> Armor = new List<ISellableItem>
        {
        };

        private static readonly List<ISellableItem> Rings = new List<ISellableItem>
        {
        };

        private static readonly List<ISellableItem> Keys = new List<ISellableItem>
        {
            new ShopItem("End Map", 10),
            new ShopItem("Allah Map", 15),
            new ShopItem("Thanos Map", 25),
            new ShopItem("Hitler Map", 25),
            new ShopItem("Santa Map", 25),
            new ShopItem("Groove Street map", 30),
            new ShopItem("Wither Storm Map", 20)
        };

        private static readonly List<ISellableItem> Items = new List<ISellableItem>
        {
            new ShopItem("Backpack", 10),
            new ShopItem("Blood Stone", 1),
            new ShopItem("Magic Stone", 1),
            new ShopItem("Attack Stone", 1),
            new ShopItem("Defense Stone", 1),
            new ShopItem("Speed Stone", 1),
            new ShopItem("Dexterity Stone", 1),
            new ShopItem("String", 0),
            new ShopItem("Glass Bottle", 0)
        };


        public static readonly Dictionary<TileRegion, Tuple<List<ISellableItem>, CurrencyType, /*Rank Req*/int>> Shops = 
            new Dictionary<TileRegion, Tuple<List<ISellableItem>, CurrencyType, int>>()
        {
            { TileRegion.Store_1, new Tuple<List<ISellableItem>, CurrencyType, int>(Weapons, CurrencyType.Gold, 0) },
            { TileRegion.Store_2, new Tuple<List<ISellableItem>, CurrencyType, int>(Abilities, CurrencyType.Gold, 0) },
            { TileRegion.Store_3, new Tuple<List<ISellableItem>, CurrencyType, int>(Armor, CurrencyType.Gold, 0) },
            { TileRegion.Store_4, new Tuple<List<ISellableItem>, CurrencyType, int>(Rings, CurrencyType.Gold, 0) },
            { TileRegion.Store_5, new Tuple<List<ISellableItem>, CurrencyType, int>(Keys, CurrencyType.Gold, 0) },
            { TileRegion.Store_6, new Tuple<List<ISellableItem>, CurrencyType, int>(Items, CurrencyType.Gold, 0) },
            //Store 9 - Market
            //Store 10 - Market
            //Store 11 - Market
            //Store 12 - Market
            //Store 13 - Market
            //Store 14 - Market
        };
        
        public static void Init(RealmManager manager)
        {
            foreach (var shop in Shops)
                foreach (var shopItem in shop.Value.Item1.OfType<ShopItem>())
                {
                    if (!manager.Resources.GameData.IdToObjectType.TryGetValue(shopItem.Name, out ushort id))
                        Log.WarnFormat("Item name: {0}, not found.", shopItem.Name);
                    else
                        shopItem.SetItem(id);
                }
        }
    }
}