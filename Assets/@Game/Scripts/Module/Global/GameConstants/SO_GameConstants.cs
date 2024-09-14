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

        [Header("Leaderboard")]
        public string publicKey;

        [Header("Badge")]
        public List<Badge> badges;

        public Badge GetCurrentBadge(int xp)
        {
            if (xp <= 0)
                return badges[0];
            
            foreach (var badge in badges)
            {
                if (xp > badge.amount && xp <= GetNextBadge(badge).amount)
                    return badge;
            }

            return badges[badges.Count - 1];
        }

        public Badge GetNextBadge(Badge currentBadge)
        {
            return badges[badges.IndexOf(currentBadge) + 1];
        }
    }

    [Serializable]
    public class Badge
    {
        public string name;
        public int amount;
    }
}
