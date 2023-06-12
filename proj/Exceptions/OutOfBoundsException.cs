/// <summary>
/// Excecao para quando a posicao estiver fora do mapa
/// </summary>
public class OutOfBoundsException : Exception
{
    public OutOfBoundsException() : base("Out of bounds") { }
}