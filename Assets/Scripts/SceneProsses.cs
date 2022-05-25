using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PathCreation.Examples;
public class SceneProsses : SingeltonGeneric<SceneProsses>
{
    PathFollower patfollower;
    GameObject PlayerObj;
    #region singelton
    private void Awake()
    {
        MakeSingelton(this);
    }
    #endregion

    private void Start()
    {
        PlayerObj = GameObject.FindGameObjectWithTag("Player");
        patfollower = PlayerObj.GetComponent<PathFollower>();
    }
    public IEnumerator ISceneChange(float Delay)
    {
       
        yield return new WaitForEndOfFrame();
        SceneManager.LoadScene("DemoScene2");
        SceneManager.activeSceneChanged += ChangedActiveScene;
    }
    private void ChangedActiveScene(Scene current, Scene next)//Change Scene
    {
        patfollower.distanceTravelled = 0;
        patfollower.FindPath();
        patfollower.speed = 0;
        string currentName = current.name;
        if (currentName == null)
        {
            currentName = "Replaced";
        }
    }

}
