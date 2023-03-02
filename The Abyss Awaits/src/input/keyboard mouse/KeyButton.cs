using Microsoft.Xna.Framework.Input;

namespace The_Abyss_Awaits.input.keyboard_mouse;

public class KeyButton {
    public Keys Key;
    public InputState InputState;

    public KeyButton(Keys key) {
        Key = key;
        InputState = InputState.None;
    }
}