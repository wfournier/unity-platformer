using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{

    #region Declarations --------------------------------------------------

    private PlayerController player;
    private Camera mainCamera;

    public float waitToRespawn;
    public GameObject deathEffect;

    public HealthBar healthBar;

    public int coinCount;
    public int keyCount;

    public Text coinText;
    public Text keyText;

    #endregion


    #region Public Methods ------------------------------------------------

    public void AddHealth(int value)
    {
        healthBar.Add(value);
    }

    public void RemoveHealth(int value)
    {
        if (player.invulnerable) return;

        healthBar.Remove(value);
        StartCoroutine(InvulnerableCo());
    }

    public void SetHealth(int value)
    {
        healthBar.Set(value);
    }

    public void SetHealthMax()
    {
        healthBar.Set(healthBar.totalHealth);
    }

    public void Respawn()
    {
        StartCoroutine(RespawnCo());
    }

    public void AddCoins(int count)
    {
        SetCoinCount(coinCount + count);
    }

    public void RemoveCoins(int count)
    {
        SetCoinCount(coinCount - count);
    }

    public void SetCoinCount(int count)
    {
        coinCount = count;
        UpdateCoinText();
    }

    public void AddKey(int count)
    {
        SetKeyCount(keyCount + count);
    }

    public void RemoveKey(int count)
    {
        SetKeyCount(keyCount - count);
    }

    public void SetKeyCount(int count)
    {
        keyCount = count;
        UpdateKeyText();
    }

    #endregion


    #region Private/Protected Methods -------------------------------------

    // Start is called before the first frame update
    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        mainCamera = Camera.main;
        healthBar = FindObjectOfType<HealthBar>();

        UpdateUICounters();
    }

    // Update is called once per frame
    private void Update()
    {
        // if(!player.invulnerable && healthBar.currentHealth <= 0)
        //     Respawn();
    }

    private IEnumerator InvulnerableCo()
    {
        player.invulnerable = true;
        float window = healthBar.currentHealth <= 0 ? waitToRespawn + player.invulnerabilityWindow : player.invulnerabilityWindow;
        
        yield return new WaitForSeconds(window);

        player.invulnerable = false;
    }

    private IEnumerator RespawnCo()
    {
        Transform playerTransform = player.transform;

        Vector3 playerPosition = playerTransform.position;
        Quaternion playerRotation = playerTransform.rotation;

        Vector3 cameraPosition = mainCamera.transform.position;
        Vector3 effectPosition = player.isInKillZone ? new Vector3(playerPosition.x, cameraPosition.y - mainCamera.orthographicSize) : playerPosition;

        player.invulnerable = true;
        player.gameObject.SetActive(false);
        Instantiate(deathEffect, effectPosition, playerRotation);

        yield return new WaitForSeconds(waitToRespawn);

        player.transform.position = player.respawnPosition;
        player.gameObject.SetActive(true);

        SetHealthMax();
        player.invulnerable = false;
        SetCoinCount((int) Math.Ceiling((float) coinCount / 2));
    }

    private void UpdateCoinText()
    {
        coinText.text = $"{coinCount}";
    }

    private void UpdateKeyText()
    {
        keyText.text = $"{keyCount}";
    }

    private void UpdateUICounters()
    {
        UpdateCoinText();
        UpdateKeyText();
    }

    #endregion

}