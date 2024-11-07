using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpawnWordScripts
{
    public class SceneLoaderPoint : MonoBehaviour
    {
        private GameObject Boss;
        private float WinningMoney;
        
        public static SceneLoaderPoint Instance;

        
        public delegate void OnBattleLoad();
        public static event OnBattleLoad BattleLoad;
        
        private void OnEnable()
        {
            UIWordMapPointInfo.SceneLoad += LoadScene;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDisable()
        {
            UIWordMapPointInfo.SceneLoad -= LoadScene;
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject); 
            }

        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
        }

        private void LoadScene(SpawnPointInfo spawnPointInfo)
        {
            Boss = spawnPointInfo.Boss;
            WinningMoney = spawnPointInfo.WinningMoney;
            
            BattleLoad?.Invoke();
        }
        
    }
}