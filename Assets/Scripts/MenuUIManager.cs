using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject OptionsMenu;
    public void StartNew()
    {
        SceneManager.LoadScene(2);
    }

    public void Options()
    {
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }
    
    public void BackToMain()
    {
        OptionsMenu.SetActive(false);
        MainMenu.SetActive(true);        
    }
    public void MuteSound()
    {
        audioSource.enabled = !audioSource.enabled;
    }
    public void Quit()
    {        
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); 
#endif        
    }
}
