namespace Application.Entities;
public class Administrador : Usuario
{
    public List<Rol> RolesExistentes { get; set; }
    public List<Usuario> UsuariosExistentes { get; protected set; }

    public Administrador(string nombre, string contraseña) : base(nombre, contraseña)
    {
        RolesExistentes = new List<Rol>();
        UsuariosExistentes = new List<Usuario>();
    }

    public void CrearRol(string nombre)
    {
        if (!RolesExistentes.Any(x => x.Nombre == nombre))
            RolesExistentes.Add(new Rol(nombre));
        else
            throw new Exception("Rol existente");
    }

    public void EliminarRol(string nombre)
    {
        RolesExistentes.RemoveAll(x => x.Nombre == nombre);

        foreach (Usuario usuario in UsuariosExistentes)
            usuario.RolesAsignados.RemoveAll(x => x.Nombre == nombre);
    }

    public void CrearUsuario(string nombre, string contraseña)
    {
        if (!UsuariosExistentes.Any(x => x.Nombre == nombre))
            UsuariosExistentes.Add(new Operacional(nombre, contraseña));
        else
            throw new Exception("Usuario existente");
    }

    public void HabilitarUsuario(string nombre) => Habilitado = true;

    public void DesabilitarUsuario(string nombre)
    {
        Usuario usuario = UsuariosExistentes.First(x => x.Nombre == nombre);
        usuario.Habilitado = false;
    }

    public void AsignarRol(Usuario usuario, Rol rol) => usuario.RolesAsignados.Add(rol);

    public void DesasignarRol(Usuario usuario, Rol rol) => usuario.RolesAsignados.Remove(rol);

    public bool IniciarSesion(string usuario, string contraseña)
    {
        if (UsuariosExistentes.Any(x => x.Nombre == usuario && x.Contraseña == contraseña && x.Habilitado == true))
            return true;
        else
            return false;
    }
}