using Agate.MVC.Base;
using ProjectAdvergame.Message;

namespace ProjectAdvergame.Module.SaveSystem
{
    public class SaveSystemConnector : BaseConnector
    {
        private SaveSystemController _saveSystem;

        protected override void Connect()
        {
            Subscribe<GameResultHeartMessage>(_saveSystem.SaveHeartResult);
            Subscribe<GameResultStarMessage>(_saveSystem.SaveStarResult);
            Subscribe<GameResultScoreMessage>(_saveSystem.SaveScoreResult);
            Subscribe<UnlockLevelMessage>(_saveSystem.UnlockLevel);
            Subscribe<UnlockCharacterMessage>(_saveSystem.UnlockCharacter);
            Subscribe<DeleteSaveDataMessage>(_saveSystem.DeleteSaveData);
            Subscribe<FullStarMessage>(_saveSystem.FullStar);
            Subscribe<UpdateUsernameMessage>(_saveSystem.UpdateUsername);
        }

        protected override void Disconnect()
        {
            Unsubscribe<GameResultHeartMessage>(_saveSystem.SaveHeartResult);
            Unsubscribe<GameResultStarMessage>(_saveSystem.SaveStarResult);
            Unsubscribe<GameResultScoreMessage>(_saveSystem.SaveScoreResult);
            Unsubscribe<UnlockLevelMessage>(_saveSystem.UnlockLevel);
            Unsubscribe<UnlockCharacterMessage>(_saveSystem.UnlockCharacter);
            Unsubscribe<DeleteSaveDataMessage>(_saveSystem.DeleteSaveData);
            Unsubscribe<FullStarMessage>(_saveSystem.FullStar);
            Unsubscribe<UpdateUsernameMessage>(_saveSystem.UpdateUsername);
        }
    }
}