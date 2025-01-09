﻿
namespace PLA.Api.InterfaceAdapters.Repositories;

public class UsuariosRepocitory : IUsuariosRepocitory
{
    private readonly PasteleriaDbContext _db;
    public UsuariosRepocitory(PasteleriaDbContext dbContext) => (_db) = (dbContext);

    public async ValueTask<Usuario> Add(Usuario usuario)
    {
        usuario.Estatus = true;
        _db.Usuarios.Add(usuario);
        await _db.SaveChangesAsync();
        return usuario;
    }

    public async ValueTask<string> GetPassword(long idUsuario) =>
        await _db.Usuarios.Where(f => f.Id == idUsuario).Select(s => s.Password).FirstOrDefaultAsync();

    public async ValueTask<Usuario> GetUsuarioById(int id) =>
        await _db.Usuarios.FirstOrDefaultAsync(f => f.Id == id);

    public async ValueTask<Usuario> GetUsuarioByTelefono(string telefono) =>
        await _db.Usuarios.FirstOrDefaultAsync(f => f.Telefono == telefono);

    public async ValueTask<Usuario> Update(Usuario usuario)
    {
        var usuarioTmp = await _db.Usuarios.FirstOrDefaultAsync(f => f.Id == usuario.Id);
        if (usuarioTmp.IsNull())
            return null;

        usuarioTmp.Nombre = usuario.Nombre;
        usuarioTmp.ApellidoPaterno = usuario.ApellidoPaterno;
        usuarioTmp.ApellidoMaterno = usuario.ApellidoMaterno;
        usuarioTmp.FechaNacimiento = usuario.FechaNacimiento;
        usuarioTmp.Telefono = usuario.Telefono;
        usuarioTmp.Password = usuario.Password;
        await _db.SaveChangesAsync();
        return usuarioTmp;
    }

    public async ValueTask<bool> UpdatePassword(long idUsuario, PasswordDTO password)
    {
        var usuarioTmp = await _db.Usuarios.FirstOrDefaultAsync(f => f.Id == idUsuario);
        if (usuarioTmp.IsNull())
            return false;
        usuarioTmp.Password = password.NewPassword;
        await _db.SaveChangesAsync();
        return true;
    }
}
