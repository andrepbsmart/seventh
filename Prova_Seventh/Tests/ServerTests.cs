using System;
using Xunit;
using Prova.Domain.Entities;

namespace Prova.Tests
{
    public class ServerTests
    {
        private const string CONST_ID = "766BC8E5-36E9-492B-A654-8D3A283E0FA3";
        private const string CONST_NAME = "SERVIDOR";
        private const string CONST_IP = "201.20.66.69";
        private const int CONST_PORT = 10;

        [Fact]
        public void Deve_Criar_Servidor()
        {
            Server dados = new(CONST_NAME, CONST_IP, CONST_PORT);
            Assert.True(!dados.Notification.HasNotifications);
        }

        [Fact]
        public void Deve_Atualizar_Servidor()
        {
            Server dados = new(CONST_ID, CONST_NAME, CONST_IP, CONST_PORT);
            Assert.True(!dados.Notification.HasNotifications);
        }

        //if (string.IsNullOrEmpty(idServer) && update == true)
        //{
        //    _notify.Add(nameof(idServer), "ID não informado");
        //}

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Deve_Validar_ID_na_Atualizacao(string id)
        {
            const string _mensagemesperada = "ID não informado";

            AssertExtensions.ThrowsWithMessage(() => new Server(id, CONST_NAME, CONST_IP, CONST_PORT), _mensagemesperada);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Deve_Validar_se_Nome_Informado(string name)
        {
            const string _mensagemesperada = "Nome do servidor não informado";

            AssertExtensions.ThrowsWithMessage(() => new Server(name, CONST_IP, CONST_PORT), _mensagemesperada);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Deve_Validar_se_IP_Informado(string ip)
        {
            const string _mensagemesperada = "IP do servidor não informado";

            AssertExtensions.ThrowsWithMessage(() => new Server(CONST_NAME, ip, CONST_PORT), _mensagemesperada);
        }

        [Theory]
        [InlineData("9999")]
        public void Deve_Validar_se_IP_Valido(string ip)
        {
            const string _mensagemesperada = "Endereço IP do servidor inválido";

            AssertExtensions.ThrowsWithMessage(() => new Server(CONST_NAME, ip, CONST_PORT), _mensagemesperada);
        }

        [Theory]
        [InlineData(0)]
        public void Deve_Validar_Porta(int port)
        {
            const string _mensagemesperada = "Porta do servidor não informada";

            AssertExtensions.ThrowsWithMessage(() => new Server(CONST_NAME, CONST_IP, port), _mensagemesperada);
        }
    }
}
