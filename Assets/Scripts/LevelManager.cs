using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public float waitToRespawn;
    public PlayerController player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        player.gameObject.SetActive(false);
        player.transform.position = player.respawnPosition;
        player.gameObject.SetActive(true);
    }
}
