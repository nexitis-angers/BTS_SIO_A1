using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyHome.Domain;
using MyHome.Infrastructure;
using MyHome.Web.Models.Account;

namespace MyHome.Web.Controllers
{
    public class AccountController : Controller
    {
        #region Private attributes
        /// <summary>
        /// Le contexte de la base de données
        /// le readonly protège toute modification de l'instance en dehors du constructeur
        /// </summary>
        private readonly MyHomeDbContext dbContext = null;
        #endregion

        public AccountController(MyHomeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View(new RegisterViewModel());
        }

        public IActionResult Register(RegisterViewModel vm)
        {
            List<string> errors = new List<string>();


            if(ModelState.IsValid)
            {
                // Créer un utilisateur depuis le view model
                var newUser = new User()
                {
                    Email = vm.Email,
                    FirstName = vm.FirstName,
                    LastName = vm.LastName,
                    Password = vm.Password
                };

                // Ajout de l'objet au contexte de données (tracking)
                this.dbContext.Add(newUser);
                // Application des modifications en base de données
                this.dbContext.SaveChanges();
            }
            else
            {
                // La saisie utilisateur est invalide, on génère une liste d'erreurs
                foreach (var value in ModelState.Values)
                {
                    if (value.Errors.Count > 0)
                    {
                        // Solution 1
                        //foreach (var error in value.Errors)
                        //{
                        //    errors.Add(error.ErrorMessage);
                        //}

                        // Solution 2, avec une expression lambda
                        errors.AddRange( // Ajouter plusieurs éléments en une fois
                            value.Errors.Select( // Sélection d'une propriété de l'objet
                                error => error.ErrorMessage));
                    }
                }

                // Création d'une chaine de caractères avec toutes les erreurs
                ViewData["errors"] = string.Join("<br />", errors);
            }

            #region Méthode "novice"
            //if(string.IsNullOrEmpty(vm.FirstName) || vm.FirstName.Length > 50)
            //{
            //    errors.Add("Le prénom est obligatoire, sa longueur ne doit pas dépasser 50 caractères");
            //}

            //if (string.IsNullOrEmpty(vm.LastName) || vm.LastName.Length > 50)
            //{
            //    errors.Add("Le nom de famille est obligatoire, sa longueur ne doit pas dépasser 50 caractères");
            //}

            //if (string.IsNullOrEmpty(vm.Email) || vm.Email.Length > 125)
            //{
            //    errors.Add("L'email est obligatoire, sa longueur ne doit pas dépasser 50 caractères");
            //}

            //if (string.IsNullOrEmpty(vm.Password) || vm.Password.Length > 50)
            //{
            //    errors.Add("Le mot de passe est obligatoire, sa longueur ne doit pas dépasser 50 caractères");
            //}
            
            //if(errors.Count == 0)
            //{
            //    // TODO : implémenter la sauvegarder
            //}
            //else
            //{
            //    // Affichage des erreurs
            //    ViewData["errors"] = string.Join(',', errors);
            //}
            #endregion

            return View();
        }

    }
}