using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderDistortion : MonoBehaviour
{
    Renderer cubeRenderer;
    [SerializeField] Color32 color = new Color32(60, 195, 184, 255);
    [SerializeField] [Range(0, 1)] float transparency = 0f;
    [SerializeField] [Range(0, 1)] float colorCutout = 0f;
    [SerializeField] float amplitude = 0f;
    [SerializeField] float distance = 0f;
    [SerializeField] float speed = 0f;
    [SerializeField] float amount = 0f;

    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        //SetRendererValues();
    }

    // For testing purposes used to set values in editor..
    private void SetRendererValues()
    {
        cubeRenderer.material.SetColor("_Color", color);
        cubeRenderer.material.SetFloat("_Transparency", transparency);
        cubeRenderer.material.SetFloat("_ColorCutout", colorCutout);
        cubeRenderer.material.SetFloat("_Amplitude", amplitude);
        cubeRenderer.material.SetFloat("_Distance", distance);
        cubeRenderer.material.SetFloat("_Speed", speed);
        cubeRenderer.material.SetFloat("_Amount", amount);

    }

    public void SetRendererColor(Color32 color)
    {
        cubeRenderer.material.SetColor("_Color", color);
       // cubeRenderer.material.color = new Color32();
    }
    public void SetRendererTransparency(float transparency)
    {
        cubeRenderer.material.SetFloat("_Transparency", transparency);
    }
    public void SetRendererColorCutout(float colorCutout)
    {
        cubeRenderer.material.SetFloat("_ColorCutout", colorCutout);
    }
    public void SetRendererAmplitude(float amplitude)
    {
        cubeRenderer.material.SetFloat("_Amplitude", amplitude);

    }
    public void SetRendererDistance(float distance)
    {
        cubeRenderer.material.SetFloat("_Distance", distance);

    }
    public void SetRendererSpeed(float speed)
    {
        cubeRenderer.material.SetFloat("_Speed", speed);

    }
    public void SetRendererAmount(float amount)
    {
        cubeRenderer.material.SetFloat("_Amount", amount);
    }

    public int GetRedValue()
    {
        return color.r;
    }
    public int GetGreenValue()
    {
        return color.g;
    }
    public int GetBlueValue()
    {
        return color.b;
    }
}
