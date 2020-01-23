using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    #region Declarations --------------------------------------------------

    private PlayerController _player;
    private Camera _mainCamera;

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
        if (_player.invulnerable) return;

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

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnPlayerCo());
        StartCoroutine(InvulnerableCo());
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

    private void Start()
    {
        _player = FindObjectOfType<PlayerController>();
        _mainCamera = Camera.main;
        healthBar = FindObjectOfType<HealthBar>();

        UpdateUICounters();
    }

    private void Update()
    {
        if (healthBar.currentHealth <= 0 && !_player.dead)
            RespawnPlayer();
    }

    private IEnumerator InvulnerableCo()
    {
        _player.invulnerable = true;

        yield return new WaitForSeconds(_player.invulnerabilityWindow);

        _player.invulnerable = false;
    }

    private IEnumerator RespawnPlayerCo()
    {
        var playerTransform = _player.transform;

        var playerPosition = playerTransform.position;
        var playerRotation = playerTransform.rotation;

        var cameraPosition = _mainCamera.transform.position;
        var effectPosition = _player.isInKillZone
            ? new Vector3(playerPosition.x, cameraPosition.y - _mainCamera.orthographicSize)
            : playerPosition;

        _player.Kill();
        Instantiate(deathEffect, effectPosition, playerRotation);

        yield return new WaitForSeconds(waitToRespawn);

        _player.transform.position = _player.respawnPosition;
        _player.Respawn();

        SetHealthMax();
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