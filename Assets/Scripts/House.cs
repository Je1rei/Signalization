using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Signalization _signalization;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Thief other))
        {
            _signalization.SignalizationOn();
            Debug.Log("коснулись");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Thief other))
        {
            _signalization.SignalizationOff();
            Debug.Log("вышли");
        }
    }
}
