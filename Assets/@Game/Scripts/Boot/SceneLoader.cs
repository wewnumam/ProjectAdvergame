using Agate.MVC.Base;

namespace ProjectAdvergame.Boot
{
    public class SceneLoader : BaseLoader<SceneLoader>
    {
        protected override string SplashScene { get { return "SplashScreen";} }
    }
}
