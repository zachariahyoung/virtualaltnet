using System;
using MvcContrib.TestHelper;
using NUnit.Framework;
using Rhino.Mocks;
using SharpArch.Core.PersistenceSupport;
using SharpArch.Testing;
using SharpArch.Testing.NUnit;
using System.Collections.Generic;
using System.Web.Mvc;
using van.Core;
using van.Web.Controllers;
 

namespace Tests.van.Web.Controllers
{
    [TestFixture]
    public class CategoriesControllerTests
    {
        [SetUp]
        public void SetUp() {
            ServiceLocatorInitializer.Init();
            controller = new CategoriesController(CreateMockCategoryRepository());
        }

        /// <summary>
        /// Add a couple of objects to the list within CreateCategories and change the 
        /// "ShouldEqual(0)" within this test to the respective number.
        /// </summary>
        [Test]
        public void CanListCategories() {
            ViewResult result = controller.Index().AssertViewRendered();

            result.ViewData.Model.ShouldNotBeNull();
            (result.ViewData.Model as List<Category>).Count.ShouldEqual(0);
        }

        [Test]
        public void CanShowCategory() {
            ViewResult result = controller.Show(1).AssertViewRendered();

			result.ViewData.ShouldNotBeNull();
			
            (result.ViewData.Model as Category).Id.ShouldEqual(1);
        }

        [Test]
        public void CanInitCategoryCreation() {
            ViewResult result = controller.Create().AssertViewRendered();
            
            result.ViewData.Model.ShouldNotBeNull();
            result.ViewData.Model.ShouldBeOfType(typeof(CategoriesController.CategoryFormViewModel));
            (result.ViewData.Model as CategoriesController.CategoryFormViewModel).Category.ShouldBeNull();
        }

        [Test]
        public void CanEnsureCategoryCreationIsValid() {
            Category categoryFromForm = new Category();
            ViewResult result = controller.Create(categoryFromForm).AssertViewRendered();

            result.ViewData.Model.ShouldNotBeNull();
            result.ViewData.Model.ShouldBeOfType(typeof(CategoriesController.CategoryFormViewModel));
        }

        [Test]
        public void CanCreateCategory() {
            Category categoryFromForm = CreateTransientCategory();
            RedirectToRouteResult redirectResult = controller.Create(categoryFromForm)
                .AssertActionRedirect().ToAction("Index");
            controller.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()].ToString()
				.ShouldContain("was successfully created");
        }

        [Test]
        public void CanUpdateCategory() {
            Category categoryFromForm = CreateTransientCategory();
            EntityIdSetter.SetIdOf<int>(categoryFromForm, 1);
            RedirectToRouteResult redirectResult = controller.Edit(categoryFromForm)
                .AssertActionRedirect().ToAction("Index");
            controller.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()].ToString()
				.ShouldContain("was successfully updated");
        }

        [Test]
        public void CanInitCategoryEdit() {
            ViewResult result = controller.Edit(1).AssertViewRendered();

			result.ViewData.Model.ShouldNotBeNull();
            result.ViewData.Model.ShouldBeOfType(typeof(CategoriesController.CategoryFormViewModel));
            (result.ViewData.Model as CategoriesController.CategoryFormViewModel).Category.Id.ShouldEqual(1);
        }

        [Test]
        public void CanDeleteCategory() {
            RedirectToRouteResult redirectResult = controller.Delete(1)
                .AssertActionRedirect().ToAction("Index");
            
            controller.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()].ToString()
				.ShouldContain("was successfully deleted");
        }

		#region Create Mock Category Repository

        private IRepository<Category> CreateMockCategoryRepository() {

            IRepository<Category> mockedRepository = MockRepository.GenerateMock<IRepository<Category>>();
            mockedRepository.Expect(mr => mr.GetAll()).Return(CreateCategories());
            mockedRepository.Expect(mr => mr.Get(1)).IgnoreArguments().Return(CreateCategory());
            mockedRepository.Expect(mr => mr.SaveOrUpdate(null)).IgnoreArguments().Return(CreateCategory());
            mockedRepository.Expect(mr => mr.Delete(null)).IgnoreArguments();

			IDbContext mockedDbContext = MockRepository.GenerateStub<IDbContext>();
			mockedDbContext.Stub(c => c.CommitChanges());
			mockedRepository.Stub(mr => mr.DbContext).Return(mockedDbContext);
            
            return mockedRepository;
        }

        private Category CreateCategory() {
            Category category = CreateTransientCategory();
            EntityIdSetter.SetIdOf<int>(category, 1);
            return category;
        }

        private List<Category> CreateCategories() {
            List<Category> categories = new List<Category>();

            // Create a number of domain object instances here and add them to the list

            return categories;
        }
        
        #endregion

        /// <summary>
        /// Creates a valid, transient Category; typical of something retrieved back from a form submission
        /// </summary>
        private Category CreateTransientCategory() {
            Category category = new Category() {
				Description = "Dependency Injection"
            };
            
            return category;
        }

        private CategoriesController controller;
    }
}
