using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goToStudio() {
        SceneManager.LoadScene("XRI_Examples_Main");
    }

    public void goToHome() {
        SceneManager.LoadScene("MainMenu");
    }
}
