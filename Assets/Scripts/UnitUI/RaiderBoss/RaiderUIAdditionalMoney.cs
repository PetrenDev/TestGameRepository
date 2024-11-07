using TMPro;
using UnityEngine;

namespace UnitUI.RaiderBoss
{
    public class RaiderUIAdditionalMoney : MonoBehaviour
    {
        [SerializeField] private GameObject UIIcon;
        [SerializeField] private GameObject Canvas;
        [SerializeField] private TextMeshProUGUI textAllMoney;
        
        private void Start()
        {
            OpenIcon();
        }

        private void OpenIcon()
        {
            UIIcon.SetActive(true);
        }
        
        private void CloseIcon()
        {
            UIIcon.SetActive(false);
            Canvas.SetActive(false);
        }
        
     
        public void OpenCanvas()
        {
            Canvas.SetActive(true);
        }
    }
}