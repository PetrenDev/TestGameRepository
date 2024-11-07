using UnityEngine;

namespace UnitUI.Units
{
    public class UpgradeUnitUICanvas : MonoBehaviour
    {
        [Header("UI items")]
        [SerializeField] private GameObject MainCanvasUI;
        [SerializeField] private GameObject StatsCanvas;
        [SerializeField] private GameObject UpgradeCanvas;
        
        private void OnEnable()
        {
            TrainingUnitController.TrainingUnitPress += TrainingUnitPress;
        }

        private void OnDisable()
        {
            TrainingUnitController.TrainingUnitPress -= TrainingUnitPress;
        }
        
        void Start()
        {
            HideUpgradeInfo();
        }

        private void TrainingUnitPress(TrainingUnitController unit)
        {
            MainCanvasUI.SetActive(true);
        }
        
        private void HideUpgradeInfo()
        {
            MainCanvasUI.SetActive(false);
            UpgradeCanvas.SetActive(false);
            StatsCanvas.SetActive(true);
        }

        public void ShowUpgrade()
        {
            StatsCanvas.SetActive(false);
            UpgradeCanvas.SetActive(true);
        }
    }
}
