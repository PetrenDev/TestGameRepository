using SpawnWordScripts;
using UnityEngine;

namespace Managers
{
    public class SceneLoaderManager : MonoBehaviour
    {
        public delegate void OnSceneLoaded(string sceneName);
        public static event OnSceneLoaded SceneLoaded;
        
        private void OnEnable()
        {
            SceneLoaderPoint.BattleLoad += LoadBattleScene;
        }

        private void OnDisable()
        {
            SceneLoaderPoint.BattleLoad -= LoadBattleScene;
        }

        public void LoadTrainingScene()
        {
            SceneLoaded?.Invoke("BasaScene");
        }
    
        public virtual void LoadWordMapSceneLose() { }
        
        public virtual void LoadWordMapSceneWin() { }
        
        public void LoadWordMapScene()
        {
            Time.timeScale = 1;
            SceneLoaded?.Invoke("WorldMapScene11");
        }
        
        public void LoadBattleScene()
        {
            Time.timeScale = 1;
            SceneLoaded?.Invoke("Level 1");
        }
    }
}
