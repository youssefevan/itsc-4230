using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private void Awake() {
        GameObject[] musicPlayer =  GameObject.FindGameObjectsWithTag("Music");
        
        if(musicPlayer.Length > 1) {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
