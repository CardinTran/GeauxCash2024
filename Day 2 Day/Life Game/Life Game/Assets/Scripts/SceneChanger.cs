using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Pass the scene name as a parameter to this method
    void OnMouseDown()
    {
        SceneManager.LoadScene("Beds"); // Change this scene name based on your needs
    }
}
