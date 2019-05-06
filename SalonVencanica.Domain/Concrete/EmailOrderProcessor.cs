using SalonVencanica.Domain.Abstract;
using SalonVencanica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SalonVencanica.Domain.Concrete
{
    //ova klasa je konkretna implementacija abstraktnog Procesora Narudzbenice
    //upotrebljena je preko svog interfejsa u kontroleru 'CartController'
    public class EmailOrderProcessor : IOrderProcessor
    {
        //privatna globalna variabla sa email postavkama
        //koristi se samo u ovoj klasi
        EmailSettings emailSettings;

        //konstruktor sa inicializacijom globalne variable
        //poziva se pri samom kreiranju instance ove klase
        public EmailOrderProcessor(EmailSettings settings)
        {
            emailSettings = settings;
        }

        //ova funkcija procesuira narudzbenicu na osnovu sadrzaja korpe i korisnickih podataka za slaznje narucene robe
        //poziva se u klasi 'CartController'
        public void ProcessOrder(Cart cart, ShippingDetails shippingInfo)
        {
            //instanciranje objekta SmtpClient
            using (var smtpClient = new SmtpClient())
            {
                //dodela vrednosti poljima SmtpClient-a iz EmailSettings objekta
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;

                //dodela kredencijala za google app na osnovu username i sifre
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(emailSettings.Username, emailSettings.Password);

                //string-builder objekat koji prikazuje korisniku podatke od uspesne narudzbenice
                StringBuilder body = new StringBuilder()
                    .AppendLine("Nova narudzbina je uspesno poslata")
                    .AppendLine("---")
                    .AppendLine("Artikli:");

                //ovde dodjaemo ukupnu vrednost i broj artikala u korpi u specificnom formatu
                foreach (var line in cart.Lines)
                {
                    var subtotal = line.Product.Price * line.Quantity;
                    body.AppendFormat("{0}x{1})(ukupno:{2:c})\n", line.Quantity, line.Product.Name, subtotal);
                }

                //ovde dodajemo podatke o adresi za slanje kao sto su ime, ulica, grad, drzava, postanski broj i opciju za poklon pakovanje
                body.AppendFormat("Ukupna vrednost porudzbine:{0:c}", cart.ComputeTotalValue())
                    .AppendLine("---")
                    .AppendLine("Poslati na:")
                    .AppendLine(shippingInfo.Name)
                    .AppendLine(shippingInfo.Linija1)
                    .AppendLine(shippingInfo.Linija2 ?? "")
                    .AppendLine(shippingInfo.Linija3 ?? "")
                    .AppendLine(shippingInfo.Grad)
                    .AppendLine(shippingInfo.Okrug ?? "")
                    .AppendLine(shippingInfo.Drzava)
                    .AppendLine(shippingInfo.PTT)
                    .AppendLine(shippingInfo.Eposta)
                    .AppendLine("---")
                    .AppendFormat("Ukrasno pakovanje: {0}", shippingInfo.GiftWrap ? "Da" : "Ne");

                //ovde instanciramo objekat email poruke i prosledjujemo mu upravo kreirani tekstualni objekat, email adresu sa koje se salje i adresu na koju se salje
                MailMessage mailMesage = new MailMessage(emailSettings.MailFromAddress, shippingInfo.Eposta, "Nova porudzbina je poslata!", body.ToString());

                //ovde putem smtp klijenta saljemo upravo kreirani email objekat
                smtpClient.Send(mailMesage);
            }
        }
    }
}
