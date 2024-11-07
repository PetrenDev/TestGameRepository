using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SpawnWordScripts
{
    public class PointUIController : MonoBehaviour
    {
        [Header("Map Img")] 
        public GameObject ImgClock;
        public GameObject CloseImg;
        public TextMeshProUGUI LevelText;
        public Slider timerSlider;
        
        public void ResetUI(int level)
        {
            LevelText.text = level.ToString();
            ShowHideImg(false);
            timerSlider.gameObject.SetActive(false);
            UpdateButtonGraphics(true);
        }

        public void UpdateButtonGraphics(bool isInteractable)
        {
            CloseImg.SetActive(!isInteractable);
        }

        public void ShowHideImg(bool temp)
        {
            ImgClock.SetActive(temp);
        }
        
    }
    
}