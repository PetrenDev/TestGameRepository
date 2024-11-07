using System;
using Managers.Resource;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UIResource : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI coinsText;
        [SerializeField] private TextMeshProUGUI gemsText;

        private void OnEnable()
        {
            ResourceManager.ResourceUpdated += UpdateResourceText;
        }

        private void OnDisable()
        {
            ResourceManager.ResourceUpdated -= UpdateResourceText;
        }
        

        private void UpdateResourceText(ResourceType type, int amount)
        {
            switch (type)
            {
                case ResourceType.Coin:
                    coinsText.text = amount.ToString();
                    break;
                case ResourceType.Gem:
                    gemsText.text = amount.ToString();
                    break;
            }
        }
    }
}