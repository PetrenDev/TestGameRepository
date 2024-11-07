using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Managers
{
    public class SceneShadeAsync : MonoBehaviour
    {
        public GameObject loadingScreen; 
        public Slider loadingBar;

        private void OnEnable()
        {
            SceneLoaderManager.SceneLoaded += LoadSceneAsync;
        }

        private void OnDisable()
        {
            SceneLoaderManager.SceneLoaded += LoadSceneAsync;
        }

        private void Start()
        {
            loadingScreen.SetActive(false);
        }

        public void LoadSceneAsync(string sceneName)
        {
            loadingScreen.SetActive(true);
        
            StartCoroutine(LoadAsync(sceneName));
        }

        private IEnumerator LoadAsync(string sceneName)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        
            operation.allowSceneActivation = false;

            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / 0.9f);
                loadingBar.value = progress;
            
                if (operation.progress >= 0.9f)
                {
                    yield return new WaitForSeconds(0.5f); 
                    operation.allowSceneActivation = true; 
                }

                yield return null; 
            }
        
            loadingScreen.SetActive(false);
        }
    }
}