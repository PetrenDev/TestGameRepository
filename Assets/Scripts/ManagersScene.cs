using UnityEngine;

public class ManagersScene : MonoBehaviour
{
    public static ManagersScene Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else if (Instance != this)
        {
            Destroy(gameObject); 
        }

    }
}
