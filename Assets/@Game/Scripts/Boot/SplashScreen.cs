using Agate.MVC.Base;
using Agate.MVC.Core;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ProjectAdvergame.Boot
{
    public class SplashScreen : BaseSplash<SplashScreen>
    {
        [SerializeField] GameObject _splashUI;
        [SerializeField] GameObject _transitionUI;
        [SerializeField] bool showGameInfo;
        [SerializeField] TMP_Text versionText;
        [SerializeField] TMP_Text activeSceneText;
        [SerializeField] Image photoImage;
        [SerializeField] List<Sprite> photoSprites;

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
            photoSprites = RollList(photoSprites, 1);
            photoImage.sprite = photoSprites[0];
        }

        private List<T> RollList<T>(List<T> list, int steps)
        {
            int count = list.Count;
            if (count == 0 || steps <= 0)
                return list;

            steps = steps % count;
            List<T> rolledList = new List<T>(count);
            rolledList.AddRange(list.GetRange(count - steps, steps));
            rolledList.AddRange(list.GetRange(0, count - steps));

            return rolledList;
        }
    }
}
