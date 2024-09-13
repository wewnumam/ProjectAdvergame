using System;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectAdvergame.Module.GameConstants
{
    [CreateAssetMenu(fileName = "GameConstants", menuName = "ProjectAdvergame/GameConstants", order = 0)]
    public class SO_GameConstants : ScriptableObject
    {
        [Header("Pre Game")]
        public float onReadyCountdown;

        [Header("Beat Accuracy")]
        public float minPerfectTapPhase;

        [Header("Score")]
        public int scoreEarlyAmount;
        public int scorePerfectAmount;
        public int scoreLateAmount;

        [Header("Health")]
        public int initialHealth;

        [Header("Badge")]
        public List<Badge> badges;
    }

    [Serializable]
    public class Badge
    {
        public string name;
        public int score;
    }
}
