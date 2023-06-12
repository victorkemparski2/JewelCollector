
/// <summary>
/// Classe que manipula tudo relacionado as posicoes das entidades
/// </summary>
public class Map
{
    /// <summary>
    /// Largura do mapa
    /// </summary>
    /// <value></value>
    public int Width { get => EntityGrid.Width; }
    /// <summary>
    /// Altura do mapa
    /// </summary>
    /// <value></value>
    public int Height { get => EntityGrid.Height; }

    /// <summary>
    /// Grid para armazenar as entidades, mais informacoes na documentacao da classe Grid
    /// </summary>
    /// <value></value>
    private Grid<Entity> EntityGrid;

    /// <summary>
    /// Lista de joias essencialmente para checar a quantidade de joias restantes no mapa
    /// </summary>
    /// <value></value>
    private List<Jewel> Jewels { get; }

    /// <summary>
    /// Construtor da classe Map
    /// Inicializacao das instancias da classe
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public Map(int width, int height)
    {
        EntityGrid = new Grid<Entity>(width, height);
        Jewels = new List<Jewel>();
    }

    /// <summary>
    /// Verifica se tem alguma entidade em certa posicao
    /// </summary>
    /// <param name="position">Posicao a ser verificada</param>
    /// <returns></returns>
    private bool HasEntity(Position position)
    {
        return this.EntityGrid.Get(position) != null;
    }

    /// <summary>
    /// Gera uma posicao aleatoria ate achar uma posicao vazia (nao ha entidades nessa posicao)
    /// </summary>
    /// <returns>A posicao vazia</returns>
    public Position GetEmptyPosition()
    {
        Random rnd = new Random();
        Position position;
        do
        {
            position = new Position(rnd.Next(Width), rnd.Next(Height));
        } while (HasEntity(position));
        return position;
    }

    /// <summary>
    /// Funcao wrapper para Grid
    /// </summary>
    /// <param name="entity">Entidade a ser Inserida</param>
    /// <param name="position">Posicao da entidade</param>
    private void Set(Position position, Entity? entity)
    {
        EntityGrid.Set(position, entity);
    }

    /// <summary>
    /// Insere a entidade no Grid
    /// </summary>
    /// <param name="entity">A entidade que sera inserida</param>
    public void Insert(Entity entity)
    {
        if (entity is Jewel jewel)
        {
            Jewels.Add(jewel);
        }
        Set(entity.Position, entity);
    }

    /// <summary>
    /// Atualiza a posicao da entidade
    /// </summary>
    /// <param name="oldPosition">Posicao anterior</param>
    /// <param name="newPosition">Posicao nova</param>
    /// <param name="entity">A entidade a ser atualizada</param>
    public void UpdatePosition(Position oldPosition, Position newPosition, Entity entity)
    {
        Set(oldPosition, null);
        Set(newPosition, entity);
    }

    /// <summary>
    /// O robo interage com as entidade ao seu redor
    /// </summary>
    /// <param name="robot">O robo</param>
    public void Interact(Robot robot)
    {
        List<Entity> entities = EntityGrid.GetNearby(robot.Position);
        foreach (Entity entity in entities)
        {
            if (entity is ICollectable ic)
            {
                Set(entity.Position, null);
                if (entity is Jewel jewel) Jewels.Remove(jewel);
                ic.Collect(robot);
            }
            if (entity is IRechargeable ir)
            {
                ir.Recharge(robot);
            }
        }
    }

    /// <summary>
    /// Verifica se o robo pode ir a uma certa posicao
    /// </summary>
    /// <param name="nextPosition">a posicao a ser verificada</param>
    public void CheckCollision(Position nextPosition)
    {
        if (EntityGrid.IsOutOfBounds(nextPosition)) throw new OutOfBoundsException();
        if (EntityGrid.Get(nextPosition) != null) throw new CollisionException();
    }

    /// <summary>
    /// Imprime o mapa
    /// </summary>
    public void Print()
    {
        foreach ((Position position, String lineEnd) tuple in Position.LoopAll(Width, Height))
        {
            Entity? e = EntityGrid.Get(tuple.position);
            Console.Write(e == null ? "--" : e);
            Console.Write(tuple.lineEnd);
        }

    }

    /// <summary>
    /// Verifica se ainda tem joia no mapa
    /// </summary>
    /// <returns></returns>
    public bool IsCleared()
    {
        return !Jewels.Any();
    }

}
