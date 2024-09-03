using Agate.MVC.Base;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectAdvergame.Module.CharacterData
{
    public interface ICharacterDataModel : IBaseModel
    {
        SO_CharacterData CurrentCharacterData { get; }
        SO_CharacterCollection CharacterCollection { get; }

        GameObject CurrentPrefab { get; }
        CharacterReactions CurrentCharacterReactions { get; }
    }

    public class CharacterReactions
    {
        public Sprite earlyReaction;
        public List<Sprite> perfectReactions;
        public Sprite lateReaction;
    }
}