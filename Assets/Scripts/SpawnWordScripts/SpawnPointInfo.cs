using System;
using System.Collections;
using System.Collections.Generic;
using Managers.Resource;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace SpawnWordScripts
{
    public class SpawnPointInfo : MonoBehaviour
    {
        [Header("Dot Info")] 
        [SerializeField] public string NamePoint;
        [SerializeField] public float TimerSpawn; 
        [SerializeField] public int LevelPoint; 
        [SerializeField] public Vector2 MinMaxMoney;

        [Header("Spawn Info")] 
        public GameObject Boss;

        public bool IsPointOpen { get; set; }
        public bool IsActiveTimer { get; set; }
        public bool InBattleComplete { get; set; }
        
        public PointUIController pointUIController { get; set; }
        private Slider sliderTimer;
        private float currentTimer;
        public int WinningMoney { get; set; }
        private DateTime startTime = DateTime.Now;

        public SpawnPointController SpawnPointController { get; set; }
        
        private string StringSaveDataActivate = "StringSaveDataActivate";
        private string StringSaveDataPlayedPoint  = "StringSaveDataPlayedPoint";
        private string StringSaveDataTimer  = "StringSaveDataTimer";
        private string StringSaveWinningData  = "StringSaveWinningData";
        
        public delegate void OnWordPointTap(SpawnPointInfo spawnPointInfo);
        public static event OnWordPointTap WordPointTap;
        private Coroutine  coroutine;
        
        private void OnMouseDown()
        {
            if(IsActiveTimer)
                return;
            
            WordPointTap?.Invoke(this);
        }

        private void Awake()
        {
            StringSaveDataActivate += transform.parent.name + transform.parent.parent.name;
            StringSaveDataPlayedPoint += transform.parent.name + transform.parent.parent.name;
            StringSaveDataTimer += transform.parent.name + transform.parent.parent.name;
            StringSaveWinningData += transform.parent.name + transform.parent.parent.name;
            pointUIController = GetComponent<PointUIController>();
            
            LoadInformation();
            SetUISettings();
        }
        
        private void SetUISettings()
        {
            sliderTimer = pointUIController.timerSlider;
            sliderTimer.maxValue = TimerSpawn;
            sliderTimer.value = 0;
            
            sliderTimer.gameObject.SetActive(false);
            pointUIController.ResetUI(LevelPoint);
        }

        public void SetActivePoint()
        {
            InBattleComplete = false;
            IsPointOpen = true;
            PlayerPrefs.SetString(StringSaveDataActivate, IsPointOpen.ToString());
            PlayerPrefs.SetString(StringSaveDataPlayedPoint, InBattleComplete.ToString());
        }

        public void ResetPoint()
        {
            pointUIController.ResetUI(LevelPoint);
            InBattleComplete = false;
            IsPointOpen = false;
            
            PlayerPrefs.SetString(StringSaveDataActivate, IsPointOpen.ToString());
            PlayerPrefs.SetString(StringSaveDataPlayedPoint , InBattleComplete.ToString());
        }

        private void LoadInformation()
        {
            if (PlayerPrefs.HasKey(StringSaveWinningData))
            {
                WinningMoney = PlayerPrefs.GetInt(StringSaveWinningData);
            }
            else
            {
                WinningMoney = (int)Random.Range(MinMaxMoney.x, MinMaxMoney.y);
                PlayerPrefs.SetInt(StringSaveWinningData, WinningMoney);
            }
                
            string currentActiveInfo = PlayerPrefs.GetString(StringSaveDataActivate);
            if (currentActiveInfo == "True")
                IsPointOpen = true;
            else
                IsPointOpen = false;
            
            string currentPlayedInfo = PlayerPrefs.GetString(StringSaveDataPlayedPoint);
            if (currentPlayedInfo == "True")
                InBattleComplete = true;
            else
                InBattleComplete = false;
        }

        public void PlayInPoint()
        {
            InBattleComplete = true;
            PlayerPrefs.SetString(StringSaveDataPlayedPoint, InBattleComplete.ToString());
            
            PlayerPrefs.SetString("LEVELWHICHPLAYED", StringSaveDataPlayedPoint);
        }

        public void StartTimerPlay()
        {
            //Add coins
            ResourceManager.Instance.AddResource(ResourceType.Coin, WinningMoney);
            PlayerPrefs.DeleteKey(StringSaveWinningData);
            
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
            }
            
            IsActiveTimer = true;
            pointUIController.UpdateButtonGraphics(false);
            
            if (PlayerPrefs.HasKey(StringSaveDataTimer))
            {
                string savedTimeString = PlayerPrefs.GetString(StringSaveDataTimer);
                startTime = DateTime.Parse(savedTimeString);

                TimeSpan timePassed = DateTime.Now - startTime;

                currentTimer = (float)timePassed.TotalSeconds;
            }
            else
            {
                startTime = DateTime.Now;
                PlayerPrefs.SetString(StringSaveDataTimer, startTime.ToString());
                PlayerPrefs.Save();

                currentTimer = 0;
            }
            
            pointUIController.ShowHideImg(true);
            sliderTimer.gameObject.SetActive(true);
            coroutine = StartCoroutine(StartTimer());
        }
        
        private IEnumerator StartTimer()
        {
            while (currentTimer < TimerSpawn)
            {
                currentTimer += 0.1f;
                sliderTimer.value = currentTimer;
                yield return new WaitForSeconds(0.1f); 
            }
            
            IsActiveTimer = false;
            SpawnPointController.SetNewPointInMap(this);
            gameObject.SetActive(false);
            PlayerPrefs.DeleteKey(StringSaveDataTimer); 
        }
        
    }
    
}
