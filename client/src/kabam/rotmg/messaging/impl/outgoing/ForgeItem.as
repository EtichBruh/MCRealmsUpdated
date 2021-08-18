package kabam.rotmg.messaging.impl.outgoing {
import flash.utils.IDataOutput;

import kabam.rotmg.messaging.impl.data.SlotObjectData;

public class ForgeItem extends OutgoingMessage {

    public function ForgeItem(_arg_1:uint, _arg_2:Function) {
        super(_arg_1, _arg_2);
    }

    public var type_:int;
    public var slot1_:SlotObjectData
    public var slot2_:SlotObjectData
    public var slot3_:SlotObjectData
    public var slot4_:SlotObjectData
    public var slot5_:SlotObjectData
    public var slot6_:SlotObjectData
    public var slot7_:SlotObjectData
    public var slot8_:SlotObjectData
    public var slot9_:SlotObjectData

    override public function writeToOutput(_arg1:IDataOutput):void {
        _arg1.writeInt(this.type_);
        this.slot1_.writeToOutput(_arg1);
        this.slot2_.writeToOutput(_arg1);
        this.slot3_.writeToOutput(_arg1);
        this.slot4_.writeToOutput(_arg1);
        this.slot5_.writeToOutput(_arg1);
        this.slot6_.writeToOutput(_arg1);
        this.slot7_.writeToOutput(_arg1);
        this.slot8_.writeToOutput(_arg1);
        this.slot9_.writeToOutput(_arg1);
    }

    override public function toString():String {
        return formatToString("FORGEITEM", "type_", "slot1_", "slot2_", "slot3_", "slot4_", "slot5_", "slot6_", "slot7_", "slot8_", "slot9_");
    }
}
}
