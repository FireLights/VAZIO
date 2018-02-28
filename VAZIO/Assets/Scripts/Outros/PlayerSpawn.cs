using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpawn : MonoBehaviour {

    public GameObject playerPrefab;
    GameObject playerInstance;

    public float respawnTimer = 3;
    private float curTimer;
    public Text respawnTimerText;

	void Start () {
        spawnPlayer();
        curTimer = respawnTimer;
	}
	
	void Update ()
    {
        updateUI();
        if (playerInstance == null)
        {
            curTimer -= Time.deltaTime;

            if (curTimer <= 0)
            {
                spawnPlayer();
            }
        }
    }  
    
    void spawnPlayer ()
    {
        curTimer = respawnTimer;
        playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
    } 

    void updateUI()
    {
        if (playerInstance == null)
        {
            respawnTimerText.text = (Mathf.RoundToInt(curTimer)).ToString();
        } else if (playerInstance != null)
        {
            respawnTimerText.text = null;
        }

    }

}
