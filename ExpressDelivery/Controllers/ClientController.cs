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
            return _clientRepository.LoadAll();;
        }

        public List<Client> LoadByName(string name)
        {
            return _clientRepository.LoadByName(name);
        }

        public List<Client> LoadById(string name)
        {
            return _clientRepository.LoadById(name);
        }

        public int LastClientId()
        {
            return _clientRepository.LastClientId();
        }

        public int Save(Client client, string type)
        {
            if (client.Nome.Equals("") || client.CPF.Equals("") || client.Endereco.Equals("") ||
                client.Numero.ToString() == "" || client.Cidade.Equals("") || client.Estado.Equals("") ||
                client.CEP.Equals("") || client.Estado.Equals(""))
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
