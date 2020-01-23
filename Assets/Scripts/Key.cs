using UnityEngine;

public class Key : MonoBehaviour
{
    #region Declarations --------------------------------------------------

    private LevelManager _levelManager;

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
            _levelManager.AddKey(1);
            Destroy(gameObject);
        }
    }

    #endregion
}