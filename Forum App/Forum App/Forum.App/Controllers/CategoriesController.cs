using System.Linq;
using Forum.App.Services;
using Forum.App.Views;

namespace Forum.App.Controllers
{
    using System;

    using Contracts;
    using UserInterface.Contracts;

    public class CategoriesController : IController, IPaginationController
    {
        public CategoriesController()
        {
            this.CurrentPage = 0;
            this.LoadCategories();
        }

        private enum Command
        {
            Back = 0,
            ViewPost = 1,
            PreviousPage = 11,
            NextPage = 12
        }

        public const int PAGE_OFFSET = 10;
        private const int COMMAND_COUNT = PAGE_OFFSET + 3;

        public int CurrentPage { get; set; }

        private string[] AllCategoryNames { get; set; }

        private string[] CurrentPageCategories { get; set; }

        private int LastPage
        {
            get { return this.AllCategoryNames.Length / (PAGE_OFFSET + 1); }
        }

        private bool IsFirstPage
        {
            get { return this.CurrentPage == 0; }
        }

        private bool IsLastPage
        {
            get { return this.CurrentPage == this.LastPage; }
        }

        private void ChangePage(bool forward = true)
        {
            this.CurrentPage += forward ? 1 : -1;
        }

        private void LoadCategories()
        {
            this.AllCategoryNames = PostService.GetAllCategoryNames();

            this.CurrentPageCategories = this.AllCategoryNames
                .Skip(this.CurrentPage * PAGE_OFFSET)
                .Take(PAGE_OFFSET)
                .ToArray();
        }

        public IView GetView(string userName)
        {
            LoadCategories();
            return new CategoriesView(this.CurrentPageCategories, this.IsFirstPage, this.IsLastPage);
        }

        public MenuState ExecuteCommand(int index)
        {
            if (index > 1 && index < 11)
            {
                index = 1;
            }

            switch ((Command)index)
            {
                case Command.Back:
                    return MenuState.Back;
                case Command.ViewPost:
                    return MenuState.OpenCategory;
                case Command.PreviousPage:
                    this.ChangePage(false);
                    return MenuState.Rerender;
                case Command.NextPage:
                    this.ChangePage();
                    return MenuState.Rerender;
            }

            throw new InvalidCommandException();
        }
    }
}
