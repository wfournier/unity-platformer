using System.Collections;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;


public class LevelManager : MonoBehaviour
{

    #region Declarations --------------------------------------------------

    private PlayerController player;
    private Camera mainCamera;

    public float waitToRespawn;
    public GameObject deathEffect;

    #endregion


    #region Public Methods ------------------------------------------------

    public void Respawn()
    {
        StartCoroutine(nameof(RespawnCo));
    }

    #endregion


    #region Private/Protected Methods -------------------------------------

    // Start is called before the first frame update
    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private IEnumerator RespawnCo()
    {
        Transform playerTransform = player.transform;
        
        Vector3 playerPosition = playerTransform.position;
        Quaternion playerRotation = playerTransform.rotation;

        Vector3 cameraPosition = mainCamera.transform.position;
        Vector3 effectPosition = player.isInKillZone ? new Vector3(playerPosition.x, cameraPosition.y - mainCamera.orthographicSize) : playerPosition;

        player.gameObject.SetActive(false);
        Instantiate(deathEffect, effectPosition, playerRotation);

        yield return new WaitForSeconds(waitToRespawn);

        player.transform.position = player.respawnPosition;
        player.gameObject.SetActive(true);
    }

    #endregion

}