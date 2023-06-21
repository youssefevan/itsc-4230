using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationUI : MonoBehaviour
{

    [SerializeField] GameObject nextLevelUI;
    [SerializeField] System.String nextScene;
    bool levelComplete = false;

    void Start() {
        nextLevelUI.SetActive(false);
        levelComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)) {
            SceneManager.LoadScene("MainMenu");
        }

        if (Input.GetKeyUp(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        if (Input.GetKeyUp(KeyCode.Space) && levelComplete == true) {
            SceneManager.LoadScene(nextScene);
        }
    }

    public void LevelComplete() {
        nextLevelUI.SetActive(true);
        levelComplete = true;
    }
}
