using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaietransPubSoft.Classes
{
    class Constantes
    {
        public static string AppName = "TAP&LEAVE_Soft";
        public static string ip= "192.168.137.1:8081";
        public static string cheminPhp= "http://$ip/transpaie_php/";
        public static string cheminPhoto= "http://$ip/transpaie_php/images/";
        public static String[] PassagerDBChamps = new String[]
        {
            "code",
            "noms",
            "adresse",
            "contact",
            "mail",
            "typepieceid",
            "numeropieceid",           
            "username",
            "usersession",
            "qrCode",
            "photo"
        };
       public static String[] ProprietaireDBChamps = new String[]
       {
            "code",
            "noms",
            "adresse",
            "contact",
            "mail",
            "typepieceid",
            "numeropieceid",
            "username",
            "usersession"           
       };
       public static String[] ChauffeurDBChamps = new String[]
       {
            "code",
            "noms",
            "adresse",
            "contact",
            "mail",
            "typepieceid",
            "numeropieceid",
            "username",
            "usersession"
       };
       public static String[] EnginDBChamps = new String[]
       {
           "code",
           "marque",
           "couleur",
           "numeroplaque",
           "refProprietaire",
           "refCategorie",
           "nombreplace",
           "compte",
           "usersession"            
       };
       public static String[] AffectChauffeurDBChamps = new String[]
       {
           "code",
           "refEngin",
           "refChauffeur",
           "usersession"
       };
       public static String[] ChargeCompteDBChamps = new String[]
       {
           "code",
           "refClient",
           "montant",
           "usersession"
       };
      public static String[] PaiementBusrDBChamps = new String[]
       {
           "code",
           "montant",
           "refClient",
           "refAffectChauffeur",          
           "usersession"
       };
      public static String[] RetraitBusDBChamps = new String[]
       {
           "code",
           "refAffectChauffeur",
           "montant",
           "libelle",
           "usersession"           
       };
      public static String[] VirementDBChamps = new String[]
       {
           "code",
           "montant",
           "refAffectChauffeur",
           "refEngin",
           "libelle",
           "usersession"           
       };
      public static String[] AgentDBChamps = new String[]
       {
           "code",
           "noms",
           "adresse",
           "contact",
           "mail",
           "sexe",
           "datenaissance",
           "lieunaissance",
           "etatcivil",
           "niveauetude",
           "fonction",
           "image",
           "qrCode",
           "username",
           "password",
           "usersession"           
       };

      public static String[] ParametrePrixDBChamps = new String[]
       {
           "code",
           "prix",
           "usersession"
       };
       public static String[] AlerteDBChamps = new String[]
       {
           "code",
           "message",
           "usersession"
       };
      public static String[] EntrepriseDBChamps = new String[]
       {
            "code",
            "nom",
            "adresse",
            "telephone",
            "mail",
            "photo",
            "siteweb",
            "boitepostal",
            "rccm",
            "idNat",
            "NumImpot"
       };

        public static String[] UtilisateurDBChamps = new String[]
        {
            "code",
            "nom",
            "pass",
            "niveau"
        };

    }
}
