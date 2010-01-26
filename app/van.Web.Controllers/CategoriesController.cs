using System.Web.Mvc;
using van.Core;
using SharpArch.Core.PersistenceSupport;
using SharpArch.Core.DomainModel;
using System.Collections.Generic;
using System;
using SharpArch.Web.NHibernate;
using NHibernate.Validator.Engine;
using System.Text;
using SharpArch.Web.CommonValidator;
using SharpArch.Core;

namespace van.Web.Controllers
{
    [HandleError]
    public class CategoriesController : Controller
    {
        public CategoriesController(IRepository<Category> categoryRepository) {
            Check.Require(categoryRepository != null, "categoryRepository may not be null");

            this.categoryRepository = categoryRepository;
        }

        [Transaction]
        public ActionResult Index() {
            IList<Category> categories = categoryRepository.GetAll();
            return View(categories);
        }

        [Transaction]
        public ActionResult Show(int id) {
            Category category = categoryRepository.Get(id);
            return View(category);
        }

        public ActionResult Create() {
            CategoryFormViewModel viewModel = CategoryFormViewModel.CreateCategoryFormViewModel();
            return View(viewModel);
        }

        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Category category) {
            if (ViewData.ModelState.IsValid && category.IsValid()) {
                categoryRepository.SaveOrUpdate(category);

                TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = 
					"The category was successfully created.";
                return RedirectToAction("Index");
            }

            CategoryFormViewModel viewModel = CategoryFormViewModel.CreateCategoryFormViewModel();
            viewModel.Category = category;
            return View(viewModel);
        }

        [Transaction]
        public ActionResult Edit(int id) {
            CategoryFormViewModel viewModel = CategoryFormViewModel.CreateCategoryFormViewModel();
            viewModel.Category = categoryRepository.Get(id);
            return View(viewModel);
        }

        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(Category category) {
            Category categoryToUpdate = categoryRepository.Get(category.Id);
            TransferFormValuesTo(categoryToUpdate, category);

            if (ViewData.ModelState.IsValid && category.IsValid()) {
                TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = 
					"The category was successfully updated.";
                return RedirectToAction("Index");
            }
            else {
                categoryRepository.DbContext.RollbackTransaction();

				CategoryFormViewModel viewModel = CategoryFormViewModel.CreateCategoryFormViewModel();
				viewModel.Category = category;
				return View(viewModel);
            }
        }

        private void TransferFormValuesTo(Category categoryToUpdate, Category categoryFromForm) {
			categoryToUpdate.Description = categoryFromForm.Description;
        }

        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id) {
            string resultMessage = "The category was successfully deleted.";
            Category categoryToDelete = categoryRepository.Get(id);

            if (categoryToDelete != null) {
                categoryRepository.Delete(categoryToDelete);

                try {
                    categoryRepository.DbContext.CommitChanges();
                }
                catch {
                    resultMessage = "A problem was encountered preventing the category from being deleted. " +
						"Another item likely depends on this category.";
                    categoryRepository.DbContext.RollbackTransaction();
                }
            }
            else {
                resultMessage = "The category could not be found for deletion. It may already have been deleted.";
            }

            TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = resultMessage;
            return RedirectToAction("Index");
        }

		/// <summary>
		/// Holds data to be passed to the Category form for creates and edits
		/// </summary>
        public class CategoryFormViewModel
        {
            private CategoryFormViewModel() { }

			/// <summary>
			/// Creation method for creating the view model. Services may be passed to the creation 
			/// method to instantiate items such as lists for drop down boxes.
			/// </summary>
            public static CategoryFormViewModel CreateCategoryFormViewModel() {
                CategoryFormViewModel viewModel = new CategoryFormViewModel();
                
                return viewModel;
            }

            public Category Category { get; internal set; }
        }

        private readonly IRepository<Category> categoryRepository;
    }
}
