using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace The_Abyss_Awaits.input.controller;

public static class Controller {
    private static GamePadState _gamepadCurrent = GamePad.GetState(PlayerIndex.One);
    private static readonly Dictionary<Controls, ControllerButton> ControllerBindings = new();

    // Constructor
    static Controller() {
        AddBinding(Controls.Menu, Buttons.Start);
    }

    // Add a button binding
    private static void AddBinding(Controls item, Buttons button) {
        ControllerBindings.Add(item, new ControllerButton(button));
    }

    // Update gamepad - returns if controller active
    public static bool Update() {
        _gamepadCurrent = GamePad.GetState(PlayerIndex.One);
        
        // Return false immediately if controller not available
        if (!_gamepadCurrent.IsConnected) return false;

        // Update specific buttons
        foreach (var bind in ControllerBindings.Select(binding => binding.Value)) {
            if (_gamepadCurrent.IsButtonDown(bind.Button)) {
                bind.InputState = bind.InputState == InputState.Up ? InputState.Pressed : InputState.Down;
            } else { 
                bind.InputState = bind.InputState == InputState.Down ? InputState.Released : InputState.Up;
            }
        }
        
        return true;
    }

    // Get left joystick vector
    public static Vector2 GetLeftJoystick() {
        return _gamepadCurrent.ThumbSticks.Left;
    }

    // Get right joystick vector
    public static Vector2 GetRightJoystick() {
        return _gamepadCurrent.ThumbSticks.Right;
    }

    // Get the state of a binding
    public static InputState GetButtonState(Controls item) {
        return ControllerBindings[item].InputState;
    }

    // Set current vibration
    public static void SetVibration(float left, float right) {
        GamePad.SetVibration(PlayerIndex.One, left, right);
    }
}