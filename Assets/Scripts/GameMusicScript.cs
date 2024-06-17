
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMusicScript : MonoBehaviour
{
    private static GameMusicScript instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update() {
        if(SceneManager.GetActiveScene().buildIndex != 1) {
            Destroy(gameObject);
        }
    }
}
