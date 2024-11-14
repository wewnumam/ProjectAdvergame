using Dan.Enums;
using Dan.Main;
using Dan.Models;
using ProjectAdvergame.Module.GameConstants;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DateFilteredLeaderboard : MonoBehaviour
{
    [SerializeField] SO_GameConstants gameConstants;
    [SerializeField] List<AllTimeLeaderboardItem> allTimeLeaderboardItems;
    [SerializeField] List<WeeklyLeaderboardItem> leaderBoardItems;
    [SerializeField] TMP_Text dateRangeText;
    [SerializeField] ulong startUnixTime; // Set this in the Inspector as a Unix timestamp
    [SerializeField] ulong endUnixTime; // Set this in the Inspector as a Unix timestamp

    private void Start()
    {
        LoadEntries();
    }

    private void LoadEntries()
    {
        // Retrieve all-time entries as a broad filter
        LeaderboardCreator.GetLeaderboard(gameConstants.publicKey,
            LeaderboardSearchQuery.ByTimePeriod(TimePeriodType.AllTime),
            OnEntriesLoaded, OnError);
    }

    private void OnEntriesLoaded(Entry[] entries)
    {
        dateRangeText?.SetText(GetDateRangeText());

        // Filter entries by Unix timestamp
        List<Entry> filteredEntries = new List<Entry>();
        foreach (var entry in entries)
        {
            Debug.Log(entry.Date);
            ulong entryUnixTime = entry.Date;// Assuming entry.UnixTimestamp exists
            if (entryUnixTime >= startUnixTime && entryUnixTime <= endUnixTime)
            {
                filteredEntries.Add(entry);
            }
        }
        filteredEntries.Sort((entry1, entry2) => entry2.Score.CompareTo(entry1.Rank));

        // Display the filtered entries
        for (int i = 0; i < filteredEntries.Count && i < leaderBoardItems.Count; i++)
        {
            Entry entry = filteredEntries[i];
            string username = entry.Username;
            if (entry.Username.Equals("Username"))
                username = "Anonymous";
            
            leaderBoardItems[i].rank.text = entry.Rank.ToString();
            leaderBoardItems[i].username.text = username;
            leaderBoardItems[i].score.text = entry.Score.ToString();
        }

        for (int i = 0; i < entries.Length && i < allTimeLeaderboardItems.Count; i++)
        {
            string username = entries[i].Username;
            if (entries[i].Username.Equals("Username"))
                username = "Anonymous";
            allTimeLeaderboardItems[i].username?.SetText(username);
            allTimeLeaderboardItems[i].score?.SetText(entries[i].Score.ToString());
        }
    }

    private void OnError(string error)
    {
        Debug.LogError(error);
    }

    private string GetDateRangeText()
    {
        // Convert Unix timestamps to DateTime for display
        DateTime startDate = DateTimeOffset.FromUnixTimeSeconds((long)startUnixTime).DateTime;
        DateTime endDate = DateTimeOffset.FromUnixTimeSeconds((long)endUnixTime).DateTime;

        // Format the date range as "29 Sep - today"
        return $"{startDate:dd MMM} - {endDate:dd MMM}";
    }
}
