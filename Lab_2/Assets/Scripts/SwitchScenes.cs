using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    public void MainMenuToGeolocation()
    {
        SceneManager.LoadScene("Geolocation", LoadSceneMode.Single);
    }
    public void GeolocationToMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
