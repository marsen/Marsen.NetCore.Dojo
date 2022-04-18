using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.BridgePattern.LegacyHandsetBrand.Refactored.Soft;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.BridgePattern.LegacyHandsetBrand.Refactored.Brand;

public sealed class HandsetMotorola : HandsetBrand
{
    public HandsetMotorola(Application app) : base(app)
    {
        Brand = "Motorola";
    }
}