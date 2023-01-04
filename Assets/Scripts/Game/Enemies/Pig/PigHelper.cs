using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigHelper : MonoBehaviour
{
    // Start is called before the first frame update
    public void FinishAttack()
    {
        transform.parent.GetComponent<Pig>().InflictDamage();
    }
}
