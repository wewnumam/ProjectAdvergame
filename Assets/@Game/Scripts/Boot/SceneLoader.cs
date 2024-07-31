using Agate.MVC.Base;
using ProjectAdvergame.Utility;

namespace ProjectAdvergame.Boot
{
    public class SceneLoader : BaseLoader<SceneLoader>
    {
        protected override string SplashScene { get { return TagManager.SCENE_SPLASHSCREEN;} }
    }
}
