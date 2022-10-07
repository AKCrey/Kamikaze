using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float sceneLoadingDelay = 2.0f;

    private Coroutine routine = null;

    public void ResetGame()
    {
        //...Reset Game
        if(routine == null)
        {
            routine = StartCoroutine(ResettingGame());    
        }
        

    }

    private IEnumerator ResettingGame()
    {
        yield return new WaitForSeconds(sceneLoadingDelay);
        //Resetting the game

        SceneManager.UnloadSceneAsync(gameObject.scene.buildIndex);
        SceneManager.LoadScene(gameObject.scene.buildIndex);

        routine = null;
    }

}
