using DG.Tweening;
using NaughtyAttributes;
using ProjectAdvergame.Module.LevelData;
using ProjectAdvergame.Utility;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BeatCreator : MonoBehaviour
{
    [ReadOnly] public bool isPlay;
    [ReadOnly] public float currentTime;
    [ReadOnly] public int currentSwitchDirectionIndex;
    [ReadOnly] public EnumManager.Direction currentDirection;
    [ReadOnly] public List<GameObject> beatObjs;

    [SerializeField] TMP_Text currentTimeText;
    [SerializeField] AudioSource audioSource;
    [SerializeField] SO_BeatCreatorData beatCreatorData;
    [SerializeField] GameObject beatPrefab;
    

    private void Awake()
    {
        currentDirection = EnumManager.Direction.FromEast;
        audioSource.clip = beatCreatorData.clip;
    }

    private void Start()
    {
        if (beatCreatorData.beats.Count > 0)
        {
            beatObjs = new List<GameObject>();

            foreach (var beat in beatCreatorData.beats)
            {
                GameObject obj = Instantiate(beatPrefab, new Vector3(beat.direction == EnumManager.Direction.FromEast ? beat.interval : -beat.interval, 0, 0), Quaternion.identity);
                beatObjs.Add(obj);
            }
        }
    }

    private void Update()
    {
        if (!isPlay)
            return;

        currentTime += Time.deltaTime;
        currentTimeText?.SetText($"{currentTime:F2}");

        if (currentSwitchDirectionIndex < beatCreatorData.switchDirections.Count)
        {
            if (currentTime > beatCreatorData.switchDirections[currentSwitchDirectionIndex])
            {
                if (currentDirection == EnumManager.Direction.FromEast)
                    currentDirection = EnumManager.Direction.FromWest;
                else
                    currentDirection = EnumManager.Direction.FromEast;

                currentSwitchDirectionIndex++;
            }
        }
    }

    public void AddBeat()
    {
        Beat beat = new Beat();
        beat.interval = currentTime;
        beat.direction = currentDirection;
        beatCreatorData.beats.Add(beat);
    }

    public void Record()
    {
        beatCreatorData.beats = new List<Beat>();
        isPlay = true;
        audioSource.Play();
    }

    public void Playback()
    {
        isPlay = true;
        for (int i = 0; i < beatObjs.Count; i++)
            beatObjs[i].transform.DOMoveX(0, beatCreatorData.beats[i].interval).SetEase(Ease.Linear);
        
        audioSource.Play();
    }
}
