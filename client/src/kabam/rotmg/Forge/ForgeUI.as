package kabam.rotmg.Forge {
import com.company.assembleegameclient.game.AGameSprite;
import com.company.assembleegameclient.ui.DeprecatedTextButton;
import com.company.assembleegameclient.ui.FrameChef;

import flash.events.Event;
import flash.events.MouseEvent;

import kabam.rotmg.questrewards.components.ModalItemSlot;

import org.osflash.signals.Signal;

public class ForgeUI extends FrameChef {

    public const cancel:Signal = new Signal();

    public var gameSprite:AGameSprite;
    public var slot1:ModalItemSlot;
    public var slot2:ModalItemSlot;
    public var slot3:ModalItemSlot;
    public var slot4:ModalItemSlot;
    public var slot5:ModalItemSlot;
    public var slot6:ModalItemSlot;
    public var slot7:ModalItemSlot;
    public var slot8:ModalItemSlot;
    public var slot9:ModalItemSlot;
    public var forgeButton:DeprecatedTextButton;
    public var typeButton:DeprecatedTextButton;

    public function ForgeUI(_arg_1:AGameSprite) {
        this.gameSprite = _arg_1;
        super("Craft your items.", "", 288);
        this.addForgeUI();
        this.forgeButton = new DeprecatedTextButton(16, "Forge");
        this.forgeButton.y = 305;
        this.forgeButton.x = 108;
        addChild(this.forgeButton)

        this.typeButton = new DeprecatedTextButton(16, "Swords");
        this.typeButton.y = 350;
        this.typeButton.x = 102;
        addChild(this.typeButton)

        XButton.addEventListener(MouseEvent.CLICK, this.onClose);
    }


    private function addForgeUI() : void {
        this.slot1 = new ModalItemSlot(true, false);
        this.slot1.y = 70;
        this.slot1.x = 15;
        addChild(this.slot1);

        this.slot2 = new ModalItemSlot(true, false);
        this.slot2.y = slot1.y;
        this.slot2.x = slot1.x + 80;
        addChild(this.slot2);

        this.slot3 = new ModalItemSlot(true, false);
        this.slot3.y = slot1.y;
        this.slot3.x = slot2.x + 80;
        addChild(this.slot3);

        this.slot4 = new ModalItemSlot(true, false);
        this.slot4.y = slot1.y + 80;
        this.slot4.x = slot1.x;
        addChild(this.slot4);

        this.slot5 = new ModalItemSlot(true, false);
        this.slot5.y = slot1.y + 80;
        this.slot5.x = slot2.x;
        addChild(this.slot5);

        this.slot6 = new ModalItemSlot(true, false);
        this.slot6.y = slot1.y + 80;
        this.slot6.x = slot3.x;
        addChild(this.slot6);

        this.slot7 = new ModalItemSlot(true, false);
        this.slot7.y = slot1.y + 160;
        this.slot7.x = slot1.x;
        addChild(this.slot7);

        this.slot8 = new ModalItemSlot(true, false);
        this.slot8.y = slot1.y + 160;
        this.slot8.x = slot2.x;
        addChild(this.slot8);

        this.slot9 = new ModalItemSlot(true, false);
        this.slot9.y = slot1.y + 160;
        this.slot9.x = slot3.x;
        addChild(this.slot9);
    }

    public function getItemSlot1():ModalItemSlot {
        return (this.slot1);
    }
    public function getItemSlot2():ModalItemSlot {
        return (this.slot2);
    }
    public function getItemSlot3():ModalItemSlot {
        return (this.slot3);
    }
    public function getItemSlot4():ModalItemSlot {
        return (this.slot4);
    }
    public function getItemSlot5():ModalItemSlot {
        return (this.slot5);
    }
    public function getItemSlot6():ModalItemSlot {
        return (this.slot6);
    }
    public function getItemSlot7():ModalItemSlot {
        return (this.slot7);
    }
    public function getItemSlot8():ModalItemSlot {
        return (this.slot8);
    }
    public function getItemSlot9():ModalItemSlot {
        return (this.slot9);
    }

    private function onClose(e:Event) : void {
    }


}
}

