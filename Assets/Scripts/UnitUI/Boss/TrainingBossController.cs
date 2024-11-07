using UnityEngine;

namespace UnitUI.Boss
{
    public class TrainingBossController : MonoBehaviour
    {
        [Header("UI Canvas")] 
        [SerializeField] private UpgradeBossUICanvas upgradeBossUICanvas;
        
        
        public void OpenUpgradeOptions()
        {
            upgradeBossUICanvas.OpenTrainCanvas();
        }
        
    }
}