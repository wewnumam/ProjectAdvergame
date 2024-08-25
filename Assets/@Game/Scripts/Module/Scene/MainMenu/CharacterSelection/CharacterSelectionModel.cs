using Agate.MVC.Base;
using ProjectAdvergame.Module.CharacterData;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectAdvergame.Module.CharacterSelection
{
    public class CharacterSelectionModel : BaseModel, ICharacterSelectionModel
    {
        public SO_CharacterCollection CharacterCollection { get; private set; }
        public List<string> UnlockedCharacters { get; private set; }
        public int CurrentHeartCount { get; private set; }
        public int CurrentStarCount { get; private set; }
        public string CurrentCharacterName { get; private set; }
        public string CurrentCharacterFullName { get; private set; }
        public GameObject CurrentPrefab { get; private set; }

        public void SetCharacterCollection(SO_CharacterCollection characterCollection)
        {
            CharacterCollection = characterCollection;
            SetDataAsDirty();
        }

        public void SetUnlockedCharacters(List<string> unlockedCharacters)
        {
            UnlockedCharacters = unlockedCharacters;
            SetDataAsDirty();
        }

        public void SetCurrentHeartCount(int count)
        {
            CurrentHeartCount = count;
            SetDataAsDirty();
        }

        public void SetCurrentStarCount(int count)
        {
            CurrentStarCount = count;
            SetDataAsDirty();
        }

        public void SubtractHeart(int cost)
        {
            CurrentHeartCount -= cost;
            SetDataAsDirty();
        }

        public void SetCurrentContent(string currentCharacterName, string currentCharacterFullName, GameObject currentPrefab)
        {
            CurrentCharacterName = currentCharacterName;
            CurrentCharacterFullName = currentCharacterFullName;
            CurrentPrefab = currentPrefab;
            SetDataAsDirty();
        }
    }
}