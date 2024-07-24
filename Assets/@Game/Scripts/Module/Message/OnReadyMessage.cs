using UnityEngine.Events;

namespace ProjectAdvergame.Message
{
    public struct OnReadyMessage 
    {
        public UnityAction OnComplete {  get; private set; }

        public OnReadyMessage(UnityAction onComplete)
        {
            OnComplete = onComplete;
        }
    }
}