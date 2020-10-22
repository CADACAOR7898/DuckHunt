using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject duck;
    public GameObject winW;
    public GameObject dogW;
    public Text textValor;

    int puntos = 0;
    bool win = false;
    bool dog = false;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn",1f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (win == true && dog == true)
        {
            CancelInvoke("Spawn");
        }

        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>().Play();
        }
    }

    void Spawn()
    {
        float randomX = Random.Range(60f,960f);
        float randomY = Random.Range(570f, 120f); ;

        Vector3 randomPosition = new Vector3(randomX, randomY, 0);

        Instantiate(duck,
            randomPosition, Quaternion.identity);
    }
    
    public void IncrementScore()
    {
        puntos++;
        textValor.text = puntos.ToString();

        if (puntos >= 20)
        {
            win = true;
            dog = true;
            winW.SetActive(win);
            dogW.SetActive(dog);
        }

    }
}
