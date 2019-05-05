using UnityEngine;


public class Coin : MonoBehaviour
{

    #region Declarations --------------------------------------------------

    private LevelManager levelManager;

    public int coinValue = 1;

    #endregion


    #region Private/Protected Methods -------------------------------------

    // Start is called before the first frame update
    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            levelManager.AddCoins(coinValue);
            Destroy(gameObject);
        }
    }

    #endregion

}