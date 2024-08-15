using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public static Manager instance { get; private set; }
    public GameObject winScreen;
    public GameObject text;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null && instance != this) {
            Destroy(gameObject);
        }
        winScreen.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Win() {
        text.SetActive(false);
        winScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart() {
        SceneManager.LoadScene(0);
    }

}
