using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{

    private GameObject player;
    private GameObject mainCamera;

    public int levelNumber;

    private Animator doorAnim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(mainCamera);

        doorAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        doorAnim.SetBool("doorOpen", true);
        StartCoroutine(levelDelay());
    }

    IEnumerator levelDelay()
    {
        yield return new WaitForSeconds(1);
        player.transform.position = new Vector3(0, 0, 0);
        SceneManager.LoadScene(levelNumber);
    }

}
