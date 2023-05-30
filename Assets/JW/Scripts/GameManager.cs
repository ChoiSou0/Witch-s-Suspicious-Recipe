using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void Loading(string ls)
    {
        StartCoroutine(LoadDelay(ls));
    }

    IEnumerator LoadDelay(string ls)
    {
        SceneManager.LoadScene("LoadScene");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(ls);
    }
}