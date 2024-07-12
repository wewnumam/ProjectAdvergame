using Agate.MVC.Base;
using Agate.MVC.Core;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectAdvergame.Boot
{
    public class SplashScreen : BaseSplash<SplashScreen>
    {
        [SerializeField] GameObject _splashUI;
        [SerializeField] GameObject _transitionUI;
        [SerializeField] bool showGameInfo;
        [SerializeField] TMP_Text versionText;
        [SerializeField] TMP_Text activeSceneText;

        protected override IMain GetMain()
        {
            return GameMain.Instance;
        }

        protected override ILoad GetLoader()
        {
            return SceneLoader.Instance;
        }

        protected override void StartSplash()
        {
            base.StartSplash();
            _splashUI.SetActive(true);
            _transitionUI.SetActive(false);
        }

        protected override void FinishSplash()
        {
            base.FinishSplash();
            _splashUI.SetActive(false);
        }

        protected override void StartTransition()
        {
            base.StartTransition();
            _transitionUI.SetActive(true);
        }

        protected override void FinishTransition()
        {
            base.FinishTransition();
            _transitionUI.SetActive(false);

            if (showGameInfo)
            {
                versionText.SetText(Application.version);
                activeSceneText.SetText(SceneManager.GetActiveScene().name);
            }
            else
            {
                versionText.enabled = false;
                activeSceneText.enabled = false;
            }
        }

    }
}
