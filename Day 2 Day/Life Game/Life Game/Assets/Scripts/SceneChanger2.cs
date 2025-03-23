using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger2 : MonoBehaviour
{
    // Pass the scene name as a parameter to this method
    void OnMouseDown()
    {
        SceneManager.LoadScene("City"); // Change this scene name based on your needs
    }
}
