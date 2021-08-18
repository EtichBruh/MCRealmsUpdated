package kabam.rotmg.Forge {
import com.company.assembleegameclient.game.AGameSprite;

import flash.events.MouseEvent;

import kabam.lib.net.api.MessageProvider;
import kabam.lib.net.impl.SocketServer;
import kabam.rotmg.dialogs.control.CloseDialogsSignal;
import kabam.rotmg.dialogs.control.OpenDialogNoModalSignal;
import kabam.rotmg.game.signals.AddTextLineSignal;
import kabam.rotmg.messaging.impl.GameServerConnection;
import kabam.rotmg.messaging.impl.data.SlotObjectData;
import kabam.rotmg.messaging.impl.outgoing.ForgeItem;
import kabam.rotmg.questrewards.components.ModalItemSlot;

import org.swiftsuspenders.Injector;

import robotlegs.bender.bundles.mvcs.Mediator;

public class ForgeUIMediator extends Mediator {

    [Inject]
    public var injector:Injector;
    [Inject]
    public var closeDialogs:CloseDialogsSignal;
    [Inject]
    public var socketServer:SocketServer;
    [Inject]
    public var messages:MessageProvider;
    [Inject]
    public var view:ForgeUI;
    [Inject]
    public var gameSprite:AGameSprite;
    [Inject]
    public var openNoModalDialog:OpenDialogNoModalSignal;
    [Inject]
    public var addTextLine:AddTextLineSignal;
    [Inject]
    public var itemslot1:ModalItemSlot;
    [Inject]
    public var itemslot2:ModalItemSlot;
    [Inject]
    public var itemslot3:ModalItemSlot;
    [Inject]
    public var itemslot4:ModalItemSlot;
    [Inject]
    public var itemslot5:ModalItemSlot;
    [Inject]
    public var itemslot6:ModalItemSlot;
    [Inject]
    public var itemslot7:ModalItemSlot;
    [Inject]
    public var itemslot8:ModalItemSlot;
    [Inject]
    public var itemslot9:ModalItemSlot;
    [Inject]
    public var slot1Data:SlotObjectData;
    [Inject]
    public var slot2Data:SlotObjectData;
    [Inject]
    public var slot3Data:SlotObjectData;
    [Inject]
    public var slot4Data:SlotObjectData;
    [Inject]
    public var slot5Data:SlotObjectData;
    [Inject]
    public var slot6Data:SlotObjectData;
    [Inject]
    public var slot7Data:SlotObjectData;
    [Inject]
    public var slot8Data:SlotObjectData;
    [Inject]
    public var slot9Data:SlotObjectData;

    private var type:int = 0;

    override public function initialize():void {
        this.clearItemslots();
        this.itemslot1 = this.view.getItemSlot1()
        this.itemslot2 = this.view.getItemSlot2()
        this.itemslot3 = this.view.getItemSlot3()
        this.itemslot4 = this.view.getItemSlot4()
        this.itemslot5 = this.view.getItemSlot5()
        this.itemslot6 = this.view.getItemSlot6()
        this.itemslot7 = this.view.getItemSlot7()
        this.itemslot8 = this.view.getItemSlot8()
        this.itemslot9 = this.view.getItemSlot9()
        this.view.forgeButton.addEventListener(MouseEvent.CLICK, this.onButtonForge);
        this.view.typeButton.addEventListener(MouseEvent.CLICK, this.onSwitchType);
    }
    override public function destroy():void {
        super.destroy();
    }

    private function clearItemslots() : void {
        this.itemslot1 = null;
        this.itemslot2 = null;
        this.itemslot3 = null;
        this.itemslot4 = null;
        this.itemslot5 = null;
        this.itemslot6 = null;
        this.itemslot7 = null;
        this.itemslot8 = null;
        this.itemslot9 = null;
    }

    private function onSwitchType(_arg_1:MouseEvent) : void {
        if (type == 0) {
            this.view.typeButton.setText("Pickaxes");
            type = 1;
            return;
        }
        if (type == 1) {
            this.view.typeButton.setText("Bows");
            type = 2;
            return;
        }
        if (type == 2) {
            this.view.typeButton.setText("Staves");
            type = 3;
            return;
        }
        if (type == 3) {
            this.view.typeButton.setText("Axes");
            type = 4;
            return;
        }
        if (type == 4) {
            this.view.typeButton.setText("Wands");
            type = 5;
            return;
        }
        if (type == 5) {
            this.view.typeButton.setText("Abilities");
            type = 6;
            return;
        }
        if (type == 6) {
            this.view.typeButton.setText("Armors");
            type = 7;
            return;
        }
        if (type == 7) {
            this.view.typeButton.setText("Rings");
            type = 8;
            return;
        }
        if (type == 8) {
            this.view.typeButton.setText("Items");
            type = 9;
            return;
        }
        if (type == 9) {
            this.view.typeButton.setText("Swords");
            type = 0;
            return;
        }
    }


    protected function onButtonForge(_arg_1:MouseEvent):void {
        slot1Data = new SlotObjectData();
        slot1Data.objectId_ = this.itemslot1.objectId;
        slot1Data.objectType_ = this.itemslot1.itemId;
        slot1Data.slotId_ = this.itemslot1.slotId;
        slot2Data = new SlotObjectData();
        slot2Data.objectId_ = this.itemslot2.objectId;
        slot2Data.objectType_ = this.itemslot2.itemId;
        slot2Data.slotId_ = this.itemslot2.slotId;
        slot3Data = new SlotObjectData();
        slot3Data.objectId_ = this.itemslot3.objectId;
        slot3Data.objectType_ = this.itemslot3.itemId;
        slot3Data.slotId_ = this.itemslot3.slotId;
        slot4Data = new SlotObjectData();
        slot4Data.objectId_ = this.itemslot4.objectId;
        slot4Data.objectType_ = this.itemslot4.itemId;
        slot4Data.slotId_ = this.itemslot4.slotId;
        slot5Data = new SlotObjectData();
        slot5Data.objectId_ = this.itemslot5.objectId;
        slot5Data.objectType_ = this.itemslot5.itemId;
        slot5Data.slotId_ = this.itemslot5.slotId;
        slot6Data = new SlotObjectData();
        slot6Data.objectId_ = this.itemslot6.objectId;
        slot6Data.objectType_ = this.itemslot6.itemId;
        slot6Data.slotId_ = this.itemslot6.slotId;
        slot7Data = new SlotObjectData();
        slot7Data.objectId_ = this.itemslot7.objectId;
        slot7Data.objectType_ = this.itemslot7.itemId;
        slot7Data.slotId_ = this.itemslot7.slotId;
        slot8Data = new SlotObjectData();
        slot8Data.objectId_ = this.itemslot8.objectId;
        slot8Data.objectType_ = this.itemslot8.itemId;
        slot8Data.slotId_ = this.itemslot8.slotId;
        slot9Data = new SlotObjectData();
        slot9Data.objectId_ = this.itemslot9.objectId;
        slot9Data.objectType_ = this.itemslot9.itemId;
        slot9Data.slotId_ = this.itemslot9.slotId;
        var _local_1:ForgeItem;
        _local_1 = (this.messages.require(GameServerConnection.FORGEITEM) as ForgeItem);
        _local_1.type_ = type;
        _local_1.slot1_ = this.slot1Data;
        _local_1.slot2_ = this.slot2Data;
        _local_1.slot3_ = this.slot3Data;
        _local_1.slot4_ = this.slot4Data;
        _local_1.slot5_ = this.slot5Data;
        _local_1.slot6_ = this.slot6Data;
        _local_1.slot7_ = this.slot7Data;
        _local_1.slot8_ = this.slot8Data;
        _local_1.slot9_ = this.slot9Data;
        this.socketServer.sendMessage(_local_1);
        this.closeDialogs.dispatch()
    }


}
}
