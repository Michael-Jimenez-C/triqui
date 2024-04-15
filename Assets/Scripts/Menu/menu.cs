using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void begin(){
        SceneManager.LoadScene(1,LoadSceneMode.Single);
    }
}
