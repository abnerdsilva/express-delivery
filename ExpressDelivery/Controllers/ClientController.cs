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
            return _clientRepository.LoadAll();
        }

        public List<Client> LoadByName(string name)
        {
            return _clientRepository.LoadByName(name);
        }

        public List<Client> LoadById(string id)
        {
            return _clientRepository.LoadById(id);
        }

        public Client LoadByPhone(string phone)
        {
            return _clientRepository.LoadByPhone(phone);
        }

        public int LastClientId()
        {
            return _clientRepository.LastClientId();
        }

        public int Save(Client client, string type)
        {
            if (client.Nome == null || client.Endereco == null || client.CEP == null ||
                client.Bairro == null || client.Telefone == null)
            {
                MessageError = @"Verique os campos obrigatórios";
                return -1;
            }

            if (client.Nome.Equals("") || client.Endereco.Equals("") || client.Numero.ToString() == "" ||
                client.CEP.Equals("") || client.Bairro.Equals("") || client.Telefone.Equals(""))
            {
                MessageError = @"Verique os campos obrigatórios";
                return -1;
            }

            var result = _clientRepository.Save(client, type);
            MessageError = _clientRepository.Message;
            return result;
        }
    }
}