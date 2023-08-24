namespace Application.Entities;
public class Rol
{
    public string Nombre { get; set; }
    public bool Habilitado { get; set; }
    public List<Usuario> UsuariosAsignados { get; private set; }

    public Rol(string nombre)
    {
        Nombre = nombre;
        UsuariosAsignados = new List<Usuario>();
    }

    public void Habilitar() => Habilitado = true;
    public void Desabilitar() => Habilitado = false;
}