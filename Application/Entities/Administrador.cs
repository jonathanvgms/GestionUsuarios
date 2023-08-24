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

    public void CrearRol(Rol rol)
    {
        if (!RolesExistentes.Any(x => x.Nombre == rol.Nombre))
            RolesExistentes.Add(rol);
        else
            throw new Exception("Rol existente");
    }

    public void EliminarRol(Rol rol)
    {
        RolesExistentes.RemoveAll(x => x.Nombre == rol.Nombre);

        foreach (Usuario usuario in UsuariosExistentes)
            usuario.RolesAsignados.RemoveAll(x => x.Nombre == rol.Nombre);
    }

    public void CrearUsuario(Usuario usuario)
    {
        if (!UsuariosExistentes.Any(x => x.Nombre == usuario.Nombre))
            UsuariosExistentes.Add(new Operacional(usuario.Nombre, usuario.Contraseña));
        else
            throw new Exception("Usuario existente");
    }

    public void HabilitarUsuario(Usuario usuario) => usuario.Habilitado = true;

    public void DesabilitarUsuario(Usuario usuario)
    {
        Usuario usuarioExistente = UsuariosExistentes.First(x => x.Nombre == usuario.Nombre);
        usuarioExistente.Habilitado = false;
    }

    public void AsignarRol(Usuario usuario, Rol rol) => usuario.RolesAsignados.Add(rol);

    public void DesasignarRol(Usuario usuario, Rol rol) => usuario.RolesAsignados.Remove(rol);

    public bool IniciarSesion(Usuario usuario)
    {
        if (UsuariosExistentes.Any(x => x.Nombre == usuario.Nombre && x.Contraseña == usuario.Contraseña && x.Habilitado == true))
            return true;
        else
            return false;
    }
}