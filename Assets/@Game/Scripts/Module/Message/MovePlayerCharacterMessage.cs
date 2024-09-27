namespace ProjectAdvergame.Message
{
    public struct MovePlayerCharacterMessage 
    {
        public float CurrentStoneZPos { get; }

        public MovePlayerCharacterMessage(float currentStoneZPos)
        {
            CurrentStoneZPos = currentStoneZPos;
        }
    }
}