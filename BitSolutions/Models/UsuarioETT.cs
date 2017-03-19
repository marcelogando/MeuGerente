using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitSolutions.Models
{
    public class UsuarioETT
    {
        private String _nome;
        private String _sobrenome;
        private String _email;
        private String _estado;
        private String _genero;
        private String _idade;

        public string Nome
        {
            get
            {
                return _nome;
            }

            set
            {
                _nome = value;
            }
        }

        public string Sobrenome
        {
            get
            {
                return _sobrenome;
            }

            set
            {
                _sobrenome = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
            }
        }

        public string Estado
        {
            get
            {
                return _estado;
            }

            set
            {
                _estado = value;
            }
        }

        public string Genero
        {
            get
            {
                return _genero;
            }

            set
            {
                _genero = value;
            }
        }

        public string Idade
        {
            get
            {
                return _idade;
            }

            set
            {
                _idade = value;
            }
        }
    }
}