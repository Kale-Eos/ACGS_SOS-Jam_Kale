using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeController : MonoBehaviour
{
    public Animator anim;
    [SerializeField]
    string sceneName1 = "Level1";
    [SerializeField]
    string sceneName2 = "Level2";
    [SerializeField]
    string sceneName3 = "Level3";
    [SerializeField]
    string sceneName4 = "Level4";
    [SerializeField]
    string sceneName5 = "Level5";
    [SerializeField]
    string sceneName6 = "Level6";
    [SerializeField]
    string sceneNameFree = "FreeRoam";

    public void Loader1()
    {
        anim.SetTrigger("End");
        Invoke("LoadScene1", 1);                             // loads onto the Level 1 scene
    }

    public void Loader2()
    {
        anim.SetTrigger("End");
        Invoke("LoadScene2", 1);                             // loads onto the Level 2 scene
    }

    public void Loader3()
    {
        anim.SetTrigger("End");
        Invoke("LoadScene3", 1);                             // loads onto the Level 3 scene
    }

    public void Loader4()
    {
        anim.SetTrigger("End");
        Invoke("LoadScene4", 1);                             // loads onto the Level 4 scene
    }

    public void Loader5()
    {
        anim.SetTrigger("End");
        Invoke("LoadScene5", 1);                             // loads onto the Level 5 scene
    }

    public void Loader6()
    {
        anim.SetTrigger("End");
        Invoke("LoadScene6", 1);                             // loads onto the Level 5 scene
    }

    public void LoaderFree()
    {
        anim.SetTrigger("End");
        Invoke("LoadSceneFreeRoam", 1);                      // loads onto the Free Roam scene
    }

    void LoadScene1()
    {
        SceneManager.LoadScene(sceneName1);                  // function onto the Level 1 scene
    }

    void LoadScene2()
    {
        SceneManager.LoadScene(sceneName2);                  // function onto the Level 2 scene
    }

    void LoadScene3()
    {
        SceneManager.LoadScene(sceneName3);                  // function onto the Level 3 scene
    }

    void LoadScene4()
    {
        SceneManager.LoadScene(sceneName4);                  // function onto the Level 4 scene
    }

    void LoadScene5()
    {
        SceneManager.LoadScene(sceneName5);                  // function onto the Level 5 scene
    }

    void LoadScene6()
    {
        SceneManager.LoadScene(sceneName6);                  // function onto the Level 5 scene
    }

    void LoadSceneFreeRoam()
    {
        SceneManager.LoadScene(sceneNameFree);               // function onto the tutorial scene
    }
}
