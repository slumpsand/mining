using System;

public class SpriteNotRegisteredException : Exception
{
    public SpriteNotRegisteredException(string spriteName, Exception inner)
        : base(String.Format("Sprite '{}' isn't registered!", spriteName), inner) { }
}

public class SingletonBrokenException : Exception
{
    public SingletonBrokenException(Type type)
        : base(String.Format("Singleton '{}' doesn't have an instance.", type.FullName)) { }

    public SingletonBrokenException(Type type, int count)
        : base(String.Format("Singleton '{}' has to many instances: {}.", type.FullName, count)) { }
}