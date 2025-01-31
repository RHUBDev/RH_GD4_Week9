using UnityEngine;
using UnityEngine.SceneManagement;

public class TimelineEvents : MonoBehaviour
{
    public void switchScene()
    {
        SceneManager.LoadScene(1);
    }
}
