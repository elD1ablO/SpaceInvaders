using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLogo : MonoBehaviour
{
    [SerializeField] float StartDelay = 3f;
    void Awake()
    {
        StartCoroutine(LogoDelay());
        
    }
    IEnumerator LogoDelay()
    {
        yield return new WaitForSeconds(StartDelay);
        SceneManager.LoadScene(1);
    }
    
}
