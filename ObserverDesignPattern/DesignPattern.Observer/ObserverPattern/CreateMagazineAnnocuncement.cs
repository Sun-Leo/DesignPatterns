using DesignPattern.Observer.DAL;
using DesignPattern.Observer.Entity;
using System;

namespace DesignPattern.Observer.ObserverPattern
{
    public class CreateMagazineAnnocuncement : IObserver
    {
        private readonly IServiceProvider _serviceProvider;
        Context context = new Context();

        public CreateMagazineAnnocuncement(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void CreateNewUser(AppUser user)
        {
            context.UserProcesses.Add(new UserProcess
            {
                NameSurname= user.Name + " " + user.Surname,
                Magazine="Bilim Dergisi",
                Content="Bilim Dergimiz 1 Ağustosta evinize ulaşacaktır."
            });
            context.SaveChanges();
        }
    }
}
