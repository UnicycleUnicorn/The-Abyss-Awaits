using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using The_Abyss_Awaits.input;

namespace The_Abyss_Awaits.gameobjects;

public class Player : IStats {

    // General
    private MainGame _game;
    private Vector2 _pos;
    private Texture2D _sprite;
    private float _spriteWidth;
    private float _moveSpeed = 5.0f;
    
    // Player Controlled Stats
    public byte Alchemy = 0;
    public byte Casting = 0;
    public byte Imbuement = 0;
    public byte Blacksmithing = 0;
    public byte Jewling = 0;
    
    // Level Controlled Stats
    public byte Mana = 0;
    public byte Health = 0;
    public byte Speed = 0;
    public byte Strength = 0;
    public byte Luck = 0;
    public byte Charisma = 0;
    public byte Stamina = 0;
    
    
    // Level
    public byte Level = 1;        // 1 -> ?
    public short DungeonRank = 0; // 0 -> 999

    public float SpriteHeight {
        get {
            return _sprite.Height * _spriteWidth / _sprite.Width;
        }
    }

    public Rectangle Rectangle {
        get {
            return new Rectangle((int)_pos.X, (int)_pos.Y, (int)_spriteWidth, (int)SpriteHeight);
        }
    }

    public Player(MainGame game, Vector2 pos) {
        this._game = game;
        this._pos = pos;
        _spriteWidth = 100f;
    }

    public void AddToStat(byte stat, byte val) {
        stat += val;
    }

    public void LoadContent() {
        _sprite = _game.Content.Load<Texture2D>("steve");
    }
    
    public void Update(GameTime time) {
        HandleUserInput();
    }

    public void Draw(GameTime time, SpriteBatch spriteBatch) {
        spriteBatch.Draw(_sprite, Rectangle, Color.White);
    }

    private void HandleUserInput() {
        _pos.X += UserInput.MovementVector.X * _moveSpeed;
        _pos.Y -= UserInput.MovementVector.Y * _moveSpeed;
    }
}