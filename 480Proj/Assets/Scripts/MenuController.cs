using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject menu; // Assign your menu GameObject in the Inspector

    // Method to quit the game
    public void QuitGame()
    {
        // If in the Unity editor, stop playing
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        // Quit the application
        Application.Quit();
        #endif
    }

    // Method to load the StartScene
    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }

    // Show the menu when the palm is facing up
    public void ShowMenu()
    {
        if (menu != null)
        {
            Debug.Log("Showing Menu!");
            menu.SetActive(true);
        }
    }

    // Hide the menu when the palm is no longer facing up
    public void HideMenu()
    {
        if (menu != null)
        {
            Debug.Log("Hiding Menu!");
            menu.SetActive(false);
        }
    }
}
