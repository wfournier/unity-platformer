using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    #region Declarations --------------------------------------------------

    public Sprite flagClosed;
    public Sprite flagOpened;

    public bool active;

    private SpriteRenderer _spriteRenderer;

    #endregion


    #region Private/Protected Methods -------------------------------------

    // Start is called before the first frame update
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!active && other.CompareTag("Player"))
        {
            _spriteRenderer.sprite = flagOpened;
            active = true;
        }
    }

    #endregion
}