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
        StartCoroutine(nameof(RespawnCo));
    }

    public IEnumerator RespawnCo()
    {
        player.gameObject.SetActive(false);
        
        yield return new WaitForSeconds(waitToRespawn);
        
        player.transform.position = player.respawnPosition;
        player.gameObject.SetActive(true);
    }
}
