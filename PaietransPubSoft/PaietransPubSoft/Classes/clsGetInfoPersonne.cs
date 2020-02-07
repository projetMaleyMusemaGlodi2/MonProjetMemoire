using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaietransPubSoft.Classes
{
    class clsGetInfoPersonne
    {
        public static clsGetInfoPersonne _instance = null;

        int id;
        string nom;
        string nomTable;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                nom = value;
            }
        }

        public string NomTable
        {
            get
            {
                return nomTable;
            }

            set
            {
                nomTable = value;
            }
        }

        public static clsGetInfoPersonne GetInstance()
        {
            if (_instance == null)
                _instance = new clsGetInfoPersonne();
            return _instance;
        }
    }
}
