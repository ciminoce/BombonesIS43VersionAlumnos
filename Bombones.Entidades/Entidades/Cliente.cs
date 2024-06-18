namespace Bombones.Entidades.Entidades
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public int Documento { get; set; }
        public string Apellido { get; set; } = null!;
        public string Nombres { get; set; }= null!;
    }

}
