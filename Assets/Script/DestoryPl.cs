﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryPl : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            GameObject.Destroy(coll.gameObject);
        }
    }


}
