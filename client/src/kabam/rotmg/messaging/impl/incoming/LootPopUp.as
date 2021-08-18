package kabam.rotmg.messaging.impl.incoming
{
import flash.utils.IDataInput;

public class LootPopUp extends IncomingMessage
{
    public var bagType_:int;

    public function LootPopUp(param1:uint, param2:Function)
    {
        super(param1,param2);
    }

    override public function parseFromInput(param1:IDataInput) : void
    {
        this.bagType_ = param1.readByte();
    }

    override public function toString() : String
    {
        return formatToString("LootNotify","bagType_");
    }
}
}
