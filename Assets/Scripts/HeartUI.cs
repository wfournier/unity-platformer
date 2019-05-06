using System;
using UnityEngine;
using UnityEngine.UI;


public class HeartUI : MonoBehaviour
{

    #region Declarations --------------------------------------------------
    
    private Image image;

    public Sprite full;
    public Sprite half;
    public Sprite empty;
    public HeartState state;
    
    [Range(1, 10)]
    public int position;
    
    [HideInInspector]
    public int value;

    #endregion


    #region Private/Protected Methods -------------------------------------

    // Start is called before the first frame update
    private void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    private void Update()
    {
        value = (int) state;
        switch (state)
        {
            case HeartState.Full:
                image.sprite = full;
                break;
            case HeartState.Half:
                image.sprite = half;
                break;
            case HeartState.Empty:
                image.sprite = empty;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    #endregion

}


public enum HeartState
{

    Full = 2,
    Half = 1,
    Empty = 0

}