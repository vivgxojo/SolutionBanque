using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using SolutionBanque.Models;

namespace SolutionBanque.Models
{
    //TODO : revenir sur la validation JQuery qui n'Est pas déclenchée IClientModelValidator
    //TODO : revenir sur la validation du DateTime pour choisir le format et avoir les messages en français
    public class CompteBanquaire : IValidatableObject
    {
        List<ValidationResult> _errors = new List<ValidationResult>();

        [Required (ErrorMessage = "Ce champ est obligatoire")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "Ce champ n'accepte que des lettres et doit commencer par une majuscule.")]
        public string Nom { get; set; }

        [Required (ErrorMessage = "Ce champ est obligatoire")]
        [Display(Name = "Prénom")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "Ce champ n'accepte que des lettres et doit commencer par une majuscule.")]
        public string Prenom { get; set; }

        [Required (ErrorMessage = "Ce champ est obligatoire")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Date de naissance")]
        public DateTime? DateNaissance { get; set; } //? Empêche le message en anglais

        [Required (ErrorMessage = "Ce champ est obligatoire")]
        [RegularExpression(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}", ErrorMessage = "Doit avoir le format 333-333-3333")]
        [Display(Name = "Téléphone")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [Range(0, int.MaxValue)]
        [Display(Name = "Numéro de l'adresse")]
        public int NoAdresse { get; set; }

        [Required (ErrorMessage = "Ce champ est obligatoire")]
        public string Rue { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [Display(Name = "Numéro d'appartement")]
        public string App { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public string Province { get; set; }


        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [RegularExpression(@"^[A-Z][0-9][A-Z] ?[0-9][A-Z][0-9]$", ErrorMessage = "Doit avoir le format H0H 0H0")]
        [Display(Name = "Code Postal")]
        public string CodePostal { get; set; }


        [Required (ErrorMessage = "Ce champ est obligatoire")]
        public string Employeur  { get; set; }

        private decimal? _salaire;
        [Required (ErrorMessage = "Ce champ est obligatoire")]
        //[DisplayFormat(DataFormatString = "{0:C2}")]
        public string Salaire {
            get { return string.Format("C2", _salaire); }
            set {
                try
                {
                    decimal s = decimal.Parse(value);
                    if (s < 0)
                    {
                        _errors.Add(new ValidationResult(
                        "Le salaire ne peut pas être négatif.",
                        new[] { nameof(Salaire) }));
                    }
                    else _salaire = s;
                }
                catch {
                    _errors.Add(new ValidationResult(
                        "Le salaire doit être un nombre valide.", 
                        new[] { nameof(Salaire) }));
                }
            }
        }

        [Required (ErrorMessage = "Ce champ est obligatoire")]
        [Display(Name = "Dépôt")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DepotValide(ErrorMessage = "Erreur du serveur : Le dépôt doit être positif.")]
        public decimal? Depot { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return _errors;
        }
    }
}