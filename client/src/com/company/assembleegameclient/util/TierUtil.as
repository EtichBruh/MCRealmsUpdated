package com.company.assembleegameclient.util
{
import com.company.assembleegameclient.misc.DefaultLabelFormat;
import com.company.assembleegameclient.misc.UILabel;
import com.company.assembleegameclient.ui.tooltip.TooltipHelper;

public class TierUtil
{


    public function TierUtil()
    {
        super();
    }

    public static function getTierTag(_arg_1:XML, _arg_2:int = 12) : UILabel
    {
        var _local_9:UILabel = null;
        var _local_10:Number = NaN;
        var _local_11:String = null;
        var _local_3:* = isPet(_arg_1) == false;
        var _local_4:* = _arg_1.hasOwnProperty("Consumable") == false;
        var _local_6:* = _arg_1.hasOwnProperty("Treasure") == false;
        var _local_7:* = _arg_1.hasOwnProperty("PetFood") == false;
        var _local_8:Boolean = _arg_1.hasOwnProperty("Tier");
        if(_local_3 && _local_4 && _local_6 && _local_7)
        {
            _local_9 = new UILabel();
            if(_local_8)
            {
                _local_10 = 16777215;
                _local_11 = "T" + _arg_1.Tier;
            }
            else if (_arg_1.hasOwnProperty("END"))
            {
                _local_10 = 0x6a0dad;
                _local_11 = "E";
            }
            else if (_arg_1.hasOwnProperty("Common")) //Easy
            {
                _local_10 = 0xC8C8C8;
                _local_11 = "I";
            }
            else if (_arg_1.hasOwnProperty("Uncommon")) //Normal
            {
                _local_10 = 0x12D34F;
                _local_11 = "II";
            }
            else if (_arg_1.hasOwnProperty("Rare")) //Hard
            {
                _local_10 = 0x1EA7FA;
                _local_11 = "III";
            }
            else if (_arg_1.hasOwnProperty("Epic")) //Insane
            {
                _local_10 = 0x9012D8;
                _local_11 = "IV";
            }
            else if (_arg_1.hasOwnProperty("Legendary")) //Ultra
            {
                _local_10 = 0xF4FB09;
                _local_11 = "V";
            }
            else if(_arg_1.hasOwnProperty("@setType"))
            {
                _local_10 = TooltipHelper.SET_COLOR;
                _local_11 = "ST";
            }
            else
            {
                _local_10 = TooltipHelper.UNTIERED_COLOR;
                _local_11 = "UT";
            }
            _local_9.text = _local_11;
            DefaultLabelFormat.tierLevelLabel(_local_9,_arg_2,_local_10);
            return _local_9;
        }
        return null;
    }

    public static function isPet(itemDataXML:XML) : Boolean
    {
        var activateTags:XMLList = null;
        activateTags = itemDataXML.Activate.(text() == "PermaPet");
        return activateTags.length() >= 1;
    }
}
}
