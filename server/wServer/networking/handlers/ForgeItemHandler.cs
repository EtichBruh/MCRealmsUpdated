using wServer.networking.packets;
using wServer.networking.packets.incoming;
using System;
using System.Linq;
using System.Collections.Generic;

namespace wServer.networking.handlers
{
    internal class ForgeItemHandler : PacketHandlerBase<ForgeItem>
    {

        public override PacketId ID => PacketId.FORGEITEM;

        protected override void HandlePacket(Client client, ForgeItem packet)
        {
            Handle(client, packet);
        }

        private void Handle(Client client, ForgeItem packet)
        {
            switch (packet.type)
            {
                case 0:
                    Craft(client, packet, "Swords");
                    break;
                case 1:
                    Craft(client, packet, "Pickaxes");
                    break;
                case 2:
                    Craft(client, packet, "Bows");
                    break;
                case 3:
                    Craft(client, packet, "Staves");
                    break;
                case 4:
                    Craft(client, packet, "Axes");
                    break;
                case 5:
                    Craft(client, packet, "Wands");
                    break;
                case 6:
                    Craft(client, packet, "Abilities");
                    break;
                case 7:
                    Craft(client, packet, "Armors");
                    break;
                case 8:
                    Craft(client, packet, "Rings");
                    break;
                case 9:
                    Craft(client, packet, "Items");
                    break;
                default:
                    Craft(client, packet, "Swords");
                    break;
            }
        }

        private void Craft(Client client, ForgeItem packet, string type)
        {
            ushort slotValue = 0x0;
            var inventory = client.Player.Inventory;

            switch (type)
            {
                #region Weapons

                case "Swords":
                    #region TieredSwords

                    #region Wooden Sword
                    if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5053 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5053 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5436;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Stone Sword
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5054 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5054 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5438;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Redstone Sword
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5055 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5055 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5440;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Lapis Lazuli Sword
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5056 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5056 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5442;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Golden Sword
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5050 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5050 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5444;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Iron Sword
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5051 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5051 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5446;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Diamond Sword
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5052 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5052 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5448;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Emerald Sword
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5650 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5650 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5150;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Obsidian Sword
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5057 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5057 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5234;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Bedrock Sword
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x8489 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x8489 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x8765;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #endregion

                    #region TieredPickaxes
                    #region Wooden Pickaxe
                    else if (
                        packet.slot1.ObjectType == 0x5053 &&
                        packet.slot2.ObjectType == 0x5053 &&
                        packet.slot3.ObjectType == 0x5053 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5568;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Stone Pickaxe
                    else if (
                        packet.slot1.ObjectType == 0x5054 &&
                        packet.slot2.ObjectType == 0x5054 &&
                        packet.slot3.ObjectType == 0x5054 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5570;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Redstone Pickaxe
                    else if (
                        packet.slot1.ObjectType == 0x5055 &&
                        packet.slot2.ObjectType == 0x5055 &&
                        packet.slot3.ObjectType == 0x5055 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5572;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Lapis Lazuli Pickaxe
                    else if (
                        packet.slot1.ObjectType == 0x5056 &&
                        packet.slot2.ObjectType == 0x5056 &&
                        packet.slot3.ObjectType == 0x5056 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5574;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Golden Pickaxe
                    else if (
                        packet.slot1.ObjectType == 0x5050 &&
                        packet.slot2.ObjectType == 0x5050 &&
                        packet.slot3.ObjectType == 0x5050 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5576;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Iron Pickaxe
                    else if (
                        packet.slot1.ObjectType == 0x5051 &&
                        packet.slot2.ObjectType == 0x5051 &&
                        packet.slot3.ObjectType == 0x5051 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5578;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Diamond Pickaxe
                    else if (
                        packet.slot1.ObjectType == 0x5052 &&
                        packet.slot2.ObjectType == 0x5052 &&
                        packet.slot3.ObjectType == 0x5052 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5580;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Emerald Pickaxe
                    else if (
                        packet.slot1.ObjectType == 0x5650 &&
                        packet.slot2.ObjectType == 0x5650 &&
                        packet.slot3.ObjectType == 0x5650 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5582;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Obsidian Pickaxe
                    else if (
                        packet.slot1.ObjectType == 0x5057 &&
                        packet.slot2.ObjectType == 0x5057 &&
                        packet.slot3.ObjectType == 0x5057 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5584;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Bedrock Pickaxe
                    else if (
                        packet.slot1.ObjectType == 0x8489 &&
                        packet.slot2.ObjectType == 0x8489 &&
                        packet.slot3.ObjectType == 0x8489 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x8771;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion
                    #endregion

                    #region TieredHoes

                    #region Stone Hoe
                    if (
                        packet.slot1.ObjectType == 0x5054 &&
                        packet.slot2.ObjectType == 0x5054 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x8983;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Redstone Hoe
                    else if (
                        packet.slot1.ObjectType == 0x5055 &&
                        packet.slot2.ObjectType == 0x5055 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x8985;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Lapis Lazuli Hoe
                    else if (
                        packet.slot1.ObjectType == 0x5056 &&
                        packet.slot2.ObjectType == 0x5056 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x8987;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Golden Hoe
                    else if (
                        packet.slot1.ObjectType == 0x5050 &&
                        packet.slot2.ObjectType == 0x5050 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x8989;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Iron Hoe
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5051 &&
                        packet.slot3.ObjectType == 0x5051 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x8989;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Diamond Hoe
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5052 &&
                        packet.slot3.ObjectType == 0x5052 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x8993;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Emerald Hoe
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5650 &&
                        packet.slot3.ObjectType == 0x5650 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x8995;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Obsidian Pickaxe
                    else if (
                        packet.slot1.ObjectType == 0x5057 &&
                        packet.slot2.ObjectType == 0x5057 &&
                        packet.slot3.ObjectType == 0x5057 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5584;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Bedrock Pickaxe
                    else if (
                        packet.slot1.ObjectType == 0x8489 &&
                        packet.slot2.ObjectType == 0x8489 &&
                        packet.slot3.ObjectType == 0x8489 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x8771;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion
                    #endregion

                    #region UntieredSwords

                    #region Villager's Emerald Dildo
                    if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5077 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5077 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5375;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Boner Sword
                    if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5071 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5072 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5357;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region FISTS of fury iron
                    if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5078 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5078 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5078 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5111;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Slime Basher
                    if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5215 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5215 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5595;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Wither Skeleton's Stone Sword
                    if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5224 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5224 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x4054;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region WHIP OF A FUCKING NIGGER FROM GERMANY
                    if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x8665 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x7661 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x6999 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x8666;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region MURDERS LONG SHARP DILDO
                    if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5078 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5078 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x7367 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x7369;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #endregion

                    #region Untiered pickaxes

                    #region THICC Diamond Pickaxe
                    else if (
                        packet.slot1.ObjectType == 0x5076 &&
                        packet.slot2.ObjectType == 0x5076 &&
                        packet.slot3.ObjectType == 0x5076 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x4568;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Pick of the Gay Reaper
                    else if (
                        packet.slot1.ObjectType == 0x4660 &&
                        packet.slot2.ObjectType == 0x4660 &&
                        packet.slot3.ObjectType == 0x4660 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x8489 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x8489 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x4587;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #endregion

                    break;

                case "Pickaxes":
                    if (inventory[packet.slot1.SlotId].ObjectType != packet.slot1.ObjectType || inventory[packet.slot2.SlotId].ObjectType != packet.slot2.ObjectType || inventory[packet.slot3.SlotId].ObjectType != packet.slot3.ObjectType || inventory[packet.slot5.SlotId].ObjectType != packet.slot5.ObjectType || inventory[packet.slot8.SlotId].ObjectType != packet.slot8.ObjectType)
                    {
                        return;
                    }
                    #region Tiered

                    #region Wooden Pickaxe
                    else if (
                        packet.slot1.ObjectType == 0x5053 &&
                        packet.slot2.ObjectType == 0x5053 &&
                        packet.slot3.ObjectType == 0x5053 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5568;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Stone Pickaxe
                    else if (
                        packet.slot1.ObjectType == 0x5054 &&
                        packet.slot2.ObjectType == 0x5054 &&
                        packet.slot3.ObjectType == 0x5054 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5570;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Redstone Pickaxe
                    else if (
                        packet.slot1.ObjectType == 0x5055 &&
                        packet.slot2.ObjectType == 0x5055 &&
                        packet.slot3.ObjectType == 0x5055 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5572;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Lapis Lazuli Pickaxe
                    else if (
                        packet.slot1.ObjectType == 0x5056 &&
                        packet.slot2.ObjectType == 0x5056 &&
                        packet.slot3.ObjectType == 0x5056 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5574;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Golden Pickaxe
                    else if (
                        packet.slot1.ObjectType == 0x5050 &&
                        packet.slot2.ObjectType == 0x5050 &&
                        packet.slot3.ObjectType == 0x5050 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5576;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Iron Pickaxe
                    else if (
                        packet.slot1.ObjectType == 0x5051 &&
                        packet.slot2.ObjectType == 0x5051 &&
                        packet.slot3.ObjectType == 0x5051 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5578;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Diamond Pickaxe
                    else if (
                        packet.slot1.ObjectType == 0x5052 &&
                        packet.slot2.ObjectType == 0x5052 &&
                        packet.slot3.ObjectType == 0x5052 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5580;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Emerald Pickaxe
                    else if (
                        packet.slot1.ObjectType == 0x5650 &&
                        packet.slot2.ObjectType == 0x5650 &&
                        packet.slot3.ObjectType == 0x5650 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5582;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Obsidian Pickaxe
                    else if (
                        packet.slot1.ObjectType == 0x5057 &&
                        packet.slot2.ObjectType == 0x5057 &&
                        packet.slot3.ObjectType == 0x5057 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5584;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Bedrock Pickaxe
                    else if (
                        packet.slot1.ObjectType == 0x8489 &&
                        packet.slot2.ObjectType == 0x8489 &&
                        packet.slot3.ObjectType == 0x8489 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x8771;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #endregion

                    #region Untiered

                    #region THICC Diamond Pickaxe
                    else if (
                        packet.slot1.ObjectType == 0x5076 &&
                        packet.slot2.ObjectType == 0x5076 &&
                        packet.slot3.ObjectType == 0x5076 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x4568;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Pick of the Gay Reaper
                    else if (
                        packet.slot1.ObjectType == 0x4660 &&
                        packet.slot2.ObjectType == 0x4660 &&
                        packet.slot3.ObjectType == 0x4660 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x8489 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x8489 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x4587;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #endregion
                    break;

                case "Bows":
                    if (inventory[packet.slot2.SlotId].ObjectType != packet.slot2.ObjectType || inventory[packet.slot3.SlotId].ObjectType != packet.slot3.ObjectType || inventory[packet.slot4.SlotId].ObjectType != packet.slot4.ObjectType || inventory[packet.slot6.SlotId].ObjectType != packet.slot6.ObjectType || inventory[packet.slot8.SlotId].ObjectType != packet.slot8.ObjectType || inventory[packet.slot9.SlotId].ObjectType != packet.slot9.ObjectType)
                    {
                        return;
                    }
                    #region Tiered

                    #region Wooden Bow
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5049 &&
                        packet.slot3.ObjectType == 0x5058 &&
                        packet.slot4.ObjectType == 0x5049 &&
                        packet.slot5.ObjectType == -1 &&
                        packet.slot6.ObjectType == 0x5058 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == 0x5058)
                    {
                        slotValue = 0x5430;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        inventory[packet.slot9.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Stone Bow
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5054 &&
                        packet.slot3.ObjectType == 0x5058 &&
                        packet.slot4.ObjectType == 0x5054 &&
                        packet.slot5.ObjectType == -1 &&
                        packet.slot6.ObjectType == 0x5058 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5054 &&
                        packet.slot9.ObjectType == 0x5058)
                    {
                        slotValue = 0x5431;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        inventory[packet.slot9.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Redstone Bow
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5055 &&
                        packet.slot3.ObjectType == 0x5058 &&
                        packet.slot4.ObjectType == 0x5055 &&
                        packet.slot5.ObjectType == -1 &&
                        packet.slot6.ObjectType == 0x5058 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5055 &&
                        packet.slot9.ObjectType == 0x5058)
                    {
                        slotValue = 0x5432;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        inventory[packet.slot9.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Lapis Lazuli Bow
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5056 &&
                        packet.slot3.ObjectType == 0x5058 &&
                        packet.slot4.ObjectType == 0x5056 &&
                        packet.slot5.ObjectType == -1 &&
                        packet.slot6.ObjectType == 0x5058 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5056 &&
                        packet.slot9.ObjectType == 0x5058)
                    {
                        slotValue = 0x5433;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        inventory[packet.slot9.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Golden Bow
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5050 &&
                        packet.slot3.ObjectType == 0x5058 &&
                        packet.slot4.ObjectType == 0x5050 &&
                        packet.slot5.ObjectType == -1 &&
                        packet.slot6.ObjectType == 0x5058 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5050 &&
                        packet.slot9.ObjectType == 0x5058)
                    {
                        slotValue = 0x5434;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        inventory[packet.slot9.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Iron Bow
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5051 &&
                        packet.slot3.ObjectType == 0x5058 &&
                        packet.slot4.ObjectType == 0x5051 &&
                        packet.slot5.ObjectType == -1 &&
                        packet.slot6.ObjectType == 0x5058 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5051 &&
                        packet.slot9.ObjectType == 0x5058)
                    {
                        slotValue = 0x5235;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        inventory[packet.slot9.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Diamond Bow
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5052 &&
                        packet.slot3.ObjectType == 0x5058 &&
                        packet.slot4.ObjectType == 0x5052 &&
                        packet.slot5.ObjectType == -1 &&
                        packet.slot6.ObjectType == 0x5058 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5052 &&
                        packet.slot9.ObjectType == 0x5058)
                    {
                        slotValue = 0x5236;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        inventory[packet.slot9.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Emerald Bow
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5650 &&
                        packet.slot3.ObjectType == 0x5058 &&
                        packet.slot4.ObjectType == 0x5650 &&
                        packet.slot5.ObjectType == -1 &&
                        packet.slot6.ObjectType == 0x5058 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5650 &&
                        packet.slot9.ObjectType == 0x5058)
                    {
                        slotValue = 0x5237;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        inventory[packet.slot9.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Obsidian Bow
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5057 &&
                        packet.slot3.ObjectType == 0x5058 &&
                        packet.slot4.ObjectType == 0x5057 &&
                        packet.slot5.ObjectType == -1 &&
                        packet.slot6.ObjectType == 0x5058 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5057 &&
                        packet.slot9.ObjectType == 0x5058)
                    {
                        slotValue = 0x5238;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        inventory[packet.slot9.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Bedrock Bow
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x8489 &&
                        packet.slot3.ObjectType == 0x5058 &&
                        packet.slot4.ObjectType == 0x8489 &&
                        packet.slot5.ObjectType == -1 &&
                        packet.slot6.ObjectType == 0x5058 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x8489 &&
                        packet.slot9.ObjectType == 0x5058)
                    {
                        slotValue = 0x8762;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        inventory[packet.slot9.SlotId] = null;
                        return;
                    }
                    #endregion
                    #endregion

                    #region Untiered

                    #region Villager's Emerald Bow
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5077 &&
                        packet.slot3.ObjectType == 0x5058 &&
                        packet.slot4.ObjectType == 0x5077 &&
                        packet.slot5.ObjectType == -1 &&
                        packet.slot6.ObjectType == 0x5058 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5077 &&
                        packet.slot9.ObjectType == 0x5058)
                    {
                        slotValue = 0x4534;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        inventory[packet.slot9.SlotId] = null;
                        return;
                    }
                    #endregion

                    #endregion
                    break;

                case "Staves":
                    if (inventory[packet.slot3.SlotId].ObjectType != packet.slot3.ObjectType || inventory[packet.slot5.SlotId].ObjectType != packet.slot5.ObjectType || inventory[packet.slot7.SlotId].ObjectType != packet.slot7.ObjectType)
                    {
                        return;
                    }
                    #region Tiered

                    #region Wooden Staff
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == -1 &&
                        packet.slot3.ObjectType == 0x5053 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == 0x5049 &&
                        packet.slot8.ObjectType == -1 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x6983;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot3.SlotId] = miscslot;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Stone Staff
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == -1 &&
                        packet.slot3.ObjectType == 0x5054 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == 0x5049 &&
                        packet.slot8.ObjectType == -1 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x6984;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot3.SlotId] = miscslot;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Redstone Staff
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == -1 &&
                        packet.slot3.ObjectType == 0x5055 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == 0x5049 &&
                        packet.slot8.ObjectType == -1 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x6985;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot3.SlotId] = miscslot;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Lapis Lazuli Staff
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == -1 &&
                        packet.slot3.ObjectType == 0x5056 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == 0x5049 &&
                        packet.slot8.ObjectType == -1 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x6986;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot3.SlotId] = miscslot;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Golden Staff
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == -1 &&
                        packet.slot3.ObjectType == 0x5050 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == 0x5049 &&
                        packet.slot8.ObjectType == -1 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x6987;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot3.SlotId] = miscslot;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Iron Staff
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == -1 &&
                        packet.slot3.ObjectType == 0x5051 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == 0x5049 &&
                        packet.slot8.ObjectType == -1 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x6988;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot3.SlotId] = miscslot;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Diamond Staff
                    else if (
                         packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == -1 &&
                        packet.slot3.ObjectType == 0x5052 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == 0x5049 &&
                        packet.slot8.ObjectType == -1 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x6989;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot3.SlotId] = miscslot;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Emerald Staff
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == -1 &&
                        packet.slot3.ObjectType == 0x5650 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == 0x5049 &&
                        packet.slot8.ObjectType == -1 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x6990;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot3.SlotId] = miscslot;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Obsidian Staff
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == -1 &&
                        packet.slot3.ObjectType == 0x5057 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == 0x5049 &&
                        packet.slot8.ObjectType == -1 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x6991;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot3.SlotId] = miscslot;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Bedrock Staff
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == -1 &&
                        packet.slot3.ObjectType == 0x8489 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == 0x5049 &&
                        packet.slot8.ObjectType == -1 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x8772;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot3.SlotId] = miscslot;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        return;
                    }
                    #endregion

                    #endregion

                    #region Untiered

                    #region Slime Staff
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == -1 &&
                        packet.slot3.ObjectType == 0x5215 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == 0x5049 &&
                        packet.slot8.ObjectType == -1 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x4426;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot3.SlotId] = miscslot;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        return;
                    }
                    #endregion

                    #endregion
                    break;

                case "Axes":
                    if (inventory[packet.slot1.SlotId].ObjectType != packet.slot1.ObjectType || inventory[packet.slot2.SlotId].ObjectType != packet.slot2.ObjectType || inventory[packet.slot4.SlotId].ObjectType != packet.slot4.ObjectType || inventory[packet.slot5.SlotId].ObjectType != packet.slot5.ObjectType || inventory[packet.slot8.SlotId].ObjectType != packet.slot8.ObjectType)
                    {
                        return;
                    }
                    #region Tiered

                    #region Wooden Axe
                    else if (
                        packet.slot1.ObjectType == 0x5053 &&
                        packet.slot2.ObjectType == 0x5053 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == 0x5053 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5450;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Stone Axe
                    else if (
                        packet.slot1.ObjectType == 0x5054 &&
                        packet.slot2.ObjectType == 0x5054 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == 0x5054 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5452;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Redstone Axe
                    else if (
                        packet.slot1.ObjectType == 0x5055 &&
                        packet.slot2.ObjectType == 0x5055 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == 0x5055 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5454;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Lapis Lazuli Axe
                    else if (
                        packet.slot1.ObjectType == 0x5056 &&
                        packet.slot2.ObjectType == 0x5056 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == 0x5056 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5456;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Golden Axe
                    else if (
                        packet.slot1.ObjectType == 0x5050 &&
                        packet.slot2.ObjectType == 0x5050 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == 0x5050 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5458;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Iron Axe
                    else if (
                        packet.slot1.ObjectType == 0x5051 &&
                        packet.slot2.ObjectType == 0x5051 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == 0x5051 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5460;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Diamond Axe
                    else if (
                        packet.slot1.ObjectType == 0x5052 &&
                        packet.slot2.ObjectType == 0x5052 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == 0x5052 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5462;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Emerald Axe
                    else if (
                        packet.slot1.ObjectType == 0x5650 &&
                        packet.slot2.ObjectType == 0x5650 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == 0x5650 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5464;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Obsidian Axe
                    else if (
                        packet.slot1.ObjectType == 0x5057 &&
                        packet.slot2.ObjectType == 0x5057 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == 0x5057 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5466;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Bedrock Axe
                    else if (
                        packet.slot1.ObjectType == 0x8489 &&
                        packet.slot2.ObjectType == 0x8489 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == 0x8489 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x8767;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #endregion

                    #region Untiered

                    #region Herobrines's Battle Axe
                    else if (
                        packet.slot1.ObjectType == 0x5052 &&
                        packet.slot2.ObjectType == 0x5076 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == 0x5052 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == -1 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5049 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5379;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #endregion
                    break;

                case "Wands":
                    if (inventory[packet.slot2.SlotId].ObjectType != packet.slot2.ObjectType || inventory[packet.slot3.SlotId].ObjectType != packet.slot3.ObjectType || inventory[packet.slot5.SlotId].ObjectType != packet.slot5.ObjectType || inventory[packet.slot6.SlotId].ObjectType != packet.slot6.ObjectType || inventory[packet.slot7.SlotId].ObjectType != packet.slot7.ObjectType)
                    {
                        return;
                    }
                    #region Tiered

                    #region Wooden Wand
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5053 &&
                        packet.slot3.ObjectType == 0x5053 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == 0x5053 &&
                        packet.slot7.ObjectType == 0x5049 &&
                        packet.slot8.ObjectType == -1 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5468;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Stone Wand
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5054 &&
                        packet.slot3.ObjectType == 0x5054 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == 0x5054 &&
                        packet.slot7.ObjectType == 0x5049 &&
                        packet.slot8.ObjectType == -1 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5470;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Redstone Wand
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5055 &&
                        packet.slot3.ObjectType == 0x5055 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == 0x5055 &&
                        packet.slot7.ObjectType == 0x5049 &&
                        packet.slot8.ObjectType == -1 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5472;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Lapis Lazuli Wand
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5056 &&
                        packet.slot3.ObjectType == 0x5056 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == 0x5056 &&
                        packet.slot7.ObjectType == 0x5049 &&
                        packet.slot8.ObjectType == -1 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5474;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Golden Wand
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5050 &&
                        packet.slot3.ObjectType == 0x5050 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == 0x5050 &&
                        packet.slot7.ObjectType == 0x5049 &&
                        packet.slot8.ObjectType == -1 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5476;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Iron Wand
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5051 &&
                        packet.slot3.ObjectType == 0x5051 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == 0x5051 &&
                        packet.slot7.ObjectType == 0x5049 &&
                        packet.slot8.ObjectType == -1 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5478;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Diamond Wand
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5052 &&
                        packet.slot3.ObjectType == 0x5052 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == 0x5052 &&
                        packet.slot7.ObjectType == 0x5049 &&
                        packet.slot8.ObjectType == -1 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5480;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Emerald Wand
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5650 &&
                        packet.slot3.ObjectType == 0x5650 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == 0x5650 &&
                        packet.slot7.ObjectType == 0x5049 &&
                        packet.slot8.ObjectType == -1 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5482;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Obsidian Wand
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5057 &&
                        packet.slot3.ObjectType == 0x5057 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == 0x5057 &&
                        packet.slot7.ObjectType == 0x5049 &&
                        packet.slot8.ObjectType == -1 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5484;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Bedrock Wand
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x8489 &&
                        packet.slot3.ObjectType == 0x8489 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == 0x8489 &&
                        packet.slot7.ObjectType == 0x5049 &&
                        packet.slot8.ObjectType == -1 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x8769;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        return;
                    }
                    #endregion

                    #endregion

                    #region Untiered

                    #region Wand of the Unrevoken Death
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x6838 &&
                        packet.slot3.ObjectType == 0x5068 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == 0x6838 &&
                        packet.slot7.ObjectType == 0x5049 &&
                        packet.slot8.ObjectType == -1 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x5335;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Wand of a Foul Foe
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5112 &&
                        packet.slot3.ObjectType == 0x5113 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5049 &&
                        packet.slot6.ObjectType == 0x5112 &&
                        packet.slot7.ObjectType == 0x5049 &&
                        packet.slot8.ObjectType == -1 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x4427;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Trident of the Sea
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5218 &&
                        packet.slot3.ObjectType == 0x5218 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5052 &&
                        packet.slot6.ObjectType == 0x5218 &&
                        packet.slot7.ObjectType == 0x5052 &&
                        packet.slot8.ObjectType == -1 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x4083;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Enchanted Trident of the Sea
                    else if (
                        packet.slot1.ObjectType == -1 && packet.slot2.ObjectType == 0x5220 && packet.slot3.ObjectType == 0x5220 &&
                        packet.slot4.ObjectType == -1 && packet.slot5.ObjectType == 0x5076 && packet.slot6.ObjectType == 0x5220 &&
                        packet.slot7.ObjectType == 0x5076 && packet.slot8.ObjectType == -1 && packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x4429;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Stick of the Blaze
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5223 &&
                        packet.slot3.ObjectType == 0x5223 &&
                        packet.slot4.ObjectType == -1 &&
                        packet.slot5.ObjectType == 0x5222 &&
                        packet.slot6.ObjectType == 0x5223 &&
                        packet.slot7.ObjectType == 0x5222 &&
                        packet.slot8.ObjectType == -1 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x4049;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        return;
                    }
                    #endregion

                    #endregion
                    break;

                #endregion

                #region Equipment

                case "Abilities":
                    if (inventory[packet.slot2.SlotId].ObjectType != packet.slot2.ObjectType || inventory[packet.slot4.SlotId].ObjectType != packet.slot4.ObjectType || inventory[packet.slot5.SlotId].ObjectType != packet.slot5.ObjectType || inventory[packet.slot6.SlotId].ObjectType != packet.slot6.ObjectType || inventory[packet.slot8.SlotId].ObjectType != packet.slot8.ObjectType)
                    {
                        return;
                    }
                    #region Tiered

                    #region Speed I Potion
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x6837 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == 0x6836 &&
                        packet.slot5.ObjectType == 0x5059 &&
                        packet.slot6.ObjectType == 0x6837 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x6836 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x7678;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Speed II Potion
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x7678 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == 0x7678 &&
                        packet.slot5.ObjectType == 0x5059 &&
                        packet.slot6.ObjectType == 0x7678 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x7678 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x7677;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Speed III Potion
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x7677 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == 0x7677 &&
                        packet.slot5.ObjectType == 0x5059 &&
                        packet.slot6.ObjectType == 0x7677 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x7677 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x7679;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion


                    #region Health I Potion
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x6834 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == 0x6835 &&
                        packet.slot5.ObjectType == 0x5059 &&
                        packet.slot6.ObjectType == 0x6834 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x6835 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x8488;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Health II Potion
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x8488 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == 0x8488 &&
                        packet.slot5.ObjectType == 0x5059 &&
                        packet.slot6.ObjectType == 0x8488 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x8488 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x7577;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Health III Potion
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x7577 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == 0x7577 &&
                        packet.slot5.ObjectType == 0x5059 &&
                        packet.slot6.ObjectType == 0x7577 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x7577 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x7578;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion


                    #region Haste I Potion
                    else if (
                        packet.slot1.ObjectType == -1 && packet.slot2.ObjectType == 0x6837 && packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == 0x6835 && packet.slot5.ObjectType == 0x5059 && packet.slot6.ObjectType == 0x6837 &&
                        packet.slot7.ObjectType == -1 && packet.slot8.ObjectType == 0x6835 && packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x8589;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Haste II Potion
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x8589 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == 0x8589 &&
                        packet.slot5.ObjectType == 0x5059 &&
                        packet.slot6.ObjectType == 0x8589 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x8589 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x8599;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Haste III Potion
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x8599 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == 0x8599 &&
                        packet.slot5.ObjectType == 0x5059 &&
                        packet.slot6.ObjectType == 0x8599 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x8599 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x8600;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion



                    #region Invisibility Potion
                    else if (
                        packet.slot1.ObjectType == 0x6a0d &&
                        packet.slot2.ObjectType == 0x6a0d &&
                        packet.slot3.ObjectType == 0x6a0d &&
                        packet.slot4.ObjectType == 0x6a11 &&
                        packet.slot5.ObjectType == 0x5059 &&
                        packet.slot6.ObjectType == 0x6a11 &&
                        packet.slot7.ObjectType == 0x6a0d &&
                        packet.slot8.ObjectType == 0x6a0d &&
                        packet.slot9.ObjectType == 0x6a0d)
                    {
                        slotValue = 0x6a10;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        inventory[packet.slot9.SlotId] = null;
                        return;
                    }
                    #endregion

                    #endregion
                    break;

                case "Armors":
                    if (inventory[packet.slot1.SlotId].ObjectType != packet.slot1.ObjectType || inventory[packet.slot3.SlotId].ObjectType != packet.slot3.ObjectType || inventory[packet.slot4.SlotId].ObjectType != packet.slot4.ObjectType || inventory[packet.slot5.SlotId].ObjectType != packet.slot5.ObjectType || inventory[packet.slot6.SlotId].ObjectType != packet.slot6.ObjectType || inventory[packet.slot7.SlotId].ObjectType != packet.slot7.ObjectType || inventory[packet.slot8.SlotId].ObjectType != packet.slot8.ObjectType || inventory[packet.slot9.SlotId].ObjectType != packet.slot9.ObjectType)
                    {
                        return;
                    }
                    #region Tiered

                    #region Leather Chestplate
                    else if (
                        packet.slot1.ObjectType == 0x5060 &&
                        packet.slot2.ObjectType == -1 &&
                        packet.slot3.ObjectType == 0x5060 &&
                        packet.slot4.ObjectType == 0x5060 &&
                        packet.slot5.ObjectType == 0x5060 &&
                        packet.slot6.ObjectType == 0x5060 &&
                        packet.slot7.ObjectType == 0x5060 &&
                        packet.slot8.ObjectType == 0x5060 &&
                        packet.slot9.ObjectType == 0x5060)
                    {
                        slotValue = 0x8752;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        inventory[packet.slot9.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Stone Chestplate
                    else if (
                        packet.slot1.ObjectType == 0x5054 &&
                        packet.slot2.ObjectType == -1 &&
                        packet.slot3.ObjectType == 0x5054 &&
                        packet.slot4.ObjectType == 0x5054 &&
                        packet.slot5.ObjectType == 0x5054 &&
                        packet.slot6.ObjectType == 0x5054 &&
                        packet.slot7.ObjectType == 0x5054 &&
                        packet.slot8.ObjectType == 0x5054 &&
                        packet.slot9.ObjectType == 0x5054)
                    {
                        slotValue = 0x8753;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        inventory[packet.slot9.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Redstone Chestplate
                    else if (
                        packet.slot1.ObjectType == 0x5055 &&
                        packet.slot2.ObjectType == -1 &&
                        packet.slot3.ObjectType == 0x5055 &&
                        packet.slot4.ObjectType == 0x5055 &&
                        packet.slot5.ObjectType == 0x5055 &&
                        packet.slot6.ObjectType == 0x5055 &&
                        packet.slot7.ObjectType == 0x5055 &&
                        packet.slot8.ObjectType == 0x5055 &&
                        packet.slot9.ObjectType == 0x5055)
                    {
                        slotValue = 0x8754;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        inventory[packet.slot9.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Lapis Lazuli Chestplate
                    else if (
                        packet.slot1.ObjectType == 0x5056 &&
                        packet.slot2.ObjectType == -1 &&
                        packet.slot3.ObjectType == 0x5056 &&
                        packet.slot4.ObjectType == 0x5056 &&
                        packet.slot5.ObjectType == 0x5056 &&
                        packet.slot6.ObjectType == 0x5056 &&
                        packet.slot7.ObjectType == 0x5056 &&
                        packet.slot8.ObjectType == 0x5056 &&
                        packet.slot9.ObjectType == 0x5056)
                    {
                        slotValue = 0x8755;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        inventory[packet.slot9.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Golden Chestplate
                    else if (
                        packet.slot1.ObjectType == 0x5050 &&
                        packet.slot2.ObjectType == -1 &&
                        packet.slot3.ObjectType == 0x5050 &&
                        packet.slot4.ObjectType == 0x5050 &&
                        packet.slot5.ObjectType == 0x5050 &&
                        packet.slot6.ObjectType == 0x5050 &&
                        packet.slot7.ObjectType == 0x5050 &&
                        packet.slot8.ObjectType == 0x5050 &&
                        packet.slot9.ObjectType == 0x5050)
                    {
                        slotValue = 0x8756;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        inventory[packet.slot9.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Iron Chestplate
                    else if (
                        packet.slot1.ObjectType == 0x5051 &&
                        packet.slot2.ObjectType == -1 &&
                        packet.slot3.ObjectType == 0x5051 &&
                        packet.slot4.ObjectType == 0x5051 &&
                        packet.slot5.ObjectType == 0x5051 &&
                        packet.slot6.ObjectType == 0x5051 &&
                        packet.slot7.ObjectType == 0x5051 &&
                        packet.slot8.ObjectType == 0x5051 &&
                        packet.slot9.ObjectType == 0x5051)
                    {
                        slotValue = 0x8757;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        inventory[packet.slot9.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Diamond Chestplate
                    else if (
                        packet.slot1.ObjectType == 0x5052 &&
                        packet.slot2.ObjectType == -1 &&
                        packet.slot3.ObjectType == 0x5052 &&
                        packet.slot4.ObjectType == 0x5052 &&
                        packet.slot5.ObjectType == 0x5052 &&
                        packet.slot6.ObjectType == 0x5052 &&
                        packet.slot7.ObjectType == 0x5052 &&
                        packet.slot8.ObjectType == 0x5052 &&
                        packet.slot9.ObjectType == 0x5052)
                    {
                        slotValue = 0x8758;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        inventory[packet.slot9.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Emerald Chestplate
                    else if (
                        packet.slot1.ObjectType == 0x5650 &&
                        packet.slot2.ObjectType == -1 &&
                        packet.slot3.ObjectType == 0x5650 &&
                        packet.slot4.ObjectType == 0x5650 &&
                        packet.slot5.ObjectType == 0x5650 &&
                        packet.slot6.ObjectType == 0x5650 &&
                        packet.slot7.ObjectType == 0x5650 &&
                        packet.slot8.ObjectType == 0x5650 &&
                        packet.slot9.ObjectType == 0x5650)
                    {
                        slotValue = 0x8759;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        inventory[packet.slot9.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Obsidian Chestplate
                    else if (
                        packet.slot1.ObjectType == 0x5057 &&
                        packet.slot2.ObjectType == -1 &&
                        packet.slot3.ObjectType == 0x5057 &&
                        packet.slot4.ObjectType == 0x5057 &&
                        packet.slot5.ObjectType == 0x5057 &&
                        packet.slot6.ObjectType == 0x5057 &&
                        packet.slot7.ObjectType == 0x5057 &&
                        packet.slot8.ObjectType == 0x5057 &&
                        packet.slot9.ObjectType == 0x5057)
                    {
                        slotValue = 0x8760;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        inventory[packet.slot9.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Bedrock Chestplate
                    else if (
                        packet.slot1.ObjectType == 0x8489 &&
                        packet.slot2.ObjectType == -1 &&
                        packet.slot3.ObjectType == 0x8489 &&
                        packet.slot4.ObjectType == 0x8489 &&
                        packet.slot5.ObjectType == 0x8489 &&
                        packet.slot6.ObjectType == 0x8489 &&
                        packet.slot7.ObjectType == 0x8489 &&
                        packet.slot8.ObjectType == 0x8489 &&
                        packet.slot9.ObjectType == 0x8489)
                    {
                        slotValue = 0x8761;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        inventory[packet.slot9.SlotId] = null;
                        return;
                    }
                    #endregion

                    #endregion

                    #region Untiered

                    #region Skeleton Plate
                    else if (
                        packet.slot1.ObjectType == 0x5071 &&
                        packet.slot2.ObjectType == -1 &&
                        packet.slot3.ObjectType == 0x5071 &&
                        packet.slot4.ObjectType == 0x5071 &&
                        packet.slot5.ObjectType == 0x5072 &&
                        packet.slot6.ObjectType == 0x5071 &&
                        packet.slot7.ObjectType == 0x5071 &&
                        packet.slot8.ObjectType == 0x5071 &&
                        packet.slot9.ObjectType == 0x5071)
                    {
                        slotValue = 0x4056;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        inventory[packet.slot9.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Golem Armor
                    else if (
                        packet.slot1.ObjectType == 0x5051 &&
                        packet.slot2.ObjectType == -1 &&
                        packet.slot3.ObjectType == 0x5051 &&
                        packet.slot4.ObjectType == 0x5051 &&
                        packet.slot5.ObjectType == 0x5078 &&
                        packet.slot6.ObjectType == 0x5051 &&
                        packet.slot7.ObjectType == 0x5078 &&
                        packet.slot8.ObjectType == 0x5078 &&
                        packet.slot9.ObjectType == 0x5078)
                    {
                        slotValue = 0x4425;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        inventory[packet.slot9.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region BARBIES SEXY DRESS
                    else if (
                        packet.slot1.ObjectType == 0x8434 &&
                        packet.slot2.ObjectType == -1 &&
                        packet.slot3.ObjectType == 0x8434 &&
                        packet.slot4.ObjectType == 0x8434 &&
                        packet.slot5.ObjectType == 0x8432 &&
                        packet.slot6.ObjectType == 0x8434 &&
                        packet.slot7.ObjectType == 0x8434 &&
                        packet.slot8.ObjectType == 0x8434 &&
                        packet.slot9.ObjectType == 0x8434)
                    {
                        slotValue = 0x8436;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        inventory[packet.slot9.SlotId] = null;
                        return;
                    }
                    #endregion

                    #endregion
                    break;

                case "Rings":
                    if (inventory[packet.slot2.SlotId].ObjectType != packet.slot2.ObjectType || inventory[packet.slot4.SlotId].ObjectType != packet.slot4.ObjectType || inventory[packet.slot6.SlotId].ObjectType != packet.slot6.ObjectType || inventory[packet.slot8.SlotId].ObjectType != packet.slot8.ObjectType)
                    {
                        return;
                    }
                    #region Tiered

                    #region Ring of Great Health
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5062 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == 0x5050 &&
                        packet.slot5.ObjectType == -1 &&
                        packet.slot6.ObjectType == 0x5050 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5050 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x6992;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Ring of Great Magic
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5063 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == 0x5050 &&
                        packet.slot5.ObjectType == -1 &&
                        packet.slot6.ObjectType == 0x5050 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5050 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x6993;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Ring of Great Attack
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5064 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == 0x5050 &&
                        packet.slot5.ObjectType == -1 &&
                        packet.slot6.ObjectType == 0x5050 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5050 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x6994;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Ring of Great Defense
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5065 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == 0x5050 &&
                        packet.slot5.ObjectType == -1 &&
                        packet.slot6.ObjectType == 0x5050 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5050 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x6995;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Ring of Great Speed
                    else if (
                        packet.slot1.ObjectType == -1 &&
                        packet.slot2.ObjectType == 0x5066 &&
                        packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == 0x5050 &&
                        packet.slot5.ObjectType == -1 &&
                        packet.slot6.ObjectType == 0x5050 &&
                        packet.slot7.ObjectType == -1 &&
                        packet.slot8.ObjectType == 0x5050 &&
                        packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x6996;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Ring of Great Dexterity
                    else if (
                        packet.slot1.ObjectType == -1 && packet.slot2.ObjectType == 0x5067 && packet.slot3.ObjectType == -1 &&
                        packet.slot4.ObjectType == 0x5050 && packet.slot5.ObjectType == -1 && packet.slot6.ObjectType == 0x5050 &&
                        packet.slot7.ObjectType == -1 && packet.slot8.ObjectType == 0x5050 && packet.slot9.ObjectType == -1)
                    {
                        slotValue = 0x6997;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot2.SlotId] = miscslot;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        return;
                    }
                    #endregion

                    #endregion
                    break;

                #endregion

                #region Essential

                #region Items

                case "Items":
                    if (inventory[packet.slot1.SlotId].ObjectType != packet.slot1.ObjectType || inventory[packet.slot2.SlotId].ObjectType != packet.slot2.ObjectType || inventory[packet.slot3.SlotId].ObjectType != packet.slot3.ObjectType || inventory[packet.slot4.SlotId].ObjectType != packet.slot4.ObjectType || inventory[packet.slot5.SlotId].ObjectType != packet.slot5.ObjectType || inventory[packet.slot6.SlotId].ObjectType != packet.slot6.ObjectType || inventory[packet.slot7.SlotId].ObjectType != packet.slot7.ObjectType || inventory[packet.slot8.SlotId].ObjectType != packet.slot8.ObjectType || inventory[packet.slot9.SlotId].ObjectType != packet.slot9.ObjectType)
                    {
                        return;
                    }
                    #region Blocks

                    #region Magical Water
                    else if (
                        packet.slot1.ObjectType == 0x8889 &&
                        packet.slot2.ObjectType == 0x8889 &&
                        packet.slot3.ObjectType == 0x8889 &&
                        packet.slot4.ObjectType == 0x8889 &&
                        packet.slot5.ObjectType == 0x8776 &&
                        packet.slot6.ObjectType == 0x8889 &&
                        packet.slot7.ObjectType == 0x8889 &&
                        packet.slot8.ObjectType == 0x8889 &&
                        packet.slot9.ObjectType == 0x8889)
                    {
                        slotValue = 0x8775;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        inventory[packet.slot9.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Block of Glowstone
                    else if (
                        packet.slot1.ObjectType == 0x8774 &&
                        packet.slot2.ObjectType == 0x8774 &&
                        packet.slot3.ObjectType == 0x8774 &&
                        packet.slot4.ObjectType == 0x8774 &&
                        packet.slot5.ObjectType == 0x8774 &&
                        packet.slot6.ObjectType == 0x8774 &&
                        packet.slot7.ObjectType == 0x8774 &&
                        packet.slot8.ObjectType == 0x8774 &&
                        packet.slot9.ObjectType == 0x8774)
                    {
                        slotValue = 0x8773;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        inventory[packet.slot9.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Block of Coal
                    else if (
                        packet.slot1.ObjectType == 0x5070 &&
                        packet.slot2.ObjectType == 0x5070 &&
                        packet.slot3.ObjectType == 0x5070 &&
                        packet.slot4.ObjectType == 0x5070 &&
                        packet.slot5.ObjectType == 0x5070 &&
                        packet.slot6.ObjectType == 0x5070 &&
                        packet.slot7.ObjectType == 0x5070 &&
                        packet.slot8.ObjectType == 0x5070 &&
                        packet.slot9.ObjectType == 0x5070)
                    {
                        slotValue = 0x5073;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        inventory[packet.slot9.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Block of Redstone
                    else if (
                        packet.slot1.ObjectType == 0x5055 &&
                        packet.slot2.ObjectType == 0x5055 &&
                        packet.slot3.ObjectType == 0x5055 &&
                        packet.slot4.ObjectType == 0x5055 &&
                        packet.slot5.ObjectType == 0x5055 &&
                        packet.slot6.ObjectType == 0x5055 &&
                        packet.slot7.ObjectType == 0x5055 &&
                        packet.slot8.ObjectType == 0x5055 &&
                        packet.slot9.ObjectType == 0x5055)
                    {
                        slotValue = 0x5074;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        inventory[packet.slot9.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Block of Lapis Lazuli
                    else if (
                        packet.slot1.ObjectType == 0x5056 &&
                        packet.slot2.ObjectType == 0x5056 &&
                        packet.slot3.ObjectType == 0x5056 &&
                        packet.slot4.ObjectType == 0x5056 &&
                        packet.slot5.ObjectType == 0x5056 &&
                        packet.slot6.ObjectType == 0x5056 &&
                        packet.slot7.ObjectType == 0x5056 &&
                        packet.slot8.ObjectType == 0x5056 &&
                        packet.slot9.ObjectType == 0x5056)
                    {
                        slotValue = 0x5075;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        inventory[packet.slot9.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Block of Diamond
                    else if (
                        packet.slot1.ObjectType == 0x5052 &&
                        packet.slot2.ObjectType == 0x5052 &&
                        packet.slot3.ObjectType == 0x5052 &&
                        packet.slot4.ObjectType == 0x5052 &&
                        packet.slot5.ObjectType == 0x5052 &&
                        packet.slot6.ObjectType == 0x5052 &&
                        packet.slot7.ObjectType == 0x5052 &&
                        packet.slot8.ObjectType == 0x5052 &&
                        packet.slot9.ObjectType == 0x5052)
                    {
                        slotValue = 0x5076;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        inventory[packet.slot9.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Block of Emerald
                    else if (
                        packet.slot1.ObjectType == 0x5650 &&
                        packet.slot2.ObjectType == 0x5650 &&
                        packet.slot3.ObjectType == 0x5650 &&
                        packet.slot4.ObjectType == 0x5650 &&
                        packet.slot5.ObjectType == 0x5650 &&
                        packet.slot6.ObjectType == 0x5650 &&
                        packet.slot7.ObjectType == 0x5650 &&
                        packet.slot8.ObjectType == 0x5650 &&
                        packet.slot9.ObjectType == 0x5650)
                    {
                        slotValue = 0x5077;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        inventory[packet.slot9.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Block of Iron
                    else if (
                        packet.slot1.ObjectType == 0x5051 &&
                        packet.slot2.ObjectType == 0x5051 &&
                        packet.slot3.ObjectType == 0x5051 &&
                        packet.slot4.ObjectType == 0x5051 &&
                        packet.slot5.ObjectType == 0x5051 &&
                        packet.slot6.ObjectType == 0x5051 &&
                        packet.slot7.ObjectType == 0x5051 &&
                        packet.slot8.ObjectType == 0x5051 &&
                        packet.slot9.ObjectType == 0x5051)
                    {
                        slotValue = 0x5078;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        inventory[packet.slot9.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Block of Gold
                    else if (
                        packet.slot1.ObjectType == 0x5050 &&
                        packet.slot2.ObjectType == 0x5050 &&
                        packet.slot3.ObjectType == 0x5050 &&
                        packet.slot4.ObjectType == 0x5050 &&
                        packet.slot5.ObjectType == 0x5050 &&
                        packet.slot6.ObjectType == 0x5050 &&
                        packet.slot7.ObjectType == 0x5050 &&
                        packet.slot8.ObjectType == 0x5050 &&
                        packet.slot9.ObjectType == 0x5050)
                    {
                        slotValue = 0x5079;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        inventory[packet.slot9.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Reaper's Hood 2.0 but material
                    else if (
                        packet.slot1.ObjectType == 0x8489 &&
                        packet.slot2.ObjectType == 0x8489 &&
                        packet.slot3.ObjectType == 0x8489 &&
                        packet.slot4.ObjectType == 0x8489 &&
                        packet.slot5.ObjectType == 0x8662 &&
                        packet.slot6.ObjectType == 0x8489 &&
                        packet.slot7.ObjectType == 0x8489 &&
                        packet.slot8.ObjectType == 0x8489 &&
                        packet.slot9.ObjectType == 0x8489)
                    {
                        slotValue = 0x4589;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        inventory[packet.slot9.SlotId] = null;
                        return;
                    }
                    #endregion

                    #region Magic? Stick
                    else if (
                        packet.slot1.ObjectType == 0x6983 &&
                        packet.slot2.ObjectType == 0x6a0e &&
                        packet.slot3.ObjectType == 0x6983 &&
                        packet.slot4.ObjectType == 0x6a0f &&
                        packet.slot5.ObjectType == 0x5059 &&
                        packet.slot6.ObjectType == 0x6a09 &&
                        packet.slot7.ObjectType == 0x6983 &&
                        packet.slot8.ObjectType == 0x6a0a &&
                        packet.slot9.ObjectType == 0x6983)
                    {
                        slotValue = 0x6a11;

                        if (slotValue == 0x0) return;

                        var miscslot = client.Player.Manager.Resources.GameData.Items[slotValue];
                        inventory[packet.slot1.SlotId] = miscslot;
                        inventory[packet.slot2.SlotId] = null;
                        inventory[packet.slot3.SlotId] = null;
                        inventory[packet.slot4.SlotId] = null;
                        inventory[packet.slot5.SlotId] = null;
                        inventory[packet.slot6.SlotId] = null;
                        inventory[packet.slot7.SlotId] = null;
                        inventory[packet.slot8.SlotId] = null;
                        inventory[packet.slot9.SlotId] = null;
                        return;
                    }
                    #endregion

                    #endregion
                    break;
                    
                #endregion

                #endregion
            }
        }
    }
}