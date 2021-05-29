using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Stars : MonoBehaviour
{
    [SerializeField] List<Star> _Stars = new List<Star>();

    public void Initialize(int StarsNumber)
    {
        if (_Stars.Count == 0 || StarsNumber > 3)
        {
            throw new ArgumentOutOfRangeException();
        }

        for (int star = 0; star < 3; star ++)
        {
            if(star < StarsNumber) 
                _Stars[star].ChangeState(true);
            else
                _Stars[star].ChangeState(false);
        }
    }
}
