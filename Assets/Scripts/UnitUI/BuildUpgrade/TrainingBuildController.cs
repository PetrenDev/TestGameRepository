using UnityEngine;

namespace UnitUI.BuildUpgrade
{
    public class TrainingBuildController : MonoBehaviour
    {
        [Header("UI Canvas")] 
        [SerializeField] private UpgradeBuildUICanvas upgradeBossUICanvas;
        
        
        public void OpenUpgradeOptions()
        {
            upgradeBossUICanvas.OpenTrainCanvas();
        }
    }
}