using System.Collections;
using UnityEngine;

public class Enemy_VFX : MonoBehaviour
{
    private SpriteRenderer sr;
    private Material originalMat;
    [SerializeField] private Material onDamageVfxMat;
    [SerializeField] private float onDamageVfxDuration = 0.15f;
    private Coroutine onDamageVfxCo;

    private void Awake()
    {
        sr =GetComponentInChildren<SpriteRenderer>();
        originalMat = sr.material;
    }

    public void PlayOnDamageVFX()
    {
        if(onDamageVfxCo != null)
        {
            StopCoroutine(onDamageVfxCo);
        }
        onDamageVfxCo = StartCoroutine(OnDamageVFXco());
    }

    private IEnumerator OnDamageVFXco()
    {
        sr.material = onDamageVfxMat;

        yield return new WaitForSeconds(onDamageVfxDuration);

        sr.material = originalMat;
    }
}
