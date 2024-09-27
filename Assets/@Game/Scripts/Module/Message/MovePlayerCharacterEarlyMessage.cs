namespace ProjectAdvergame.Message
{
    public struct MovePlayerCharacterEarlyMessage
    {
        public float CurrentStoneZPos { get; }
        public float Duration { get; }

        public MovePlayerCharacterEarlyMessage(float moveAmount, float duration)
        {
            CurrentStoneZPos = moveAmount;
            Duration = duration;
        }
    }
}