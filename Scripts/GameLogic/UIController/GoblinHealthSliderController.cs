using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoblinHealthSliderController : MonoBehaviour
{
    void Update()
    {
        if (this.GetComponent<Slider>().value <= 0)
            StartCoroutine("DestroyDelay");
    }

    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(8);
        Destroy(this.gameObject);
    }
}
