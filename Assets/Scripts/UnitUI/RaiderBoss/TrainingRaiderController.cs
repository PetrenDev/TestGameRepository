using UnityEngine;

namespace UnitUI.RaiderBoss
{
    public class TrainingRaiderController : MonoBehaviour
    {
        [Header("UI Canvas")] 
        [SerializeField] private UpgradeRaiderUICanvas upgradeBossUICanvas;
        
        
        public void OpenUpgradeOptions()
        {
            upgradeBossUICanvas.OpenTrainCanvas();
        }
        
    }
}