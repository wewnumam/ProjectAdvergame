using Agate.MVC.Base;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectAdvergame.Module.PlayerCharacter
{
    public class PlayerCharacterView : BaseView
    {
        public Sprite earlyReaction;
        public List<Sprite> perfectReactions;
        public Sprite lateReaction;
        public Image reactionImage;
        public Transform playerCharacterObject;
    }
}