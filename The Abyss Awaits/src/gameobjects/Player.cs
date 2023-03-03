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
    private float _moveSpeed = 5.0f; // Play with number
    
    // Player Controlled Stats
    public byte Alchemy;
    public byte Casting;
    public byte Imbuement;
    public byte Blacksmithing;
    public byte Jewling;
    
    // Level Controlled Stats
    public byte Mana;
    public byte Health;
    public byte Speed;
    public byte Strength;
    public byte Luck;
    public byte Charisma;
    public byte Stamina;
    
    // Level
    public byte Level;        // 1 -> ?
    public short DungeonRank; // 0 -> 999

    public int ExperiencePoints;
    public int DungeonPoints;

    public float SpriteHeight {
        get {
            return _sprite.Height * _spriteWidth / _sprite.Width; // Play with number
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

        Alchemy = 0;
        Casting = 0;
        Imbuement = 0;
        Blacksmithing = 0;
        Jewling = 0;

        Mana = 0;
        Health = 0;
        Speed = 0;
        Strength = 0;
        Luck = 0;
        Charisma = 0;
        Stamina = 0;

        Level = 1;
        ExperiencePoints = 0;
        DungeonRank = 0;
        DungeonPoints = 0;
        
        _spriteWidth = 100f; // Play with number
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

    public short CalculateRequiredExperienceForLevelUp(byte lvl) {
        return lvl *= 5; // Play with equation
    }
    
    public short CalculateRequiredDungeonPointsForLevelUp(short lvl) {
        return lvl *= 5; // Play with equation
    }

    public void LevelUp() {
        int requiredExp = CalculateRequiredExperienceForLevelUp(Level);
        int requiredDgp = CalculateRequiredDungeonPointsForLevelUp(DungeonRank);
        
        if (ExperiencePoints >= requiredExp) {
            Level += 1;
            ExperiencePoints %= requiredExp;
        }
        
        if (DungeonPoints >= requiredDgp) {
            DungeonRank += 1;
            DungeonPoints %= requiredDgp;
        }
    }

    private void HandleUserInput() {
        _pos.X += UserInput.MovementVector.X * _moveSpeed; // Play with number
        _pos.Y -= UserInput.MovementVector.Y * _moveSpeed; // Play with number
    }
}