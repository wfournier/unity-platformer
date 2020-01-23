using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Declarations --------------------------------------------------

    public GameObject target;
    public float followAhead;
    public float smoothing;

    private Vector3 _targetPosition;

    #endregion


    #region Private/Protected Methods -------------------------------------

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        var currentPosition = transform.position;
        _targetPosition = new Vector3(target.transform.position.x, currentPosition.y, currentPosition.z);

        if (target.transform.localScale.x > 0f)
            _targetPosition = new Vector3(_targetPosition.x + followAhead, _targetPosition.y, _targetPosition.z);
        else
            _targetPosition = new Vector3(_targetPosition.x - followAhead, _targetPosition.y, _targetPosition.z);

        transform.position = Vector3.Lerp(transform.position, _targetPosition, smoothing * Time.deltaTime);
    }

    #endregion
}