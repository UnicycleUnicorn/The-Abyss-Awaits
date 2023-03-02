using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace The_Abyss_Awaits.input.keyboard_mouse;

public static class KeyboardMouse {
    private static KeyboardState _keyboardCurrent = Keyboard.GetState();
    private static MouseState _mouseCurrent = Mouse.GetState();
    private static readonly Dictionary<Controls, MouseButton> MouseBindings = new();
    private static readonly Dictionary<Controls, KeyButton> KeyboardBindings = new();
    
    // Constructor
    static KeyboardMouse() {
        AddBinding(Controls.Menu, Keys.Escape);
        AddBinding(Controls.Up, Keys.W);
        AddBinding(Controls.Down, Keys.S);
        AddBinding(Controls.Left, Keys.A);
        AddBinding(Controls.Right, Keys.D);
        AddBinding(Controls.Walk, Keys.LeftShift);
    }

    // Add a mouse binding
    private static void AddBinding(Controls item, MouseButtons button) {
        MouseBindings.Add(item, new MouseButton(button));
    }
    
    // Add a keyboard binding
    private static void AddBinding(Controls item, Keys key) {
        KeyboardBindings.Add(item, new KeyButton(key));
    }

    private static bool IsMouseButtonDown(MouseButtons button) {
        return button switch {
            MouseButtons.LeftButton => _mouseCurrent.LeftButton == ButtonState.Pressed,
            MouseButtons.RightButton => _mouseCurrent.RightButton == ButtonState.Pressed,
            MouseButtons.MiddleButton => _mouseCurrent.MiddleButton == ButtonState.Pressed,
            MouseButtons.XButton1 => _mouseCurrent.XButton1 == ButtonState.Pressed,
            MouseButtons.XButton2 => _mouseCurrent.XButton2 == ButtonState.Pressed,
            _ => throw new ArgumentOutOfRangeException(nameof(button), button, null)
        };
    }

    // Update keyboard & mouse
    public static void Update() {
        _keyboardCurrent = Keyboard.GetState();
        _mouseCurrent = Mouse.GetState();

        // Update keyboard keys
        foreach (var bind in KeyboardBindings.Select(binding => binding.Value)) {
            if (_keyboardCurrent.IsKeyDown(bind.Key)) {
                bind.InputState = bind.InputState == InputState.Up ? InputState.Pressed : InputState.Down;
            } else {
                bind.InputState = bind.InputState == InputState.Down ? InputState.Released : InputState.Up;
            }
        }

        // Update mouse buttons
        foreach (var bind in MouseBindings.Select(binding => binding.Value)) {
            if (IsMouseButtonDown(bind.MouseButtons)) {
                bind.InputState = bind.InputState == InputState.Up ? InputState.Pressed : InputState.Down;
            } else {
                bind.InputState = bind.InputState == InputState.Down ? InputState.Released : InputState.Up;
            }
        }
    }

    // Get mouse position
    public static Vector2 GetMousePosition() {
        return new Vector2(_mouseCurrent.X, _mouseCurrent.Y);
    }

    // Get scroll position
    public static int GetScrollPosition() {
        return _mouseCurrent.ScrollWheelValue;
    }

    public static InputState GetButtonState(Controls item) {
        if (MouseBindings.ContainsKey(item)) return MouseBindings[item].InputState;
        return KeyboardBindings[item].InputState;
    }
}