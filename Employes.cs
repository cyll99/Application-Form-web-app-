using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Christ- Yan Love LAROSE
/// </summary>
namespace Etudiant
{
    class Promotion
    {
        string _departement, _poste, _dateDebut, _dateFin;
        public Promotion(string departement, string poste, string dateDebut, string dateFin)
        { 
            this.DateDebut = dateDebut;
            this.DateFin = dateFin;
            this._poste = poste;
            this._departement = departement;
        }

        public String Departement
        {
            get => _departement;
            set => _departement = Utilities.capitalize(value);

        }

        public String Poste
        {
            get => _poste;
            set => _poste = Utilities.capitalize(value);

        }

        public String DateDebut
        {
            get => _dateDebut; set => _dateDebut = value;
        }

        public String DateFin
        {
            get => _dateFin; set => _dateFin = value;
        }

    }

    class ParcoursProf
    {
        String _detention, _discipline, _date;

        public ParcoursProf(String detention, string discipline, String date)
        {
            this._detention = detention;
            this._discipline = discipline;
            this._date = date;
        }
        public String Detention
        {
            get => _detention;
            set => _detention = Utilities.capitalize(value);

        }
        public String Discipline
        {
            get => _discipline;
            set => _discipline = Utilities.capitalize(value);

        }
        public String Date
        {
            get => _date; set => _date = value;
        }
    }
    class Employes
    {
        DateTime now = DateTime.Now;

        String  _nom, _prenom1, _prenom2, _sexe,  _adresseRue, _email, _dateNaissance, _dateEmbauche, _telephone, _nomAContacter, _prenomAContacter, _lienParente, _TelPersonne;
        List<Promotion> _lPromotions;
        List<ParcoursProf> _lParcoursProf;
        // Constructeur avec toutes les proprietes
        public Employes(string nom, string prenom1, string prenom2, string sexe,string email, string adresseRue, string dateNaissance, string dateEmbauche, string telephone, 
                        string nomAContacter, string prenomAContacter, string lienParente, string telPersonne)
        {   
            this.Nom = nom;
            this.Prenom1 = prenom1;
            this.Prenom2 = prenom2;
            this.Sexe = sexe;
            this.DateNaissance = dateNaissance;
            this.DateEmbauche = dateEmbauche;
            this.NomAContacter = nomAContacter;
            this.PrenomAContacter = prenomAContacter;
            this.LienParente = lienParente;
            this.Telephone = telephone;
            this.TelPersonne = telPersonne;
            this.AdresseRue = adresseRue;
            this._email = email;
        }

        public Employes(List<Promotion> lPromotions)
        {
            
            _lPromotions = lPromotions;
          
        }

        public Employes(List<ParcoursProf> lParcoursProf) 
        {
            _lParcoursProf = lParcoursProf;


        }



        // getters and setters for the employees
        public String Nom
        {
            get => _nom;
            set => _nom = Utilities.capitalize(value);

        }


        public String Prenom1
        {
            get => _prenom1;
            set
            {
                if (value.Length != 0)
                    _prenom1 = Utilities.capitalize(value);
                else
                    _prenom1 = "";
            }

        }

        public String Prenom2
        {
            get => _prenom2;
            set
            {
                if (value.Length != 0)
                    _prenom2 = Utilities.capitalize(value);
                else
                    _prenom2 = "";
            }

        }

    

        public String AdresseRue
        {
            get => _adresseRue;
            set => _adresseRue = Utilities.capitalize(value);

        }

        public String Sexe
        {
            get => _sexe;
            set => _sexe = value;

        }

        public String Telephone
        {
            get => _telephone;
            set => _telephone = Utilities.capitalize(value);

        }

        public String DateNaissance
        {
            get => _dateNaissance;
            set => _dateNaissance = value;

        }

        public String DateEmbauche
        {
            get => _dateEmbauche; set => _dateEmbauche = value; 

        }


        //getters and setters for contact

        public String NomAContacter
        {
            get => _nomAContacter;
            set => _nomAContacter = Utilities.capitalize(value);

        }

        public String PrenomAContacter
        {
            get => _prenomAContacter;
            set => _prenomAContacter = Utilities.capitalize(value);

        }

        public String Email
        {
            get => _email;
            set => _email = value;

        }

        public String LienParente
        {
            get => _lienParente; set => _lienParente = value;

        }

        public String TelPersonne
        {
            get => _TelPersonne; set => _TelPersonne = value;

        }
      






    }

}