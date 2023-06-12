/// <summary>
/// Excecao para quando tiver colisao
/// </summary>
public class CollisionException : Exception
{
    public CollisionException() : base("Collision detected, invalid movement") { }
}