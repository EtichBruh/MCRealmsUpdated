package kabam.rotmg.Forge.components
{
import com.company.assembleegameclient.game.AGameSprite;
import com.company.assembleegameclient.game.GameSprite;
import com.company.assembleegameclient.ui.DeprecatedTextButton;
import com.company.assembleegameclient.ui.panels.Panel;
import kabam.rotmg.dialogs.control.OpenDialogNoModalSignal;
import kabam.rotmg.pets.util.PetsViewAssetFactory;
import kabam.rotmg.text.view.TextFieldDisplayConcrete;
import kabam.rotmg.text.view.stringBuilder.LineBuilder;

public class ForgePanel extends Panel
{


    private const titleText:TextFieldDisplayConcrete = PetsViewAssetFactory.returnTextfield(16777215,16,true);

    [Inject]
    public var gameSprite:AGameSprite;

    [Inject]
    public var openDialog:OpenDialogNoModalSignal;

    private var title:String = "Craft";

    private var buttonText:String = "Start Crafting";

    private var objectType:int;

    var forgeButton:DeprecatedTextButton;

    public function ForgePanel(_arg_1:GameSprite, _arg_2:int)
    {
        super(_arg_1);
        this.objectType = _arg_2;
        this.titleText.setStringBuilder(new LineBuilder().setParams(this.title));
        addChild(this.titleText);
        this.forgeButton = new DeprecatedTextButton(16,this.buttonText);
        this.forgeButton.textChanged.addOnce(this.alignButton);
        addChild(this.forgeButton);
    }

    private function alignButton() : void
    {
        this.forgeButton.x = WIDTH / 2 - this.forgeButton.width / 2;
        this.forgeButton.y = HEIGHT - this.forgeButton.height - 4;
        this.titleText.x = WIDTH / 2 - this.titleText.width / 2;
        this.titleText.y = HEIGHT - this.titleText.height - 4 - 30;
    }
}
}
