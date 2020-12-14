using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;

public class sceneSwapper : MonoBehaviour
{
    public void swapScene(string scene){
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}