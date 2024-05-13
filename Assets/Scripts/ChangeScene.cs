using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int sceneIndex;

    private void OnTriggerEnter2D(Collider2D other)
    {
       Debug.Log("Triggering");
       if(other.tag == "Player")
       {
           SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
       }
    }
}
