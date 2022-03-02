using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteAnimation : MonoBehaviour
{
    public Transform top;
    public Transform bottom;
    public bool repeatable;
    public float speed = 2f;
    public float duration = 5f;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (repeatable)
        {
            yield return TextAnimation(bottom, top, duration);
            yield return TextAnimation(top, bottom, duration);
        }
    }

    public IEnumerator TextAnimation(Transform a, Transform b, float time)
    {
        float ai = a.position.y;
        float bi = b.position.y;
        float i = 0.0f;
        float rate = (1.0f / time) * speed;

        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            transform.position = new Vector3(a.position.x ,Mathf.Lerp(ai, bi, i), a.position.z);

            yield return null;
        }


    }
}
