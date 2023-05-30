using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scenes
{
    Title,
    Lobby,
    Game
}

public class SceneLoadManager : SingleTon_DontDestroy<SceneLoadManager>
{
    public void LoadSceneAsync(Scenes scene)
    {
        SceneManager.LoadSceneAsync((int)scene);
    }
}
