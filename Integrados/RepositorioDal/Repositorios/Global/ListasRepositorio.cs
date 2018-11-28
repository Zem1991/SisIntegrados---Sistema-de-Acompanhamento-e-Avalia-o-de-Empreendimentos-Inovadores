using System.Collections.Generic;
using System.Web.Mvc;

namespace Repositorio.DAL.Repositorios
{
    public class ListasRepositorio
    {
        public static List<SelectListItem> AtivoInativo()
        {

            List<SelectListItem> AtivoInativo = new List<SelectListItem>();
            AtivoInativo.AddRange(new[]{
                new SelectListItem() { Text = "Ativo", Value = "A" },
                new SelectListItem() { Text = "Inativo", Value = "I" },
            });

            return AtivoInativo;
        }

        public static string AtivoInativo(string status)
        {
            string retorno = "";

            if (status.Equals("A"))
            {
                retorno = "Ativo";
            }
            else
            {
                retorno = "Inativo";
            }
            return retorno;
        }
    }
}