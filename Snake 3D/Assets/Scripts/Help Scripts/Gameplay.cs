using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour
{
    public static Gameplay instance;
    public GameObject coin_PickUp;

    private float min_X = -16.5f, max_X = 16.5f, min_Y = -8f, max_Y = 8f;
    private float z_Pos = -0.5f;

    private Text score_Text;
    private int scoreCount;

    void Awake()
    {
        MakeInstance();
    }
    void Start()
    {
        score_Text = GameObject.Find("Score").GetComponent<Text>();

        Invoke("StartSpawning", 0.5f);
    }

    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void StartSpawning()
    {
        StartCoroutine(SpawnPickUps());
    }

    public void CancelSpawning()
    {
        CancelInvoke("StartSpawning");
    }

    IEnumerator SpawnPickUps()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 2f));

        if(Random.Range(0,10) >= 2)
        {

            Instantiate(coin_PickUp,
                        new Vector3(Random.Range(min_X, max_X), Random.Range(min_Y, max_Y), z_Pos),
                        Quaternion.identity);
        }

        Invoke("StartSpawning", 0f);
    }

    public void IncreaseScore()
    {
        scoreCount++;
        score_Text.text = "Score: " + scoreCount;
    }
}







