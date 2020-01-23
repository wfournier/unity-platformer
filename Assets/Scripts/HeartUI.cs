using System;
using UnityEngine;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour
{
    #region Declarations --------------------------------------------------

    private Image _image;

    public Sprite full;
    public Sprite half;
    public Sprite empty;
    public HeartState state;

    [Range(1, 10)] public int position;

    [HideInInspector] public int value;

    #endregion


    #region Private/Protected Methods -------------------------------------

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    private void Update()
    {
        value = (int) state;
        switch (state)
        {
            case HeartState.Full:
                _image.sprite = full;
                break;
            case HeartState.Half:
                _image.sprite = half;
                break;
            case HeartState.Empty:
                _image.sprite = empty;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    #endregion
}


public enum HeartState
{
    // The int value represents the amount of health represented by each heart state
    Full = 2,
    Half = 1,
    Empty = 0
}