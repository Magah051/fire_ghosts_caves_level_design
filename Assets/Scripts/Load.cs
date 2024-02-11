using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Load : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }
}
