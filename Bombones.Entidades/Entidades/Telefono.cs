namespace Bombones.Entidades.Entidades
{
    public class Telefono
    {
        public int TelefonoId { get; set; }
        public string NroTelefono { get; set; } = null!;
        public int TipoTelefonoId { get; set; }
        public TipoTelefono? TipoTelefono { get; set; }
    }
}
