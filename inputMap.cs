// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/inputMap.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMap : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""inputMap"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""589c1509-a86b-4786-afed-33a37d8b6b81"",
            ""actions"": [
                {
                    ""name"": ""moveLeft"",
                    ""type"": ""Button"",
                    ""id"": ""02143c56-1c75-4e87-8f9f-30c5afd9a4d1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""moveRight"",
                    ""type"": ""Button"",
                    ""id"": ""819ef962-b8bd-4380-9cfa-d045abb6df0d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateForward"",
                    ""type"": ""Button"",
                    ""id"": ""c31dc564-bbd5-45a5-abe3-6ad5036b743e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""moveDown"",
                    ""type"": ""Button"",
                    ""id"": ""89eaa80f-0bd2-45c5-8067-546e63b6bc35"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""fastDown"",
                    ""type"": ""Button"",
                    ""id"": ""ad4bccd6-986d-47f4-ac0f-5fa890aa1f81"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b7284b9c-820b-4fe4-a89e-45bfc7beefd7"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""moveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73cecdb9-49f0-4815-9328-9206bc823e6a"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""moveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9841f15d-70ba-4bd7-bec6-987146238478"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9897ff24-07a8-4b6a-a164-938c7f94e8e7"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""moveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8729820d-1234-4463-b767-c42bf6f75246"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""fastDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Touch"",
            ""bindingGroup"": ""Touch"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": [
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""XR"",
            ""bindingGroup"": ""XR"",
            ""devices"": [
                {
                    ""devicePath"": ""<XRController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_moveLeft = m_Player.FindAction("moveLeft", throwIfNotFound: true);
        m_Player_moveRight = m_Player.FindAction("moveRight", throwIfNotFound: true);
        m_Player_RotateForward = m_Player.FindAction("RotateForward", throwIfNotFound: true);
        m_Player_moveDown = m_Player.FindAction("moveDown", throwIfNotFound: true);
        m_Player_fastDown = m_Player.FindAction("fastDown", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_moveLeft;
    private readonly InputAction m_Player_moveRight;
    private readonly InputAction m_Player_RotateForward;
    private readonly InputAction m_Player_moveDown;
    private readonly InputAction m_Player_fastDown;
    public struct PlayerActions
    {
        private @InputMap m_Wrapper;
        public PlayerActions(@InputMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @moveLeft => m_Wrapper.m_Player_moveLeft;
        public InputAction @moveRight => m_Wrapper.m_Player_moveRight;
        public InputAction @RotateForward => m_Wrapper.m_Player_RotateForward;
        public InputAction @moveDown => m_Wrapper.m_Player_moveDown;
        public InputAction @fastDown => m_Wrapper.m_Player_fastDown;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @moveLeft.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveLeft;
                @moveLeft.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveLeft;
                @moveLeft.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveLeft;
                @moveRight.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveRight;
                @moveRight.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveRight;
                @moveRight.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveRight;
                @RotateForward.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotateForward;
                @RotateForward.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotateForward;
                @RotateForward.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotateForward;
                @moveDown.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveDown;
                @moveDown.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveDown;
                @moveDown.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveDown;
                @fastDown.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFastDown;
                @fastDown.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFastDown;
                @fastDown.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFastDown;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @moveLeft.started += instance.OnMoveLeft;
                @moveLeft.performed += instance.OnMoveLeft;
                @moveLeft.canceled += instance.OnMoveLeft;
                @moveRight.started += instance.OnMoveRight;
                @moveRight.performed += instance.OnMoveRight;
                @moveRight.canceled += instance.OnMoveRight;
                @RotateForward.started += instance.OnRotateForward;
                @RotateForward.performed += instance.OnRotateForward;
                @RotateForward.canceled += instance.OnRotateForward;
                @moveDown.started += instance.OnMoveDown;
                @moveDown.performed += instance.OnMoveDown;
                @moveDown.canceled += instance.OnMoveDown;
                @fastDown.started += instance.OnFastDown;
                @fastDown.performed += instance.OnFastDown;
                @fastDown.canceled += instance.OnFastDown;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_TouchSchemeIndex = -1;
    public InputControlScheme TouchScheme
    {
        get
        {
            if (m_TouchSchemeIndex == -1) m_TouchSchemeIndex = asset.FindControlSchemeIndex("Touch");
            return asset.controlSchemes[m_TouchSchemeIndex];
        }
    }
    private int m_JoystickSchemeIndex = -1;
    public InputControlScheme JoystickScheme
    {
        get
        {
            if (m_JoystickSchemeIndex == -1) m_JoystickSchemeIndex = asset.FindControlSchemeIndex("Joystick");
            return asset.controlSchemes[m_JoystickSchemeIndex];
        }
    }
    private int m_XRSchemeIndex = -1;
    public InputControlScheme XRScheme
    {
        get
        {
            if (m_XRSchemeIndex == -1) m_XRSchemeIndex = asset.FindControlSchemeIndex("XR");
            return asset.controlSchemes[m_XRSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMoveLeft(InputAction.CallbackContext context);
        void OnMoveRight(InputAction.CallbackContext context);
        void OnRotateForward(InputAction.CallbackContext context);
        void OnMoveDown(InputAction.CallbackContext context);
        void OnFastDown(InputAction.CallbackContext context);
    }
}
