using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class CameraShader : MonoBehaviour {

    public Material effectMat;
    public Slider DisplacementSlider;
    private float sliderValue;

    private void Start()
    {

    }

    private void Update()
    {
        sliderValue = DisplacementSlider.value;
        effectMat.SetFloat("_Magnitude", sliderValue);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        //Render this source to that destination using that effect.
        Graphics.Blit(source, destination, effectMat);
    }
}
