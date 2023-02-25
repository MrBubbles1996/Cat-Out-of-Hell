using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;

    public int levelToLoad;

    public void PlayNextLevel()
    {
        FadeToLevel();
    }

    public void FadeToLevel ()
    {
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void Quit()
    {
      Application.Quit();
    }
}
