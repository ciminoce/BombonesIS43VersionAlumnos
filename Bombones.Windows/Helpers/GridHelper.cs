using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;

namespace Bombones.Windows.Helpers
{
    public static class GridHelper
    {
        public static void LimpiarGrilla(DataGridView grid)
        {
            grid.Rows.Clear();
        }
        public static DataGridViewRow ConstruirFila(DataGridView grid)
        {
            var r = new DataGridViewRow();
            r.CreateCells(grid);
            return r;
        }

        public static void SetearFila(DataGridViewRow r, object obj)
        {
            switch (obj)
            {
                case TipoDeChocolate tc:
                    r.Cells[0].Value = tc.Descripcion;
                    break;
                case TipoDeRelleno tr:
                    r.Cells[0].Value = tr.Descripcion;
                    break;
                case TipoDeNuez tn:
                    r.Cells[0].Value = tn.Descripcion;
                    break;
                case Pais p:
                    r.Cells[0].Value = p.NombrePais;
                    break;
                case ProvinciaEstadoListDto pe:
                    r.Cells[0].Value = pe.NombreProvinciaEstado;
                    r.Cells[1].Value = pe.NombrePais;
                    break;
                case CiudadListDto ciudad:
                    r.Cells[0].Value = ciudad.NombreCiudad;
                    r.Cells[1].Value = ciudad.NombreProvinciaEstado;
                    r.Cells[2].Value = ciudad.NombrePais;
                    break;
                case FabricaListDto fabrica:
                    r.Cells[0].Value=fabrica.NombreFabrica;
                    r.Cells[1].Value=fabrica.Direccion;
                    r.Cells[2].Value = fabrica.NombreCiudad;
                    r.Cells[3].Value = fabrica.NombreProvinciaEstado;
                    r.Cells[4].Value = fabrica.NombrePais;
                    break;
                case ClienteListDto cliente:
                    r.Cells[0].Value=cliente.Documento;
                    r.Cells[1].Value = $"{cliente.Apellido} {cliente.Nombres}";
                    break;
                default:
                    break;
            }

            r.Tag= obj;
        }

        public static void AgregarFila(DataGridViewRow r, 
            DataGridView grid)
        {
            grid.Rows.Add(r);
        }
        public static void QuitarFila(DataGridViewRow r, 
            DataGridView grid)
        {
            grid.Rows.Remove(r);
        }
    }
}
