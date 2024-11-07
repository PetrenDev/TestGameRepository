using UnityEngine;

namespace UnitUI.Bar
{
    public class TrainingBarController : MonoBehaviour
    {
        [Header("UI Canvas")] 
        [SerializeField] private UpgradeBarUICanvas upgradeBossUICanvas;
        
        
        public void OpenUpgradeOptions()
        {
            upgradeBossUICanvas.OpenTrainCanvas();
        }
    }
}