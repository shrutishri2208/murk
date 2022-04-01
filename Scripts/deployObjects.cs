using System.Collections;
using UnityEngine;

public class deployObjects : MonoBehaviour
{
    public GameObject obPrefab;
    public GameObject obPrefab2;

    public GameObject starPrefab;
    public GameObject revivePrefab;
    public GameObject whitePrefab;

    float respawnTime;
    public float level1;
    public float level2;
    public float level3;

    public GameObject tap;


    void Start()
    {
        tap.SetActive(true);
        Invoke("delaySpawn", 2f);
        //Invoke("startDelay", 2f);


       /* if (PlayerPrefs.GetFloat("game1") == 0f)
        {
            tap.SetActive(true);
            Invoke("delaySpawn", 5f);
            PlayerPrefs.SetFloat("game1", 1f);

        }
        else
        {
            tap.SetActive(false);
            StartCoroutine(objectSpawner());
        }*/
        StartCoroutine(reviveSpawner());
        PlayerPrefs.SetFloat("level", 1);
    }


    /*public void startDelay()
    {
        Time.timeScale = 0.5f;
    }*/



    public void delaySpawn()
    {
        StartCoroutine(objectSpawner());
    }

    private void spawnObjects()
    {       


        float posX = Random.Range(-2.5f, 2.5f);
        if(posX <= 0.5 && posX >= 0)
        {
            posX += 0.5f;
        }
        else if(posX >= -0.5 && posX <= 0)
        {
            posX -= 0.5f;
        }

        float l = PlayerPrefs.GetFloat("level");

        


        if(l == 1 || l == 3 || l == 5)
        {
            GameObject o = Instantiate(obPrefab) as GameObject;
            o.transform.position = new Vector2(posX, transform.position.y + 8f);
        }

        else if(l == 2 || l == 4)
        {
            GameObject o2 = Instantiate(obPrefab2) as GameObject;
            o2.transform.position = new Vector2(0f, transform.position.y + 8f);
        }




        GameObject s = Instantiate(starPrefab) as GameObject;


        if (l == 1 || l == 2)
        {

            s.transform.position = new Vector2(Random.Range(-2f, 2f), transform.position.y + 11.5f);
        }
        else if (l == 3 || l == 4)
        {

            s.transform.position = new Vector2(Random.Range(-2f, 2f), transform.position.y + 10.5f);
        }
        else if (l == 5)
        {
            s.transform.position = new Vector2(Random.Range(-2f, 2f), transform.position.y + 10f);
        }



        GameObject w = Instantiate(whitePrefab) as GameObject;

        w.transform.position = new Vector2(0f, transform.position.y + 15f);
    }

    IEnumerator objectSpawner()
    {

        while (true)
        {
            float l = PlayerPrefs.GetFloat("level");

            if(l == 1 || l == 2)
            {
                respawnTime = level1;
            }
            else if(l == 3 || l == 4)
            {
                respawnTime = level2;
            }
            else if(l == 5)
            {
                respawnTime = level3;
            }
          
            yield return new WaitForSeconds(respawnTime);//respawnTime * Time.deltaTime);
            spawnObjects();
        }
    }


    void spawnRevive()
    {
        GameObject r = Instantiate(revivePrefab) as GameObject;
        r.transform.position = new Vector2(Random.Range(-1.5f, 1.5f), transform.position.y + 5f);
    }

    IEnumerator reviveSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(8f, 16f) * 2f);//00f * Time.deltaTime);
            spawnRevive();
        }
    }


}





