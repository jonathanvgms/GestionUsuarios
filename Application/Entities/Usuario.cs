namespace Application.Entities;
public abstract class Usuario
{
    public string Nombre { get; set; }
    public string Contraseña { get; set; }
    public bool Habilitado { get; set; }
    public List<Rol> RolesAsignados { get; protected set; }
    public Usuario(string nombre, string contraseña)
    {
        Nombre = nombre;
        Contraseña = contraseña;
        Habilitado = false;
        RolesAsignados = new List<Rol>();
    }
}