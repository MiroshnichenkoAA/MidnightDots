using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public float inputThrottle;
    public float inputBrakes;
    public float inputSteering;
    public float inputHandBrake;
  
    public InputManager _inputs;

  
    
  
    

  

    [SerializeField] public float steeringSensivity;

   

    private void Awake()
    {
        _inputs = new InputManager();
      
    }

    private void OnEnable()
    {
        _inputs.Enable();
    }

    private void OnDisable()
    {
        _inputs.Disable();
    }

    void FixedUpdate()
    {    
             BasicInput();
    }


    private void BasicInput()
    {
        inputThrottle = _inputs.Gameplay.AccBrakes.ReadValue<float>() < 0 ? 0 : _inputs.Gameplay.AccBrakes.ReadValue<float>();
        inputBrakes = _inputs.Gameplay.AccBrakes.ReadValue<float>() > 0 ? 0 : _inputs.Gameplay.AccBrakes.ReadValue<float>();
        inputSteering = Mathf.Lerp(inputSteering, _inputs.Gameplay.Steering.ReadValue<float>(), steeringSensivity * Time.fixedDeltaTime);
       // inputSteering = _inputs.Gameplay.Steering.ReadValue<float>();
        inputHandBrake = _inputs.Gameplay.HandBrake.ReadValue<float>();
      
    }


   

    
}
