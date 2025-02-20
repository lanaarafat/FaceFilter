using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void FilterPage()
    {
        SceneManager.LoadScene(1);
    }

    public void About()
    {
        SceneManager.LoadScene(2); 
    }

    public void HomePage()
    {
        SceneManager.LoadScene(0);
    }
}
