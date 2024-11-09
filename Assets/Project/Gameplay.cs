//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.2
//     from Assets/Project/Gameplay.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Gameplay: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Gameplay()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Gameplay"",
    ""maps"": [
        {
            ""name"": ""TouchScreen"",
            ""id"": ""225a8b32-d982-4fd3-a947-869231b19ad6"",
            ""actions"": [
                {
                    ""name"": ""TouchPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3d65121a-76ee-4422-91c3-e9786cc21335"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Touch"",
                    ""type"": ""Button"",
                    ""id"": ""e8446b6d-1e9a-4f19-b5a0-fc12e2652071"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c211d2d3-b97c-423a-9d3a-90f6ffd4cadb"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6271f67c-3ced-4d66-80b8-45245d1909f0"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // TouchScreen
        m_TouchScreen = asset.FindActionMap("TouchScreen", throwIfNotFound: true);
        m_TouchScreen_TouchPosition = m_TouchScreen.FindAction("TouchPosition", throwIfNotFound: true);
        m_TouchScreen_Touch = m_TouchScreen.FindAction("Touch", throwIfNotFound: true);
    }

    ~@Gameplay()
    {
        UnityEngine.Debug.Assert(!m_TouchScreen.enabled, "This will cause a leak and performance issues, Gameplay.TouchScreen.Disable() has not been called.");
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // TouchScreen
    private readonly InputActionMap m_TouchScreen;
    private List<ITouchScreenActions> m_TouchScreenActionsCallbackInterfaces = new List<ITouchScreenActions>();
    private readonly InputAction m_TouchScreen_TouchPosition;
    private readonly InputAction m_TouchScreen_Touch;
    public struct TouchScreenActions
    {
        private @Gameplay m_Wrapper;
        public TouchScreenActions(@Gameplay wrapper) { m_Wrapper = wrapper; }
        public InputAction @TouchPosition => m_Wrapper.m_TouchScreen_TouchPosition;
        public InputAction @Touch => m_Wrapper.m_TouchScreen_Touch;
        public InputActionMap Get() { return m_Wrapper.m_TouchScreen; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchScreenActions set) { return set.Get(); }
        public void AddCallbacks(ITouchScreenActions instance)
        {
            if (instance == null || m_Wrapper.m_TouchScreenActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_TouchScreenActionsCallbackInterfaces.Add(instance);
            @TouchPosition.started += instance.OnTouchPosition;
            @TouchPosition.performed += instance.OnTouchPosition;
            @TouchPosition.canceled += instance.OnTouchPosition;
            @Touch.started += instance.OnTouch;
            @Touch.performed += instance.OnTouch;
            @Touch.canceled += instance.OnTouch;
        }

        private void UnregisterCallbacks(ITouchScreenActions instance)
        {
            @TouchPosition.started -= instance.OnTouchPosition;
            @TouchPosition.performed -= instance.OnTouchPosition;
            @TouchPosition.canceled -= instance.OnTouchPosition;
            @Touch.started -= instance.OnTouch;
            @Touch.performed -= instance.OnTouch;
            @Touch.canceled -= instance.OnTouch;
        }

        public void RemoveCallbacks(ITouchScreenActions instance)
        {
            if (m_Wrapper.m_TouchScreenActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ITouchScreenActions instance)
        {
            foreach (var item in m_Wrapper.m_TouchScreenActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_TouchScreenActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public TouchScreenActions @TouchScreen => new TouchScreenActions(this);
    public interface ITouchScreenActions
    {
        void OnTouchPosition(InputAction.CallbackContext context);
        void OnTouch(InputAction.CallbackContext context);
    }
}
