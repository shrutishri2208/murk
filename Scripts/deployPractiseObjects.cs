using System.Collections;
using UnityEngine;

public class deployPractiseObjects : MonoBehaviour
{
    public GameObject obPrefab;
    public GameObject obPrefab2;

    public GameObject whitePrefab;

    float respawnTime;

    Coroutine OS;

    public GameObject tap;

    void Start()
    {
        tap.SetActive(true);
        Invoke("startCoroutine", 2f);
        //Invoke("startDelay", 2f);



        /*if (PlayerPrefs.GetFloat("game1") == 0f)
        {
            tap.SetActive(true);
            Invoke("startCoroutine", 5f);
            Invoke("startDelay", 2f);
            PlayerPrefs.SetFloat("game1", 1f);

        }
        else
        {
        tap.SetActive(false);
        OS = StartCoroutine(objectSpawner());
        }*/

    PlayerPrefs.SetFloat("level", 1);

    }

    public void startDelay()
    {
        Time.timeScale = 0.5f;
    }




    public void startCoroutine()
    {
        OS = StartCoroutine(objectSpawner());
    }

    public void stopCoroutine()
    {
        StopCoroutine(OS);
    }


    IEnumerator objectSpawner()
    {

        while (true)
        {
            float l = PlayerPrefs.GetFloat("level");

            if (l == 1 || l == 2)
            {
                respawnTime = 1.9f;
            }
            else if (l == 3 || l == 4)
            {
                respawnTime = 1.7f;
            }
            else if (l == 5)
            {
                respawnTime = 1.7f;
            }

            yield return new WaitForSeconds(respawnTime);//respawnTime * Time.deltaTime);
            spawnObjects();
        }
    }



    private void spawnObjects()
    {


        float posX = Random.Range(-2.5f, 2.5f);
        if (posX <= 0.5 && posX >= 0)
        {
            posX += 0.5f;
        }
        else if (posX >= -0.5 && posX <= 0)
        {
            posX -= 0.5f;
        }

        float l = PlayerPrefs.GetFloat("level");




        if (l == 1 || l == 3 || l == 5)
        {
            GameObject o = Instantiate(obPrefab) as GameObject;
            o.transform.position = new Vector2(posX, transform.position.y + 8f);
        }

        else if (l == 2 || l == 4)
        {
            GameObject o2 = Instantiate(obPrefab2) as GameObject;
            o2.transform.position = new Vector2(0f, transform.position.y + 8f);
        }





        GameObject w = Instantiate(whitePrefab) as GameObject;

        w.transform.position = new Vector2(0f, transform.position.y + 15f);
    }


}





