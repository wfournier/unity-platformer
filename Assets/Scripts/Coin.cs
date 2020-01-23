using UnityEngine;

public class Coin : MonoBehaviour
{
    #region Declarations --------------------------------------------------

    private LevelManager _levelManager;

    public int coinValue = 1;

    #endregion


    #region Private/Protected Methods -------------------------------------

    private void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
    }

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _levelManager.AddCoins(coinValue);
            Destroy(gameObject);
        }
    }

    #endregion
}