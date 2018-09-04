﻿using RegistroEjemplo.DAL;
using RegistroEjemplo.Entidades;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RegistroEjemplo.DAL.Scripts;

namespace RegistroEjemplo.BLL
{
    public class PersonaBLL
    {
        public static bool Guardar(Personas persona)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try {
                if (contexto.Personas.Add(persona)!=null)
                    {
                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception) {
                throw;
            }
            return paso;
        }

        public static bool Modificar(Personas persona)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(persona).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }


    }
}
   