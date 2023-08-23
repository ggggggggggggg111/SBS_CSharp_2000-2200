using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUpText : MonoBehaviour
{
    private TMP_Text _message;
    [SerializeField] private Vector3 _startPos;
    [SerializeField] private Vector3 _direction = Vector3.up;
    [SerializeField] private float _moveSpeed = 0.5f;
    [SerializeField] private float _fadeSpeed = 0.5f;
    private Color _colorOrign;
    public event Action onHide;
    public void PopUp()
    {
        transform.position = _startPos;
        _message.color = _colorOrign;
        gameObject.SetActive(true);
    }
    public void PopUp(string newMessage)
    {
        _message.text = newMessage;
        PopUp();
    }

    private void Awake()
    {
        _message = GetComponent<TMP_Text>();
        _colorOrign = _message.color;
    }

    private void Update()
    {
        transform.Translate(_direction * _moveSpeed * Time.deltaTime);

        float a = _message.color.a - _fadeSpeed * Time.deltaTime;

        if (a > 0)
        {
            _message.color = new Color(_colorOrign.r, _colorOrign.g,_colorOrign.b, a);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
