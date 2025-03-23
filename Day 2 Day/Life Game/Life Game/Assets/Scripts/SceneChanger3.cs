using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger3 : MonoBehaviour
{
    // Pass the scene name as a parameter to this method
    void OnMouseDown()
    {
        SceneManager.LoadScene("WorkPlace"); // Change this scene name based on your needs
    }
}
