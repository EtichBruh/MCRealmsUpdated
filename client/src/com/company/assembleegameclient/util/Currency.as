package com.company.assembleegameclient.util {
public class Currency {

    public static const INVALID:int = -1;
    public static const GOLD:int = 0;
    public static const FAME:int = 1;
    public static const GUILD_FAME:int = 2;
    public static const FORTUNE:int = 3;
    public static const GOLDINGOT:int = 4;
    public static const IRON:int = 5;
    public static const DIAMOND:int = 6;
    //public static const GEMS:int = 4;


    public static function typeToName(_arg1:int):String {
        switch (_arg1) {
            case GOLDINGOT:
                return ("GoldIngot");
            case IRON:
                return ("Iron");
            case DIAMOND:
                return ("Diamond");
            case GOLD:
                return ("Gold");
            case FAME:
                return ("Fame");
            case GUILD_FAME:
                return ("Guild Fame");
            case FORTUNE:
                return ("Fortune Token");
            //case GEMS:
            //    return ("Gem");
        }
        return ("");
    }


}
}
