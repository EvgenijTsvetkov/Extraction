using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighlightButton : MonoBehaviour
{
    [SerializeField] private Image _background;
    [SerializeField] private TMP_Text _text;
    
    [SerializeField] private Color _colorForText;
    [SerializeField] private Color _colorForBackground;

    private Color _defaultTextColor;
    private Color _defaultBackgroundColor;

    private void Awake()
    {
        _defaultTextColor = _text.color;
        _defaultBackgroundColor = _background.color;
    }

    public void Activate()
    {
        _background.color = _colorForBackground;
        _text.color = _colorForText;
    }

    public void Deactivate()
    {
        _background.color = _defaultBackgroundColor;
        _text.color = _defaultTextColor;
    }
}
