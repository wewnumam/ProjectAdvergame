using ProjectAdvergame.Utility;
using System.Collections.Generic;

namespace ProjectAdvergame.Message
{
    public struct UpdateZPosCollectionMessage
    {
        public List<float> ZPosCollection { get; }

        public UpdateZPosCollectionMessage(List<float> zPosCollection)
        {
            ZPosCollection = zPosCollection;
        }
    }
}