using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    #region Declarations --------------------------------------------------

    private LevelManager _levelManager;
    public int damage;

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
        if (other.CompareTag("Player")) _levelManager.RemoveHealth(damage);
    }

    #endregion
}