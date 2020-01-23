using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    #region Declarations --------------------------------------------------

    public float lifeTime;

    #endregion


    #region Private/Protected Methods -------------------------------------

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0f) Destroy(gameObject);
    }

    #endregion
}