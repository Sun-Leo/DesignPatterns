using DesignPattern.Observer.DAL;
using DesignPattern.Observer.Entity;
using System;

namespace DesignPattern.Observer.ObserverPattern
{
    public class CreateWelcomeMessage : IObserver
    {
        private readonly IServiceProvider _serviceProvider;
        Context context = new Context();

        public CreateWelcomeMessage(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void CreateNewUser(AppUser user)
        {
            context.WelcomeMessages.Add(new WelcomeMessage
            {
                NameSurname=user.Name + " " + user.Surname,
                Content="Dergi Bültenimize Kayıt Olduğunuz İçin Teşekkür Ederiz."
            });
            context.SaveChanges();
        }
    }
}
