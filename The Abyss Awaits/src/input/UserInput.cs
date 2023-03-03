using Microsoft.Xna.Framework;
using The_Abyss_Awaits.input.controller;
using The_Abyss_Awaits.input.keyboard_mouse;

namespace The_Abyss_Awaits.input;

public static class UserInput {
    private static List<Controls> _keyboardSpecificControls = new() {Controls.Down, Controls.Left, Controls.Right, Controls.Up, Controls.Walk};
    
    public static bool UsingController = false;
    public static Vector2 MovementVector = Vector2.Zero;
    
    public static void Update() {
        // Auto-switch to controller if available
        UsingController = Controller.Update();
        if (UsingController) {
            // Set movement vector
            MovementVector = Controller.GetLeftJoystick();
        } else {
            // Keyboard & Mouse updates
            KeyboardMouse.Update();
            
            // Set movement vector
            var walking = KeyboardMouse.GetButtonState(Controls.Walk) == InputState.Down ? 0.5f : 1f;
            
            var x = KeyboardMouse.GetButtonState(Controls.Right) == InputState.Down ? 1 : 0;
            if (KeyboardMouse.GetButtonState(Controls.Left) == InputState.Down) {
                x -= 1;
            }
            var y = KeyboardMouse.GetButtonState(Controls.Up) == InputState.Down ? 1 : 0;
            if (KeyboardMouse.GetButtonState(Controls.Down) == InputState.Down) {
                y -= 1;
            }
            MovementVector = new Vector2(x * walking, y * walking);
        }
    }

    public static void Vibrate(float left, float right) {
        if (UsingController) Controller.SetVibration(left, right);
    }
    
    public static InputState GetInputState(Controls item) {
        if (_keyboardSpecificControls.Contains(item) || !UsingController) return KeyboardMouse.GetButtonState(item);
        return Controller.GetButtonState(item);
    }

}