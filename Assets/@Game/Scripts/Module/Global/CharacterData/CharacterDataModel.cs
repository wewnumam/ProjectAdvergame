using Agate.MVC.Base;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectAdvergame.Module.CharacterData
{
    public class CharacterDataModel : BaseModel, ICharacterDataModel
    {
        public SO_CharacterData CurrentCharacterData { get; private set; }
        public SO_CharacterCollection CharacterCollection { get; private set; }

        public GameObject CurrentPrefab { get; private set; }
        public CharacterReactions CurrentCharacterReactions { get; private set; }
        public List<Sprite> CharacterIcons { get; private set; }

        public void SetCurrentCharacterData(SO_CharacterData characterData)
        {
            CurrentCharacterData = characterData;
            SetDataAsDirty();
        }

        public void SetCharacterCollection(SO_CharacterCollection characterCollection)
        {
            CharacterCollection = characterCollection;
            SetDataAsDirty();
        }

        public void SetCurrentPrefab(GameObject currentPrefab)
        {
            CurrentPrefab = currentPrefab;
            SetDataAsDirty();
        }

        public void ResetCurrentCharacterReactions()
        {
            CurrentCharacterReactions = new CharacterReactions();
            CurrentCharacterReactions.perfectReactions = new List<Sprite>();
            SetDataAsDirty();
        }

        public void SetCurrentEarlyReaction(Sprite earlyReaction)
        {
            CurrentCharacterReactions.earlyReaction = earlyReaction;
            SetDataAsDirty();
        }

        public void AddCurrentPerfectReaction(Sprite perfectReaction)
        {
            CurrentCharacterReactions.perfectReactions.Add(perfectReaction);
            SetDataAsDirty();
        }

        public void SetCurrentLateReaction(Sprite lateReaction)
        {
            CurrentCharacterReactions.lateReaction = lateReaction;
            SetDataAsDirty();
        }

        public void ResetCharacterIcons()
        {
            CharacterIcons = new List<Sprite>();
            SetDataAsDirty();
        }

        public void AddCharacterIcon(Sprite characterIcon)
        {
            CharacterIcons.Add(characterIcon);
            SetDataAsDirty();
        }
    }
}