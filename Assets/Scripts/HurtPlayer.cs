using UnityEngine;


public class HurtPlayer : MonoBehaviour
{

    #region Declarations --------------------------------------------------

    private LevelManager levelManager;

    #endregion


    #region Private/Protected Methods -------------------------------------

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            levelManager.RemoveHealth(1);
        }
    }

    #endregion

}