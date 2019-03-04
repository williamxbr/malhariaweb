using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using MalhariaWeb.Models;

namespace MalhariaWeb.Roles
{
    public class ConfigRoles : RoleProvider
    {
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }



        public override string[] GetRolesForUser(string username)
        {
            ContextDB db = new ContextDB();

            USUARIO usuario = db.USUARIO.FirstOrDefault(u => u.NOME_USUARIO == username);

            if (usuario == null)
                return new string[] { };

            List<string> permissoes = new List<string>();

            switch (usuario.TIPO_USUARIO)
            {
                case eTipoUsuario.Administrador :
                    permissoes.Add("Administrador");
                    break;
                case eTipoUsuario.Gerencia :
                    permissoes.Add("Gerencia");
                    break;
                case eTipoUsuario.PCP :
                    permissoes.Add("PCP");
                    break;
                case eTipoUsuario.Operador :
                    permissoes.Add("Operador");
                    break;
            }

            return permissoes.ToArray();

        }

    }
}