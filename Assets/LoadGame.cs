using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadGamee());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator LoadGamee()
    {
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene("Scene_1_Start_Game");
    }
}
