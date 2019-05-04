using UnityEngine;


public class CameraController : MonoBehaviour
{

    #region Declarations --------------------------------------------------

    public GameObject target;
    public float followAhead;
    public float smoothing;

    private Vector3 targetPosition;

    #endregion


    #region Private/Protected Methods -------------------------------------

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 currentPosition = transform.position;
        targetPosition = new Vector3(target.transform.position.x, currentPosition.y, currentPosition.z);

        if (target.transform.localScale.x > 0f)
        {
            targetPosition = new Vector3(targetPosition.x + followAhead, targetPosition.y, targetPosition.z);
        }
        else
        {
            targetPosition = new Vector3(targetPosition.x - followAhead, targetPosition.y, targetPosition.z);
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
    }

    #endregion

}