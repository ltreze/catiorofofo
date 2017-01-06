﻿using System.Collections.Generic;
using System.IO;

namespace App4.Model
{
    public class PostModel
    {
        private Stream FotoStream { get; set; }

        public int PostId { get; set; }

        public string Legenda { get; set; }

        public int UsuarioId { get; set; }

        public UsuarioModel Usuario { get; set; }

        public string AvatarUrl
        {
            get
            {
                return Configuracao.UrlWebApi + "api/foto?na=" + NomeArquivoAvatar;
            }
        }

        public string NomeArquivo { get; set; }

        public string NomeArquivoAvatar { get; set; }

        public bool CurtidaHabilitada { get; set; } = true;

        public string CurtidaTexto { get { return CurtidaHabilitada ? "curtir" : "descurtir"; } }

        public int NumCurtidas { get { return Curtidas.Count; } }

        public List<CurtidaModel> Curtidas { get; set; }

        public string FotoUrl
        {
            get
            {
                return Configuracao.UrlWebApi + "api/foto?na=" + NomeArquivo;
            }
        }

        public PostModel(Stream stream)
        {
            FotoStream = stream;
        }

        public PostModel()
        {
            Curtidas = new List<CurtidaModel>();
        }

        public byte[] ObterByteArrayFoto()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                FotoStream.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}
