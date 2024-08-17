using ProjectAdvergame.Utility;
using UnityEngine;

namespace ProjectAdvergame.Message
{
    public struct LoadProgressMessage
    {
        public string Label { get; }
        public float Percentage { get; }
        public bool IsDone { get; }

        public LoadProgressMessage(string label, float percentage, bool isDone)
        {
            Label = label;
            Percentage = percentage;
            IsDone = isDone;
        }
    }
}