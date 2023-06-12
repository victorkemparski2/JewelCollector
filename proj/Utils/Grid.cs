/// <summary>
/// Classe de utilidade para facilitar a interacao entre a classe Position e um array bidimensional generica
/// </summary>
/// <typeparam name="T"></typeparam>
public class Grid<T> where T : class
{
    /// <summary>
    /// Largura
    /// </summary>
    /// <value></value>
    public int Width { get; }
    /// <summary>
    /// Height
    /// </summary>
    /// <value></value>
    public int Height { get; }

    /// <summary>
    /// Array bidimensional interna
    /// </summary>
    private T?[,] grid;

    /// <summary>
    /// construtor
    /// </summary>
    public Grid(int width, int height)
    {
        Width = width;
        Height = height;
        grid = new T?[width, height];
    }

    /// <summary>
    /// Coloca o objeto do tipo generico na posicao
    /// </summary>
    public void Set(Position position, T? obj)
    {
        grid[position.X, position.Y] = obj;
    }

    /// <summary>
    /// Retorna o objeto da posicao
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public T? Get(Position position)
    {
        return grid[position.X, position.Y];
    }

    /// <summary>
    /// Retorna os objetos em volta da posicao
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public List<T> GetNearby(Position position)
    {
        List<T> objs = new List<T>();
        foreach (Position p in position.GetNearby())
        {
            if (!IsOutOfBounds(p))
            {
                T? obj = Get(p);
                if (obj != null) objs.Add(obj);
            }
        }
        return objs;
    }

    /// <summary>
    /// Verifica se esta fora do mapa
    /// </summary>
    /// <param name="x">limite X do mapa</param>
    /// <param name="y">limite X do mapa</param>
    /// <returns></returns>
    public bool IsOutOfBounds(Position position)
    {
        return position.X >= Width || position.X < 0 || position.Y >= Height || position.Y < 0;
    }
}