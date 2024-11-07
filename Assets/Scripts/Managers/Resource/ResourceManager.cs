using System;
using System.Collections.Generic;
using SpawnWordScripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers.Resource
{
    [Serializable]
    public class Resource
    {
        public ResourceType type;
        public int amount;
    }
    
    public class ResourceManager : MonoBehaviour
    { 
        [SerializeField] private List<Resource> startingResources = new List<Resource>();
        
        private Dictionary<ResourceType, int> resources = new Dictionary<ResourceType, int>();
        public static ResourceManager Instance;
        
        public delegate void OnResourceUpdated(ResourceType type, int amount);
        public static event OnResourceUpdated ResourceUpdated;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        private void Start()
        {
            LoadResources();

            if (!PlayerPrefs.HasKey("StartRes"))
            {
                foreach (var resource in startingResources)
                {
                    AddResource(resource.type, resource.amount);
                }
                PlayerPrefs.SetInt("StartRes", 1);
            }
            
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoad;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoad;
        }

        private void OnSceneLoad(Scene scene, LoadSceneMode mode)
        {
            LoadResources();
        }

        private void SaveResources()
        {
            foreach (var resource in resources)
            {
                PlayerPrefs.SetInt(resource.Key.ToString(), resource.Value);
            }
            PlayerPrefs.Save();
        }

        private void LoadResources()
        {
            foreach (ResourceType resourceType in Enum.GetValues(typeof(ResourceType)))
            {
                if (PlayerPrefs.HasKey(resourceType.ToString()))
                {
                    resources[resourceType] = PlayerPrefs.GetInt(resourceType.ToString());
                }
                else
                {
                    resources[resourceType] = 0; 
                }
                
                ResourceUpdated?.Invoke(resourceType, resources[resourceType]);
            }
        }

        public void AddResource(ResourceType type, int amount)
        {
            if (!resources.ContainsKey(type))
            {
                resources[type] = 0; 
            }

            resources[type] += amount;
            
            ResourceUpdated?.Invoke(type, resources[type]);
            SaveResources();
        }

        public bool RemoveResource(ResourceType type, int amount)
        {
            if(!CanAfford(type, amount))
                return false;
            
            if (resources.ContainsKey(type))
            {
                resources[type] = Mathf.Max(0, resources[type] - amount); 
                
                ResourceUpdated?.Invoke(type, resources[type]);
                SaveResources();

                return true;
            }

            return false;
        }

        public int GetResource(ResourceType type)
        {
            if (resources.ContainsKey(type))
            {
                return resources[type];
            }
            return 0;
        }

        public bool CanAfford(ResourceType type, float priceTrain)
        {
            if (resources.ContainsKey(type) && resources[type] - priceTrain >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}