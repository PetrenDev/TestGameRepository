using TMPro;
using UnityEngine;

namespace SpawnWordScripts
{
    public class UIWordMapPointInfo : MonoBehaviour
    {
        [Header("UI Information")] 
        public TextMeshProUGUI TopTextNamePoint;
        public TextMeshProUGUI MoneyText;
        public TextMeshProUGUI TimerText;
        public TextMeshProUGUI LevelPoint;
        public GameObject Canvas;

        private PointUIController posPointUIController = null;
        private SpawnPointInfo spawnPointInfo = null;

        public delegate void OnSceneLoad(SpawnPointInfo spawnPointInfo);
        public static event OnSceneLoad SceneLoad;

        private void OnEnable()
        {
            SpawnPointInfo.WordPointTap += OnWordPointTap;
        }

        private void OnDisable()
        {
            SpawnPointInfo.WordPointTap -= OnWordPointTap;
        }

        private void OnWordPointTap(SpawnPointInfo _spawnPointInfo)
        {
            spawnPointInfo = _spawnPointInfo;
            posPointUIController = spawnPointInfo.pointUIController;
            OpenInfo(spawnPointInfo);
        }
        
        private void Start()
        {
            Canvas.SetActive(false);
        }
        
        private void UpgradeTextInfo(string _TopTextNamePoint, string _MoneyText, float _Timer, string _LevelPoint)
        {
            TopTextNamePoint.text = _TopTextNamePoint;
            MoneyText.text = _MoneyText;
            LevelPoint.text = _LevelPoint;
            
            int minutes = (int)(_Timer / 60);
            float seconds = (_Timer % 60);
            TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        
        private void OpenInfo(SpawnPointInfo spawnPointInfo)
        {
            UpgradeTextInfo(spawnPointInfo.NamePoint, 
                spawnPointInfo.WinningMoney.ToString(),
                spawnPointInfo.TimerSpawn,
                spawnPointInfo.LevelPoint.ToString());
            
            Canvas.SetActive(true);
        }
        
        public void PlayScene()
        {
            if (spawnPointInfo != null)
            {
                spawnPointInfo.PlayInPoint();
                SceneLoad?.Invoke(spawnPointInfo);
            }
            else
            {
                Debug.LogError("Error Load Scene");
            }
        }
    }
}