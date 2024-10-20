using ProjectAdvergame.Utility;

namespace ProjectAdvergame.Message
{
    public struct BeatAccuracyMessage
    {
        public EnumManager.BeatAccuracy BeatAccuracy { get; }
        public EnumManager.StoneType StoneType { get; }
        public int CurrentIndex { get; }

        public BeatAccuracyMessage(EnumManager.BeatAccuracy beatAccuracy, EnumManager.StoneType stoneType, int currentIndex)
        {
            BeatAccuracy = beatAccuracy;
            StoneType = stoneType;
            CurrentIndex = currentIndex;
        }
    }
}