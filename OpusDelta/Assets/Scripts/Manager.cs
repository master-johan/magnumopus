using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    List<GameObject> enemyList;
    GameObject player;

    void Start()
    {
        enemyList = new List<GameObject>();
        enemyList.AddRange(GameObject.FindGameObjectsWithTag("EnemySimple"));

        player = GameObject.FindGameObjectWithTag("Player");
        Cursor.visible = false;
    }

    void Update()
    {



        foreach (var e in enemyList)
        {
            if (e.GetComponent<Stats>().health <= 0)
            {
                enemyList.Remove(e);
                break;
            }
            
        }
        if(enemyList.Count <= 0)
        {
            StartCoroutine(ChangeToWinScreen());
        }

        if(player.GetComponent<Health>().currenthealth <= 0)
        {
            StartCoroutine(ChangeToLoseScreen());
        }

    }
    IEnumerator ChangeToWinScreen()
    {
        yield return new WaitForSeconds(5);

        SceneManager.LoadScene(2);
    }
    IEnumerator ChangeToLoseScreen()
    {
        yield return new WaitForSeconds(5);

        SceneManager.LoadScene(3);
    }
}
