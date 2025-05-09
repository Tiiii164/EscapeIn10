using System.Collections;
using UnityEngine;

public class FlashEffect : MonoBehaviour
{
    [SerializeField] private Renderer meshRenderer;

    [SerializeField] private Color flashColor = Color.white;
    [SerializeField] private float flashDuration = 0.1f;

    private Material _originalMaterial;
    private Color _originalColor;

    private void Awake()
    {
        if (meshRenderer == null)
            meshRenderer = GetComponentInChildren<Renderer>();

        _originalMaterial = meshRenderer.material;
        _originalColor = _originalMaterial.color;
    }

    public void PlayFlash()
    {
        StartCoroutine(Flash());
    }

    private IEnumerator Flash()
    {
        meshRenderer.material.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        meshRenderer.material.color = _originalColor;
    }
}
