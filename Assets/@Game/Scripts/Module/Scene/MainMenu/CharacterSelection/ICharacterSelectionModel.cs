using Agate.MVC.Base;
using ProjectAdvergame.Module.CharacterData;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectAdvergame.Module.CharacterSelection
{
    public interface ICharacterSelectionModel : IBaseModel
    {
        SO_CharacterCollection CharacterCollection { get; }
        List<string> UnlockedCharacters { get; }
        int CurrentHeartCount { get; }
        int CurrentStarCount { get; }
        string CurrentCharacterName { get; }
        string CurrentCharacterFullName { get; }
        GameObject CurrentPrefab { get;  }
    }
}