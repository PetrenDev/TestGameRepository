using Managers;
using UnityEngine;

public class DragCamera : MonoBehaviour
{
    private Camera mainCamera;
    public float dragSpeedX = 2;
    public float dragSpeedY = 2;
    private Vector3 dragOrigin;
    public bool LoadCoordinates;
    private void OnEnable()
    {
        SceneLoaderManager.SceneLoaded += SaveCameraPosition;
    }

    private void OnDisable()
    {
        SceneLoaderManager.SceneLoaded -= SaveCameraPosition;
    }
    
    private void Start()
    {
        mainCamera = Camera.main;
        if(LoadCoordinates)
            LoadCameraPosition();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0)) return;

        Vector3 difference = mainCamera.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(difference.x * -dragSpeedX, 0, difference.y * -dragSpeedY);

        mainCamera.transform.Translate(move, Space.World);
        dragOrigin = Input.mousePosition;
    }
    
    public void SaveCameraPosition(string name)
    {
        if (mainCamera != null && LoadCoordinates)
        {
            PlayerPrefs.SetFloat("CameraPosX", mainCamera.transform.position.x);
            PlayerPrefs.SetFloat("CameraPosY", mainCamera.transform.position.y);
            PlayerPrefs.SetFloat("CameraPosZ", mainCamera.transform.position.z);
            PlayerPrefs.Save();
        }
    }

    public void LoadCameraPosition()
    {
        if (mainCamera != null && PlayerPrefs.HasKey("CameraPosX"))
        {
            float x = PlayerPrefs.GetFloat("CameraPosX");
            float y = PlayerPrefs.GetFloat("CameraPosY");
            float z = PlayerPrefs.GetFloat("CameraPosZ");
            mainCamera.transform.position = new Vector3(x, y, z);
        }
    }
}
