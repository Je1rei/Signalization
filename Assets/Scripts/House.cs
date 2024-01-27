using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Signalization _signalization;

    private void OnTriggerEnter2D(Collider2D house)
    {
        if (house.gameObject.TryGetComponent(out Thief thief))
        {
            _signalization.ToggleSignalization(isActivate : true);
        }
    }

    private void OnTriggerExit2D(Collider2D house)
    {
        if (house.gameObject.TryGetComponent(out Thief thief))
        {
            _signalization.ToggleSignalization(isActivate: false);
        }
    }
}
