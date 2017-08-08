using System;

public class SpriteNotRegisteredException : Exception
{
    public SpriteNotRegisteredException(string spriteName, Exception inner)
        : base(String.Format("Sprite '{}' isn't registered!", spriteName), inner) { }
}