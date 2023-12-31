﻿using DesignPattern.Observer.DAL;
using DesignPattern.Observer.Entity;
using Microsoft.AspNetCore.Hosting.Server;
using System;

namespace DesignPattern.Observer.ObserverPattern
{
    public class CreateDiscountCode : IObserver
    {
        private readonly IServiceProvider _serviceProvider;
        Context context= new Context();

        public CreateDiscountCode(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void CreateNewUser(AppUser user)
        {
            context.Discounts.Add(new Discount
            {
                DiscountCode="DERGİAĞUSTOS",
                DiscountAmount=45,
                DiscountStatus=true
            });
            context.SaveChanges();
        }
    }
}
