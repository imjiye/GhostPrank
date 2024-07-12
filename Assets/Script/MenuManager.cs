using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject CanvasPause;
    public GameObject btnReStart;
    public GameObject btnContinue;
    public GameObject btnGameEnd;

    public string thisScene;

    public void OpenMenu()
    {
        CanvasPause.SetActive(true);
    }

    public void LoadScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }

    public void ReStart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(thisScene);
    }

    public void Continue()
    {
        CanvasPause.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GameEnd() 
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    public void OnTogglePauseButton()
    {
        if (Time.timeScale == 0) //∏ÿ√Á¿÷¿∏∏È
        {
            Time.timeScale = 1f; //Ω√¿€
            
        }
        else //øÚ¡˜¿Ã∏È
        {
            Time.timeScale = 0; //∏ÿ√ﬂ±‚
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
