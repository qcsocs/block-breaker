using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Manager : MonoBehaviour
{
    
    public void LoadLevel(string name)
    {
        print("Level load requested for : " + name);
        Application.LoadLevel(name);

    }

    public void Quit()
    {
#if (UNITY_EDITOR || DEVELOPMENT_BUILD)
        Debug.Log(this.name + " : " + this.GetType() + " : " + System.Reflection.MethodBase.GetCurrentMethod().Name);
#endif
#if (UNITY_EDITOR)
        UnityEditor.EditorApplication.isPlaying = false;
#elif (UNITY_STANDALONE)
    Application.Quit();
#elif (UNITY_WEBGL)
    Application.OpenURL("https://opendays.qcsocs.tk/");
#endif
    }
    public void LoadNextLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
    public void BrickDestroyed()
    {
        if (Brick.breakableCount <= 0)
        {
            print("load next level");
            LoadNextLevel();
        }
    }
    public void CheatMode()
    {
        Paddle.autoPlay = true;
    }
}