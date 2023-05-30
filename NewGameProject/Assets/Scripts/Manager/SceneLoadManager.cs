using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Scenes
{
    Title,
    Lobby,
    Game
}

public class SceneLoadManager : SingleTon_DontDestroy<SceneLoadManager>
{
    [SerializeField]
    Canvas loadingCanvas;
    [SerializeField]
    Image progressBar;
    AsyncOperation currentLoad;
    
    IEnumerator Coroutine_Update()
    {
        while (true)
        {
            if (currentLoad != null)
            {
                var progress = currentLoad.progress;
                progressBar.fillAmount = progress;

                if (progress >= 1f)
                {
                    progressBar.fillAmount = 1f;
                    loadingCanvas.enabled = false;
                    currentLoad = null;
                }
            }
            
            yield return null;
        }
    }

    public void LoadSceneAsync(Scenes scene)
    {
        currentLoad = SceneManager.LoadSceneAsync((int)scene);
        loadingCanvas.enabled = true;
    }

    protected override void OnStart()
    {
        StartCoroutine(Coroutine_Update());
        loadingCanvas.enabled = false;
    }
}
