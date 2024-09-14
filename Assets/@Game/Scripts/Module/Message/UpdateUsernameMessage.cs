using ProjectAdvergame.Utility;

namespace ProjectAdvergame.Message
{
    public struct UpdateUsernameMessage
    {
        public string Username { get; }

        public UpdateUsernameMessage(string username)
        {
            Username = username;
        }
    }
}