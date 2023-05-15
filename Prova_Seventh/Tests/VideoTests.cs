using System;
using Xunit;
using Prova.Domain.Entities;

namespace Prova.Tests
{
    public class VideoTests
    {
        private const string CONST_ID = "AB4D2BF6-C94E-47B1-ABA8-2166A68EF3AB";
        private const string CONST_SERVER = "766BC8E5-36E9-492B-A654-8D3A283E0FA3";
        private const string CONST_DESCRIPTION = "DESCRIÇÃO DO VIDEO";
        private const string CONST_CONTENT = "CONTEUDO DO VIDEO EM BASE 64";

        [Fact]
        public void Deve_Criar_Video()
        {
            Video dados = new(CONST_SERVER, CONST_DESCRIPTION, CONST_CONTENT);
            Assert.True(!dados.Notification.HasNotifications);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Deve_Validar_Servidor(string server)
        {
            const string _mensagemesperada = "Servidor não informado";

            AssertExtensions.ThrowsWithMessage(() => new Video(server, CONST_DESCRIPTION, CONST_CONTENT), _mensagemesperada);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Deve_Validar_Descricao(string description)
        {
            const string _mensagemesperada = "Descrição do vídeo não informada";

            AssertExtensions.ThrowsWithMessage(() => new Video(CONST_SERVER, description, CONST_CONTENT), _mensagemesperada);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Deve_Validar_Conteudo(string content)
        {
            const string _mensagemesperada = "Conteúdo binario do video não informado";

            AssertExtensions.ThrowsWithMessage(() => new Video(CONST_SERVER, CONST_DESCRIPTION, content), _mensagemesperada);
        }
    }
}
