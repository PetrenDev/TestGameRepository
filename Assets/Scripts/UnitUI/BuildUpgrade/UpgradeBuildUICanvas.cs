using UnityEngine;
using UnityEngine.UI;

namespace UnitUI.BuildUpgrade
{
    public class UpgradeBuildUICanvas : MonoBehaviour
    {
        [Header("UI items")] 
        [SerializeField] private GameObject MainCanvasUI;
        [SerializeField] private GameObject StatsCanvas;
        [SerializeField] private GameObject UpgradeCanvas;

        [Header("UI Page Stats")] 
        [SerializeField] private GameObject[] PageStats;
        [SerializeField] private Button[] ButtonPageStats;

        private int IndexPage;
        void Start()
        {
            HideMainCanvasInfo();
            ButtonPageStats[IndexPage].interactable = false;
        }

        private void HideMainCanvasInfo()
        {
            MainCanvasUI.SetActive(false);
            UpgradeCanvas.SetActive(false);
            StatsCanvas.SetActive(true);
        }
        
        public void OpenTrainCanvas()
        {
            MainCanvasUI.SetActive(true);
            ShowStatsWindow();
        }
        
        private void ShowStatsWindow()
        {
            StatsCanvas.SetActive(true);
            UpgradeCanvas.SetActive(false);
        }
        
        public void ShowUpgradeWindow()
        {
            StatsCanvas.SetActive(false);
            UpgradeCanvas.SetActive(true);
        }
        
        public void ShowPageStat(int index)
        {
            for (int i = 0; i < PageStats.Length; i++)
            {
                PageStats[i].SetActive(false);
                ButtonPageStats[i].interactable = true;
            }
            
            IndexPage = index;
            ButtonPageStats[IndexPage].interactable = false;
            PageStats[IndexPage].SetActive(true);
        }
        
        public void SetStatsPage()
        {
            PageStats[IndexPage].SetActive(true);
        }
    }
}
