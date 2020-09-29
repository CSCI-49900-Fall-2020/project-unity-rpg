using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringFront : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        transform.SetAsLastSibling(); //draw last in hierarachy
    }
}
