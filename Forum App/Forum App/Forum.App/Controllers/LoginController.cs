using System;
using Forum.App.Services;
using Forum.App.UserInterface;
using Forum.App.Views;

namespace Forum.App.Controllers
{
    using Contracts;
    using UserInterface.Contracts;

    public class LogInController : IController, IReadUserInfoController
    {
        private enum Command
        {
            ReadUsername,
            ReadPassword,
            LogIn,
            Back
        }

        public string Username { get; private set; }
        private string Password { get; set; }
        private bool Error { get; set; }

        public LogInController()
        {
            this.ResetLogIn();
        }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.ReadUsername:
                    this.ReadUsername();
                    return MenuState.Login;
                case Command.ReadPassword:
                    this.ReadPassword();
                    return MenuState.Login;
                case Command.LogIn:
                    bool loggedIn = UserService.TryLogInUser(this.Username, this.Password);
                    if (loggedIn)
                    {
                        return MenuState.SuccessfulLogIn;
                    }

                    this.Error = true;
                    return MenuState.Error;
                case Command.Back:
                    this.ResetLogIn();
                    return MenuState.Back;
            }

            throw new InvalidOperationException();
        }

        public IView GetView(string userName)
        {
            return new LogInView(this.Error, this.Username, this.Password.Length);
        }

        public void ReadPassword()
        {
            this.Password = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }

        public void ReadUsername()
        {
            this.Username = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }

        private void ResetLogIn()
        {
            this.Error = false;
            this.Username = string.Empty;
            this.Password = string.Empty;
        }
    }
}
