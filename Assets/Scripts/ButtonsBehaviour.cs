using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsBehaviour : MonoBehaviour
{
    public void FadingScene()
    {
        SceneManager.LoadScene("FadingCube");
    }

    public void PopLevel1()
    {
        SceneManager.LoadScene("Level01");
    }
    public void PopLevel2()
    {
        SceneManager.LoadScene("Level02");
    }
    public void SeaScene()
    {
        SceneManager.LoadScene("Tools/Sea/V 1.1/Scenes/LevelTest/SampleScene");
        //Debug.Log(SceneManager.GetSceneByPath("Tools/Sea/V 1.1/Scenes/LevelTest/SampleScene"));
    }

/*    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Application.Quit();
    }*/
}
