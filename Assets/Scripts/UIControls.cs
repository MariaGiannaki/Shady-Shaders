using System.Collections;
using System.Collections.Generic;
using Custom.Color;
using UnityEngine;
using UnityEngine.UI;

public class UIControls : MonoBehaviour
{
    public GameObject cube;
    public Dropdown CubesDropdown;
    public InputField amplitudeInput;
    public InputField distanceInput;
    public InputField speedInput;
    public InputField amountInput;
    public Slider colorCutoutSlider;
    public Slider transparencySlider;
    public InputField redValue;
    public InputField greenValue;
    public InputField blueValue;

    GameObject player;
    GameObject spawnedCubes;
    GameObject selectedCube;

    int count = 0;
    [SerializeField] float spawnOffset = 3f;
    bool fieldsActive = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spawnedCubes = GameObject.Find("Spawned Cubes");

        // redValue.text = cube.GetComponent<ShaderDistortion>().GetRedValue().ToString();
        // greenValue.text = cube.GetComponent<ShaderDistortion>().GetGreenValue().ToString();
        // blueValue.text = cube.GetComponent<ShaderDistortion>().GetBlueValue().ToString();

        //speedInput.text = "20";
    }

    private void Update()
    {
        selectedCube = GameObject.Find("Cube" + CubesDropdown.value);

        if (!fieldsActive)
            MakeInputsActive();
    }

    public void AddCube()
    {
        GameObject newCube = (GameObject)Instantiate(cube, new Vector3(player.transform.position.x, 0, player.transform.position.z + spawnOffset), Quaternion.identity);
        newCube.transform.parent = spawnedCubes.transform;
        newCube.name = "Cube" + count;
        CubesDropdown.options.Add(new Dropdown.OptionData { text = newCube.name });
        CubesDropdown.RefreshShownValue();
        count++;
    }

    public GameObject GetSelectedCube()
    {
        return selectedCube;
    }

    public void SetInputAmplitude()
    {
        selectedCube.GetComponent<ShaderDistortion>().SetRendererAmplitude(float.Parse(amplitudeInput.text));
    }
    public void SetInputDistance()
    {
        selectedCube.GetComponent<ShaderDistortion>().SetRendererDistance(float.Parse(distanceInput.text));
    }
    public void SetInputSpeed()
    {
        selectedCube.GetComponent<ShaderDistortion>().SetRendererSpeed(float.Parse(speedInput.text));
    }
    public void SetInputAmount()
    {
        selectedCube.GetComponent<ShaderDistortion>().SetRendererAmount(float.Parse(amountInput.text));
    }
    public void SetColorCutoutAmount()
    {
        selectedCube.GetComponent<ShaderDistortion>().SetRendererColorCutout(colorCutoutSlider.value);
    }
    public void SetTransparencyAmount()
    {
        // for some reason transparency works opossite... 1= trasparent, 0 = opaque
        selectedCube.GetComponent<ShaderDistortion>().SetRendererTransparency(transparencySlider.value);
    }

    public void SetColor()
    {
        var shaderColor = new ShaderColor(redValue.text, greenValue.text, blueValue.text);
        selectedCube.GetComponent<ShaderDistortion>().SetRendererColor(new Color32(shaderColor.Red, shaderColor.Green, shaderColor.Blue, shaderColor.Alpha));

        // set the validated colors to the TextInputs
        redValue.text = shaderColor.Red.ToString();
        greenValue.text = shaderColor.Green.ToString();
        blueValue.text = shaderColor.Blue.ToString();
    }

    private void MakeInputsActive()
    {
        if (!selectedCube)
        {
            colorCutoutSlider.enabled = false;
            transparencySlider.enabled = false;
            amplitudeInput.enabled = false;
            distanceInput.enabled = false;
            speedInput.enabled = false;
            amountInput.enabled = false;
            redValue.enabled = false;
            greenValue.enabled = false;
            blueValue.enabled = false;
        }
        else
        {
            colorCutoutSlider.enabled = true;
            transparencySlider.enabled = true;
            amplitudeInput.enabled = true;
            distanceInput.enabled = true;
            speedInput.enabled = true;
            amountInput.enabled = true;
            redValue.enabled = true;
            greenValue.enabled = true;
            blueValue.enabled = true;

            SetDefaultValues();
            fieldsActive = true;
        }
    }

    private void SetDefaultValues() {
        redValue.text = "60";
        greenValue.text = "195";
        blueValue.text = "185";
    }

}
