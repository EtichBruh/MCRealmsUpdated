package kabam.rotmg.ui.signals {
import kabam.rotmg.ui.model.Key;

import org.osflash.signals.Signal;

public class EndRaidSignal extends Signal {

    public static var instance:EndRaidSignal;

    public function EndRaidSignal() {
        super(Key);
        instance = this;
    }

}
}
