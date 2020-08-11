using System.Text;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.LegacyHandsetBrand
{
    public class HandsetBrand
    {
        protected readonly HandsetApp App;
        protected string Band = "Nokia";

        protected HandsetBrand(HandsetApp app)
        {
            App = app;
        }

        public virtual void Run()
        {
            
        }
    }
}