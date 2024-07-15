using ProjectAdvergame.Utility;

namespace ProjectAdvergame.Message
{
    public struct BeatAccuracyMessage
    {
        public EnumManager.BeatAccuracy BeatAccuracy { get; }

        public BeatAccuracyMessage(EnumManager.BeatAccuracy beatAccuracy)
        {
            BeatAccuracy = beatAccuracy;
        }
    }
}