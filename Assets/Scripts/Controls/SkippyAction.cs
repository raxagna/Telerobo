// GENERATED AUTOMATICALLY FROM 'Assets/_Razan/Scripts 1/Controls/SkippyAction.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @SkippyAction : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @SkippyAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""SkippyAction"",
    ""maps"": [
        {
            ""name"": ""Joystick"",
            ""id"": ""efc571e9-d994-4313-8fe7-15d47c63eec3"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""818e38a6-fcd1-4670-9b97-9c8596cdd64c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Gaze"",
                    ""type"": ""Value"",
                    ""id"": ""592f7484-4cb7-453b-856c-31391bd8697b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fc68e793-1f38-4cd3-84d0-5b6ae833310c"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""16cc0045-f3c7-4d1e-a0ca-75562ab05a1a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gaze"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ea5d264e-7429-4f22-bb5e-8cf8ad43e037"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gaze"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b08fb89a-5cff-437a-97b8-23670e5d3715"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gaze"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Tank"",
            ""id"": ""116180b9-2445-4328-ab0c-71c6819329a2"",
            ""actions"": [
                {
                    ""name"": ""Right Tread"",
                    ""type"": ""Value"",
                    ""id"": ""bdd9de31-7b12-4cd7-9b89-b951514761e8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left Tread"",
                    ""type"": ""Value"",
                    ""id"": ""d974fa10-db7b-4abf-b396-9210fb024796"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""RF"",
                    ""id"": ""bb6e443a-5a8a-42db-b25d-85cb02ff2eb9"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left Tread"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ab519eb7-8eb2-4914-a12c-6f50df45ac3a"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""2D player"",
                    ""action"": ""Left Tread"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5cb9df24-8831-4114-b175-4151f864da15"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""2D player"",
                    ""action"": ""Left Tread"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""96"",
                    ""id"": ""a5e2d514-5ed0-48e2-937b-ff6afd118a02"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right Tread"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ad535426-d5e4-45fa-8f6c-6ddb31149ab0"",
                    ""path"": ""<Keyboard>/numpad9"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""2D player"",
                    ""action"": ""Right Tread"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4967c78b-e7aa-45f6-84d5-959464d7b553"",
                    ""path"": ""<Keyboard>/numpad6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""2D player"",
                    ""action"": ""Right Tread"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Joystick
        m_Joystick = asset.FindActionMap("Joystick", throwIfNotFound: true);
        m_Joystick_Move = m_Joystick.FindAction("Move", throwIfNotFound: true);
        m_Joystick_Gaze = m_Joystick.FindAction("Gaze", throwIfNotFound: true);
        // Tank
        m_Tank = asset.FindActionMap("Tank", throwIfNotFound: true);
        m_Tank_RightTread = m_Tank.FindAction("Right Tread", throwIfNotFound: true);
        m_Tank_LeftTread = m_Tank.FindAction("Left Tread", throwIfNotFound: true);
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

    // Joystick
    private readonly InputActionMap m_Joystick;
    private IJoystickActions m_JoystickActionsCallbackInterface;
    private readonly InputAction m_Joystick_Move;
    private readonly InputAction m_Joystick_Gaze;
    public struct JoystickActions
    {
        private @SkippyAction m_Wrapper;
        public JoystickActions(@SkippyAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Joystick_Move;
        public InputAction @Gaze => m_Wrapper.m_Joystick_Gaze;
        public InputActionMap Get() { return m_Wrapper.m_Joystick; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(JoystickActions set) { return set.Get(); }
        public void SetCallbacks(IJoystickActions instance)
        {
            if (m_Wrapper.m_JoystickActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_JoystickActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_JoystickActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_JoystickActionsCallbackInterface.OnMove;
                @Gaze.started -= m_Wrapper.m_JoystickActionsCallbackInterface.OnGaze;
                @Gaze.performed -= m_Wrapper.m_JoystickActionsCallbackInterface.OnGaze;
                @Gaze.canceled -= m_Wrapper.m_JoystickActionsCallbackInterface.OnGaze;
            }
            m_Wrapper.m_JoystickActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Gaze.started += instance.OnGaze;
                @Gaze.performed += instance.OnGaze;
                @Gaze.canceled += instance.OnGaze;
            }
        }
    }
    public JoystickActions @Joystick => new JoystickActions(this);

    // Tank
    private readonly InputActionMap m_Tank;
    private ITankActions m_TankActionsCallbackInterface;
    private readonly InputAction m_Tank_RightTread;
    private readonly InputAction m_Tank_LeftTread;
    public struct TankActions
    {
        private @SkippyAction m_Wrapper;
        public TankActions(@SkippyAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @RightTread => m_Wrapper.m_Tank_RightTread;
        public InputAction @LeftTread => m_Wrapper.m_Tank_LeftTread;
        public InputActionMap Get() { return m_Wrapper.m_Tank; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TankActions set) { return set.Get(); }
        public void SetCallbacks(ITankActions instance)
        {
            if (m_Wrapper.m_TankActionsCallbackInterface != null)
            {
                @RightTread.started -= m_Wrapper.m_TankActionsCallbackInterface.OnRightTread;
                @RightTread.performed -= m_Wrapper.m_TankActionsCallbackInterface.OnRightTread;
                @RightTread.canceled -= m_Wrapper.m_TankActionsCallbackInterface.OnRightTread;
                @LeftTread.started -= m_Wrapper.m_TankActionsCallbackInterface.OnLeftTread;
                @LeftTread.performed -= m_Wrapper.m_TankActionsCallbackInterface.OnLeftTread;
                @LeftTread.canceled -= m_Wrapper.m_TankActionsCallbackInterface.OnLeftTread;
            }
            m_Wrapper.m_TankActionsCallbackInterface = instance;
            if (instance != null)
            {
                @RightTread.started += instance.OnRightTread;
                @RightTread.performed += instance.OnRightTread;
                @RightTread.canceled += instance.OnRightTread;
                @LeftTread.started += instance.OnLeftTread;
                @LeftTread.performed += instance.OnLeftTread;
                @LeftTread.canceled += instance.OnLeftTread;
            }
        }
    }
    public TankActions @Tank => new TankActions(this);
    public interface IJoystickActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnGaze(InputAction.CallbackContext context);
    }
    public interface ITankActions
    {
        void OnRightTread(InputAction.CallbackContext context);
        void OnLeftTread(InputAction.CallbackContext context);
    }
}
