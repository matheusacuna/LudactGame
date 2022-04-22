using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandle : MonoBehaviour
{
    public void NextScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

}
