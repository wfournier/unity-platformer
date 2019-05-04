using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private PlayerController player;

    public float waitToRespawn;
    public GameObject deathEffect;
    
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
        StartCoroutine(nameof(RespawnCo));
    }

    private IEnumerator RespawnCo()
    {
        Transform playerTransform = player.transform;
        
        player.gameObject.SetActive(false);
        Instantiate(deathEffect, playerTransform.position, playerTransform.rotation);
        
        yield return new WaitForSeconds(waitToRespawn);
        
        player.transform.position = player.respawnPosition;
        player.gameObject.SetActive(true);
    }
}
