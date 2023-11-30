using ExpressDelivery.Models;
using ExpressDelivery.Repository;
using System;
using System.Collections.Generic;

namespace ExpressDelivery.Controllers
{
    internal class ClientController
    {
        private readonly ClientRepository _clientRepository = new ClientRepository();

        public string MessageError = "";

        public List<Client> LoadAll()
        {
            var resp = _clientRepository.LoadAll().Result;
            MessageError = _clientRepository.Message;
            return resp;
        }

        public List<Client> LoadByName(string name)
        {
            var resp = _clientRepository.LoadByName(name).Result;
            MessageError = _clientRepository.Message;
            return resp;
        }

        public List<Client> LoadById(string id)
        {
            var resp = _clientRepository.LoadById(id).Result;
            MessageError = _clientRepository.Message;
            return resp;
        }

        public Client LoadByPhone(string phone)
        {
            var resp = _clientRepository.LoadByPhone(phone).Result;
            MessageError = _clientRepository.Message;
            return resp;
        }

        public Client Save(Client client, string type)
        {
            if (client.Nome == null || client.Endereco == null || client.CEP == null ||
                client.Bairro == null || client.Telefone == null)
            {
                MessageError = @"Verique os campos obrigatórios";
                return null;
            }

            if (client.Nome.Equals("") || client.Endereco.Equals("") || client.Numero.ToString() == "" ||
                client.CEP.Equals("") || client.Bairro.Equals("") || client.Telefone.Equals(""))
            {
                MessageError = @"Verique os campos obrigatórios";
                return null;
            }

            Client clientTemp;
            if (type.Equals("new"))
                clientTemp = _clientRepository.Create(client).Result;
            else
                clientTemp = _clientRepository.Update(client).Result;

            MessageError = _clientRepository.Message;
            return clientTemp;
        }
    }
}