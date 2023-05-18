using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour
{
    public GameObject transition;
    
    private void Update()
    {
        AllFruitsCollected();
    }


    public void AllFruitsCollected()
    {
        if (transform.childCount==0)
        {
            transition.SetActive(true);
            Invoke("ChangeScene", 0.5);
        }
    }
    void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
