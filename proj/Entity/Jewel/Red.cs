/// <summary>
/// Class para joia vermelha
/// </summary>
public class Red : Jewel
{
    /// <summary>
    /// Construtor com coordenadas separadas
    /// </summary>
    public Red(int x, int y) : base(new Position(x, y)) { }

    /// <summary>
    /// Construtor com coordenada em Position
    /// </summary>
    public Red(Position position) : base(position) { }

    /// <summary>
    /// Representacao em String da entidade
    /// </summary>
    public override string ToString()
    {
        return "JR";
    }

    /// <summary>
    /// Valor da Joia
    /// </summary>
    public override int GetValue()
    {
        return 100;
    }
}