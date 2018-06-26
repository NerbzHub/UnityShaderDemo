/*
    CameraShader.cs
    
    Purpose: Adds my custom displacement image effect's variables to a UI slider.

    @author Nathan Nette
 */
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class CameraShader : MonoBehaviour {

    // Gets the displacement effect material.
    public Material effectMat;

    // Gets the Slider component from the one on the UI.
    public Slider DisplacementSlider;

    // A float to store the slider's value.
    private float sliderValue;

    // Update runs every frame.
    private void Update()
    {
        // Sets the slider value's float to the current value of the slider.
        sliderValue = DisplacementSlider.value;

        // Sets the float of the variable in the shader to the slider value.
        effectMat.SetFloat("_Magnitude", sliderValue);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        //Render this source to that destination using that effect.
        Graphics.Blit(source, destination, effectMat);
    }
}
