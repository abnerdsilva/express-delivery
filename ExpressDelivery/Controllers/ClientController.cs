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
            var resp = _clientRepository.LoadAll();
            MessageError = _clientRepository.Message;
            return resp;
        }

        public List<Client> LoadByName(string name)
        {
            var resp = _clientRepository.LoadByName(name);
            MessageError = _clientRepository.Message;
            return resp;
        }

        public List<Client> LoadById(string id)
        {
            var resp = _clientRepository.LoadById(id);
            MessageError = _clientRepository.Message;
            return resp;
        }

        public Client LoadByPhone(string phone)
        {
            var resp = _clientRepository.LoadByPhone(phone);
            MessageError = _clientRepository.Message;
            return resp;
        }

        public int LastClientId()
        {
            var resp = _clientRepository.LastClientId();
            MessageError = _clientRepository.Message;
            return resp;
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