using Dan.Enums;
using Dan.Main;
using Dan.Models;
using ProjectAdvergame.Module.GameConstants;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeeklyLeaderboard : MonoBehaviour
{
    [SerializeField] SO_GameConstants gameConstants;
    [SerializeField] GameObject entryPrefab;
    [SerializeField] Transform entryParent;
    [SerializeField] List<GameObject> leaderBoardItems;
    [SerializeField] TMP_Text weekText;

    private void Start()
    {
        LoadEntries();
        weekText?.SetText(GetCurrentWeek());
    }

    private void LoadEntries()
    {
        LeaderboardCreator.GetLeaderboard(gameConstants.publicKey, LeaderboardSearchQuery.ByTimePeriod(TimePeriodType.ThisWeek), OnEntriesLoaded, OnError);
    }

    private void OnEntriesLoaded(Entry[] entries)
    {
        for (int i = 0; i < entries.Length; i++)
        {
            if (i >= leaderBoardItems.Count)
                break;
            
            Entry entry = entries[i];
            TextMeshProUGUI textObject = leaderBoardItems[i].GetComponentInChildren<TextMeshProUGUI>();
            string username = entry.Username;
            if (entry.Username.Equals("Username"))
                username = "Anonymous";
            textObject.text = $"{entry.Rank}. {username} - {entry.Score}";
            leaderBoardItems[i].SetActive(true);
        }
    }

    private void OnError(string error)
    {
        Debug.LogError(error);
    }

    private string GetCurrentWeek()
    {
        // Get the current date
        DateTime today = DateTime.Now;

        // Calculate the start and end of the current week (Sunday to Saturday)
        DayOfWeek currentDay = today.DayOfWeek;
        DateTime startOfWeek = today.AddDays(-(int)currentDay); // Sunday
        DateTime endOfWeek = startOfWeek.AddDays(6); // Saturday

        // Format the dates as "29 Sep - 5 Oct"
        return $"{startOfWeek:dd MMM} - {endOfWeek:dd MMM}";
    }
}
