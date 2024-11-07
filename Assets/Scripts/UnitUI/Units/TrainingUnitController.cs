using UnityEngine;

namespace UnitUI.Units
{
    public class TrainingUnitController : MonoBehaviour
    {
        public delegate void OnTrainingUnitPress(TrainingUnitController trainingUnit);
        public static event OnTrainingUnitPress TrainingUnitPress;
        
        
        public void OpenUpgradeOptions()
        {
            
            TrainingUnitPress?.Invoke(this);
            //UnitUICanvas.ShowUpgradeInfo();
        }
    }
}